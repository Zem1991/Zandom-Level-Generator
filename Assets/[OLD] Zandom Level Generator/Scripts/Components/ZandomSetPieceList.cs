using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Components
{
    /// <summary>
    /// Using two lists instead of a dictionary because those are natively serializable inside Unity's inspector.
    /// </summary>
    [CreateAssetMenu(menuName = "Zandom/Set Piece List")]
    public class ZandomSetPieceList : ScriptableObject
    {
        [Header("List")]
        [SerializeField] private List<string> names = new();
        [SerializeField] private List<ZandomSetPiece> items = new();

        public ZandomSetPiece Get(string name)
        {
            int index = names.IndexOf(name);
            return items[index];
        }
    }
}
