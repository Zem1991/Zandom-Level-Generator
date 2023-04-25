using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddingRooms : LevelGeneratorTask
{
    private List<Room> StartingRooms { get; set; }

    public BuddingRooms(LevelGenerator levelGenerator, IEnumerable<Room> startingRooms) : base(levelGenerator)
    {
        StartingRooms = new(startingRooms);
    }

    public override IEnumerator Run()
    {
        bool avoidSizeBoundaries = LevelGenerator.ZandomParameters.avoidSizeBoundaries;
        RoomPositionChecker roomPositionChecker = new(LevelGenerator.Level);
        Queue<Room> rooms = new(StartingRooms);
        int levelArea = 0;
        foreach (var item in rooms)
        {
            levelArea += item.Area;
        }
        while (rooms.Count > 0)
        {
            int maximum = Constants.LEVEL_AREA_MAX;
            if (levelArea >= maximum)
            {
                Debug.Log($"Reached target area: {levelArea}/{maximum}");
                break;
            }
            Room sourceRoom = rooms.Dequeue();
            if (avoidSizeBoundaries)
            {
                bool tooFar = roomPositionChecker.CheckBoundsProximity(sourceRoom);
                if (tooFar) continue;
            }
            List<Room> newRooms = Run(sourceRoom);
            foreach (var item in newRooms)
            {
                levelArea += item.Area;
                rooms.Enqueue(item);
            }
        }
        yield return null;
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
