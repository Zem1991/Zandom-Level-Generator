using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Components;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Helpers;
using ZandomLevelGenerator.Task;

namespace ZandomLevelGenerator.Examples.DiabloCathedral
{
    public class NormalEncounterPlacement : LevelGeneratorTask
    {
        public NormalEncounterPlacement(LevelGenerator levelGenerator) : base(levelGenerator)
        {
        }

        public override IEnumerator Run()
        {
            ZandomObstacle obstacleData = LevelGenerator.ZandomObstacleList.Get("Normal Encounter");
            List<Room> validRooms = new();
            foreach (var item in LevelGenerator.Level.Rooms.Values)
            {
                //if (item.Type == RoomType.SPECIAL) continue;
                validRooms.Add(item);
            }
            ObstaclePlacement obstaclePlacement = new(LevelGenerator, obstacleData, validRooms);
            yield return obstaclePlacement.Run();
            if (LevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
            {
                yield return new GenerateFinalObstacles(LevelGenerator).Run();
            }
        }
    }
}
