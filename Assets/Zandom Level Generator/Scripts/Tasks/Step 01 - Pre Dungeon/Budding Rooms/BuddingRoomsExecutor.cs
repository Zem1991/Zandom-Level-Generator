using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Helpers;

namespace ZandomLevelGenerator.Task
{
    public class BuddingRoomsExecutor
    {
        public BuddingRoomsExecutor(LevelGenerator levelGenerator)
        {
            LevelGenerator = levelGenerator;
        }

        protected LevelGenerator LevelGenerator { get; }

        public Room Run(Vector2Int position, Vector2Int size, bool vertical, Room parent)
        {
            RoomBuilder roomBuilder = new(LevelGenerator);
            bool canBuild = roomBuilder.CanBuild(position, size);
            Room result = null;
            if (canBuild)
            {
                result = roomBuilder.Build(position, size, vertical, parent);
                ApplyBorders applyBorders = new(LevelGenerator);
                applyBorders.Apply(result);
            }
            return result;
        }
    }
}
