//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ZandomStateBegin : ZandomState
//{
//    public ZandomStateBegin(LevelGenerator levelGenerator) : base(levelGenerator)
//    {
//    }

//    public override ZandomStateName Name => ZandomStateName.BEGIN;

//    public override ZandomState NextIfFailure()
//    {
//        return null;
//    }

//    public override ZandomState NextIfSuccess()
//    {
//        return new ZandomStateStep01(LevelGenerator);
//    }

//    protected override List<LevelGeneratorTask> GetTasks()
//    {
//        throw new System.NotImplementedException();
//    }

//    protected override bool GetChecks(out string message)
//    {
//        throw new System.NotImplementedException();
//    }
//}
