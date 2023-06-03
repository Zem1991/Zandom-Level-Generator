using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;

namespace ZandomLevelGenerator.Tasks.Common
{
    public class PlaceStartLocation : GeneratorTask
    {
        public PlaceStartLocation(ZandomLevelGenerator zandomLevelGenerator, Func<Vector3> positionFunction) : base(zandomLevelGenerator)
        {
            PositionFunction = positionFunction;
        }

        public Func<Vector3> PositionFunction { get; }

        protected override void RunContents()
        {
            throw new NotImplementedException();
        }
    }
}
