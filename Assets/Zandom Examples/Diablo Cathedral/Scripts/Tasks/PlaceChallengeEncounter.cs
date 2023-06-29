using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Examples.DiabloCathedral.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Common;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Tasks
{
    public class PlaceChallengeEncounter : GeneratorTask
    {
        public PlaceChallengeEncounter(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public override void RunContents()
        {
            string objectName = "Challenge Encounter";
            PlaceObstaclesParameters parameters = CreateParameters();
            //PlaceObstacles placeObstacles = new(ZandomLevelGenerator, objectName, parameters);
            PlaceObstaclesPerRoom placeObstacles = new(ZandomLevelGenerator, objectName, parameters);
            placeObstacles.RunContents();
        }

        private PlaceObstaclesParameters CreateParameters()
        {
            var amountFunction = AmountFunction();
            var paddingTileFunction = PaddingTileFunction();
            var obstacleTileFunction = ObstacleTileFunction();
            PlaceObstaclesParameters result = new(amountFunction, paddingTileFunction, obstacleTileFunction);
            return result;
        }

        private Func<ZandomLevelGenerator, int> AmountFunction()
        {
            int result(ZandomLevelGenerator zandomLevelGenerator)
            {
                DiabloCathedralStyleParameters zandomTemplateStyleParameters = zandomLevelGenerator.ZandomParameters as DiabloCathedralStyleParameters;
                return zandomTemplateStyleParameters.ChallengeEncounters;
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
                canPlaceObstacle |= tile.Code == "Area";
                return canPlaceObstacle;
            }
            return result;
        }

        private Func<ZandomLevelGenerator, TilePlan, bool> ObstacleTileFunction()
        {
            bool result(ZandomLevelGenerator zandomLevelGenerator, TilePlan tile)
            {
                LevelPlan levelPlan = zandomLevelGenerator.GeneratorCoroutine.Level;
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
                levelPlan.Sectors.TryGetValue(tile.SectorsIds.ElementAt(0), out SectorPlan sector);
                if (sector.Type != SectorType.NORMAL) return false;
                bool canPlaceObstacle = tile.Type == TileType.AREA;
                canPlaceObstacle |= tile.Code == "Area";
                if (!canPlaceObstacle) return false;
                return true;
            }
            return result;
        }
    }
}
