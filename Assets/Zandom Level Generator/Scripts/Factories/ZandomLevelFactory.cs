using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.Factories
{
    public class ZandomLevelFactory
    {
        public ZandomLevel Create(LevelPlan plan, Transform parent = null)
        {
            ZandomLevel result = plan.Result;
            if (result)
            {
                Object.Destroy(result.gameObject);
            }
            result = ForceCreate(plan, parent);
            return result;
        }

        private ZandomLevel ForceCreate(LevelPlan plan, Transform parent = null)
        {
            GameObject instance = new();
            Transform transform = instance.transform;
            Vector3 position = parent == null ? Vector3.zero : parent.position;
            Quaternion rotation = Quaternion.identity;
            transform.SetPositionAndRotation(position, rotation);
            ZandomLevel result = instance.AddComponent<ZandomLevel>();
            plan.Result = result;
            return result;
        }
    }
}
