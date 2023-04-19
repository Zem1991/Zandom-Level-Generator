using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Zandom/Tileset")]
public class ZandomTileset : ScriptableObject
{
    [Header("Rooms")]
    public GameObject borderTile;
    public GameObject cornerTile;

    [Header("Walls")]
    public GameObject wallTile;
    public GameObject destructibleWallTile;
    public GameObject barsTile;
    public GameObject doorTile;

    [Header("Floors")]
    public GameObject floorTile;
    public GameObject specialFloorTile;

    public GameObject GetModel(TileType tileType)
    {
        GameObject result = null;
        switch (tileType)
        {
            case TileType.ROOM_BORDER:
                result = borderTile;
                break;
            case TileType.ROOM_CORNER:
                result = cornerTile;
                break;
            case TileType.WALL:
                result = wallTile;
                break;
            case TileType.DESTRUCTIBLE_WALL:
                result = destructibleWallTile;
                break;
            case TileType.BARS:
                result = barsTile;
                break;
            case TileType.DOOR:
                result = doorTile;
                break;
            case TileType.FLOOR:
                result = floorTile;
                break;
            case TileType.SPECIAL_FLOOR:
                result = specialFloorTile;
                break;
        }
        return result;
    }
}
