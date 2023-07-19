using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/ObstacleData")]
    public class ObstacleData : ScriptableObject
    {
        [Header("Settings")]
        [SerializeField] private GameObject gameObject;
        [SerializeField] private bool canPlaceWithinStartPosition = true;
        [SerializeField] private Vector3Int size = new(4, 1, 4);
        [SerializeField] private Vector3Int padding = new(1, 0, 1);
        [SerializeField] private bool normalSectorAllowed = true;
        [SerializeField] private bool importantSectorAllowed = false;
        [SerializeField] private bool secretSectorAllowed = false;

        public GameObject GameObject { get => gameObject; }
        public bool CanPlaceWithinStartPosition { get => canPlaceWithinStartPosition; }
        public Vector3Int Size { get => size; }
        public Vector3Int Padding { get => padding; }
        public bool NormalSectorAllowed { get => normalSectorAllowed; }
        public bool ImportantSectorAllowed { get => importantSectorAllowed; }
        public bool SecretSectorAllowed { get => secretSectorAllowed; }
    }
}
