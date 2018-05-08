using EntelectChallenge.Domain.Core;
using EntelectChallenge.Domain.Entities;
using EntelectChallenge.Domain.Pools;

namespace EntelectChallenge.Domain.Stratergies
{
    public abstract class Stratergy : IStratergy
    {
        protected readonly IStratergyPool stratergyPool;
        protected readonly GameState gameState;

        public Stratergy(IStratergyPool stratergyPool, GameState gameState)
        {
            this.stratergyPool = stratergyPool;
            this.gameState = gameState;
        }

        public abstract Weight CalculateWeight(Weight weight);
    }
}
