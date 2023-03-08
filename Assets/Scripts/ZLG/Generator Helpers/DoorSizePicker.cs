using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSizePicker
{
    public int Pick(Wall wall)
    {
        int length = wall.Tiles.Count;
        if (length < Constants.SMALL_DOOR_MIN_LENGTH) return 2;
        if (length > Constants.BIG_DOOR_MAX_LENGTH) return 4;
        int rng = Random.Range(1, 3);
        rng *= 2;
        return rng;
    }
}
