using EntelectChallenge.Domain.Core;
using EntelectChallenge.Domain.Entities;

namespace EntelectChallenge.Domain.Repositories
{
    public interface IGameStateRepository : IRepository
    {
        GameState GetGameState();
    }
}
