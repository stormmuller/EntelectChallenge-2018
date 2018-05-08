using System.IO;
using EntelectChallenge.Common.Helpers;
using EntelectChallenge.Domain.Entities;
using EntelectChallenge.Domain.Repositories;
using Newtonsoft.Json;

namespace EntelectChallenge.Data
{
    public class BotStateRepository : IBotStateRepository
    {
        private static readonly string botStateFileLocation = "botState.json";

        public BotState GetBotState()
        {
            return JsonHelper.LoadOrCreateFile<BotState>(Path.GetFullPath(botStateFileLocation));
        }
    }
}
