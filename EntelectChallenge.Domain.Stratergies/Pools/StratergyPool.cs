namespace StarterBot.Weighting
{
    using System;
    using System.Collections.Generic;
    using EntelectChallenge.Domain.Core;
    using EntelectChallenge.Domain.Core.Pools;

    public class StratergyPool : IStratergyPool
    {
        private readonly Dictionary<Type, IWeightingStratergy> stratergies = new Dictionary<Type, IWeightingStratergy>();
        
        public IWeightingStratergy GetStartergy<TStratergy>() where TStratergy : IWeightingStratergy
        {
            var stratergyType = typeof(TStratergy);

            if (stratergies.ContainsKey(stratergyType))
            {
                return stratergies[stratergyType];
            }

            return Activator.CreateInstance<TStratergy>();
        }
    }
}
