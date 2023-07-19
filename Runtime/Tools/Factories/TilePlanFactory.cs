using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Checkers;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class TilePlanFactory
    {
        public TilePlanFactory(StyleParameters styleParameters, LevelPlan levelPlan)
        {
            StyleParameters = styleParameters;
            LevelPlan = levelPlan;
        }

        public StyleParameters StyleParameters { get; }
        public LevelPlan LevelPlan { get; }

        public bool CanCreate(Vector3Int coordinates)
        {
            bool outsideBounds = new LevelBoundsChecker(StyleParameters).IsOutsideBounds(coordinates);
            return !outsideBounds;
        }

        public bool TryCreate(Vector3Int coordinates, out TilePlan newObject)
        {
            newObject = null;
            bool can = CanCreate(coordinates);
            if (!can) return false;
            newObject = Create(coordinates);
            return true;
        }

        public bool TryCreate(IEnumerable<Vector3Int> coordinates, out Dictionary<Vector3Int, TilePlan> newObjects)
        {
            newObjects = new();
            foreach (var item in coordinates)
            {
                bool can = CanCreate(item);
                if (!can) return false;
            }
            newObjects = Create(coordinates);
            return true;
        }

        private TilePlan Create(Vector3Int coordinates)
        {
            bool exists = LevelPlan.Tiles.TryGetValue(coordinates, out TilePlan result);
            if (!exists)
            {
                result = new(LevelPlan, coordinates);
                LevelPlan.Tiles.Add(coordinates, result);
            }
            return result;
        }

        private Dictionary<Vector3Int, TilePlan> Create(IEnumerable<Vector3Int> coordinates)
        {
            Dictionary<Vector3Int, TilePlan> result = new();
            foreach (Vector3Int coord in coordinates)
            {
                TilePlan tile = Create(coord);
                result.Add(coord, tile);
            }
            return result;
        }
    }
}
