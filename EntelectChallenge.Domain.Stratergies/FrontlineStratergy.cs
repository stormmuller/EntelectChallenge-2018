using EntelectChallenge.Domain.Pools;
using EntelectChallenge.Domain.Entities;

namespace EntelectChallenge.Domain.Stratergies
{
    public class FrontlineStratergy : Stratergy
    {
        public FrontlineStratergy(IStratergyPool stratergyPool, GameState gameState) 
            : base(stratergyPool, gameState)
        {
        }

        public override Weight CalculateWeight(Weight weight)
        {
            if (weight.X == gameState.FrontLine)
            {
                weight.Amount++;
            }

            return weight;
        }
    }
}
