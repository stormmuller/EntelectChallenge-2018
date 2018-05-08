using EntelectChallenge.Domain.Entities;
using EntelectChallenge.Domain.Pools;

namespace EntelectChallenge.Domain.Stratergies
{
    public class RootStratergy : Stratergy
    {
        public RootStratergy(IStratergyPool stratergyPool, GameState gameState) 
            : base(stratergyPool, gameState)
        {
        }

        public override Weight CalculateWeight(Weight weight)
        {
            if (gameState.Round == 1)
            {
                weight = stratergyPool
                    .GetStartergy<FirstTurnStratergy>()
                    .CalculateWeight(weight);
            }

            return weight;
        }
    }
}
