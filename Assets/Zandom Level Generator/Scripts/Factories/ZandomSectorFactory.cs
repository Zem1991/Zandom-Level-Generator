using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.Factories
{
    public class ZandomSectorFactory
    {
        public ZandomSectorFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public ZandomSector Create(SectorPlan plan, GameObject model)
        {
            ZandomSector result = plan.Result;
            if (result)
            {
                Object.Destroy(result.gameObject);
            }
            result = ForceCreate(plan, model);
            return result;
        }

        private ZandomSector ForceCreate(SectorPlan plan, GameObject model)
        {
            Transform parent = LevelPlan.Result.transform;
            Vector3 position = parent.position;
            Quaternion rotation = Quaternion.identity;
            GameObject instance = Object.Instantiate(model, position, rotation, parent);
            ZandomSector result = instance.AddComponent<ZandomSector>();
            plan.Result = result;
            return result;
        }
    }
}
