using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.Helpers
{
    public class DoorSizePicker// : LevelGeneratorTask
    {
        private LevelGenerator levelGenerator;

        public DoorSizePicker(LevelGenerator levelGenerator)
        {
            this.levelGenerator = levelGenerator;
        }

        public DoorSize Pick(Wall wall)
        {
            int length = wall.Tiles.Count;
            if (length < levelGenerator.ZandomParameters.smallDoorLengthMin) return DoorSize.SMALL;
            if (length > levelGenerator.ZandomParameters.largeDoorLengthMax) return DoorSize.LARGE;
            int rng = Random.Range(1, 3);
            rng *= 2;
            DoorSize result = DoorSize.SMALL;
            if (rng <= 0) result = DoorSize.LARGE;
            return result;
        }
    }
}
