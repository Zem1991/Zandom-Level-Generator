using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CathedralSpineExecutor
{
    private LevelGenerator levelGenerator;

    public CathedralSpineExecutor(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    public void Run(Vector2Int position, SetPiece setPiece, bool verticalOrientation)
    {
        RoomBuilder roomBuilder = new(levelGenerator);
        if (!roomBuilder.CanBuild(position, setPiece.Size)) return;
        roomBuilder.Build(position, setPiece, verticalOrientation, null);
    }
}
