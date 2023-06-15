using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;

namespace ZandomLevelGenerator.Examples.ZandomTemplate.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Examples/Zandom Template/StyleParameters")]
    public class ZandomTemplateStyleParameters : StyleParameters
    {
        [Header("Zandom Template")]
        [SerializeField] private Vector3Int centralRoomSize = new(12, 1, 12);
        [SerializeField] private Vector3Int buddingRoomSize = new(8, 1, 8);
        [SerializeField] private int doorwayLength = 4;
        [SerializeField] private int sectorCountTarget = 20;

        public Vector3Int CentralRoomSize { get => centralRoomSize; }
        public Vector3Int BuddingRoomSize { get => buddingRoomSize; }
        public int DoorwayLength { get => doorwayLength; }
        public int SectorCountTarget { get => sectorCountTarget; }
    }
}
