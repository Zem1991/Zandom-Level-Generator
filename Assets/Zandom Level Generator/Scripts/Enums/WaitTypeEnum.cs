using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Enums
{
    public enum WaitType
    {
        /// <summary>
        /// Only the Zandom generator coroutine will be waited for, and all results will be provided at once.
        /// The GeneratorCoroutine itself handles the waiting, since it knows when the last stage was ran.
        /// </summary>
        ZANDOM,
        /// <summary>
        /// Every generator stage will be waited for, and their results will be provided after all of their tasks are performed.
        /// The GeneratorCoroutine itself handles the waiting, since it iterates over each stage.
        /// </summary>
        STAGE,
        /// <summary>
        /// Every generator task will be waited for, and their results will be provided after doing everything they are required to do.
        /// The GeneratorStage itself handles the waiting, since it iterates over each task.
        /// </summary>
        TASK,
        ///// <summary>
        ///// Every iteration inside a task will be waited for, and their results will be provided individually.
        ///// This one should be defined within the task classes. If you create custom tasks it's up to you to handle the waiting.
        ///// </summary>
        //ITERATION,
    }
}
