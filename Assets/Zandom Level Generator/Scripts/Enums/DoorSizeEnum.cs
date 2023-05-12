using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorSize
{
    SMALL = 2,//'S',
    LARGE = 4,//'L',
}

public static class DoorSizeExtensions
{
    public static string ObjectName(this DoorSize doorSize)
    {
        string result = null;
        switch (doorSize)
        {
            case DoorSize.SMALL:
                result = "Small Door";
                break;
            case DoorSize.LARGE:
                result = "Large Door";
                break;
        }
        return result;
    }
}
