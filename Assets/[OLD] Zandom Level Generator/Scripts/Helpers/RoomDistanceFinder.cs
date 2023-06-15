//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using ZandomLevelGenerator.BaseObjects;

//namespace ZandomLevelGenerator.Helpers
//{
//    public class RoomDistanceFinder
//    {
//        public int Find(Room sector1, Room sector2)
//        {
//            Room earlier = sector1;
//            Room later = sector2;
//            if (sector1.Age > sector2.Age)
//            {
//                earlier = sector2;
//                later = sector1;
//            }
//            int steps = 0;
//            while (earlier.Age < later.Age)
//            {
//                later = later.Parent;
//                steps++;
//            }
//            if (earlier != later)
//            {
//                while (earlier.Parent != later.Parent)
//                {
//                    earlier = earlier.Parent;
//                    later = later.Parent;
//                    steps++;
//                    steps++;
//                }
//                steps++;
//            }
//            return steps;
//        }
//    }
//}
