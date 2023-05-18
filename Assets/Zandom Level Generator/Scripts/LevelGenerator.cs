using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Components;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.FinalObjects;
using ZandomLevelGenerator.Gizmos;
using ZandomLevelGenerator.State;

namespace ZandomLevelGenerator
{
    public class LevelGenerator : MonoBehaviour
    {
        [Header("References")]
        public ZandomStyle ZandomStyle;
        public ZandomTileset ZandomTileset;
        public ZandomParameters ZandomParameters;
        public ZandomSetPieceList ZandomSetPieceList;
        public ZandomObstacleList ZandomObstacleList;

        [Header("Settings: Generator")]
        [Min(1)] public int maxAttempts = 20;

        [Header("Settings: Task Waiting")]
        public TaskWaitSettings taskWaitSetting;
        //[Min(0F)] public int taskWaitingTier = 0;

        [Header("Runtime")]
        [SerializeField] private int attempts;
        [SerializeField] private ZandomState state;
        [SerializeField] private ZandomStateName stateName = ZandomStateName.NONE;

        public Level Level { get; private set; }
        public FinalLevel FinalLevel { get; private set; }

        public ZandomState State
        {
            get => state;
            private set
            {
                state = value;
                StateName = State != null ? State.Name : ZandomStateName.NONE;
            }
        }
        public ZandomStateName StateName { get => stateName; private set => stateName = value; }

        public void Clear()
        {
            Level = new();
            FinalLevel.Clear();
        }

        public void Run()
        {
            //ZandomStyle.Run(this);
            //state = new ZandomStateBegin(this);
            attempts = 0;
            State = new ZandomStateStep01(this);
            NewAttempt();
        }

        private void NewAttempt()
        {
            Clear();
            attempts++;
            if (attempts > maxAttempts)
            {
                Debug.LogWarning($"Too many attempts!");
                State = null;
            }
            else
            {
                Debug.Log($"Starting attempt #{attempts} at generating the next level.");
            }
        }

        private void DebugMessageSuccess(string message)
        {
            Debug.Log($"Success at state {StateName} with message: {message}");
        }

        private void DebugMessageFailure(string message)
        {
            Debug.Log($"Failure at state {StateName} with message: {message}");
        }

        private void Awake()
        {
            FinalLevel = GetComponent<FinalLevel>();
        }

        private void Start()
        {
            Run();
        }

        private void Update()
        {
            if (State == null) return;
            if (!State.TasksStarted)
            {
                StartCoroutine(State.RunTasks());
            }
            if (State.TasksFinished)
            {
                bool stateResult = State.RunChecks(out string message);
                if (string.IsNullOrEmpty(message))
                {
                    message = "--";
                }
                if (stateResult)
                {
                    DebugMessageSuccess(message);
                    State = State.NextIfSuccess();
                    if (State == null) Debug.Log($"Level generation finished.");
                    else Debug.Log($"Entering state {StateName}...");
                }
                else
                {
                    DebugMessageFailure(message);
                    State = State.NextIfFailure();
                    NewAttempt();
                }
            }
        }

        private void OnDrawGizmos()
        {
            new LevelGeneratorGizmos(this).OnDrawGizmos();
        }
    }
}
