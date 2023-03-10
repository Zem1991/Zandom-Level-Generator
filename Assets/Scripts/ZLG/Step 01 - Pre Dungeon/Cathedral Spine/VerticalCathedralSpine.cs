using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCathedralSpine
{
    private LevelGenerator levelGenerator;
    private int firstRoomPosition;
    private int corridorLength;

    public VerticalCathedralSpine(LevelGenerator levelGenerator, int firstRoomPosition, int corridorLength)
    {
        this.levelGenerator = levelGenerator;
        this.firstRoomPosition = firstRoomPosition;
        this.corridorLength = corridorLength;
    }

    public void Run()
    {
        Vector2Int position1 = new(3, firstRoomPosition);
        Vector2Int position2 = new(3, firstRoomPosition + 2 + corridorLength);
        position1 *= Constants.MODULE_SIZE;
        position2 *= Constants.MODULE_SIZE;
        Room(position1);
        Room(position2);
        if (corridorLength <= 0) return;
        Corridor();
    }

    private void Room(Vector2Int startPos)
    {
        SetPiece setPiece = new CathedralSpineRoom();
        setPiece.Rotate();
        Build(startPos, setPiece);
    }

    private void Corridor()
    {
        SetPiece setPiece = new CathedralSpineCorridor();
        setPiece.Rotate();
        for (int i = 0; i < corridorLength; i++)
        {
            int pos = firstRoomPosition + 2 + 3 + i;
            Vector2Int position = new(3, pos);
            position *= Constants.MODULE_SIZE;
            Build(position, setPiece);
        }
    }

    private void Build(Vector2Int position, SetPiece setPiece)
    {
        new CathedralSpineExecutor(levelGenerator).Run(position, setPiece, true);
    }
}
