using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Examples/Diablo Cathedral/Style Parameters")]
    public class DiabloCathedralStyleParameters : StyleParameters
    {
        [Header("Diablo Cathedral")]
        public int dae;
        [SerializeField] private int smallDoorwayLength = 2;
        [SerializeField] private int largeDoorwayLength = 4;
        [SerializeField] private int sectorCountTarget = 30;

        public int SmallDoorwayLength { get => smallDoorwayLength; }
        public int LargeDoorwayLength { get => largeDoorwayLength; }
        public int SectorCountTarget { get => sectorCountTarget; }
    }
}
