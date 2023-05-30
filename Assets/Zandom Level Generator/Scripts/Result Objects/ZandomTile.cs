using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.ResultObjects
{
    public class ZandomTile : MonoBehaviour
    {
        public void PseudoConstructor(TilePlan tilePlan)
        {
            TilePlan = tilePlan;
            name = tilePlan.ToString();
        }

        public TilePlan TilePlan { get; private set; }
    }
}
