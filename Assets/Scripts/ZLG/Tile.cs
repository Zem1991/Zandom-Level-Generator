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
    public char Type { get; set; }
}
