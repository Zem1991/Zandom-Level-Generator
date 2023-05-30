using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/SetPieceData")]
    public class SetPieceData : ScriptableObject
    {
        [Header("Settings")]
        [TextArea] private string layout;
        private Vector2Int size;
        private bool addBorders;

        public string Layout { get => layout; set => layout = value; }
        public Vector2Int Size { get => size; set => size = value; }
        public bool AddBorders { get => addBorders; set => addBorders = value; }
    }
}
