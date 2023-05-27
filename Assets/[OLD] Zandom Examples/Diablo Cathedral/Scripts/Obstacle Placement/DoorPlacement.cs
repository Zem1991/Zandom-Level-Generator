using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Components;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Task;

namespace ZandomLevelGenerator.Examples.DiabloCathedral
{
    public class DoorPlacement : LevelGeneratorTask
    {
        public DoorPlacement(LevelGenerator levelGenerator) : base(levelGenerator)
        {
        }

        public override IEnumerator Run()
        {
            foreach (Wall wall in LevelGenerator.Level.Walls.Values)
            {
                Doorway doorway = wall.Doorway;
                if (doorway == null) continue;
                Run(doorway);
                if (LevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
                {
                    Obstacle door = doorway.Door;
                    yield return new GenerateFinalObstacles(LevelGenerator).Run(door);
                }
            }
        }

        public void Run(Doorway doorway)
        {
            Wall wall = doorway.Wall;
            Level level = wall.Level;
            Room room = wall.SourceRoom;
            string objectName = doorway.DoorSize.ObjectName();
            ZandomObstacle obstacleData = LevelGenerator.ZandomObstacleList.Get(objectName);
            Obstacle door = level.CreateObstacle(obstacleData, doorway.Tiles, wall.Vertical);
            doorway.Door = door;
        }
    }
}
