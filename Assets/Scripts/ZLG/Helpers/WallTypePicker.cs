using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTypePicker
{
    public TileType Enclosed()
    {
        int rng = Random.Range(0, 2);
        if (rng > 0) return TileType.BARS;
        return Normal();
    }

    public TileType Parent()
    {
        int rng = Random.Range(0, 2);
        if (rng > 0) return Enclosed();
        return TileType.FLOOR;
    }
    
    public TileType Destructible()
    {
        return TileType.DESTRUCTIBLE_WALL;
    }

    public TileType Normal()
    {
        return TileType.WALL;
    }
}
