using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZandomState
{
    public ZandomState(LevelGenerator levelGenerator)
    {
        LevelGenerator = levelGenerator;
    }

    public LevelGenerator LevelGenerator { get; }
    public abstract ZandomStateName Name { get; }

    public bool TasksStarted { get; private set; }
    public bool TasksFinished { get; private set; }

    public IEnumerator RunTasks()
    {
        TasksStarted = true;
        List<LevelGeneratorTask> tasks = GetTasks();
        foreach (var item in tasks)
        {
            yield return item.Run();
            if (!LevelGenerator.waitTasks) continue;
            yield return new WaitForSeconds(LevelGenerator.waitTime);
        }
        TasksFinished = true;
    }

    public bool RunChecks(out string message)
    {
        return GetChecks(out message);
    }

    public abstract ZandomState NextIfFailure();
    public abstract ZandomState NextIfSuccess();
    protected abstract List<LevelGeneratorTask> GetTasks();
    protected abstract bool GetChecks(out string message);
}
