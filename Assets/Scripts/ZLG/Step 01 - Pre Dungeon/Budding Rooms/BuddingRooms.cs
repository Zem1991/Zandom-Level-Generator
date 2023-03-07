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
        bool nextVertical;// = false;
        bool enoughParents = parent?.Parent != null;
        bool tooManyParents = parent?.Parent?.Parent != null;
        bool canRetry = !tooManyParents;
        enoughParents = tooManyParents;

        if (enoughParents)
        {
            bool parentsWithSameOrientation = parent.Vertical == parent.Parent.Vertical;
            if (parentsWithSameOrientation)
            {
                nextVertical = !parent.Vertical;
            }
            else
            {
                bool keepSame = Random.Range(0, 4) <= 0;
                if (keepSame) nextVertical = parent.Vertical;
                else nextVertical = !parent.Vertical;
            }
        }
        else
        {
            nextVertical = !parent.Vertical;
        }

        RoomSizePicker sizePicker = new();
        int sizeX = sizePicker.Pick();
        int sizeZ = sizePicker.Pick();
        Vector2Int size = new(sizeX, sizeZ);

        List<Room> newRooms;
        if (nextVertical)
            newRooms = new VerticalBuddingRooms(LevelGenerator).Run(size, parent);
        else
            newRooms = new HorizontalBuddingRooms(LevelGenerator).Run(size, parent);
        bool success = newRooms.Count > 0;
        if (!success && canRetry)
        {
            if (nextVertical)
                newRooms = new HorizontalBuddingRooms(LevelGenerator).Run(size, parent);
            else
                newRooms = new VerticalBuddingRooms(LevelGenerator).Run(size, parent);
        }
        return newRooms;
    }
}
