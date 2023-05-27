using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator
{
    public class ZandomLevelGenerator : MonoBehaviour
    {
        [SerializeField] private GeneratorCoroutine generatorCoroutine;
        [SerializeField] private DateTime startTime;
        [SerializeField] private DateTime endTime;
        [SerializeField] private float timeTaken;

        public GeneratorCoroutine GeneratorCoroutine { get => generatorCoroutine; private set => generatorCoroutine = value; }
        public DateTime StartTime { get => startTime; private set => startTime = value; }
        public DateTime EndTime { get => endTime; private set => endTime = value; }
        public float TimeTaken { get => timeTaken; private set => timeTaken = value; }

        public bool IsRunning()
        {
            return GeneratorCoroutine != null;
        }

        public bool TryGenerate()
        {
            bool can = !IsRunning();
            if (can) Generate();
            return can;
        }

        private void Generate()
        {
            GeneratorCoroutine = new(this);
            GeneratorCoroutine.OnFinish += GeneratorFinish;
            StartTime = DateTime.Now;
            EndTime = DateTime.MinValue;
            TimeTaken = 0F;
            IEnumerator coroutine = GeneratorCoroutine.Run();
            StartCoroutine(coroutine);
        }

        private void GeneratorFinish()
        {
            GeneratorCoroutine.OnFinish -= GeneratorFinish;
            GeneratorCoroutine = null;
            EndTime = DateTime.Now;
            TimeSpan tmElapsed = EndTime - StartTime;
            TimeTaken = (float)(tmElapsed.TotalMilliseconds / 1000F);
        }
    }
}
