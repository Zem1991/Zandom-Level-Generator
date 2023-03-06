using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTypePicker
{
    public char PickNormal()
    {
        return TileTypes.FLOOR;
    }
    
    public char PickSpecial()
    {
        return TileTypes.SPECIAL_FLOOR;
    }
}
