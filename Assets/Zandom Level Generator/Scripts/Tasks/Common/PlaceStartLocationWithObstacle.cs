using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;

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
            PlaceObstacles placeObstacles = new(ZandomLevelGenerator, Constants.ZandomStartLocation, PlaceObstaclesParameters);
            placeObstacles.Run();
            Obstacle obstacle = placeObstacles.NewObstacles[0];
            //TODO: consider creating a PlaceStartLocationParameters struct too
            Vector3 positionFunction()
            {
                return obstacle.Position;
            }
            Obstacle obstacleFunction()
            {
                return obstacle;
            }
            new PlaceStartLocation(ZandomLevelGenerator, positionFunction, obstacleFunction).Run();
        }
    }
}
