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
            Debug.Log($"Finished task {this}");
            if (ZandomLevelGenerator.WaitType == WaitType.TASK)
            {
                //TODO: is this extra yielding regardless of wait type?
                yield return null;
            }
        }

        public abstract void RunContents();
    }
}
