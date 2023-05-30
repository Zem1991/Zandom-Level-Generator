using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class StartLocation : PointOfInterest
    {
        public StartLocation(Vector3 position) : base(position, "Start Location")
        {
        }
    }
}
