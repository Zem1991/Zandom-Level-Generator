using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Examples.DiabloCathedral.Customizables;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Tasks
{
    public class ThickDestructibleBorders : GeneratorTask
    {
        private readonly string destructibleCode = "Destructible Wall";

        public ThickDestructibleBorders(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public override void RunContents()
        {
            LevelPlan levelPlan = ZandomLevelGenerator.GeneratorCoroutine.Level;
            DiabloCathedralStyleParameters diabloCathedralStyleParameters = ZandomLevelGenerator.ZandomParameters as DiabloCathedralStyleParameters;
            foreach (var item in levelPlan.Tiles)
            {
                TilePlan backLeft = item.Value;
                if (!CheckTile(backLeft)) continue;
                Vector3Int coordinatesBackRight = backLeft.Coordinates;
                Vector3Int coordinatesFrontLeft = backLeft.Coordinates;
                Vector3Int coordinatesFrontRight = backLeft.Coordinates;
                coordinatesBackRight.x++;
                coordinatesFrontLeft.z++;
                coordinatesFrontRight.x++;
                coordinatesFrontRight.z++;
                levelPlan.Tiles.TryGetValue(coordinatesBackRight, out TilePlan backRight);
                levelPlan.Tiles.TryGetValue(coordinatesFrontLeft, out TilePlan frontLeft);
                levelPlan.Tiles.TryGetValue(coordinatesFrontRight, out TilePlan frontRight);
                if (!CheckTile(backRight)) continue;
                if (!CheckTile(frontLeft)) continue;
                if (!CheckTile(frontRight)) continue;
                int rng = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(0, diabloCathedralStyleParameters.ChanceOfThickDestructible);
                if (rng > 0) continue;
                backLeft.Code = destructibleCode;
                backRight.Code = destructibleCode;
                frontLeft.Code = destructibleCode;
                frontRight.Code = destructibleCode;
            }
        }

        private bool CheckTile(TilePlan tile)
        {
            if (tile == null) return false;
            if (tile.Type != TileType.BORDER) return false;
            //if (tile.Code != TileType.BORDER.ToString()) return false;
            LevelPlan levelPlan = ZandomLevelGenerator.GeneratorCoroutine.Level;
            levelPlan.Sectors.TryGetValue(tile.SectorsIds.ElementAt(0), out SectorPlan sector);
            RoomPlan room = sector as RoomPlan;
            if (room == null) return false;
            //if (room.SetPiece != null) return false;
            return true;
        }
    }
}
