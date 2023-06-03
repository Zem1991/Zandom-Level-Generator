using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ZandomLevelGenerator.Components;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/StyleParameters")]
    public class StyleParameters : ScriptableObject
    {
        [Header("Level Size Options")]
        [SerializeField] private Vector3Int levelSize = new(80, 80);
        [SerializeField] private Vector3Int moduleSize = new(10, 10);
        [SerializeField] private Vector3Int safetySize = new(10, 10);

        [Header("JSON Parameters")]
        [SerializeField] private TextAsset jsonParameters;

        public Vector3Int LevelSize { get => levelSize; }
        public Vector3Int ModuleSize { get => moduleSize; }
        public Vector3Int SafetySize { get => safetySize; }
        public TextAsset JsonParameters { get => jsonParameters; }

        public T GetValueFromJsonParameters<T>(string key)
        {
            string json = JsonParameters.ToString();
            Dictionary<string, string> jsonParameters = JsonUtility.FromJson<Dictionary<string, string>>(json);
            jsonParameters.TryGetValue(key, out string value);
            T result = (T)Convert.ChangeType(value, typeof(T));
            return result;
        }
    }
}
