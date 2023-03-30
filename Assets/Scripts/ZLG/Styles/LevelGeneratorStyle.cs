using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public abstract class LevelGeneratorStyle : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject roomBorderTile;
    public GameObject roomCornerTile;
    public GameObject floorTile;
    public GameObject specialFloorTile;
    public GameObject wallTile;
    public GameObject destructibleWallTile;
    public GameObject barsTile;
    public GameObject doorTile;

    [Header("Settings")]
    public int minimumArea = 2000;
    
    protected LevelGenerator LevelGenerator { get; private set; }

    public GameObject GetModel(char tileType)
    {
        GameObject result = null;
        switch (tileType)
        {
            case TileTypes.ROOM_BORDER:
                result = roomBorderTile;
                break;
            case TileTypes.ROOM_CORNER:
                result = roomCornerTile;
                break;
            case TileTypes.FLOOR:
                result = floorTile;
                break;
            case TileTypes.SPECIAL_FLOOR:
                result = specialFloorTile;
                break;
            case TileTypes.WALL:
                result = wallTile;
                break;
            case TileTypes.DESTRUCTIBLE_WALL:
                result = destructibleWallTile;
                break;
            case TileTypes.BARS:
                result = barsTile;
                break;
            case TileTypes.DOOR:
                result = doorTile;
                break;
        }
        return result;
    }

    public void Run(LevelGenerator levelGenerator)
    {
        LevelGenerator = levelGenerator;
        int attempts = 0;
        while (true)
        {
            Clear();
            attempts++;
            if (attempts > 20)
            {
                Debug.LogWarning($"Too many attempts!");
                break;
            }
            Debug.Log($"Starting attempt #{attempts} at generating the next level.");
            if (!Step01_PreDungeon()) continue;
            if (!Step02_Dungeon()) continue;
            if (!Step03_PostDungeon()) continue;
            break;
        }
        Debug.Log($"Level generation finished.");
    }
    
    private void Clear()
    {
        LevelGenerator.ClearLevel();
    }
    
    private bool Step01_PreDungeon()
    {
        string step = "Step 01 Pre-Dungeon";
        bool result = Step01_PreDungeon_Execution(out string message);
        if (result) DebugMessageSuccess(step, message);
        else DebugMessageFailure(step, message);
        return result;
    }

    private bool Step02_Dungeon()
    {
        string step = "Step 02 Dungeon";
        bool result = Step02_Dungeon_Execution(out string message);
        if (result) DebugMessageSuccess(step, message);
        else DebugMessageFailure(step, message);
        return result;
    }

    private bool Step03_PostDungeon()
    {
        string step = "Step 03 Post-Dungeon";
        bool result = Step03_PostDungeon_Execution(out string message);
        if (result) DebugMessageSuccess(step, message);
        else DebugMessageFailure(step, message);
        return result;
    }

    private void DebugMessageSuccess(string step, string message)
    {
        Debug.Log($"Success at {step} with message: {message}");
    }

    private void DebugMessageFailure(string step, string message)
    {
        Debug.Log($"Failure at {step} with message: {message}");
    }

    //Walkable areas
    protected abstract bool Step01_PreDungeon_Execution(out string message);
    //Object placement
    protected abstract bool Step02_Dungeon_Execution(out string message);
    //Actual tiles
    protected abstract bool Step03_PostDungeon_Execution(out string message);
}
