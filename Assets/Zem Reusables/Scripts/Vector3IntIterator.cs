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

        public bool Iterate(Vector3Int start, Vector3Int size,
            Func<int, int, int, bool> function)
        {
            return Iterate(start, size, function, function, function);
        }

        public bool Iterate(Vector3Int start, Vector3Int size,
            Func<int, int, int, bool> areaFunction, 
            Func<int, int, int, bool> borderFunction, 
            Func<int, int, int, bool> cornerFunction)
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
                        bool borderX = col == minX || col == maxX - 1;
                        bool borderZ = row == minZ || row == maxZ - 1;
                        //TODO: Not using this one because I'm not doing fancy 3D maps (yet?)
                        //bool borderY = floor == minY || floor == maxY - 1;
                        bool atCorner = borderX && borderZ;// && borderY;
                        bool atBorder = borderX || borderZ;// || borderY;
                        Func<int, int, int, bool> function;
                        if (atCorner) function = cornerFunction;
                        else if (atBorder) function = borderFunction;
                        else function = areaFunction;
                        bool success = function(col, floor, row);
                        if (!success && StopAllWhenFalse) return false;
                    }
                }
            }
            return true;
        }
    }
}
