using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Builders;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class RoomPlanFactory
    {
        public RoomPlanFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public int NextId()
        {
            return LevelPlan.Sectors.Count;
        }
        
        public RoomPlan Create(int id, Vector3Int start, Vector3Int size, SectorPlan parent = null)
        {
            HashSet<Vector3Int> tilesIds = new CoordinatesGetter().Get(start, size);
            bool exists = LevelPlan.Sectors.TryGetValue(id, out SectorPlan sector);
            RoomPlan result = sector as RoomPlan;
            if (!exists || result == null)
            {
                //TODO: doesn't delete the old one if it's not a RoomPlan
                result = new RoomPlan(LevelPlan, id, start, size, parent);
                LevelPlan.Sectors.Add(id, result);
            }
            new SectorToTilesLinker(LevelPlan).Link(id, tilesIds);
            new AreaBorderCornerBuilder(result).Rectangle(start, size);
            return result;
        }
    }
}
