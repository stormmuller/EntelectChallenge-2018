using System;
using System.Collections.Generic;
using System.Linq;
using EntelectChallenge.Common;
using EntelectChallenge.Common.Helpers;
using EntelectChallenge.Domain.Entities.Enums;

namespace EntelectChallenge.Domain.Entities
{
    public class GameState
    {
        #region backing fields
        private Player self;
        private Tuple<BuildingType, int> cheapestBuilding;
        private List<CellStateContainer> selfBuildings;
        private BuildingType[] allBuildingTypes;
        #endregion

        public List<Player> Players { get; set; }
        public CellStateContainer[][] GameMap { get; set; }
        public GameDetails GameDetails { get; set; }

        public Player Self
        {
            get
            {
                if (self == null)
                {
                    self = this.Players.Single(x => x.PlayerType == PlayerType.A);
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
                    cheapestBuilding = this.GameDetails.BuildingPrices.OrderBy(pair => pair.Value).FirstOrDefault().ToTuple();
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
                    cheapestBuilding = this.GameDetails.BuildingPrices.OrderByDescending(pair => pair.Value).FirstOrDefault().ToTuple();
                }

                return cheapestBuilding;
            }
        }

        public List<CellStateContainer> FilterRowByCell(Predicate<CellStateContainer> filter, PlayerType playerType, int row)
        {
            var cellsMeetingFilter = new List<CellStateContainer>();

            for (int rowIndex = 0; rowIndex < this.GameMap.GetLength(0); rowIndex++)
            {
                if (rowIndex != row)
                {
                    continue;
                }

                for (int columnIndex = 0; columnIndex < this.GameMap[rowIndex].Length; columnIndex++)
                {
                    var cell = this.GameMap.Find(rowIndex, columnIndex);

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
                    selfBuildings = new List<CellStateContainer>();

                    for (int rowIndex = 0; rowIndex < this.GameDetails.MapHeight; rowIndex++)
                    {
                        selfBuildings.AddRange(FilterRowByCell(c => c.Buildings.Count > 0, PlayerType.A, rowIndex));
                    }
                }

                return selfBuildings;
            }
        }

        public int MapHeight => this.GameDetails.MapHeight;

        public int SelfMapWidth => this.GameDetails.MapWidth / 2;

        public BuildingType[] AllBuildingTypes
        {
            get
            {
                if (allBuildingTypes == null)
                {
                    allBuildingTypes = this.GameDetails.BuildingPrices.Keys.ToArray();
                }

                return allBuildingTypes;
            }
        }

        public int Round => GameDetails.Round;
        public int FrontLine => SelfMapWidth - 1;

        public int GetPriceForBuilding(BuildingType buildingType)
        {
            return this.GameDetails.BuildingPrices[buildingType];
        }

        public List<Building> GetBuildingsOnCell(int rowIndex, int columnIndex)
        {
            return this.GameMap.Find(columnIndex, rowIndex).Buildings;
        }
    }
}