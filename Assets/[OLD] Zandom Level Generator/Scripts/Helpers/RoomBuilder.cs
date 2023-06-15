//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using ZandomLevelGenerator.BaseObjects;
//using ZandomLevelGenerator.Enums;

//namespace ZandomLevelGenerator.Helpers
//{
//    public class RoomBuilder
//    {
//        public ZandomLevelGenerator ZandomLevelGenerator { get; }

//        public RoomBuilder(ZandomLevelGenerator levelGenerator)
//        {
//            ZandomLevelGenerator = levelGenerator;
//        }

//        public bool CanBuild(Vector2Int start, Vector2Int size)
//        {
//            bool insideLevelBounds = ZandomLevelGenerator.Level.IsInsideBounds(start, size);
//            bool availableOnTilemap = ZandomLevelGenerator.Level.TileMap.IsAvailable(start, size);
//            return insideLevelBounds && availableOnTilemap;
//        }

//        public Room Build(Vector2Int start, Vector2Int size, bool vertical, Room parent)
//        {
//            Room room = ZandomLevelGenerator.Level.CreateRoom(start, size, vertical, parent);
//            bool areaTile(int col, int row)
//            {
//                Vector2Int coordinates = new(col, row);
//                Tile tile = ZandomLevelGenerator.Level.TileMap.Create(coordinates);
//                //room.TileMap.Add(tile);
//                room.Tiles.Add(tile);
//                tile.MentionedRooms.Add(room);
//                tile.Type = TileType.ROOM_AREA;
//                return true;
//            }
//            TileMapIterator iterator = new();
//            iterator.IterateAll(start, size, areaTile);
//            return room;
//        }

//        public Room Build(Vector2Int start, SetPiecePattern setPiece, bool vertical, Room parent)
//        {
//            Room room = Build(start, setPiece.Size, vertical, parent);
//            room.FromSetPiece = true;
//            return room;
//        }
//    }
//}
