using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Examples.DiabloCathedral.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Tasks
{
    public class WallTypePicker : GeneratorTask
    {
        private readonly string destructibleCode = "Destructible Wall";
        private readonly string areaCode = "Area";
        private readonly string thinCode = "Thin Wall";
        private readonly string barsCode = "Bars Wall";
        private readonly string borderCode = "Border";

        public WallTypePicker(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public override void RunContents()
        {
            List<BorderOverlapWall> destructibles = new();
            List<BorderOverlapWall> normals = new();
            List<BorderOverlapWall> parents = new();
            List<BorderOverlapWall> borders = new();
            DiabloCathedralStyleParameters diabloCathedralStyleParameters = ZandomLevelGenerator.ZandomParameters as DiabloCathedralStyleParameters;
            LevelPlan levelPlan = ZandomLevelGenerator.GeneratorCoroutine.Level;
            RootSectorFinder rootSectorFinder = new();
            foreach (var item in levelPlan.BorderOverlapWalls)
            {
                BorderOverlapWall wall = item.Value;
                levelPlan.Sectors.TryGetValue(wall.SourceId, out SectorPlan sector1);
                levelPlan.Sectors.TryGetValue(wall.OtherId, out SectorPlan sector2);
                bool tooShort = wall.TilesIds.Count < 2;
                int distance = rootSectorFinder.Find(sector1, sector2, out _);
                bool tooDistant = distance >= diabloCathedralStyleParameters.DistanceForDestructibleWalls;
                bool importantRoom = sector1.Type == SectorType.IMPORTANT || sector2.Type == SectorType.IMPORTANT;
                bool parentWall = sector1.Parent == sector2 || sector2.Parent == sector1;
                if (tooShort)
                {
                    borders.Add(wall);
                }
                else if (tooDistant)
                {
                    destructibles.Add(wall);
                }
                else if(importantRoom)
                {
                    normals.Add(wall);
                }
                else if (parentWall)
                {
                    parents.Add(wall);
                }
                else
                {
                    borders.Add(wall);
                }
            }
            SetDestructible(destructibles);
            SetNormal(normals);
            SetParent(parents);
            SetBorder(borders);
            ChangeWallTiles(destructibles);
            ChangeWallTiles(normals);
            ChangeWallTiles(parents);
            ChangeWallTiles(borders);
        }

        private void SetDestructible(List<BorderOverlapWall> walls)
        {
            foreach (var item in walls)
            {
                item.TileCode = destructibleCode;
            }
        }

        private void SetNormal(List<BorderOverlapWall> walls)
        {
            foreach (var item in walls)
            {
                string code = thinCode;
                bool change = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.NextBool();
                if (change) code = barsCode;
                item.TileCode = code;
            }
        }

        private void SetParent(List<BorderOverlapWall> walls)
        {
            foreach (var item in walls)
            {
                string code = areaCode;
                bool change = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.NextBool();
                if (change)
                {
                    code = thinCode;
                    change = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.NextBool();
                    if (change) code = barsCode;
                }
                item.TileCode = code;
            }
        }
        
        private void SetBorder(List<BorderOverlapWall> walls)
        {
            foreach (var item in walls)
            {
                item.TileCode = borderCode;
            }
        }

        private void ChangeWallTiles(List<BorderOverlapWall> walls)
        {
            LevelPlan levelPlan = ZandomLevelGenerator.GeneratorCoroutine.Level;
            foreach (var wall in walls)
            {
                foreach (var item in wall.TilesIds)
                {
                    levelPlan.Tiles.TryGetValue(item, out TilePlan tile);
                    if (tile.Type != TileType.BORDER) continue;
                    if (tile.Overlap != TileOverlap.WALL) continue;
                    tile.Code = wall.TileCode;
                }
            }
        }
    }
}
