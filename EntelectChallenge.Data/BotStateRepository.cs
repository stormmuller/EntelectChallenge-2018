using System.IO;
using EntelectChallenge.Domain.Entities;
using EntelectChallenge.Domain.Repositories;
using Newtonsoft.Json;

namespace EntelectChallenge.Data
{
    public class BotStateRepository : IBotStateRepository
    {
        private static readonly string botStateFileLocation = "botState.json";
        private readonly BotState botState;

        public BotState GetBotState()
        {
            BotState botState;

            if (!File.Exists(botStateFileLocation))
            {
                botState = new BotState();
                JsonConvert.SerializeObject(botState);

                return botState;
            }

            var json = File.ReadAllText(botStateFileLocation);

            return JsonConvert.DeserializeObject<BotState>(json);
        }
    }
}
