using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Builders
{
    public class WallTileBuilder
    {
        public WallTileBuilder(BorderOverlapWall borderOverlapWall)
        {
            BorderOverlapWall = borderOverlapWall;
        }

        public BorderOverlapWall BorderOverlapWall { get; }

        public void FillWall()
        {
            foreach (var item in BorderOverlapWall.TilesIds)
            {
                BorderOverlapWall.LevelPlan.Tiles.TryGetValue(item, out TilePlan tile);
                tile.Overlap = TileOverlap.WALL;
            }
        }
    }
}
