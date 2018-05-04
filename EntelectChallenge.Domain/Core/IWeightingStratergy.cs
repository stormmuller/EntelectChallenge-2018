using StarterBot.Entities.Bot;

namespace EntelectChallenge.Domain.Core
{
    public interface IWeightingStratergy
    {
        Weight CalculateWeight(GameStateAdaptor gameState, Weight weight);
    }
}
