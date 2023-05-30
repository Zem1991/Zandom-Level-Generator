using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.ResultObjects
{
    public class ZandomSector : MonoBehaviour
    {
        public void PseudoConstructor(SectorPlan sectorPlan)
        {
            SectorPlan = sectorPlan;
            name = sectorPlan.ToString();
        }

        public SectorPlan SectorPlan { get; private set; }
        public ZandomSector Parent { get => SectorPlan.Parent.Result; }
    }
}
