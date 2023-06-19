//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using ZandomLevelGenerator.BaseObjects;
//using ZandomLevelGenerator.Components;
//using ZandomLevelGenerator.Helpers;

//namespace ZandomLevelGenerator.Examples.DiabloCathedral
//{
//    public class CathedralSpineExecutor
//    {
//        private ZandomLevelGenerator levelGenerator;

//        public CathedralSpineExecutor(ZandomLevelGenerator levelGenerator)
//        {
//            this.levelGenerator = levelGenerator;
//        }

//        public Room Run(Vector2Int position, SetPiecePattern setPiece, bool verticalOrientation)
//        {
//            RoomBuilder roomBuilder = new(levelGenerator);
//            //if (!roomBuilder.CanBuild(position, setPiece.Size)) return;
//            Room room = roomBuilder.Build(position, setPiece, verticalOrientation, null);
//            SetPieceBuilder setPieceBuilder = new(levelGenerator);
//            setPieceBuilder.Build(position, setPiece);
//            return room;
//        }
//    }
//}
