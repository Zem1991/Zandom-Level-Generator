using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    //Room: PreDungeon
    ROOM_AREA = '.',
    ROOM_BORDER = '=',
    ROOM_CORNER = '#',
    //Wall: Dungeon and PostDungeon
    NORMAL_WALL = 'W',
    AGED_WALL = 'Z',
    BARS_WALL = 'B',
    //Floor: Dungeon and PostDungeon
    NORMAL_FLOOR = 'F',
    SPECIAL_FLOOR = 'S',
    DOORWAY_FLOOR = 'D',
}

public static class TileTypeExtensions
{
    public static bool IsRoom(this TileType tileType)
    {
        return tileType == TileType.ROOM_AREA || tileType == TileType.ROOM_BORDER || tileType == TileType.ROOM_CORNER;
    }

    public static bool IsFloor(this TileType tileType)
    {
        return tileType == TileType.NORMAL_FLOOR || tileType == TileType.SPECIAL_FLOOR || tileType == TileType.DOORWAY_FLOOR;
    }
}
