using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZemReusables
{
    public abstract class PseudoDictionaryScriptableObject<K, V> : ScriptableObject
    {
        [Header("List")]
        [SerializeField] protected List<PseudoItem<K, V>> items = new();

        public virtual V Get(K key)
        {
            return items.Find(item => item.key.Equals(key)).value;
        }
    }

    [System.Serializable]
    public struct PseudoItem<K, V>
    {
        public K key;
        public V value;
    }
}
