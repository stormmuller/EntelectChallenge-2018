﻿using EntelectChallenge.Domain.Entities.Enums;

namespace EntelectChallenge.Domain.Entities
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PlayerType PlayerType { get; set; }
    }
}