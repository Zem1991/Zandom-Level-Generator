using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public Tile(Vector2Int coordinates)
    {
        Coordinates = coordinates;
        MentionedRooms = new();
    }

    public Vector2Int Coordinates { get; }
    public List<Room> MentionedRooms { get; set; }
    public TileType Type { get; set; }

    public override string ToString()
    {
        return $"Tile {Coordinates} \'{Type}\'";
    }
}
