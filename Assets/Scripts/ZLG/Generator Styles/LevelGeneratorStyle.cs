using System.Collections;
using System.Collections.Generic;
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
    
    //protected LevelGeneratorStyle(LevelGenerator levelGenerator)
    //{
    //    LevelGenerator = levelGenerator;
    //}
    
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
        Step01_PreDungeon();
        Step02_Dungeon();
        Step03_PostDungeon();
    }

    //Walkable areas
    protected abstract void Step01_PreDungeon();
    //Object placement
    protected abstract void Step02_Dungeon();
    //Actual tiles
    protected abstract void Step03_PostDungeon();
}
