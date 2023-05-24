using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Components
{
    [CreateAssetMenu(menuName = "Zandom/Obstacle")]
    public class ZandomObstacle : ScriptableObject
    {
        [Header("Generator Settings")]
        [Min(1)] public int amountMinimum = 1;
        [Min(1)] public int amountDesired = 10;
        public bool canPlaceWithinStartPosition = true;
        public Vector2Int size = new(4, 4);
        public Vector2Int padding = new(0, 0);

        [Header("Object to Spawn")]
        public GameObject gameObject;
    }
}
