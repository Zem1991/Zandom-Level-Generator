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
        [SerializeField][Range(0F, 1F)] private float areaFillTarget = 0.5F;

        [Header("Diablo Cathedral - Doors")]
        [SerializeField] private int smallDoorwayLength = 2;
        [SerializeField] private int largeDoorwayLength = 4;

        [Header("Diablo Cathedral - Encounters")]
        [SerializeField] private int normalEncounters = 30;
        [SerializeField] private int challengeEncounters = 5;
        [SerializeField] private int treasureEncounters = 6;

        public float AreaFillTarget { get => areaFillTarget; }
        public int SmallDoorwayLength { get => smallDoorwayLength; }
        public int LargeDoorwayLength { get => largeDoorwayLength; }
        public int NormalEncounters { get => normalEncounters; }
        public int ChallengeEncounters { get => challengeEncounters; }
        public int TreasureEncounters { get => treasureEncounters; }
    }
}
