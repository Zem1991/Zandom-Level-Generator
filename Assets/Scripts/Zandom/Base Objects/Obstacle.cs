using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle
{
    public Obstacle(string name, Level level)
    {
        Name = name;
        Level = level;
        MentionedTiles = new();
    }

    public string Name { get; }
    public Level Level { get; }

    public bool Vertical { get; set; }
    public List<Tile> MentionedTiles { get; set; }
}
