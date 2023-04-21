using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public ZandomStyle ZandomStyle;
    public ZandomParameters ZandomParameters;
    public ZandomTileset ZandomTileset;
    public ZandomObjects ZandomObjects;

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
        ZandomStyle.Run(this);
    }

    private void OnDrawGizmos()
    {
        new LevelGeneratorGizmos(this).OnDrawGizmos();
    }
}
