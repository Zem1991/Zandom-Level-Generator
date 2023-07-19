using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.GeneratorStages
{
    public class Stage03Decorate : GeneratorStage
    {
        public Stage03Decorate(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public override StageName Name => StageName.STEP03_DECORATE;

        public override GeneratorStage NextIfFailure()
        {
            return new Stage01Plan(ZandomLevelGenerator);
        }

        public override GeneratorStage NextIfSuccess()
        {
            return new Stage04Result(ZandomLevelGenerator);
        }

        protected override List<GeneratorTask> GetTasks()
        {
            return ZandomLevelGenerator.ZandomStyle.Step03_Tasks(ZandomLevelGenerator);
        }

        protected override bool GetChecks(out string message)
        {
            return ZandomLevelGenerator.ZandomStyle.Step03_Checks(ZandomLevelGenerator, out message);
        }
    }
}
