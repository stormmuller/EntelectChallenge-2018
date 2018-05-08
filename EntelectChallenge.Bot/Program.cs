using System.IO;
using EntelectChallenge.Domain.Core;
using EntelectChallenge.Domain.Bot;
using EntelectChallenge.Domain.Stratergies;
using EntelectChallenge.Domain.Bot.Logic;
using EntelectChallenge.Data;

namespace StarterBot
{
    public class Program
    {
        private static string _commandFileName = "command.txt";

        private static IBot bot; 

        static void Main(string[] args)
        {
            bot = SetupBot();

            var command = bot.Run();

            File.WriteAllText(_commandFileName, command);
        }

        private static IBot SetupBot()
        {
            var gameStateRepository = new GameStateRepository();
            var botStateRepository = new BotStateRepository();
            var stateLogic = new StateLogic(gameStateRepository, botStateRepository);

            var gameState = stateLogic.GetGameState();
            var botState = stateLogic.GetBotState();

            var stratergyPool = new StratergyPool(gameState);

            return new Bot(gameState, stratergyPool);
        }
    }
}