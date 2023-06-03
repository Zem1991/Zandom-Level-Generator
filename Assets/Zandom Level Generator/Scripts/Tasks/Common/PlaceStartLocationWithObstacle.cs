using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;

namespace ZandomLevelGenerator.Tasks.Common
{
    public class PlaceStartLocationWithObstacle : GeneratorTask
    {
        public PlaceStartLocationWithObstacle(ZandomLevelGenerator zandomLevelGenerator, PlaceObstaclesParameters placeObstaclesParameters) : base(zandomLevelGenerator)
        {
            PlaceObstaclesParameters = placeObstaclesParameters;
        }

        public PlaceObstaclesParameters PlaceObstaclesParameters { get; }

        protected override void RunContents()
        {
            new PlaceObstacles(ZandomLevelGenerator, Constants.ZandomStartLocation, PlaceObstaclesParameters).Run();
        }
    }
}
