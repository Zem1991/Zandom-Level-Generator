using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBuddingRooms : AxisBuddingRooms
{
    public VerticalBuddingRooms(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public List<Room> Run(Vector2Int size, Room parent)
    {
        Vector2Int referencePosition = parent.Start;
        Vector2Int referenceSize = parent.Size;
        //int centeredX = referencePosition.x + (referenceSize.x / 2) - (size.x / 2);
        int roomX = referenceSize.x - size.x;
        //roomX /= 2;
        roomX = Random.Range(0, roomX);
        //roomX *= 2;
        int randomX = referencePosition.x + roomX;
        int minZ = referencePosition.y - size.y;
        int maxZ = referencePosition.y + referenceSize.y;
        minZ--;
        maxZ++;
        Vector2Int position1 = new(randomX, minZ);
        Vector2Int position2 = new(randomX, maxZ);
        return Run(position1, position2, size, true, parent);
    }
}
