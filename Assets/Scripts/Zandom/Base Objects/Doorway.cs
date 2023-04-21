using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway
{
    public Doorway(Wall wall, DoorSize doorSize, List<Tile> tiles)
    {
        Wall = wall;
        DoorSize = doorSize;
        Tiles = tiles;
    }

    public Wall Wall { get; }
    public DoorSize DoorSize { get; }
    public List<Tile> Tiles { get; }

    public Obstacle Door { get; set; }

    public void Run(Wall wall)
    {
        DoorSizePicker sizePicker = new(LevelGenerator);
        DoorSize doorSize = sizePicker.Pick(wall);
        int validLength = wall.Tiles.Count - doorSize + 1;
        int startPos = Random.Range(0, validLength);
        int endPos = startPos + doorSize;
        for (int i = startPos; i < endPos; i++)
        {
            Tile tile = wall.Tiles[i];
            tile.Type = TileType.DOORWAY;
        }
    }
}
