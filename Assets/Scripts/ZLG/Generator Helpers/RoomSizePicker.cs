using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSizePicker
{
    public int Pick()
    {
        //int size = Random.Range(0, 4);
        int size = Random.Range(0, 3);
        size += 3;  //Solid, Floor, Floor
        size *= 2;  //Mirrored
        //6, 8, 10[, 12]
        //+2 for each Border
        return size;
    }
}
