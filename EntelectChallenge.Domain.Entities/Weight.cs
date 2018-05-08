using EntelectChallenge.Domain.Entities.Enums;

namespace EntelectChallenge.Domain.Entities
{
    public class Weight
    {
        public int Amount { get; set; }
        public BuildingType Building { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public string Command
        {
            get
            {
                return $"{X},{Y},{(int)Building}";
            }
        }
    }
}
