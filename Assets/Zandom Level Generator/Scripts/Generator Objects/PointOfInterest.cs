using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class PointOfInterest
    {
        public PointOfInterest(Vector3 position, string name)
        {
            Position = position;
            Name = name;
        }

        public Vector3 Position { get; }
        public string Name { get; }
    }
}
