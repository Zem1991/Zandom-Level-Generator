using System;
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
            PlaceObstacles placeObstacles = new PlaceObstacles(ZandomLevelGenerator, Constants.ZandomStartLocation, PlaceObstaclesParameters);
            placeObstacles.Run();
            Vector3 positionFunction()
            {
                return placeObstacles.NewObstacles[0].Position;
            }
            new PlaceStartLocation(ZandomLevelGenerator, positionFunction).Run();
        }
    }
}
