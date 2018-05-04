namespace StarterBot.Weighting
{
    using System;
    using System.Collections.Generic;
    using StarterBot.Weighting.Contracts;

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
