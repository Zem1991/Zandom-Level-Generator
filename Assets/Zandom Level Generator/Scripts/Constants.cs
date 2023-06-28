using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator
{
    public static class Constants
    {
        public static string ZandomStartLocation { get; } = "ZandomStartLocation";

        //Gameplay settings
        public static float StartLocationRadius { get; } = 10F;
        public static float PointOfInterestRadius { get; } = 7.5F;

        //Gizmos colors
        public static Color SizeBoundsColor { get; } = Color.green;
        public static Color SafetyBoundsColor { get; } = Color.yellow;
        public static Color StateBoxColor { get; } = Color.white;
        public static Color EntranceZoneColor { get; } = Color.cyan;
        public static Color ExitZoneColor { get; } = Color.magenta;
    }
}
