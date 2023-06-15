//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using ZandomLevelGenerator.BaseObjects;
//using ZandomLevelGenerator.Components;
//using ZandomLevelGenerator.Enums;
//using ZandomLevelGenerator.Helpers;

//namespace ZandomLevelGenerator.Task
//{
//    public class EntrancePlacement : LevelGeneratorTask
//    {
//        public EntrancePlacement(ZandomLevelGenerator levelGenerator) : base(levelGenerator)
//        {
//        }

//        public override IEnumerator Run()
//        {
//            Level level = ZandomLevelGenerator.Level;
//            ZandomObstacle obstacleData = ZandomLevelGenerator.ZandomObstacleList.Get("Entrance");
//            List<Room> validRooms = new();
//            foreach (var item in level.Rooms.Values)
//            {
//                if (item.FromSetPiece) continue;
//                if (item.Type != RoomType.NORMAL) continue;
//                validRooms.Add(item);
//            }
//            ObstaclePlacement obstaclePlacement = new(ZandomLevelGenerator, obstacleData, validRooms);
//            yield return obstaclePlacement.Run();
//            Obstacle result = obstaclePlacement.Results[0];
//            level.SetStartLocation(result.CenterPosition);
//            if (ZandomLevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
//            {
//                yield return new GenerateFinalObstacles(ZandomLevelGenerator).Run();
//            }
//        }
//    }
//}
