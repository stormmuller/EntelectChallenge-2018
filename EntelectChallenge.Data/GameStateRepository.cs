using EntelectChallenge.Common.Helpers;
using EntelectChallenge.Domain.Entities;
using EntelectChallenge.Domain.Repositories;

namespace EntelectChallenge.Data
{
    public class GameStateRepository : IGameStateRepository
    {
        private static readonly string fileName = "state.json";

        public GameState GetGameState()
        {
            return JsonHelper.LoadFile<GameState>(fileName);
        }
    }
}
