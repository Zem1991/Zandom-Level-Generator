using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public ZandomParameters ZandomParameters;
    public ZandomTileset ZandomTileset;
    public LevelGeneratorStyle LevelGeneratorStyle;

    public Level Level { get; private set; }
    public FinalLevel FinalLevel { get; private set; }

    public void ClearLevel()
    {
        Level = new();
    }
    
    private void Awake()
    {
        ClearLevel();
        FinalLevel = GetComponent<FinalLevel>();
    }
    
    private void Start()
    {
        LevelGeneratorStyle.Run(this);
    }

    private void OnDrawGizmos()
    {
        new LevelGeneratorGizmos(this).OnDrawGizmos();
    }
}
