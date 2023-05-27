using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Components
{
    /// <summary>
    /// Using two lists instead of a dictionary because those are natively serializable inside Unity's inspector.
    /// </summary>
    [CreateAssetMenu(menuName = "Zandom/Obstacle List")]
    public class ZandomObstacleList : ScriptableObject
    {
        [Header("List")]
        [SerializeField] private List<string> names = new();
        [SerializeField] private List<ZandomObstacle> items = new();

        public ZandomObstacle Get(string name)
        {
            int index = names.IndexOf(name);
            return items[index];
        }
    }
}
