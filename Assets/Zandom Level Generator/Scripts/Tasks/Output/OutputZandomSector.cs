using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Tools.Factories;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tasks.Output
{
    public class OutputZandomSector : GeneratorTask
    {
        public OutputZandomSector(ZandomLevelGenerator zandomLevelGenerator, SectorPlan plan) : base(zandomLevelGenerator)
        {
            Plan = plan;
        }

        public SectorPlan Plan { get; }

        public override void RunContents()
        {
            ZandomSectorFactory factory = new(ZandomLevelGenerator.ZandomParameters, Plan.Level);
            factory.Create(Plan);
        }
    }
}
