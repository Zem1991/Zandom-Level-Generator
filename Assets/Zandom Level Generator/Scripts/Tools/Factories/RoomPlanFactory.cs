using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Builders;
using ZandomLevelGenerator.Tools.Checkers;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class RoomPlanFactory
    {
        public RoomPlanFactory(StyleParameters styleParameters, LevelPlan levelPlan)
        {
            StyleParameters = styleParameters;
            LevelPlan = levelPlan;
        }

        public StyleParameters StyleParameters { get; }
        public LevelPlan LevelPlan { get; }

        public int NextId()
        {
            return LevelPlan.Sectors.Count;
        }

        public bool CanCreate(Vector3Int start, Vector3Int size)
        {
            bool outsideBounds = new LevelBoundsChecker(StyleParameters).IsOutsideBounds(start, size);
            return !outsideBounds;
        }

        public bool TryCreate(int id, Vector3Int start, Vector3Int size, bool vertical, SectorPlan parent, out RoomPlan newObject)
        {
            newObject = null;
            bool can = CanCreate(start, size);
            if (!can) return false;
            newObject = Create(id, start, size, vertical, parent);
            return true;
        }

        public bool TryCreate(int id, Vector3Int start, SetPiece setPiece, bool vertical, SectorPlan parent, out RoomPlan newObject)
        {
            newObject = null;
            bool can = CanCreate(start, setPiece.Size);
            if (!can) return false;
            newObject = Create(id, start, setPiece, vertical, parent);
            return true;
        }

        private RoomPlan Create(int id, Vector3Int start, Vector3Int size, bool vertical, SectorPlan parent)
        {
            bool exists = LevelPlan.Sectors.TryGetValue(id, out SectorPlan sector);
            RoomPlan result = sector as RoomPlan;
            if (!exists || result == null)
            {
                //TODO: doesn't delete the old one if it's not a RoomPlan
                result = new RoomPlan(LevelPlan, id, start, size, vertical, parent);
                LevelPlan.Sectors.Add(id, result);
            }
            //HashSet<Vector3Int> tilesIds = new CoordinatesGetter().Get(start, size);
            new SectorToTilesLinker(StyleParameters, LevelPlan).LinkIds(result);
            new AreaBorderCornerBuilder(result).Build(start, size);
            return result;
        }

        private RoomPlan Create(int id, Vector3Int start, SetPiece setPiece, bool vertical, SectorPlan parent = null)
        {
            Vector3Int size = setPiece.Size;
            RoomPlan result = Create(id, start, size, vertical, null);
            new SetPieceBuilder(LevelPlan).Build(result, setPiece);
            return result;
        }
    }
}
