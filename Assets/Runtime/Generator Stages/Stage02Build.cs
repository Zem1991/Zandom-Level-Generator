using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.GeneratorStages
{
    public class Stage02Build : GeneratorStage
    {
        public Stage02Build(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public override StageName Name => StageName.STEP02_BUILD;

        public override GeneratorStage NextIfFailure()
        {
            return new Stage01Plan(ZandomLevelGenerator);
        }

        public override GeneratorStage NextIfSuccess()
        {
            return new Stage03Decorate(ZandomLevelGenerator);
        }

        protected override List<GeneratorTask> GetTasks()
        {
            return ZandomLevelGenerator.ZandomStyle.Step02_Tasks(ZandomLevelGenerator);
        }

        protected override bool GetChecks(out string message)
        {
            return ZandomLevelGenerator.ZandomStyle.Step02_Checks(ZandomLevelGenerator, out message);
        }
    }
}
