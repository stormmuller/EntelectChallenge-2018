using EntelectChallenge.Domain.Entities;
using EntelectChallenge.Domain.Entities.Enums;
using EntelectChallenge.Domain.Pools;

namespace EntelectChallenge.Domain.Stratergies
{
    public class EnergyStratergy : Stratergy
    {
        public EnergyStratergy(IStratergyPool stratergyPool, GameState gameState)
            : base(stratergyPool, gameState)
        {
        }

        public override Weight CalculateWeight(Weight weight)
        {
            if (weight.Building == BuildingType.Energy)
            {
                weight.Amount++;
            }

            return weight;
        }
    }
}
