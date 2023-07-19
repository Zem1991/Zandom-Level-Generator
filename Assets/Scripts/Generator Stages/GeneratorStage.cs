using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Output;

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
                yield return HandleWait();
            }
            TasksFinished = true;
        }

        public bool RunChecks(out string message)
        {
            return GetChecks(out message);
        }

        private IEnumerator HandleWait()
        {
            bool waitTask = ZandomLevelGenerator.WaitType == WaitType.TASK;
            if (waitTask)
            {
                LevelPlan levelPlan = ZandomLevelGenerator.GeneratorCoroutine.Level;
                GeneratorTask task = new OutputZandomLevel(ZandomLevelGenerator, levelPlan);
                yield return task.Run();
            }
        }

        public abstract GeneratorStage NextIfFailure();
        public abstract GeneratorStage NextIfSuccess();
        protected abstract List<GeneratorTask> GetTasks();
        protected abstract bool GetChecks(out string message);
    }
}
