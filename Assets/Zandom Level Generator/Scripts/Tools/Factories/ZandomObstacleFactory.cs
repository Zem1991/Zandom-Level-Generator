using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class ZandomObstacleFactory
    {
        public ZandomObstacleFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public ZandomObstacle Create(Obstacle plan)
        {
            ZandomObstacle result = plan.Result;
            if (result)
            {
                Object.Destroy(result.gameObject);
            }
            result = ForceCreate(plan);
            return result;
        }

        private ZandomObstacle ForceCreate(Obstacle plan)
        {
            Transform parent = LevelPlan.Result.transform;
            Vector3 position = parent.position + plan.Position;
            Quaternion rotation = Quaternion.identity;
            GameObject instance = Object.Instantiate(plan.Data.GameObject, position, rotation, parent);
            ZandomObstacle result = instance.AddComponent<ZandomObstacle>();
            result.PseudoConstructor(plan);
            plan.Result = result;
            return result;
        }
    }
}
