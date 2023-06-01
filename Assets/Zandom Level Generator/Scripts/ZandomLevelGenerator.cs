using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Gizmos;
using ZandomLevelGenerator.ResultObjects;
using ZandomLevelGenerator.Tools.Factories;

namespace ZandomLevelGenerator
{
    public class ZandomLevelGenerator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GeneratorStyle zandomStyle;
        [SerializeField] private StyleParameters zandomParameters;
        [SerializeField] private TileSet zandomTileset;
        [SerializeField] private SetPieceDataList zandomSetPieceList;
        [SerializeField] private ObstacleDataList zandomObstacleList;

        [Header("Settings")]
        [SerializeField] private string seed = null;
        [SerializeField][Min(1)] private int maxAttempts = 10;
        [SerializeField] private WaitType waitType;

        [Header("Runtime")]
        [SerializeField] private bool isRunning;
        [SerializeField] private GeneratorCoroutine generatorCoroutine;
        [SerializeField] private DateTime startTime;
        [SerializeField] private DateTime endTime;
        [SerializeField] private float timeTaken;
        [SerializeField] private ZandomLevel result;

        public GeneratorStyle ZandomStyle => zandomStyle;
        public StyleParameters ZandomParameters => zandomParameters;
        public TileSet ZandomTileset => zandomTileset;
        public SetPieceDataList ZandomSetPieceList => zandomSetPieceList;
        public ObstacleDataList ZandomObstacleList => zandomObstacleList;

        public string Seed => seed;
        public int MaxAttempts => maxAttempts;
        public WaitType WaitType => waitType;

        public bool IsRunning { get => isRunning; private set => isRunning = value; }
        public GeneratorCoroutine GeneratorCoroutine { get => generatorCoroutine; private set => generatorCoroutine = value; }
        public DateTime StartTime { get => startTime; private set => startTime = value; }
        public DateTime EndTime { get => endTime; private set => endTime = value; }
        public float TimeTaken { get => timeTaken; private set => timeTaken = value; }
        public ZandomLevel Result { get => result; private set => result = value; }

        public bool TryGenerate()
        {
            bool can = !IsRunning;
            if (can) GenerateStart();
            return can;
        }

        public void RegisterNewAttempt(LevelPlan level)
        {
            ZandomLevel zandomLevel = new ZandomLevelFactory().Create(level, transform.parent);
            Result = zandomLevel;
        }

        private void GenerateStart()
        {
            IsRunning = true;
            GeneratorCoroutine = new(this);
            GeneratorCoroutine.OnFinish += GenerateFinish;
            StartTime = DateTime.Now;
            EndTime = DateTime.MinValue;
            TimeTaken = 0F;
            IEnumerator coroutine = GeneratorCoroutine.Run();
            StartCoroutine(coroutine);
            Debug.Log($"ZandomLevelGenerator GenerateStart");
        }

        private void GenerateFinish()
        {
            IsRunning = false;
            GeneratorCoroutine.OnFinish -= GenerateFinish;
            GeneratorCoroutine = null;
            EndTime = DateTime.Now;
            TimeSpan tmElapsed = EndTime - StartTime;
            TimeTaken = (float)(tmElapsed.TotalMilliseconds / 1000F);
            Debug.Log($"ZandomLevelGenerator GenerateFinish after {TimeTaken} seconds");
        }

        private void OnDrawGizmos()
        {
            new ZandomLevelGeneratorGizmos(this).OnDrawGizmos();
        }
    }
}
