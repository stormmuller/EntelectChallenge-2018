using System;
using System.Collections.Generic;
using System.Linq;
using StarterBot.Entities;
using StarterBot.Enums;
using StarterBot.Helpers;

namespace StarterBot
{
    public class GameStateAdaptor
    {
        private readonly GameState gameState;

        #region backing fields
        private Player self;
        private Tuple<BuildingType, int> cheapestBuilding;
        private Tuple<BuildingType, int> mostExpensiveBuilding;
        private List<CellStateContainer> selfBuildings;
        private BuildingType[] allBuildingTypes;
        #endregion

        public GameStateAdaptor(GameState gameState)
        {
            this.gameState = gameState;
        }

        public Player Self
        {
            get
            {
                if (self == null)
                {
                    self = gameState.Players.Single(x => x.PlayerType == PlayerType.A);
                }

                return self;
            }
        }

        public Tuple<BuildingType, int> CheapestBuiling
        {
            get
            {
                if (cheapestBuilding == null)
                {
                    cheapestBuilding = gameState.GameDetails.BuildingPrices.OrderBy(pair => pair.Value).FirstOrDefault().ToTuple();
                }

                return cheapestBuilding;
            }
        }

        public Tuple<BuildingType, int> MostExpensiveBuilding
        {
            get
            {
                if (cheapestBuilding == null)
                {
                    cheapestBuilding = gameState.GameDetails.BuildingPrices.OrderByDescending(pair => pair.Value).FirstOrDefault().ToTuple();
                }

                return cheapestBuilding;
            }
        }
        
        public List<CellStateContainer> FilterRowByCell(Predicate<CellStateContainer> filter, PlayerType playerType, int row)
        {
            var cellsMeetingFilter = new List<CellStateContainer>();

            for (int rowIndex = 0; rowIndex < gameState.GameMap.Length; rowIndex++)
            {
                if (rowIndex != row)
                {
                    continue;
                }

                for (int columnIndex = 0; columnIndex < gameState.GameMap[rowIndex].Length; columnIndex++)
                {
                    var cell = gameState.GameMap.Find(columnIndex, rowIndex);

                    if (cell.CellOwner == playerType && filter(cell))
                    {
                        cellsMeetingFilter.Add(cell);
                    }
                }
            }

            return cellsMeetingFilter;
        }
        
        public List<CellStateContainer> SelfBuildings
        {
            get
            {
                if (selfBuildings == null)
                {
                    for (int rowIndex = 0; rowIndex < gameState.GameDetails.MapHeight; rowIndex++)
                    {
                        selfBuildings.AddRange(FilterRowByCell(c => c.Buildings.Count > 0, PlayerType.A, rowIndex));
                    }
                }

                return selfBuildings;
            }
        }

        public int MapHeight
        {
            get
            {
                return gameState.GameDetails.MapHeight;
            }
        }

        public int SelfMapWidth
        {
            get
            {
                return gameState.GameDetails.MapWidth / 2;
            }
        }

        public BuildingType[] AllBuildingTypes
        {
            get
            {
                if (allBuildingTypes == null)
                {
                    allBuildingTypes = gameState.GameDetails.BuildingPrices.Keys.ToArray();
                }

                return allBuildingTypes;
            }
        }

        public int GetPriceForBuilding(BuildingType buildingType)
        {
            return gameState.GameDetails.BuildingPrices[buildingType];
        }

        public List<Building> GetBuildingsOnCell(int rowIndex, int columnIndex)
        {
            return gameState.GameMap.Find(rowIndex, columnIndex).Buildings;
        }
    }
}
