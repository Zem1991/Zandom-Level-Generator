//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using ZandomLevelGenerator.BaseObjects;

//namespace ZandomLevelGenerator.Helpers
//{
//    public class WallBuilder
//    {
//        public WallBuilder(ZandomLevelGenerator levelGenerator)
//        {
//            ZandomLevelGenerator = levelGenerator;
//        }

//        private ZandomLevelGenerator ZandomLevelGenerator { get; }

//        public bool CanBuild(Room sourceRoom, Room neighborRoom, List<Tile> tiles)
//        {
//            if (sourceRoom == null) return false;
//            if (neighborRoom == null) return false;
//            if (tiles.Count < 2) return false;
//            return true;
//        }

//        public Wall Build(Room sourceRoom, Room neighborRoom, List<Tile> tiles)
//        {
//            Wall wall = ZandomLevelGenerator.Level.CreateWall(sourceRoom, neighborRoom, tiles);
//            //foreach (var item in tiles)
//            //{
//            //    wall.TileMap.Add(item);
//            //}
//            return wall;
//        }
//    }
//}
