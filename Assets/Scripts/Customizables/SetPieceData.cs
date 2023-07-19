using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/SetPieceData")]
    public class SetPieceData : ScriptableObject
    {
        [Header("Settings")]
        [SerializeField][TextArea] private string layout;
        [SerializeField] private Vector3Int size;
        [SerializeField] private bool addBorders;

        public string Layout { get => layout; }
        public Vector3Int Size { get => size; }
        public bool AddBorders { get => addBorders; }
    }
}
