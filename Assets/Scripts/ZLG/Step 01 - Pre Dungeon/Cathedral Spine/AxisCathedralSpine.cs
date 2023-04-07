using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AxisCathedralSpine
{
    protected LevelGenerator levelGenerator;
    protected int firstRoomPosition;
    protected int corridorLength;
    protected bool rotate;

    public AxisCathedralSpine(LevelGenerator levelGenerator, int firstRoomPosition, int corridorLength)
    {
        this.levelGenerator = levelGenerator;
        this.firstRoomPosition = firstRoomPosition;
        this.corridorLength = corridorLength;
    }

    public void Run()
    {
        Vector2Int position1 = GetPositionRoom1();
        Vector2Int position2 = GetPositionRoom2();
        position1 *= Constants.MODULE_SIZE;
        position2 *= Constants.MODULE_SIZE;
        List<Room> rooms = new();
        Room room1 = Room(position1);
        Room room2 = Room(position2);
        rooms.Add(room1);
        rooms.Add(room2);
        if (corridorLength > 0)
        {
            List<Room> corridors = Corridor();
            rooms.AddRange(corridors);
        }
        ApplyBorders applyBorders = new(levelGenerator);
        foreach (Room item in rooms)
        {
            applyBorders.Apply(item);
        }
    }

    private Room Room(Vector2Int startPos)
    {
        SetPiece setPiece = new CathedralSpineRoom();
        if (rotate) setPiece.Rotate();
        return Build(startPos, setPiece);
    }

    private List<Room> Corridor()
    {
        List<Room> result = new();
        SetPiece setPiece = new CathedralSpineCorridor();
        if (rotate) setPiece.Rotate();
        for (int i = 0; i < corridorLength; i++)
        {
            int pos = firstRoomPosition + 2 + i;
            Vector2Int position = GetPositionCorridor(pos);
            position *= Constants.MODULE_SIZE;
            if (rotate) position.x += 3;
            else position.y += 3;
            Room room = Build(position, setPiece);
            result.Add(room);
        }
        return result;
    }

    protected abstract Vector2Int GetPositionRoom1();
    protected abstract Vector2Int GetPositionRoom2();
    protected abstract Vector2Int GetPositionCorridor(int index);
    protected abstract Room Build(Vector2Int position, SetPiece setPiece);
}
