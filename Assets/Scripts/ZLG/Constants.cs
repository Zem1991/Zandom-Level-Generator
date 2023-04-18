using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    //Level size and area
    public static int LEVEL_SIZE = 80;
    public static int LEVEL_AREA_MIN { get { return (int) (LEVEL_SIZE * LEVEL_SIZE * 0.4F); } }
    public static int LEVEL_AREA_MAX { get { return (int) (LEVEL_SIZE * LEVEL_SIZE * 0.8F); } }

    //Room settings
    public static int MODULE_SIZE = 10;
    public static int ROOM_AGE_FOR_WEAK_WALLS = 4;
    public static int SMALL_DOOR_MIN_LENGTH = 4;
    public static int BIG_DOOR_MAX_LENGTH = 8;
    public static int SPECIAL_ROOM_MIN = 8;
}
