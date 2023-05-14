using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Task;

namespace ZandomLevelGenerator.State
{
    public class ZandomStateStep02 : ZandomState
    {
        public ZandomStateStep02(LevelGenerator levelGenerator) : base(levelGenerator)
        {
        }

        public override ZandomStateName Name => ZandomStateName.STEP02;

        public override ZandomState NextIfFailure()
        {
            return new ZandomStateStep01(LevelGenerator);
        }

        public override ZandomState NextIfSuccess()
        {
            return new ZandomStateStep03(LevelGenerator);
        }

        protected override List<LevelGeneratorTask> GetTasks()
        {
            return LevelGenerator.ZandomStyle.Step02_Tasks(LevelGenerator);
        }

        protected override bool GetChecks(out string message)
        {
            return LevelGenerator.ZandomStyle.Step02_Checks(LevelGenerator, out message);
        }
    }
}
