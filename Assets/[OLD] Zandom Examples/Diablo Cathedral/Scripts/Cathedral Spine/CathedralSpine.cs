using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Task;

namespace ZandomLevelGenerator.Examples.DiabloCathedral
{
    public class CathedralSpine : LevelGeneratorTask
    {
        public CathedralSpine(LevelGenerator levelGenerator) : base(levelGenerator)
        {
        }
    
        public override IEnumerator Run()
        {
            bool shorterVersion = LevelGenerator.ZandomParameters.avoidSizeBoundaries;
            int maxLength = shorterVersion ? 3 : 5;
            int corridorLength = LevelGenerator.SeededRandom.Range(0, maxLength);
            int maxPosition = maxLength - corridorLength;
            int firstRoomPosition = LevelGenerator.SeededRandom.Range(0, maxPosition);
            if (shorterVersion) firstRoomPosition++;
            bool vertical = LevelGenerator.SeededRandom.Range(0, 2) > 0;
            AxisCathedralSpine axisCathedralSpine;
            if (vertical)
            {
                axisCathedralSpine = new VerticalCathedralSpine(LevelGenerator, firstRoomPosition, corridorLength);
            }
            else
            {
                axisCathedralSpine = new HorizontalCathedralSpine(LevelGenerator, firstRoomPosition, corridorLength);
            }
            List<Room> newRooms = axisCathedralSpine.Run();
            foreach (var item in newRooms)
            {
                if (LevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
                {
                    yield return new GenerateFinalRoom(LevelGenerator, item).Run();
                }
            }
        }
    }
}
