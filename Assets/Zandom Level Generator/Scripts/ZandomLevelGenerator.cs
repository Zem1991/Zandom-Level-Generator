using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Gizmos;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator
{
    public class ZandomLevelGenerator : MonoBehaviour
    {
        [Header("References: Result")]
        private readonly LevelResult levelResult;

        [Header("References: Parameters")]
        private readonly GeneratorStyle zandomStyle;
        private readonly StyleParameters zandomParameters;
        private readonly TileSet zandomTileset;
        private readonly SetPieceDataList zandomSetPieceList;
        private readonly ObstacleDataList zandomObstacleList;

        [Header("Settings")]
        private readonly string seed = null;
        [Min(1)] private readonly int maxAttempts = 10;
        private readonly WaitType waitType;

        [Header("Runtime")]
        [SerializeField] private bool isRunning;
        [SerializeField] private GeneratorCoroutine generatorCoroutine;
        [SerializeField] private DateTime startTime;
        [SerializeField] private DateTime endTime;
        [SerializeField] private float timeTaken;

        public LevelResult LevelResult => levelResult;

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

        public bool TryGenerate()
        {
            bool can = !IsRunning;
            if (can) GenerateStart();
            return can;
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