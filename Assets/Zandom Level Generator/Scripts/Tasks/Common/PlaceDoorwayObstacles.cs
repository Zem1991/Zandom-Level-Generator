using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Factories;

namespace ZandomLevelGenerator.Tasks.Common
{
    public class PlaceDoorwayObstacles : GeneratorTask
    {
        public PlaceDoorwayObstacles(ZandomLevelGenerator zandomLevelGenerator, PlaceDoorwayObstaclesParameters parameters) : base(zandomLevelGenerator)
        {
            Parameters = parameters;
            NewObstacles = new();
        }

        public PlaceDoorwayObstaclesParameters Parameters { get; }
        public Dictionary<int, Obstacle> NewObstacles { get; }

        public override void RunContents()
        {
            string name = Parameters.ObjectNameFunction(ZandomLevelGenerator);
            ObstacleData data = ZandomLevelGenerator.ZandomObstacleList.Get(name);
            List<BorderOverlapDoorway> doorways = Parameters.DoorwaysFunction(ZandomLevelGenerator);
            foreach (var item in doorways)
            {
                PlaceObstacle(data, item);
            }
        }

        private void PlaceObstacle(ObstacleData data, BorderOverlapDoorway doorway)
        {
            ObstacleFactory factory = new(ZandomLevelGenerator.GeneratorCoroutine.Level);
            int obstacleId = factory.NextId();
            HashSet<Vector3Int> coordinates = doorway.TilesIds;
            Vector3 rotationEuler = Vector3.zero;
            Vector3Int coord1 = coordinates.ElementAt(0);
            Vector3Int coord2 = coordinates.ElementAt(1);
            bool isVertical = coord1.z != coord2.z;
            if (isVertical)
            {
                rotationEuler.y += 90;
            }
            Obstacle obstacle = factory.Create(obstacleId, coordinates, rotationEuler, data);
            NewObstacles.Add(obstacleId, obstacle);
        }
    }
}
