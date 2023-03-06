using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTypePicker
{
    public char SpecialRoom()
    {
        int rng = Random.Range(0, 2);
        if (rng > 0) return TileTypes.BARS;
        return Normal();
    }

    public char Parent()
    {
        int rng = Random.Range(0, 2);
        if (rng > 0) return SpecialRoom();
        return TileTypes.FLOOR;
    }
    
    public char Destructible()
    {
        return TileTypes.DESTRUCTIBLE_WALL;
    }

    public char Normal()
    {
        return TileTypes.WALL;
    }
}
