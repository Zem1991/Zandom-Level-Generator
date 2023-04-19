using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    //Level size and area
    public static int LEVEL_SIZE_MAX { get; } = 80;
    public static int LEVEL_AREA_MAX { get { return LEVEL_SIZE_MAX * LEVEL_SIZE_MAX; } }

    //Room settings
    public static int MODULE_SIZE { get; } = 10;
}
