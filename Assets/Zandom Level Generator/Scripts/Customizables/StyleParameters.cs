using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/Style Parameters")]
    public class StyleParameters : ScriptableObject
    {
        [Header("Level Size Options")]
        [SerializeField] private Vector3Int levelSize = new(80, 1, 80);
        [SerializeField] private Vector3Int moduleSize = new(10, 1, 10);
        [SerializeField] private Vector3Int safetySize = new(10, 1, 10);

        public Vector3Int LevelSize { get => levelSize; }
        public Vector3Int ModuleSize { get => moduleSize; }
        public Vector3Int SafetySize { get => safetySize; }
        public int Area { get => LevelSize.x * LevelSize.y * LevelSize.z; }
    }
}
