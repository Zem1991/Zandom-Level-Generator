using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZemReusables;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/TileSet")]
    public class TileSet : PseudoDictionaryScriptableObject<string, GameObject>
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

        public override GameObject Get(string code)
        {
            string areaCode = TileType.AREA.ToString();
            string borderCode = TileType.BORDER.ToString();
            string cornerCode = TileType.CORNER.ToString();
            string wallCode = TileOverlap.WALL.ToString();
            string doorwayCode = TileOverlap.DOORWAY.ToString();
            if (code == areaCode) return area;
            if (code == borderCode) return border;
            if (code == cornerCode) return corner;
            if (code == wallCode) return wall;
            if (code == doorwayCode) return doorway;
            return base.Get(code);
        }
    }
}
