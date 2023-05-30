using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.GeneratorStages
{
    public class Stage04Result : GeneratorStage
    {
        public Stage04Result(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public override StageName Name => StageName.STEP04_RESULT;

        public override GeneratorStage NextIfFailure()
        {
            throw new System.NotImplementedException();
        }

        public override GeneratorStage NextIfSuccess()
        {
            throw new System.NotImplementedException();
        }

        protected override bool GetChecks(out string message)
        {
            throw new System.NotImplementedException();
        }

        protected override List<GeneratorTask> GetTasks()
        {
            throw new System.NotImplementedException();
        }
    }
}
