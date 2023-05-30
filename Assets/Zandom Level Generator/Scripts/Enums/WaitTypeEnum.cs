using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Enums
{
    public enum WaitType
    {
        /// <summary>
        /// Only the Zandom coroutine will be waited for, and all results will be provided at once.
        /// </summary>
        ZANDOM_ONLY,
        /// <summary>
        /// Every generator stage will be waited for. All stage results will be provided after all stage tasks are performed.
        /// </summary>
        STAGE,
        /// <summary>
        /// Every generator task will be waited for, and their results will be provided after iterating over their sectors.
        /// </summary>
        TASK,
        /// <summary>
        /// Every sector mentioned in a task will be waited for, and their results will be provided individually.
        /// </summary>
        SECTOR,
    }
}
