//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using ZandomLevelGenerator.BaseObjects;
//using ZandomLevelGenerator.Components;
//using ZandomLevelGenerator.Enums;

//namespace ZandomLevelGenerator.Helpers
//{
//    public class SetPieceBuilder
//    {
//        public SetPieceBuilder(LevelGenerator levelGenerator)
//        {
//            LevelGenerator = levelGenerator;
//        }

//        private LevelGenerator LevelGenerator { get; }

//        public bool CanBuild(Vector2Int start, SetPiecePattern setPiece)
//        {
//            bool insideLevelBounds = LevelGenerator.Level.IsInsideBounds(start, setPiece.Size);
//            bool availableOnTilemap = LevelGenerator.Level.TileMap.IsAvailable(start, setPiece.Size);
//            return insideLevelBounds && availableOnTilemap;
//        }

//        public bool Build(Vector2Int start, SetPiecePattern setPiece)
//        {
//            bool setPieceTile(int col, int row)
//            {
//                Vector2Int coordinates = new(col, row);
//                char tileType = setPiece.Get(coordinates.x - start.x, coordinates.y - start.y);
//                Tile tile = LevelGenerator.Level.TileMap.Get(coordinates);
//                tile.Type = (TileType)tileType;
//                tile.FromSetPiece = true;
//                return true;
//            }
//            TileMapIterator iterator = new();
//            iterator.IterateAll(start, setPiece.Size, setPieceTile);
//            return true;
//        }
//    }
//}
