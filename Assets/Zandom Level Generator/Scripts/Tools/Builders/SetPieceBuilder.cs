using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZemReusables;

namespace ZandomLevelGenerator.Tools.Builders
{
    public class SetPieceBuilder
    {
        public SetPieceBuilder(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public void Build(RoomPlan roomPlan, SetPiece setPiece)
        {
            Vector3Int start = roomPlan.Start;
            Vector3Int size = setPiece.Size;
            bool setPieceTile(int col, int floor, int row)
            {
                Vector3Int coordinates = new(col, floor, row);
                LevelPlan.Tiles.TryGetValue(coordinates, out TilePlan tile);
                char charCode = setPiece.Get(coordinates.x - start.x, coordinates.z - start.z);
                string fullCode = setPiece.TileSet.GetFullCode(charCode);
                tile.Code = fullCode;
                return true;
            }
            Vector3IntIterator iterator = new();
            iterator.Iterate(start, size, setPieceTile);
        }
    }
}
