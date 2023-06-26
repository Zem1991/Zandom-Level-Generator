using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Enums
{
    public enum TileOverlap
    {
        NONE = ' ',
        WALL = '/',
        DOORWAY = '+',
    }

    //public static class TileOverlapExtensions
    //{
    //    public static string ToString(this TileOverlap tileOverlap)
    //    {
    //        char asChar = (char)tileOverlap;
    //        return asChar.ToString();
    //    }
    //}
}
