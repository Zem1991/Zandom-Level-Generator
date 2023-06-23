using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZemReusables;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/TileSet")]
    public class TileSet : PseudoDictionaryScriptableObject<TileSetObject>
    {
        [Header("Reserved: TileType.AREA")]
        [SerializeField] private TileSetObject area;

        [Header("Reserved: TileType.BORDER")]
        [SerializeField] private TileSetObject border;

        [Header("Reserved: TileType.CORNER")]
        [SerializeField] private TileSetObject corner;

        [Header("Reserved: TileOverlap.WALL")]
        [SerializeField] private TileSetObject wall;

        [Header("Reserved: TileOverlap.DOORWAY")]
        [SerializeField] private TileSetObject doorway;

        public override TileSetObject Get(string name)
        {
            char[] charArray = name.ToCharArray();
            if (charArray.Length == 1)
            {
                char charCode = charArray[0];
                return Get(charCode);
            }
            if (name == TileType.AREA.ToString()) return area;
            if (name == TileType.BORDER.ToString()) return border;
            if (name == TileType.CORNER.ToString()) return corner;
            if (name == TileOverlap.WALL.ToString()) return wall;
            if (name == TileOverlap.DOORWAY.ToString()) return doorway;
            return base.Get(name);
        }

        public string GetCode(char charCode)
        {
            if (charCode == area.CharCode) return area;
            if (charCode == border.CharCode) return border;
            if (charCode == corner.CharCode) return corner;
            if (charCode == wall.CharCode) return wall;
            if (charCode == doorway.CharCode) return doorway;
            foreach (var item in items)
            {
                TileSetObject tile = item.value;
                if (charCode == tile.CharCode) return tile.;
            }
            return null;
        }

        public string GetFullCode(char charCode)
        {
            throw new NotImplementedException();
        }
    }
}
