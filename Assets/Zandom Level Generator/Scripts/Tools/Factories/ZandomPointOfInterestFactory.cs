using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.ResultObjects;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class ZandomPointOfInterestFactory
    {
        public ZandomPointOfInterestFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public ZandomPointOfInterest Create(PointOfInterest plan)
        {
            ZandomPointOfInterest result = plan.Result;
            if (result)
            {
                Object.Destroy(result.gameObject);
            }
            result = ForceCreate(plan);
            return result;
        }
        
        private ZandomPointOfInterest ForceCreate(PointOfInterest plan)
        {
            GameObject instance = new();
            Transform instanceTransform = instance.transform;
            Transform parent = LevelPlan.Result.transform;
            Vector3 position = parent.position + plan.Position;
            Quaternion rotation = Quaternion.identity;
            instanceTransform.SetPositionAndRotation(position, rotation);
            instanceTransform.parent = parent;
            ZandomPointOfInterest result = instance.AddComponent<ZandomPointOfInterest>();
            result.PseudoConstructor(plan);
            plan.Result = result;
            return result;
        }
    }
}
