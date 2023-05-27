using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Helpers;

namespace ZandomLevelGenerator.BaseObjects
{
    public class TileMap
    {
        public TileMap()
        {
            Tiles = new();
        }

        private Dictionary<Vector2Int, Tile> Tiles { get; }

        public bool IsAvailable(Vector2Int start, Vector2Int size)
        {
            bool checkCoordinates(int col, int row)
            {
                Vector2Int coordinates = new(col, row);
                return !Has(coordinates);
            }
            TileMapIterator iterator = new();
            return iterator.IterateAll(start, size, checkCoordinates);
        }

        public bool Has(Vector2Int coordinates)
        {
            return Tiles.TryGetValue(coordinates, out _);
        }

        public Tile Get(Vector2Int coordinates)
        {
            Tiles.TryGetValue(coordinates, out Tile tile);
            return tile;
        }

        public Tile Create(Vector2Int coordinates)
        {
            Tile tile = new(coordinates);
            Add(tile);
            return tile;
        }

        public void Add(Tile tile)
        {
            Tiles.Add(tile.Coordinates, tile);
        }

        //public void Iterate(Func<Tile, bool> changeTileType)
        //{
        //    foreach (var item in Tiles.Values)
        //    {
        //        changeTileType(item);
        //    }
        //}
    }
}
