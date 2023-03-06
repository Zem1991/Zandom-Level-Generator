using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTypePicker
{
    public char Pick(Wall wall)
    {
        //if (TileTypes.IsFloor(wall.Type)) return wall.Type;
        //int rng = Random.Range(0, 4);
        //if (rng <= 0) return TileTypes.FLOOR;
        return TileTypes.DOOR;
    }
}
