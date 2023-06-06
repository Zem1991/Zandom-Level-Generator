using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tasks.Common
{
    public class CreateBuddingRoomsPositionPicker
    {
        public CreateBuddingRoomsPositionPicker(ZandomLevelGenerator zandomLevelGenerator)
        {
            ZandomLevelGenerator = zandomLevelGenerator;
        }

        public ZandomLevelGenerator ZandomLevelGenerator { get; }

        public Vector3Int LeftRandom(RoomPlan parent, Vector3Int size)
        {
            Vector3Int referencePosition = parent.Start;
            Vector3Int referenceSize = parent.Size;
            int roomZ = referenceSize.z - size.z;
            roomZ = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(0, roomZ);
            int randomZ = referencePosition.z + roomZ;
            int minX = referencePosition.x - size.x;
            minX--;
            Vector3Int result = new(minX, 0, randomZ);
            return result;
        }

        public Vector3Int RightRandom(RoomPlan parent, Vector3Int size)
        {
            Vector3Int referencePosition = parent.Start;
            Vector3Int referenceSize = parent.Size;
            int roomZ = referenceSize.z - size.z;
            roomZ = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(0, roomZ);
            int randomZ = referencePosition.z + roomZ;
            int maxX = referencePosition.x + referenceSize.x;
            maxX++;
            Vector3Int result = new(maxX, 0, randomZ);
            return result;
        }

        public Vector3Int BackRandom(RoomPlan parent, Vector3Int size)
        {
            Vector3Int referencePosition = parent.Start;
            Vector3Int referenceSize = parent.Size;
            int roomX = referenceSize.x - size.x;
            roomX = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(0, roomX);
            int randomX = referencePosition.x + roomX;
            int minZ = referencePosition.z - size.z;
            minZ--;
            Vector3Int result = new(randomX, 0, minZ);
            return result;
        }

        public Vector3Int FrontRandom(RoomPlan parent, Vector3Int size)
        {
            Vector3Int referencePosition = parent.Start;
            Vector3Int referenceSize = parent.Size;
            int roomX = referenceSize.x - size.x;
            roomX = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(0, roomX);
            int randomX = referencePosition.x + roomX;
            int maxZ = referencePosition.z + referenceSize.z;
            maxZ++;
            Vector3Int result = new(randomX, 0, maxZ);
            return result;
        }
    }
}
