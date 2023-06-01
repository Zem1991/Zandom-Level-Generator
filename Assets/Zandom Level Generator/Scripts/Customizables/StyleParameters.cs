using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/StyleParameters")]
    public class StyleParameters : ScriptableObject
    {
        [Header("Level Size")]
        [SerializeField] private bool avoidSafetyBounds = true;
        [SerializeField][Range(0F, 1F)] private float levelSizeTarget = 0.5F;

        [Header("Room Size")]
        [SerializeField] private Vector3Int centralRoomSize = new(16, 16);
        [SerializeField] private Vector3Int buddingRoomSize = new(10, 10);

        public bool AvoidSafetyBounds { get => avoidSafetyBounds; }
        public float LevelSizeTarget { get => levelSizeTarget; }

        //TODO: add a string/json field in ZandomParameters, and a method to retrive its values.
        public Vector3Int CentralRoomSize { get => centralRoomSize; }
        public Vector3Int BuddingRoomSize { get => buddingRoomSize; }
    }
}
