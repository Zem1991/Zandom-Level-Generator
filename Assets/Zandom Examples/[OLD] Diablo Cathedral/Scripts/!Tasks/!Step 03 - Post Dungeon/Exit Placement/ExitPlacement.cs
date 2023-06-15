//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using ZandomLevelGenerator.BaseObjects;
//using ZandomLevelGenerator.Components;
//using ZandomLevelGenerator.Enums;
//using ZandomLevelGenerator.Helpers;

//namespace ZandomLevelGenerator.Task
//{
//    public class ExitPlacement : LevelGeneratorTask
//    {
//        public ExitPlacement(ZandomLevelGenerator levelGenerator) : base(levelGenerator)
//        {
//        }

//        public override IEnumerator Run()
//        {
//            Level level = ZandomLevelGenerator.Level;
//            ZandomObstacle obstacleData = ZandomLevelGenerator.ZandomObstacleList.Get("Exit");
//            List<Room> validRooms = new();
//            Vector3 startPosition = level.StartLocation.Position;
//            foreach (var item in level.Rooms.Values)
//            {
//                if (item.FromSetPiece) continue;
//                if (item.Type != RoomType.NORMAL) continue;
//                float minDistance = Constants.EntranceSafetyRadius + Constants.ExitSafetyRadius;
//                bool withinDistance = CheckWithinDistance(item.Center, startPosition, minDistance);
//                if (withinDistance) continue;
//                validRooms.Add(item);
//            }
//            ObstaclePlacement obstaclePlacement = new(ZandomLevelGenerator, obstacleData, validRooms);
//            yield return obstaclePlacement.Run();
//            Obstacle result = obstaclePlacement.Results[0];
//            level.AddPointOfInterest(result.CenterPosition, "Exit Zone");
//            if (ZandomLevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
//            {
//                yield return new GenerateFinalObstacles(ZandomLevelGenerator).Run();
//            }
//        }

//        private bool CheckWithinDistance(Vector3 pos1, Vector3 pos2, float threshold)
//        {
//            float distance = Vector3.Distance(pos1, pos2);
//            return distance <= threshold;
//        }
//    }
//}
