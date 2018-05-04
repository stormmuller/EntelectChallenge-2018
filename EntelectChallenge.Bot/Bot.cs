using System;
using System.Collections.Generic;
using System.Linq;
using StarterBot.Entities;
using StarterBot.Entities.Bot;
using StarterBot.Enums;
using StarterBot.Weighting;
using StarterBot.Weighting.Startergies;

namespace StarterBot
{
    public class Bot
    {
        const int startingWeightAmount = 50;
        
        private readonly GameStateAdaptor gameState;
        
        public Bot(GameState gameState)
        {
            this.gameState = new GameStateAdaptor(gameState);
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

                            var stratergy =
                               StratergyPool.Instance.GetStartergy<RootStratergy>();

                            var weight = stratergy.CalculateWeight(gameState, startingWeight);

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