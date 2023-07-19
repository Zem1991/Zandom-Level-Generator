using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Samples.DiabloCathedral.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Common;

namespace ZandomLevelGenerator.Samples.DiabloCathedral.Styles
{
    public class DiabloCathedralPlaceStartLocationWithObstacleParameters
    {
        public PlaceObstaclesParameters CreateParameters()
        {
            var amountFunction = AmountFunction();
            var paddingTileFunction = PaddingTileFunction();
            var obstacleTileFunction = ObstacleTileFunction();
            PlaceObstaclesParameters result = new(amountFunction, paddingTileFunction, obstacleTileFunction);
            return result;
        }

        public Func<ZandomLevelGenerator, int> AmountFunction()
        {
            int result(ZandomLevelGenerator zandomLevelGenerator)
            {
                return 1;
            }
            return result;
        }

        private Func<ZandomLevelGenerator, TilePlan, bool> PaddingTileFunction()
        {
            bool result(ZandomLevelGenerator zandomLevelGenerator, TilePlan tile)
            {
                bool hasTile = tile != null;
                if (!hasTile) return false;
                bool hasObstacle = tile.HasObstacle();
                if (hasObstacle) return false;
                bool canPlaceObstacle = tile.Type == TileType.AREA;
                return canPlaceObstacle;
            }
            return result;
        }

        public Func<ZandomLevelGenerator, TilePlan, bool> ObstacleTileFunction()
        {
            bool result(ZandomLevelGenerator zandomLevelGenerator, TilePlan tile)
            {
                LevelPlan levelPlan = zandomLevelGenerator.GeneratorCoroutine.Level;
                levelPlan.Sectors.TryGetValue(tile.SectorsIds.ElementAt(0), out SectorPlan sector);
                if (sector.Type != SectorType.NORMAL) return false;
                RoomPlan room = sector as RoomPlan;
                if (room.SetPiece != null) return false;
                StartLocation startLocation = levelPlan.StartLocation;
                if (startLocation != null)
                {
                    Vector3 startPosition = startLocation.Position;
                    Vector3 tilePosition = tile.Coordinates;
                    float distance = Vector3.Distance(startPosition, tilePosition);
                    if (distance < Constants.StartLocationRadius)
                    {
                        return false;
                    }
                }
                bool canPlaceObstacle = tile.Type == TileType.AREA;
                return canPlaceObstacle;
            }
            return result;
        }
    }
}
