//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using ZandomLevelGenerator.BaseObjects;

//namespace ZandomLevelGenerator.Helpers
//{
//    public class TileListPositionFinder
//    {
//        public Vector3 Find(List<Tile> tiles)
//        {
//            Vector3 result = new();
//            foreach (var item in tiles)
//            {
//                //result += item.GeneratedTile.transform.position;
//                result.x += item.Coordinates.x;
//                result.z += item.Coordinates.y;
//            }
//            result /= tiles.Count;
//            return result;
//        }
//    }
//}
