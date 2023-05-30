using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/ObstacleData")]
    public class ObstacleData : ScriptableObject
    {
        [Header("Settings")]
        private readonly bool canPlaceWithinStartPosition = true;
        private readonly Vector2Int size = new(4, 4);
        private readonly Vector2Int padding = new(0, 0);
        private readonly GameObject gameObject;

        public bool CanPlaceWithinStartPosition => canPlaceWithinStartPosition;
        public Vector2Int Size => size;
        public Vector2Int Padding => padding;
        public GameObject GameObject => gameObject;
    }
}
