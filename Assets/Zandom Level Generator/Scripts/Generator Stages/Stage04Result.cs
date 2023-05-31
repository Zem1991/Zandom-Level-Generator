using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Output;

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
            bool addOutputZandomLevel = ZandomLevelGenerator.WaitType == WaitType.ZANDOM_ONLY;
            if (addOutputZandomLevel)
            {
                LevelPlan levelPlan = ZandomLevelGenerator.GeneratorCoroutine.Level;
                GeneratorTask task = new OutputZandomLevel(ZandomLevelGenerator, levelPlan);
                result.Add(task);
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
