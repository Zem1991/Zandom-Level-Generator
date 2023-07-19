using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.ResultObjects;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class ZandomSectorFactory
    {
        public ZandomSectorFactory(StyleParameters styleParameters, LevelPlan levelPlan)
        {
            StyleParameters = styleParameters;
            LevelPlan = levelPlan;
        }

        public StyleParameters StyleParameters { get; }
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
            Transform instanceTransform = instance.transform;
            //Transform parent = plan.Parent?.Result?.transform ?? plan.Level?.Result?.transform;
            Transform parent = LevelPlan.Result.transform;
            Vector3 position = parent.position;
            Quaternion rotation = Quaternion.identity;
            instanceTransform.SetPositionAndRotation(position, rotation);
            instanceTransform.parent = parent;
            ZandomSector result = instance.AddComponent<ZandomSector>();
            result.PseudoConstructor(plan);
            plan.Result = result;
            new SectorToTilesLinker(StyleParameters, LevelPlan).LinkTransforms(result);
            return result;
        }
    }
}
