using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class SectorPlanFactory
    {
        public SectorPlanFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public int NextId()
        {
            return LevelPlan.Sectors.Count;
        }

        public SectorPlan Create(int id, HashSet<Vector3Int> tilesIds, SectorPlan parent = null)
        {
            bool exists = LevelPlan.Sectors.TryGetValue(id, out SectorPlan result);
            if (!exists)
            {
                result = new(LevelPlan, id, tilesIds, parent);
                LevelPlan.Sectors.Add(id, result);
            }
            new SectorToTilesLinker(LevelPlan).Link(id, tilesIds);
            return result;
        }
        
        public SectorPlan Create(int id, Vector3Int start, Vector3Int size, SectorPlan parent = null)
        {
            HashSet<Vector3Int> tilesIds = new CoordinatesGetter().Get(start, size);
            return Create(id, tilesIds, parent);
        }
    }
}
