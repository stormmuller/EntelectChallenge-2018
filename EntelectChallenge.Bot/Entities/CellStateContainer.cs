using System.Collections.Generic;
using StarterBot.Enums;

namespace StarterBot.Entities
{
    public class CellStateContainer
    {
        public int X { get; set; } 
        public int Y { get; set; } 
        public PlayerType CellOwner { get; set; } 
        public List<Building> Buildings { get; set; } 
        public List<Missile> Missiles { get; set; } 
    }

    public static class CellStateContainerHelper
    {
        public static CellStateContainer Find(this CellStateContainer[][] cellStateContainer, int x, int y)
        {
            return cellStateContainer[x][y];
        }
    }
}