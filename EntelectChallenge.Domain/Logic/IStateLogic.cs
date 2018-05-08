using EntelectChallenge.Domain.Core;
using EntelectChallenge.Domain.Entities;

namespace EntelectChallenge.Domain.Logic
{
    public interface IStateLogic : ILogic
    {
        GameState GetGameState();
        BotState GetBotState();
    }
}
