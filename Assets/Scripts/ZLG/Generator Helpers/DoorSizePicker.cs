using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSizePicker
{
    public int Pick(Wall wall)
    {
        int length = wall.Tiles.Count;
        if (length < 4) return 2;
        if (length > 8) return 4;
        int rng = Random.Range(1, 3);
        rng *= 2;
        return rng;
    }
}
