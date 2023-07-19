using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tasks.Output
{
    public class OutputZandomLevel : GeneratorTask
    {
        public OutputZandomLevel(ZandomLevelGenerator zandomLevelGenerator, LevelPlan plan) : base(zandomLevelGenerator)
        {
            Plan = plan;
        }

        public LevelPlan Plan { get; }

        public override void RunContents()
        {
            foreach (var item in Plan.Tiles)
            {
                TilePlan plan = item.Value;
                new OutputZandomTile(ZandomLevelGenerator, plan).RunContents();
            }
            foreach (var item in Plan.Sectors)
            {
                SectorPlan plan = item.Value;
                new OutputZandomSector(ZandomLevelGenerator, plan).RunContents();
            }
            foreach (var item in Plan.Obstacles)
            {
                Obstacle plan = item.Value;
                new OutputZandomObstacle(ZandomLevelGenerator, plan).RunContents();
            }
            foreach (var item in Plan.PointsOfInterest)
            {
                PointOfInterest plan = item.Value;
                new OutputZandomPointOfInterest(ZandomLevelGenerator, plan).RunContents();
            }
        }
    }
}
