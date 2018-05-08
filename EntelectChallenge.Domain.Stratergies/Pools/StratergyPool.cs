namespace EntelectChallenge.Domain.Stratergies
{
    using System;
    using System.Collections.Generic;
    using EntelectChallenge.Domain.Core;
    using EntelectChallenge.Domain.Entities;
    using EntelectChallenge.Domain.Logic;
    using EntelectChallenge.Domain.Pools;

    public class StratergyPool : IStratergyPool
    {
        private readonly Dictionary<Type, IStratergy> stratergies = new Dictionary<Type, IStratergy>();
        private readonly GameState gameState;

        public StratergyPool(GameState gameState)
        {
            this.gameState = gameState;
        }

        public IStratergy GetStartergy<TStratergy>() where TStratergy : IStratergy
        {
            var stratergyType = typeof(TStratergy);

            if (stratergies.ContainsKey(stratergyType))
            {
                return stratergies[stratergyType];
            }

            return (IStratergy)Activator.CreateInstance(typeof(TStratergy), this, gameState);
        }
    }
}
