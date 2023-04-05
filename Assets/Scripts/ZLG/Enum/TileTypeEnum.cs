using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    //PreDungeon
    ROOM_AREA = '.',
    ROOM_BORDER = '=',
    ROOM_CORNER = '#',
    //Dungeon and PostDungeon
    FLOOR = 'F',
    SPECIAL_FLOOR = 'S',
    WALL = 'W',
    DESTRUCTIBLE_WALL = 'Z',
    BARS = 'B',
    DOOR = 'D',
}

public static class TileTypeExtensions
{
    public static bool IsRoom(this TileType tileType)
    {
        return tileType == TileType.ROOM_AREA || tileType == TileType.ROOM_BORDER || tileType == TileType.ROOM_CORNER;
    }

    public static bool IsFloor(this TileType tileType)
    {
        return tileType == TileType.FLOOR || tileType == TileType.SPECIAL_FLOOR;
    }
}
