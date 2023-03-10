using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPieceBuilder
{
    public SetPieceBuilder(LevelGenerator levelGenerator)
    {
        LevelGenerator = levelGenerator;
    }

    private LevelGenerator LevelGenerator { get; }

    public bool CanBuild(Vector2Int start, SetPiece setPiece)
    {
        bool insideLevelBounds = LevelGenerator.Level.IsInsideBounds(start, setPiece.Size);
        bool availableOnTilemap = LevelGenerator.Level.TileMap.IsAvailable(start, setPiece.Size);
        //start -= Vector2Int.one;
        //size += Vector2Int.one;
        return insideLevelBounds && availableOnTilemap;
    }

    public bool Build(Vector2Int start, SetPiece setPiece)
    {
        bool setPieceTile(int col, int row)
        {
            Vector2Int coordinates = new(col, row);
            char tileType = setPiece.Get(coordinates.x - start.x, coordinates.y - start.y);
            Tile tile = LevelGenerator.Level.TileMap.Get(coordinates);
            tile.Type = tileType;
            return true;
        }
        TileMapIterator iterator = new();
        iterator.IterateAll(start, setPiece.Size, setPieceTile);
        return true;
    }
}
