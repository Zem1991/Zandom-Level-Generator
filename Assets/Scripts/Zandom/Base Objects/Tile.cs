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

    public bool FromSetPiece { get; set; }
    public TileType Type { get; set; }
    public Obstacle Obstacle { get; set; }
    public List<Room> MentionedRooms { get; set; }

    public override string ToString()
    {
        return $"Tile {Coordinates} \'{Type}\'";
    }
}
