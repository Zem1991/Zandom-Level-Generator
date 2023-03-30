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
        DungeonAreaChecker dungeonAreaChecker = new(LevelGenerator);
        while (rooms.Count > 0)
        {
            if (dungeonAreaChecker.CheckAreaMin()) break;
            Room sourceRoom = rooms.Dequeue();
            List<Room> newRooms = Run(sourceRoom);
            foreach (Room room in newRooms) rooms.Enqueue(room);
        }
    }

    public List<Room> Run(Room parent)
    {
        bool vertical = PickAxis(parent);
        bool canRetry = CanRetry(parent);
        Vector2Int size = new RoomSizePicker().PickVector2Int();
        List<Room> newRooms = Run(vertical, size, parent);
        if (newRooms.Count <= 0 && canRetry) newRooms = Run(!vertical, size, parent);
        return newRooms;
    }

    private bool PickAxis(Room parent)
    {
        bool result;
        bool enoughParents = parent?.Parent != null;
        if (enoughParents)
        {
            bool parentsWithSameOrientation = parent.Vertical == parent.Parent.Vertical;
            if (parentsWithSameOrientation)
            {
                result = !parent.Vertical;
            }
            else
            {
                bool keepSame = Random.Range(0, 4) <= 0;
                if (keepSame) result = parent.Vertical;
                else result = !parent.Vertical;
            }
        }
        else
        {
            result = !parent.Vertical;
        }
        return result;
    }

    private bool CanRetry(Room parent)
    {
        bool tooManyParents = parent?.Parent?.Parent != null;
        if (!tooManyParents) return true;
        bool sameOrientations = parent.Vertical == parent.Parent.Vertical;
        return !sameOrientations;
    }
    
    private List<Room> Run(bool vertical, Vector2Int size, Room parent)
    {
        if (vertical)
            return new VerticalBuddingRooms(LevelGenerator).Run(size, parent);
        else
            return new HorizontalBuddingRooms(LevelGenerator).Run(size, parent);
    }
}
