using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle
{
    public Obstacle(string name, List<Tile> tiles, bool vertical, Level level, Room room)
    {
        Name = name;
        MentionedTiles = tiles;
        Vertical = vertical;
        Level = level;
        Room = room;
    }

    public string Name { get; }
    public List<Tile> MentionedTiles { get; }
    public bool Vertical { get; }
    public Level Level { get; }
    public Room Room { get; }

    public Vector3 GetFinalPosition()
    {
        Vector3 result = new();
        foreach (var item in MentionedTiles)
        {
            result += item.GeneratedTile.transform.position;
        }
        result /= MentionedTiles.Count;
        return result;
    }
}
