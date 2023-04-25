using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    public ZandomStyle ZandomStyle;
    public ZandomParameters ZandomParameters;
    public ZandomTileset ZandomTileset;
    public ZandomObjects ZandomObjects;

    [Header("Settings")]
    public bool waitTasks = true;
    public bool waitSubtasks = true;
    [Min(0F)] public float waitTime = 0.5F;
    [Min(1)] public int maxAttempts = 20;

    [Header("Runtime")]
    [SerializeField] private int attempts;
    [SerializeField] private ZandomState state;
    [SerializeField] private ZandomStateName stateName = ZandomStateName.NONE;

    public Level Level { get; private set; }
    public FinalLevel FinalLevel { get; private set; }

    public void Clear()
    {
        Level = new();
        //TODO: remove child gameobjects generated before
    }

    public void Run()
    {
        //ZandomStyle.Run(this);
        //state = new ZandomStateBegin(this);
        attempts = 0;
        state = new ZandomStateStep01(this);
        stateName = state.Name;
        NewAttempt();
    }

    private void NewAttempt()
    {
        attempts++;
        if (attempts > maxAttempts)
        {
            Debug.LogWarning($"Too many attempts!");
            state = null;
            stateName = ZandomStateName.NONE;
        }
        else
        {
            Debug.Log($"Starting attempt #{attempts} at generating the next level.");
        }
        Clear();
    }

    private void DebugMessageSuccess(string message)
    {
        Debug.Log($"Success at {state} with message: {message}");
    }

    private void DebugMessageFailure(string message)
    {
        Debug.Log($"Failure at {state} with message: {message}");
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
        if (state == null) return;
        if (!state.TasksStarted)
        {
            StartCoroutine(state.RunTasks());
        }
        if (state.TasksFinished)
        {
            bool stateResult = state.RunChecks(out string message);
            if (stateResult)
            {
                state = state.NextIfSuccess();
                DebugMessageSuccess(message);
                if (state == null) Debug.Log($"Level generation finished.");
            }
            else
            {
                state = state.NextIfFailure();
                DebugMessageFailure(message);
                NewAttempt();
            }
        }
    }

    private void OnDrawGizmos()
    {
        new LevelGeneratorGizmos(this).OnDrawGizmos();
    }
}
