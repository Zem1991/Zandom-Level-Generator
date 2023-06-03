using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;

namespace ZandomTemplate.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Examples/Zandom Template/StyleParameters")]
    public class ZandomTemplateStyleParameters : StyleParameters
    {
        [Header("Zandom Template")]
        [SerializeField] private Vector3Int centralRoomSize = new(12, 0, 12);
        [SerializeField] private Vector3Int buddingRoomSize = new(8, 0, 8);
        [SerializeField] private int sectorCountTarget = 15;

        public Vector3Int CentralRoomSize { get => centralRoomSize; }
        public Vector3Int BuddingRoomSize { get => buddingRoomSize; }
        public int SectorCountTarget { get => sectorCountTarget; }
    }
}
