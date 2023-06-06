using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.Customizables
{
    public abstract class GeneratorTask
    {
        public GeneratorTask(ZandomLevelGenerator zandomLevelGenerator)
        {
            ZandomLevelGenerator = zandomLevelGenerator;
        }

        public ZandomLevelGenerator ZandomLevelGenerator { get; }

        /// <summary>
        /// If some sync weirdness happens then revert back to having only one Run method (instead of Run and RunContents).
        /// </summary>
        /// <returns></returns>
        public IEnumerator Run()
        {
            RunContents();
            if (ZandomLevelGenerator.WaitType == WaitType.TASK)
            {
                yield return null;
            }
            Debug.Log($"Finished task {this}");
        }

        public abstract void RunContents();
    }
}
