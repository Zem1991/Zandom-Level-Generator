using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator
{
    public static class Constants
    {
        //Level size and area
        public static int LEVEL_SIZE_MAX { get; } = 80;
        public static int LEVEL_AREA_MAX { get { return LEVEL_SIZE_MAX * LEVEL_SIZE_MAX; } }

        //Room settings
        public static int MODULE_SIZE { get; } = 10;

        //Gameplay settings
        public static float EntranceSafetyRadius { get; } = 10F;
        public static float ExitSafetyRadius { get; } = 7.5F;

        //Gizmos colors
        public static Color SizeBoundsColor { get; } = Color.green;
        public static Color SafetyBoundsColor { get; } = Color.yellow;
        public static Color StateBoxColor { get; } = Color.white;
        public static Color EntranceZoneColor { get; } = Color.cyan;
        public static Color ExitZoneColor { get; } = Color.magenta;
    }
}
