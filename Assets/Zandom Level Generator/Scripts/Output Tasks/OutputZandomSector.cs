using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Factories;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.OutputTasks
{
    public class OutputZandomSector : GeneratorTask
    {
        public OutputZandomSector(ZandomLevelGenerator zandomLevelGenerator, SectorPlan plan) : base(zandomLevelGenerator)
        {
            Plan = plan;
        }

        public SectorPlan Plan { get; }

        public override IEnumerator Run()
        {
            ZandomSectorFactory factory = new(Plan.Level);
            factory.Create(Plan);
            yield return null;
        }
    }
}
