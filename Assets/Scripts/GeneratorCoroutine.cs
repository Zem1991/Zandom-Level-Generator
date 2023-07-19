using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.GeneratorStages;
using ZandomLevelGenerator.Tasks.Output;
using ZemReusables;

namespace ZandomLevelGenerator
{
    [Serializable]
    public class GeneratorCoroutine
    {
        [Header("RNG")]
        [SerializeField] private string currentSeed;
        [SerializeField] private int currentSeedInt;
        [SerializeField] private SeededRandom seededRandom;

        [Header("Zandom")]
        [SerializeField] private int attempts;
        [SerializeField] private LevelPlan level;
        [SerializeField] private GeneratorStage stage;

        public GeneratorCoroutine(ZandomLevelGenerator zandomLevelGenerator)
        {
            ZandomLevelGenerator = zandomLevelGenerator;
        }

        public ZandomLevelGenerator ZandomLevelGenerator { get; }
        public Action OnFinish { get; set; }

        public string CurrentSeed { get => currentSeed; private set => currentSeed = value; }
        public int CurrentSeedInt { get => currentSeedInt; private set => currentSeedInt = value; }
        public SeededRandom SeededRandom { get => seededRandom; private set => seededRandom = value; }

        public int Attempts { get => attempts; private set => attempts = value; }
        public LevelPlan Level { get => level; private set => level = value; }
        public GeneratorStage Stage { get => stage; private set => stage = value; }

        public IEnumerator Run()
        {
            StartLoop();
            yield return null;
            while (Stage != null)
            {
                yield return RunLoop();
            }
            EndLoop();
        }

        private void StartLoop()
        {
            SeededRandom = new(ZandomLevelGenerator.Seed);
            CurrentSeed = SeededRandom.Seed;
            CurrentSeedInt = SeededRandom.SeedInt;
            Attempts = 0;
            Stage = new Stage01Plan(ZandomLevelGenerator);
            NewAttempt();
        }

        private IEnumerator RunLoop()
        {
            if (!Stage.TasksStarted)
            {
                yield return Stage.RunTasks();
            }
            if (Stage.TasksFinished)
            {
                yield return HandleWait();
                yield return HandleStageFinished();
            }
        }

        private void EndLoop()
        {
            Debug.Log($"Level generation finished.");
            OnFinish?.Invoke();
        }

        private void NewAttempt()
        {
            Attempts++;
            Level = new(ZandomLevelGenerator.ZandomAsciiTable);
            ZandomLevelGenerator.RegisterNewAttempt(Level);
            if (Attempts > ZandomLevelGenerator.MaxAttempts)
            {
                Debug.LogError($"Too many attempts!");
                Stage = null;
            }
            else
            {
                Debug.Log($"Starting attempt #{Attempts} at generating the next level.");
            }
        }

        private IEnumerator HandleWait()
        {
            bool waitZandom = ZandomLevelGenerator.WaitType == WaitType.ZANDOM && Stage.Name == StageName.STEP04_RESULT;
            bool waitStage = ZandomLevelGenerator.WaitType == WaitType.STAGE;
            //bool waitFailSafe = ZandomLevelGenerator.WaitType == WaitType.ITERATION;
            //bool addWait = waitZandom || waitStage || waitFailSafe;
            bool addWait = waitZandom || waitStage;
            if (addWait)
            {
                GeneratorTask task = new OutputZandomLevel(ZandomLevelGenerator, Level);
                yield return task.Run();
            }
        }

        private IEnumerator HandleStageFinished()
        {
            bool stateResult = Stage.RunChecks(out string message);
            if (string.IsNullOrEmpty(message))
            {
                message = "--";
            }
            if (stateResult)
            {
                DebugMessageSuccess(message);
                Stage = Stage.NextIfSuccess();
                if (Stage != null) Debug.Log($"Entering state {Stage.Name}");
            }
            else
            {
                DebugMessageFailure(message);
                Stage = Stage.NextIfFailure();
                NewAttempt();
            }
            yield return null;
        }

        private void DebugMessageSuccess(string message)
        {
            Debug.Log($"Success at state {Stage.Name} with message: {message}");
        }

        private void DebugMessageFailure(string message)
        {
            Debug.Log($"Failure at state {Stage.Name} with message: {message}");
        }
    }
}
