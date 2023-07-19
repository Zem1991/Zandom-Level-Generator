using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.ResultObjects
{
    public class ZandomPointOfInterest : MonoBehaviour
    {
        public void PseudoConstructor(PointOfInterest plan)
        {
            SectorPlan = plan;
            name = plan.ToString();
        }

        public PointOfInterest SectorPlan { get; private set; }
    }
}
