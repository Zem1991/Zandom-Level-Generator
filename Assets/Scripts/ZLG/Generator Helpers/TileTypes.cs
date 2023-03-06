using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TileTypes
{
    //PreDungeon
    public const char ROOM_AREA = '.';
    public const char ROOM_BORDER = '=';
    public const char ROOM_CORNER = '#';

    //Dungeon and PostDungeon
    public const char FLOOR = 'F';
    public const char SPECIAL_FLOOR = 'S';
    public const char WALL = 'W';
    public const char DESTRUCTIBLE_WALL = 'Z';
    public const char BARS = 'B';
    public const char DOOR = 'D';

    public static bool IsRoom(char type)
    {
        return type == ROOM_AREA || type == ROOM_BORDER || type == ROOM_CORNER;
    }

    public static bool IsFloor(char type)
    {
        return type == FLOOR || type == SPECIAL_FLOOR;
    }
}
