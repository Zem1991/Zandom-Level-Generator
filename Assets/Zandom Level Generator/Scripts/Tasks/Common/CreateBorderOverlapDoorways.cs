using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Factories;
using static UnityEditor.Progress;

namespace ZandomLevelGenerator.Tasks.Common
{
    public class CreateBorderOverlapDoorways : GeneratorTask
    {
        public CreateBorderOverlapDoorways(ZandomLevelGenerator zandomLevelGenerator, CreateBorderOverlapDoorwaysParameters parameters) : base(zandomLevelGenerator)
        {
            Parameters = parameters;
        }

        public CreateBorderOverlapDoorwaysParameters Parameters { get; }

        public override void RunContents()
        {
            LevelPlan level = ZandomLevelGenerator.GeneratorCoroutine.Level;
            BorderOverlapDoorwayFactory factory = new(level);
            List<BorderOverlapWall> walls = Parameters.WallListFunction(ZandomLevelGenerator);
            foreach (var item in walls)
            {
                int length = Parameters.DoorwayLengthFunction(ZandomLevelGenerator, item);
                Vector3Int position = Parameters.DoorwayPositionFunction(ZandomLevelGenerator, item, length);
                HashSet<Vector3Int> doorwayTilesIds = GetDoorwayTilesIds(item, position, length);
                int id = factory.NextId();
                factory.Create(id, item.Id, doorwayTilesIds);
            }
        }

        private HashSet<Vector3Int> GetDoorwayTilesIds(BorderOverlapWall wall, Vector3Int start, int length)
        {
            List<Vector3Int> coordinates = new(wall.TilesIds);
            int startIndex = coordinates.IndexOf(start);
            HashSet<Vector3Int> result = new();
            for (int i = 0; i < length; i++)
            {
                Vector3Int coord = coordinates[startIndex + i];
                result.Add(coord);
            }
            return result;
        }
    }
}
