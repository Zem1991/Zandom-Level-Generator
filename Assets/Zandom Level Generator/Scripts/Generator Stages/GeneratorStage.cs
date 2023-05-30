using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.GeneratorStages
{
    public abstract class GeneratorStage
    {
        public GeneratorStage(ZandomLevelGenerator zandomLevelGenerator)
        {
            ZandomLevelGenerator = zandomLevelGenerator;
        }

        public ZandomLevelGenerator ZandomLevelGenerator { get; }
        public bool TasksStarted { get; private set; }
        public bool TasksFinished { get; private set; }
        public abstract StageName Name { get; }

        public IEnumerator RunTasks()
        {
            TasksStarted = true;
            List<GeneratorTask> tasks = GetTasks();
            foreach (var item in tasks)
            {
                yield return item.Run();
            }
            TasksFinished = true;
        }

        public bool RunChecks(out string message)
        {
            return GetChecks(out message);
        }

        public abstract GeneratorStage NextIfFailure();
        public abstract GeneratorStage NextIfSuccess();
        protected abstract List<GeneratorTask> GetTasks();
        protected abstract bool GetChecks(out string message);
    }
}
