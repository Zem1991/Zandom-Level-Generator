using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCathedralSpine
{
    private LevelGenerator levelGenerator;
    private int firstRoomPosition;
    private int corridorLength;

    public HorizontalCathedralSpine(LevelGenerator levelGenerator, int firstRoomPosition, int corridorLength)
    {
        this.levelGenerator = levelGenerator;
        this.firstRoomPosition = firstRoomPosition;
        this.corridorLength = corridorLength;
    }

    public void Run()
    {
        Vector2Int position1 = new(firstRoomPosition, 3);
        Vector2Int position2 = new(firstRoomPosition + 2 + corridorLength, 3);
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
        Build(startPos, setPiece);
    }

    private void Corridor()
    {
        SetPiece setPiece = new CathedralSpineCorridor();
        for (int i = 0; i < corridorLength; i++)
        {
            int pos = firstRoomPosition + 2 + i;
            Vector2Int position = new(pos, 3);
            position *= Constants.MODULE_SIZE;
            position.y += 3;
            Build(position, setPiece);
        }
    }

    private void Build(Vector2Int position, SetPiece setPiece)
    {
        new CathedralSpineExecutor(levelGenerator).Run(position, setPiece, false);
    }
}
