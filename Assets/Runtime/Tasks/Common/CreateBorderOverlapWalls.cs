using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Factories;

namespace ZandomLevelGenerator.Tasks.Common
{
    public class CreateBorderOverlapWalls : GeneratorTask
    {
        public CreateBorderOverlapWalls(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        private Dictionary<(int, int), HashSet<Vector3Int>> Overlaps { get; set; }

        public override void RunContents()
        {
            Overlaps = new();
            FindAll();
            Create();
        }

        private void FindAll()
        {
            foreach (var item in ZandomLevelGenerator.GeneratorCoroutine.Level.Tiles)
            {
                TilePlan tile = item.Value;
                if (tile == null) continue;
                if (tile.Type != TileType.BORDER) continue;
                if (tile.SectorsIds.Count <= 1) continue;
                int sourceRoom = tile.SectorsIds.ElementAt(0);
                int neighborRoom = tile.SectorsIds.ElementAt(1);
                //if (sourceRoom.FromSetPiece && neighborRoom.FromSetPiece) continue;
                (int, int) rooms = (sourceRoom, neighborRoom);
                bool hasList = Overlaps.TryGetValue(rooms, out HashSet<Vector3Int> tiles);
                if (!hasList)
                {
                    tiles = new();
                    Overlaps.Add(rooms, tiles);
                }
                tiles.Add(tile.Coordinates);
            }
        }

        private void Create()
        {
            BorderOverlapWallFactory factory = new(ZandomLevelGenerator.GeneratorCoroutine.Level);
            foreach (var item in Overlaps)
            {
                int id = factory.NextId();
                factory.Create(id, item.Key.Item1, item.Key.Item2, item.Value);
            }
        }
    }
}
