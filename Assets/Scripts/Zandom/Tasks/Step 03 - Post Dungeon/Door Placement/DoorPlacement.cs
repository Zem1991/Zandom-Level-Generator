using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (LevelGenerator.taskWaitingTier > 0)
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
        Obstacle door = level.CreateObstacle(doorway.DoorSize.ObjectName(), doorway.Tiles, wall.IsVertical(), room);
        doorway.Door = door;
    }
}
