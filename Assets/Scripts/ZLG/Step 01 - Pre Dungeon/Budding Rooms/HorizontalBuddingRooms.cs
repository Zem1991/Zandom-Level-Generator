using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBuddingRooms : AxisBuddingRooms
{
    public HorizontalBuddingRooms(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public List<Room> Run(Vector2Int size, Room parent)
    {
        Vector2Int referencePosition = parent.Start;
        Vector2Int referenceSize = parent.Size;
        //int centeredZ = referencePosition.y + (referenceSize.y / 2) - (size.y / 2);
        int roomY = referenceSize.y - size.y;
        int randomY = referencePosition.y + Random.Range(0, roomY);
        int minX = referencePosition.x - size.x;
        int maxX = referencePosition.x + referenceSize.x;
        minX--;
        maxX++;
        Vector2Int position1 = new(minX, randomY);
        Vector2Int position2 = new(maxX, randomY);
        return Run(position1, position2, size, parent);
    }
}
