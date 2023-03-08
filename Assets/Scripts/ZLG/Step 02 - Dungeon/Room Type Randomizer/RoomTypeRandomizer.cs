using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTypeRandomizer : LevelGeneratorTask
{
    public RoomTypeRandomizer(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override void Run()
    {
        List<Room> normalRooms = new();
        List<Room> specialRooms = new();
        foreach (Room room in LevelGenerator.Level.Rooms.Values)
        {
            if (room.IsEnclosed()) specialRooms.Add(room);
            else normalRooms.Add(room);
        }
        RunNormal(normalRooms);
        RunSpecial(specialRooms);
    }

    public void RunNormal(List<Room> rooms)
    {
        RoomTypePicker picker = new();
        foreach (Room room in rooms)
        {
            room.Type = picker.PickNormal();
            Run(room);
        }
    }

    public void RunSpecial(List<Room> rooms)
    {
        RoomTypePicker picker = new();
        foreach (Room room in rooms)
        {
            room.Type = picker.PickSpecial();
            Run(room);
        }
    }

    private void Run(Room room)
    {
        foreach (Tile tile in room.Tiles)
        {
            if (tile.Type == TileTypes.ROOM_AREA) tile.Type = room.Type;
        }
    }
}
