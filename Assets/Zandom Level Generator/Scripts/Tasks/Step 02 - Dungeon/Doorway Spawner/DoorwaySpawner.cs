using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Helpers;

namespace ZandomLevelGenerator.Task
{
    public class DoorwaySpawner : LevelGeneratorTask
    {
        public DoorwaySpawner(LevelGenerator levelGenerator) : base(levelGenerator)
        {
        }

        public override IEnumerator Run()
        {
            foreach (Wall wall in LevelGenerator.Level.Walls.Values)
            {
                if (!wall.CanHaveDoor()) continue;
                Run(wall);
            }
            if (LevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
            {
                foreach (Wall wall in LevelGenerator.Level.Walls.Values)
                {
                    yield return new GenerateFinalTiles(LevelGenerator, wall).Run();
                }
            }
        }

        public void Run(Wall wall)
        {
            DoorSizePicker sizePicker = new(LevelGenerator);
            DoorSize doorSize = sizePicker.Pick(wall);
            int doorSizeInt = (int)doorSize;

            int validLength = wall.Tiles.Count - doorSizeInt + 1;
            int startPos = Random.Range(0, validLength);
            int endPos = startPos + doorSizeInt;

            List<Tile> tiles = new();
            for (int i = startPos; i < endPos; i++)
            {
                Tile tile = wall.Tiles[i];
                tile.Type = TileType.DOORWAY_FLOOR;
                tiles.Add(tile);
            }

            Doorway doorway = new(wall, doorSize, tiles);
            wall.Doorway = doorway;

            //Level level = wall.Level;
            //Room room = wall.SourceRoom;
            //level.CreateObstacle(doorSize.ObjectName(), tiles, wall.IsVertical(), room);
        }
    }
}
