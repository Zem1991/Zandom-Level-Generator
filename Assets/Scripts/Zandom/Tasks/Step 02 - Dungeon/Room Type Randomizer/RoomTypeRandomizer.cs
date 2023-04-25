using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTypeRandomizer : LevelGeneratorTask
{
    public RoomTypeRandomizer(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override IEnumerator Run()
    {
        List<Room> normalRooms = new();
        List<Room> specialRooms = new();
        foreach (Room room in LevelGenerator.Level.Rooms.Values)
        {
            Run(room);
            //if (room.IsEnclosed()) specialRooms.Add(room);
            //else normalRooms.Add(room);
        }
        //RunNormal(normalRooms);
        //RunSpecial(specialRooms);
        yield return null;
    }

    //public void RunNormal(List<Room> rooms)
    //{
    //    foreach (Room room in rooms)
    //    {
    //        room.Type = RoomType.NORMAL;
    //        Run(room);
    //    }
    //}

    //public void RunSpecial(List<Room> rooms)
    //{
    //    foreach (Room room in rooms)
    //    {
    //        room.Type = RoomType.SPECIAL;
    //        Run(room);
    //    }
    //}

    private void Run(Room room)
    {
        foreach (Tile tile in room.Tiles)
        {
            if (tile.Type != TileType.ROOM_AREA) continue;
            TileType newType = TileType.FLOOR;
            if (room.Type == RoomType.SPECIAL) newType = TileType.SPECIAL_FLOOR;
            tile.Type = newType;
        }
    }
}
