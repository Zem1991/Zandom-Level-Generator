using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Components
{
    [CreateAssetMenu(menuName = "Zandom/Set Piece")]
    public class ZandomSetPiece : ScriptableObject
    {
        [Header("Settings")]
        [TextArea] public string layout;
        public Vector2Int size;
        public bool addBorders;
    }
}
