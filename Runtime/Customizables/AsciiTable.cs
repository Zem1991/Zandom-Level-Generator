using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZemReusables;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/AsciiTable")]
    public class AsciiTable : PseudoDictionaryScriptableObject<char, string>
    {
        [Header("Reserved: TileType.AREA")]
        [SerializeField] private char area = '.';

        [Header("Reserved: TileType.BORDER")]
        [SerializeField] private char border = '=';

        [Header("Reserved: TileType.CORNER")]
        [SerializeField] private char corner = '#';

        [Header("Reserved: TileOverlap.WALL")]
        [SerializeField] private char wall = '/';

        [Header("Reserved: TileOverlap.DOORWAY")]
        [SerializeField] private char doorway = '+';

        public override string Get(char code)
        {
            if (code == area) return TileType.AREA.ToString();
            if (code == border) return TileType.BORDER.ToString();
            if (code == corner) return TileType.CORNER.ToString();
            if (code == wall) return TileOverlap.WALL.ToString();
            if (code == doorway) return TileOverlap.DOORWAY.ToString();
            return base.Get(code);
        }

        //public TileType? GetTileType(char code)
        //{
        //    if (code == area) return TileType.AREA;
        //    if (code == border) return TileType.BORDER;
        //    if (code == corner) return TileType.CORNER;
        //    return null;
        //}

        //public TileOverlap? GetTileOverlap(char code)
        //{
        //    if (code == wall) return TileOverlap.WALL;
        //    if (code == doorway) return TileOverlap.DOORWAY;
        //    return null;
        //}
    }
}
