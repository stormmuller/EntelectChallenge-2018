using StarterBot.Entities.Bot;

namespace StarterBot.Weighting.Startergies
{
    public class RootStratergy : IWeightingStratergy
    {
        public Weight CalculateWeight(GameStateAdaptor gameState, Weight weight)
        {
            var noBuildingsStratergy =
                StratergyPool.Instance.GetStartergy<NoBuildingsStratergy>();

            var energyInBackLineStratergy =
                StratergyPool.Instance.GetStartergy<EnergyInBackLineStratergy>();

            weight = noBuildingsStratergy.CalculateWeight(gameState, weight);
            weight = energyInBackLineStratergy.CalculateWeight(gameState, weight);

            return weight;
        }
    }
}
