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
            return null;
        }

        public override GeneratorStage NextIfSuccess()
        {
            return null;
        }

        protected override List<GeneratorTask> GetTasks()
        {
            List<GeneratorTask> result = new();
            bool addTask = ZandomLevelGenerator.WaitType == WaitType.ZANDOM_ONLY;
            if (addTask)
            {
                //GeneratorTask task = ...
                //result.Add(task);
            }
            return result;
        }

        protected override bool GetChecks(out string message)
        {
            message = null;
            return true;
        }
    }
}
