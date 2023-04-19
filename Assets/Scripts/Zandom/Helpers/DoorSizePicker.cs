using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSizePicker// : LevelGeneratorTask
{
    private LevelGenerator levelGenerator;

    public DoorSizePicker(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    public int Pick(Wall wall)
    {
        int length = wall.Tiles.Count;
        if (length < levelGenerator.ZandomParameters.smallDoorLengthMin) return 2;
        if (length > levelGenerator.ZandomParameters.largeDoorLengthMax) return 4;
        int rng = Random.Range(1, 3);
        rng *= 2;
        return rng;
    }
}
