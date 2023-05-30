using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZemReusables
{
    public class Vector3IntIterator
    {
        public Vector3IntIterator(bool stopAllWhenFalse = true)
        {
            StopAllWhenFalse = stopAllWhenFalse;
        }

        public bool StopAllWhenFalse { get; }

        public bool Iterate(Vector3Int start, Vector3Int size, bool boundsOnly, Func<int, int, int, bool> function)
        {
            int minX = start.x;
            int minZ = start.z;
            int minY = start.y;
            int maxX = start.x + size.x;
            int maxZ = start.z + size.z;
            int maxY = start.y + size.y;
            for (int floor = minY; floor < maxY; floor++)
            {
                for (int row = minZ; row < maxZ; row++)
                {
                    for (int col = minX; col < maxX; col++)
                    {
                        if (boundsOnly)
                        {
                            bool notX = col != minX && col != maxX - 1;
                            bool notZ = row != minZ && row != maxZ - 1;
                            bool notY = floor != minY && floor != maxY - 1;
                            if (notX && notZ && notY) continue;
                        }
                        bool success = function(col, floor, row);
                        if (!success && StopAllWhenFalse) return false;
                    }
                }
            }
            return true;
        }
    }
}
