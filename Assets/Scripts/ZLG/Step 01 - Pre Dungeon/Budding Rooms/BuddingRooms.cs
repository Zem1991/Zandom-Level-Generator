using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddingRooms : LevelGeneratorTask
{
    private List<Room> StartingRooms { get; set; }

    public BuddingRooms(LevelGenerator levelGenerator, List<Room> startingRooms) : base(levelGenerator)
    {
        StartingRooms = startingRooms;
    }

    public override void Run()
    {
        Queue<Room> rooms = new(StartingRooms);
        while (rooms.Count > 0)
        {
            Room sourceRoom = rooms.Dequeue();
            List<Room> newRooms = Run(sourceRoom);
            foreach (Room room in newRooms) rooms.Enqueue(room);
        }
    }

    public List<Room> Run(Room parent)
    {
        bool vertical = !parent.Vertical;
        bool canKeepParentOrientation = parent.Parent != null;
        bool canRetry = canKeepParentOrientation;
        //bool canRetry = false;
        if (canKeepParentOrientation && Random.Range(0, 4) <= 0)
        {
            vertical = !vertical;
            //canRetry = true;
        }

        RoomSizePicker sizePicker = new();
        int sizeX = sizePicker.Pick();
        int sizeZ = sizePicker.Pick();
        Vector2Int size = new(sizeX, sizeZ);

        List<Room> newRooms;
        if (vertical)
            newRooms = new VerticalBuddingRooms(LevelGenerator).Run(size, parent);
        else
            newRooms = new HorizontalBuddingRooms(LevelGenerator).Run(size, parent);
        bool success = newRooms.Count > 0;
        if (!success && canRetry)
        {
            if (vertical)
                newRooms = new HorizontalBuddingRooms(LevelGenerator).Run(size, parent);
            else
                newRooms = new VerticalBuddingRooms(LevelGenerator).Run(size, parent);
        }
        return newRooms;
    }
}
