using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Tools.Factories;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tasks.Output
{
    public class OutputZandomPointOfInterest : GeneratorTask
    {
        public OutputZandomPointOfInterest(ZandomLevelGenerator zandomLevelGenerator, PointOfInterest plan) : base(zandomLevelGenerator)
        {
            Plan = plan;
        }

        public PointOfInterest Plan { get; }

        public override void RunContents()
        {
            ZandomPointOfInterestFactory factory = new(Plan.LevelPlan);
            factory.Create(Plan);
        }
    }
}
