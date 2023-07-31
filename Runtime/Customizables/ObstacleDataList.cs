using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZemReusables;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Level Generator/Obstacle Data List")]
    public class ObstacleDataList : PseudoDictionaryScriptableObject<string, ObstacleData>
    {
        [Header("Reserved: Constants.ZandomStartLocation")]
        [SerializeField] private ObstacleData zandomStartLocation;

        public override ObstacleData Get(string name)
        {
            if (name == Constants.ZandomStartLocation) return zandomStartLocation;
            return base.Get(name);
        }
    }
}
