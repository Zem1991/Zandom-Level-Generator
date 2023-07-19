using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;
using ZemReusables;

namespace ZandomLevelGenerator.Tools.Builders
{
    public class AreaBorderCornerBuilder
    {
        public AreaBorderCornerBuilder(SectorPlan sectorPlan)
        {
            SectorPlan = sectorPlan;
        }

        public SectorPlan SectorPlan { get; }

        public void Build(Vector3Int start, Vector3Int size)
        {
            Func<int, int, int, bool> areaFunction = RectangleArea;
            Func<int, int, int, bool> borderFunction = RectangleBorder;
            Func<int, int, int, bool> cornerFunction = RectangleCorner;
            Vector3IntIterator iterator = new();
            iterator.Iterate(start, size, areaFunction, borderFunction, cornerFunction);
        }

        private bool RectangleArea(int col, int floor, int row) => SetTileType(col, floor, row, TileType.AREA);
        private bool RectangleBorder(int col, int floor, int row) => SetTileType(col, floor, row, TileType.BORDER);
        private bool RectangleCorner(int col, int floor, int row) => SetTileType(col, floor, row, TileType.CORNER);

        private bool SetTileType(int col, int floor, int row, TileType tileType)
        {
            LevelPlan levelPlan = SectorPlan.Level;
            Vector3Int coordinates = new(col, floor, row);
            bool hasTile = levelPlan.Tiles.TryGetValue(coordinates, out TilePlan tile);
            if (!hasTile) return false;
            if (tile.Type != TileType.CORNER)
            {
                tile.Type = tileType;
            }
            //bool noCode = string.IsNullOrEmpty(tile.Code);
            //if (noCode) tile.Code = tileType.ToString();
            return true;
        }
    }
}
