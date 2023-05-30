using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZemReusables;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/TileSet")]
    public class TileSet : PseudoDictionaryScriptableObject<GameObject>
    {
        //public GameObject GetModel(TileType tileType)
        //{
        //    GameObject result = null;
        //    switch (tileType)
        //    {
        //        case TileType.ROOM_AREA:
        //            result = areaTile;
        //            break;
        //        case TileType.ROOM_BORDER:
        //            result = borderTile;
        //            break;
        //        case TileType.ROOM_CORNER:
        //            result = cornerTile;
        //            break;
        //        case TileType.NORMAL_WALL:
        //            result = normalWallTile;
        //            break;
        //        case TileType.AGED_WALL:
        //            result = agedWallTile;
        //            break;
        //        case TileType.BARS_WALL:
        //            result = barsWallTile;
        //            break;
        //        case TileType.NORMAL_FLOOR:
        //            result = normalFloorTile;
        //            break;
        //        case TileType.SPECIAL_FLOOR:
        //            result = specialFloorTile;
        //            break;
        //        case TileType.DOORWAY_FLOOR:
        //            result = doorwayFloorTile;
        //            break;
        //    }
        //    return result;
        //}
    }
}
