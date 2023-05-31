using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.Task
{
    public class RoomTypeRandomizer : LevelGeneratorTask
    {
        public RoomTypeRandomizer(LevelGenerator levelGenerator) : base(levelGenerator)
        {
        }

        public override IEnumerator Run()
        {
            //List<Room> normalRooms = new();
            //List<Room> specialRooms = new();
            foreach (Room item in LevelGenerator.Level.Rooms.Values)
            {
                Run(item);
                if (LevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
                {
                    yield return new GenerateFinalRoom(LevelGenerator, item).Run();
                }
            }
        }

        private void Run(Room room)
        {
            foreach (Tile tile in room.Tiles)
            {
                if (tile.Type != TileType.ROOM_AREA) continue;
                TileType newType = TileType.NORMAL_FLOOR;
                if (room.Type == RoomType.SPECIAL) newType = TileType.SPECIAL_FLOOR;
                tile.Type = newType;
            }
        }
    }
}
