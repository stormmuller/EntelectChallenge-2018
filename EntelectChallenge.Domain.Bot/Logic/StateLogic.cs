using EntelectChallenge.Domain.Entities;
using EntelectChallenge.Domain.Logic;
using EntelectChallenge.Domain.Repositories;

namespace EntelectChallenge.Domain.Bot.Logic
{
    public class StateLogic : IStateLogic
    {
        private readonly IGameStateRepository gameStateRepository;
        private readonly IBotStateRepository botStateRepository;

        public StateLogic(
            IGameStateRepository gameStateRepository,
            IBotStateRepository botStateRepository)
        {
            this.gameStateRepository = gameStateRepository;
            this.botStateRepository = botStateRepository;
        }

        public GameState GetGameState()
        {
            return gameStateRepository.GetGameState();
        }

        public BotState GetBotState()
        {
            return botStateRepository.GetBotState();
        }
    }
}
