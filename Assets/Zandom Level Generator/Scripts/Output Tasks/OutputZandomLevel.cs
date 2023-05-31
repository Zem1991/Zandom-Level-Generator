using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.OutputTasks
{
    public class OutputZandomLevel : GeneratorTask
    {
        public OutputZandomLevel(ZandomLevelGenerator zandomLevelGenerator, LevelPlan plan) : base(zandomLevelGenerator)
        {
            Plan = plan;
        }

        public LevelPlan Plan { get; }

        public override IEnumerator Run()
        {
            foreach (var item in Plan.Tiles)
            {
                TilePlan plan = item.Value;
                yield return new OutputZandomTile(ZandomLevelGenerator, plan).Run();
            }
            foreach (var item in Plan.Sectors)
            {
                SectorPlan plan = item.Value;
                yield return new OutputZandomSector(ZandomLevelGenerator, plan).Run();
            }
            foreach (var item in Plan.Obstacles)
            {
                //TODO:
            }
            foreach (var item in Plan.PointsOfInterest)
            {
                //TODO:
            }
        }
    }
}
