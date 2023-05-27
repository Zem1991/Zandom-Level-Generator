using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Task;

namespace ZandomLevelGenerator.State
{
    public class ZandomStateStep03 : ZandomState
    {
        public ZandomStateStep03(LevelGenerator levelGenerator) : base(levelGenerator)
        {
        }

        public override ZandomStateName Name => ZandomStateName.STEP03;

        public override ZandomState NextIfFailure()
        {
            return new ZandomStateStep01(LevelGenerator);
        }

        public override ZandomState NextIfSuccess()
        {
            return new ZandomStateEnd(LevelGenerator);
        }

        protected override List<LevelGeneratorTask> GetTasks()
        {
            return LevelGenerator.ZandomStyle.Step03_Tasks(LevelGenerator);
        }

        protected override bool GetChecks(out string message)
        {
            return LevelGenerator.ZandomStyle.Step03_Checks(LevelGenerator, out message);
        }
    }
}
