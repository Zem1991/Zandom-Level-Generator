using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZemReusables;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/ObstacleDataList")]
    public class ObstacleDataList : PseudoDictionaryScriptableObject<ObstacleData>
    {
        [Header("Reserved names")]
        [SerializeField] private ObstacleData startLocation;

        public ObstacleData StartLocation { get => startLocation; }

        public override ObstacleData Get(string name)
        {
            if (name == Constants.ZandomStartLocation) return StartLocation;
            return base.Get(name);
        }
    }
}
