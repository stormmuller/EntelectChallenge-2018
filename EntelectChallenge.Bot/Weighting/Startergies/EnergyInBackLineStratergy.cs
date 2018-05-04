using System;
using StarterBot.Entities.Bot;
using StarterBot.Enums;

namespace StarterBot.Weighting.Startergies
{
    public class EnergyInBackLineStratergy : IWeightingStratergy
    {
        public Weight CalculateWeight(GameStateAdaptor gameState, Weight weight)
        {
            if (weight.X == 0) // back line
            {
                weight.Amount++;
            }
            else
            {
                weight.Amount--;
            }

            return weight;
        }
    }
}
