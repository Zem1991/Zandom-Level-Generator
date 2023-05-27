using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.BaseObjects
{
    public class Doorway
    {
        public Doorway(Wall wall, DoorSize doorSize, List<Tile> tiles)
        {
            Wall = wall;
            DoorSize = doorSize;
            Tiles = tiles;
        }

        public Wall Wall { get; }
        public DoorSize DoorSize { get; }
        public List<Tile> Tiles { get; }

        public Obstacle Door { get; set; }
    }
}
