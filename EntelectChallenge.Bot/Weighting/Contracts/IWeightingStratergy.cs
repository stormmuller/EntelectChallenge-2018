using StarterBot.Entities.Bot;

namespace StarterBot.Weighting
{
    public interface IWeightingStratergy
    {
        Weight CalculateWeight(GameStateAdaptor gameState, Weight weight);
    }
}
