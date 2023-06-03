using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;

namespace ZandomLevelGenerator.Task
{
    public class HorizontalBuddingRooms : AxisBuddingRooms
    {
        public HorizontalBuddingRooms(LevelGenerator levelGenerator) : base(levelGenerator)
        {
        }

        public List<Room> Run(Vector2Int size, Room parent)
        {
            Vector2Int referencePosition = parent.Start;
            Vector2Int referenceSize = parent.Size;
            int roomY = referenceSize.y - size.y;
            roomY = LevelGenerator.SeededRandom.Range(0, roomY);
            int randomY = referencePosition.y + roomY;
            int minX = referencePosition.x - size.x;
            int maxX = referencePosition.x + referenceSize.x;
            minX--;
            maxX++;
            Vector2Int position1 = new(minX, randomY);
            Vector2Int position2 = new(maxX, randomY);
            return Run(position1, position2, size, false, parent);
        }
    }
}
