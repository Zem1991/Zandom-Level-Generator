using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZemReusables
{
    public abstract class PseudoDictionaryScriptableObject<T> : ScriptableObject where T : Object
    {
        [Header("List")]
        [SerializeField] protected List<PseudoItem<T>> items = new();

        public virtual T Get(string key)
        {
            return items.Find(item => item.key == key).value;
        }

        [System.Serializable]
        public class PseudoItem<T>
        {
            public string key;
            public T value;
        }
    }
}
