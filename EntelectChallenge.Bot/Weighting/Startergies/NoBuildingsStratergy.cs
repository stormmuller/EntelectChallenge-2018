namespace StarterBot.Weighting.Startergies
{
    using System.Linq;
    using StarterBot.Entities.Bot;
    using StarterBot.Enums;

    public class NoBuildingsStratergy : IWeightingStratergy
    {
        public Weight CalculateWeight(GameStateAdaptor gameState, Weight weight)
        {
            if (weight.Building == BuildingType.Attack && !gameState.SelfBuildings.Any())
            {
                weight.Amount++;
            }

            return weight;
        }
    }
}
