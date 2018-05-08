using System.Collections.Generic;
using EntelectChallenge.Domain.Entities.Enums;

namespace EntelectChallenge.Domain.Entities
{
    public class GameDetails
    {
        public int Round { get; set; }
        public int MapWidth  { get; set; }
        public int MapHeight  { get; set; }
        public Dictionary<BuildingType, int> BuildingPrices  { get; set; }  
    }
}