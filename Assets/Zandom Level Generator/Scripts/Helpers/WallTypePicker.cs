using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTypePicker
{
    public TileType Enclosed()
    {
        int rng = Random.Range(0, 2);
        if (rng > 0) return TileType.BARS_WALL;
        return Normal();
    }

    public TileType Parent()
    {
        int rng = Random.Range(0, 2);
        if (rng > 0) return Enclosed();
        return TileType.NORMAL_FLOOR;
    }
    
    public TileType AgedDestructible()
    {
        return TileType.AGED_WALL;
    }

    public TileType Normal()
    {
        return TileType.NORMAL_WALL;
    }
}
