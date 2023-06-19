//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using ZandomLevelGenerator.BaseObjects;
//using ZandomLevelGenerator.Enums;
//using ZandomLevelGenerator.Task;

//namespace ZandomLevelGenerator.Examples.DiabloCathedral
//{
//    public class CathedralSpine : LevelGeneratorTask
//    {
//        public CathedralSpine(ZandomLevelGenerator levelGenerator) : base(levelGenerator)
//        {
//        }
    
//        public override IEnumerator Run()
//        {
//            bool shorterVersion = ZandomLevelGenerator.ZandomParameters.avoidSizeBoundaries;
//            int maxLength = shorterVersion ? 3 : 5;
//            int corridorLength = ZandomLevelGenerator.SeededRandom.Range(0, maxLength);
//            int maxPosition = maxLength - corridorLength;
//            int firstRoomPosition = ZandomLevelGenerator.SeededRandom.Range(0, maxPosition);
//            if (shorterVersion) firstRoomPosition++;
//            bool vertical = ZandomLevelGenerator.SeededRandom.Range(0, 2) > 0;
//            AxisCathedralSpine axisCathedralSpine;
//            if (vertical)
//            {
//                axisCathedralSpine = new VerticalCathedralSpine(ZandomLevelGenerator, firstRoomPosition, corridorLength);
//            }
//            else
//            {
//                axisCathedralSpine = new HorizontalCathedralSpine(ZandomLevelGenerator, firstRoomPosition, corridorLength);
//            }
//            List<Room> newRooms = axisCathedralSpine.Run();
//            foreach (var item in newRooms)
//            {
//                if (ZandomLevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
//                {
//                    yield return new GenerateFinalRoom(ZandomLevelGenerator, item).Run();
//                }
//            }
//        }
//    }
//}
