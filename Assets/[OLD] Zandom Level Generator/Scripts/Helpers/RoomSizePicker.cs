//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace ZandomLevelGenerator.Helpers
//{
//    public class RoomSizePicker
//    {
//        private readonly ZandomLevelGenerator levelGenerator;

//        public RoomSizePicker(ZandomLevelGenerator levelGenerator)
//        {
//            this.levelGenerator = levelGenerator;
//        }

//        public int PickInt()
//        {
//            int size = levelGenerator.SeededRandom.Range(0, 3);
//            size += 3;  //Solid, Floor, Floor
//            size *= 2;  //Mirrored
//                        //6, 8, 10[, 12]
//                        //+2 for each Border
//            return size;
//        }

//        public Vector2Int PickVector2Int()
//        {
//            int sizeX = PickInt();
//            int sizeZ = PickInt();
//            return new(sizeX, sizeZ);
//        }
//    }
//}
