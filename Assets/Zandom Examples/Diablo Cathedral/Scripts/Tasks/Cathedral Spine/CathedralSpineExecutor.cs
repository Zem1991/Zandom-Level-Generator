using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Helpers;

public class CathedralSpineExecutor
{
    private LevelGenerator levelGenerator;

    public CathedralSpineExecutor(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    public Room Run(Vector2Int position, SetPiece setPiece, bool verticalOrientation)
    {
        RoomBuilder roomBuilder = new(levelGenerator);
        //if (!roomBuilder.CanBuild(position, setPiece.Size)) return;
        Room room = roomBuilder.Build(position, setPiece, verticalOrientation, null);
        SetPieceBuilder setPieceBuilder = new(levelGenerator);
        setPieceBuilder.Build(position, setPiece);
        return room;
    }
}
