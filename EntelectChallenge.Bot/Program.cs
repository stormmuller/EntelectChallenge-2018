using System;
using System.IO;
using Newtonsoft.Json;
using StarterBot.Entities;

namespace StarterBot
{
    public class Program
    {
        private static string _commandFileName = "command.txt";
        private static string _stateFileName = "state.json";

        static void Main(string[] args)
        {
            var json = File.ReadAllText(_stateFileName);

            var gameState = JsonConvert.DeserializeObject<GameState>(json);

            var command = new Bot(gameState).Run();

            File.WriteAllText(_commandFileName, command);
        }
    }
}