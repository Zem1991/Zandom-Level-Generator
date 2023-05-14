using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Helpers
{
    public class TileMapIterator
    {
        //public TileMapIterator(TileMap tileMap, bool canStop = true)
        public TileMapIterator(bool canStop = true)
        {
            //TileMap = tileMap;
            CanStop = canStop;
        }

        //private TileMap TileMap { get; }
        public bool CanStop { get; }

        public bool IterateAll(Vector2Int start, Vector2Int size, Func<int, int, bool> function)
        {
            return Iterate(start, size, false, function);
        }

        public bool IterateBorder(Vector2Int start, Vector2Int size, Func<int, int, bool> function)
        {
            return Iterate(start, size, true, function);
        }

        private bool Iterate(Vector2Int start, Vector2Int size, bool boundsOnly, Func<int, int, bool> function)
        {
            int minX = start.x;
            int minY = start.y;
            int maxX = start.x + size.x;
            int maxY = start.y + size.y;
            for (int row = minY; row < maxY; row++)
            {
                for (int col = minX; col < maxX; col++)
                {
                    if (boundsOnly)
                    {
                        bool notX = col != minX && col != maxX - 1;
                        bool notY = row != minY && row != maxY - 1;
                        if (notX && notY) continue;
                    }
                    bool success = function(col, row);
                    if (!success && CanStop) return false;
                }
            }
            return true;
        }
    }
}
