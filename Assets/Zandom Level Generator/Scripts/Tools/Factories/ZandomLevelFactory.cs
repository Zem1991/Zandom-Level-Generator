using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class ZandomLevelFactory
    {
        public ZandomLevel Create(LevelPlan plan, Vector3 position, Transform parent = null)
        {
            ZandomLevel result = plan.Result;
            if (result)
            {
                Object.Destroy(result.gameObject);
            }
            result = ForceCreate(plan, position, parent);
            return result;
        }

        private ZandomLevel ForceCreate(LevelPlan plan, Vector3 position, Transform parent = null)
        {
            GameObject instance = new();
            Transform instanceTransform = instance.transform;
            Quaternion rotation = Quaternion.identity;
            instanceTransform.SetPositionAndRotation(position, rotation);
            instanceTransform.parent = parent;
            ZandomLevel result = instance.AddComponent<ZandomLevel>();
            plan.Result = result;
            result.name = plan.ToString();
            return result;
        }
    }
}
