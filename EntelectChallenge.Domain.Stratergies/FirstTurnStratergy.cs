using EntelectChallenge.Domain.Pools;
using EntelectChallenge.Domain.Entities;
using EntelectChallenge.Domain.Entities.Enums;

namespace EntelectChallenge.Domain.Stratergies
{
    public class FirstTurnStratergy : Stratergy
    {
        public FirstTurnStratergy(IStratergyPool stratergyPool, GameState gameState)
            : base(stratergyPool, gameState)
        {
        }

        public override Weight CalculateWeight(Weight weight)
        {
            var startingWeightAmount = weight.Amount;

            if (weight.Building == BuildingType.Attack)
            {
                var frontLineStratergy = stratergyPool.GetStartergy<FrontlineStratergy>();

                return frontLineStratergy.CalculateWeight(weight);
            }

            return weight;
        }
    }
}
