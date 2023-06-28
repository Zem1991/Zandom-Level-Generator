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
    public class PlaceTreasureEncounter : GeneratorTask
    {
        public PlaceTreasureEncounter(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public override void RunContents()
        {
            string objectName = "Treasure Encounter";
            PlaceObstaclesParameters parameters = CreateParameters();
            PlaceObstacles placeObstacles = new(ZandomLevelGenerator, objectName, parameters);
            placeObstacles.RunContents();
        }

        private PlaceObstaclesParameters CreateParameters()
        {
            var amountFunction = AmountFunction();
            var validTilesFunction = ValidTilesFunction();
            PlaceObstaclesParameters result = new(amountFunction, validTilesFunction);
            return result;
        }

        private Func<ZandomLevelGenerator, int> AmountFunction()
        {
            int result(ZandomLevelGenerator zandomLevelGenerator)
            {
                DiabloCathedralStyleParameters zandomTemplateStyleParameters = zandomLevelGenerator.ZandomParameters as DiabloCathedralStyleParameters;
                return zandomTemplateStyleParameters.TreasureEncounters;
            }
            return result;
        }

        private Func<ZandomLevelGenerator, TilePlan, bool> ValidTilesFunction()
        {
            bool result(ZandomLevelGenerator zandomLevelGenerator, TilePlan tile)
            {
                LevelPlan levelPlan = zandomLevelGenerator.GeneratorCoroutine.Level;
                levelPlan.Sectors.TryGetValue(tile.SectorsIds.ElementAt(0), out SectorPlan sector);
                if (sector.Type != SectorType.IMPORTANT) return false;
                RoomPlan room = sector as RoomPlan;
                if (room.SetPiece != null) return false;
                bool canPlaceObstacle = tile.Type == TileType.AREA;
                return canPlaceObstacle;
            }
            return result;
        }
    }
}
