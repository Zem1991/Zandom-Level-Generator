using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.GeneratorStages
{
    public class Stage01Plan : GeneratorStage
    {
        public Stage01Plan(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public override StageName Name => StageName.STEP01_PLAN;

        public override GeneratorStage NextIfFailure()
        {
            return new Stage01Plan(ZandomLevelGenerator);
        }

        public override GeneratorStage NextIfSuccess()
        {
            return new Stage02Build(ZandomLevelGenerator);
        }

        protected override List<GeneratorTask> GetTasks()
        {
            return ZandomLevelGenerator.ZandomStyle.Step01_Tasks(ZandomLevelGenerator);
        }

        protected override bool GetChecks(out string message)
        {
            return ZandomLevelGenerator.ZandomStyle.Step01_Checks(ZandomLevelGenerator, out message);
        }
    }
}
