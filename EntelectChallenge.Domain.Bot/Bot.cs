using System.Collections.Generic;
using System.Linq;
using EntelectChallenge.Domain.Core;
using EntelectChallenge.Domain.Entities;
using EntelectChallenge.Domain.Stratergies;

namespace EntelectChallenge.Domain.Bot
{
    public class Bot : IBot
    {
        const int startingWeightAmount = 50;
        
        private readonly GameState gameState;
        private readonly StratergyPool stratergyPool;

        public Bot(GameState gameState, StratergyPool stratergyPool)
        {
            this.gameState = gameState;
            this.stratergyPool = stratergyPool;
        }

        public string Run()
        {
            var weights = new List<Weight>();

            // loop through each row
            for (int rowIndex = 0; rowIndex < gameState.MapHeight; rowIndex++)
            {
                // loop through each cell
                for (int columnIndex = 0; columnIndex < gameState.SelfMapWidth; columnIndex++)
                {
                    // is the cell clear?
                    if (!(gameState.GetBuildingsOnCell(rowIndex, columnIndex).Any()))
                    {
                        foreach (var building in gameState.AllBuildingTypes)
                        {
                            var startingWeight = new Weight
                            {
                                Amount = startingWeightAmount,
                                Building = building,
                                X = columnIndex,
                                Y = rowIndex
                            };

                            var stratergy = stratergyPool.GetStartergy<RootStratergy>();

                            var weight = stratergy.CalculateWeight(startingWeight);

                            weights.Add(weight);
                        }
                    }
                }
            }

            var chosenWeight = weights.OrderByDescending(w => w.Amount).FirstOrDefault();
            
            return chosenWeight == null ? string.Empty : chosenWeight.Command;
        }
    }
}