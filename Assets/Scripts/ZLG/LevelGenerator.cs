using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public LevelGeneratorStyle LevelGeneratorStyle;

    private void Awake()
    {
        Level = new();
        FinalLevel = GetComponent<FinalLevel>();
    }

    public Level Level { get; private set; }
    public FinalLevel FinalLevel { get; private set; }

    private void Start()
    {
        LevelGeneratorStyle.Run(this);
    }
}
