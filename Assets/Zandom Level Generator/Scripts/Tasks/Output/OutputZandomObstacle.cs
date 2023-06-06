using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Tools.Factories;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tasks.Output
{
    public class OutputZandomObstacle : GeneratorTask
    {
        public OutputZandomObstacle(ZandomLevelGenerator zandomLevelGenerator, Obstacle plan) : base(zandomLevelGenerator)
        {
            Plan = plan;
        }

        public Obstacle Plan { get; }

        public override void RunContents()
        {
            ZandomObstacleFactory factory = new(Plan.LevelPlan);
            factory.Create(Plan);
        }
    }
}
