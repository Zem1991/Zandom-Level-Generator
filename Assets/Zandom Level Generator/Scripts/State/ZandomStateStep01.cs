using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Task;

namespace ZandomLevelGenerator.State
{
    public class ZandomStateStep01 : ZandomState
    {
        public ZandomStateStep01(LevelGenerator levelGenerator) : base(levelGenerator)
        {
        }

        public override ZandomStateName Name => ZandomStateName.STEP01;

        public override ZandomState NextIfFailure()
        {
            return new ZandomStateStep01(LevelGenerator);
        }

        public override ZandomState NextIfSuccess()
        {
            return new ZandomStateStep02(LevelGenerator);
        }

        protected override List<LevelGeneratorTask> GetTasks()
        {
            return LevelGenerator.ZandomStyle.Step01_Tasks(LevelGenerator);
        }

        protected override bool GetChecks(out string message)
        {
            return LevelGenerator.ZandomStyle.Step01_Checks(LevelGenerator, out message);
        }
    }
}
