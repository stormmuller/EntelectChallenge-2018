namespace EntelectChallenge.Domain.Repositories
{
    using Core;
    using EntelectChallenge.Domain.Entities;

    public interface IBotStateRepository : IRepository
    {
        BotState GetBotState();
    }
}
