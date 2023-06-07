using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZemReusables;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/TileSet")]
    public class TileSet : PseudoDictionaryScriptableObject<GameObject>
    {
        [Header("Reserved: TileType.AREA")]
        [SerializeField] private GameObject area;

        [Header("Reserved: TileType.BORDER")]
        [SerializeField] private GameObject border;

        [Header("Reserved: TileType.CORNER")]
        [SerializeField] private GameObject corner;

        [Header("Reserved: TileOverlap.WALL")]
        [SerializeField] private GameObject wall;

        [Header("Reserved: TileOverlap.DOORWAY")]
        [SerializeField] private GameObject doorway;

        public override GameObject Get(string name)
        {
            if (name == TileTypeNew.AREA.ToString()) return area;
            if (name == TileTypeNew.BORDER.ToString()) return border;
            if (name == TileTypeNew.CORNER.ToString()) return corner;
            if (name == TileOverlap.WALL.ToString()) return wall;
            if (name == TileOverlap.DOORWAY.ToString()) return doorway;
            return base.Get(name);
        }
    }
}
