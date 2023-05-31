using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class ZandomSectorFactory
    {
        public ZandomSectorFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public ZandomSector Create(SectorPlan plan)
        {
            ZandomSector result = plan.Result;
            if (result)
            {
                Object.Destroy(result.gameObject);
            }
            result = ForceCreate(plan);
            return result;
        }

        private ZandomSector ForceCreate(SectorPlan plan)
        {
            GameObject instance = new();
            Transform transform = instance.transform;
            Transform parent = plan.Result.transform;
            Vector3 position = parent.position;
            Quaternion rotation = Quaternion.identity;
            transform.SetPositionAndRotation(position, rotation);
            ZandomSector result = instance.AddComponent<ZandomSector>();
            plan.Result = result;
            return result;
        }
    }
}
