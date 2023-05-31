using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class ZandomTileFactory
    {
        public ZandomTileFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public ZandomTile Create(TilePlan plan, GameObject model)
        {
            ZandomTile result = plan.Result;
            if (result)
            {
                Object.Destroy(result.gameObject);
            }
            result = ForceCreate(plan, model);
            return result;
        }

        private ZandomTile ForceCreate(TilePlan plan, GameObject model)
        {
            Transform parent = LevelPlan.Result.transform;
            Vector3 position = parent.position + plan.Coordinates;
            Quaternion rotation = Quaternion.identity;
            GameObject instance = Object.Instantiate(model, position, rotation, parent);
            ZandomTile result = instance.AddComponent<ZandomTile>();
            plan.Result = result;
            return result;
        }
    }
}
