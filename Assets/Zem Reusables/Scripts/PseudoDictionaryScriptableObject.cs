using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZemReusables
{
    public abstract class PseudoDictionaryScriptableObject<T> : ScriptableObject where T : Object
    {
        [Header("List")]
        [SerializeField] protected List<T> items = new();

        public T Get(string name)
        {
            return items.Find(item => item.name == name);
        }
    }
}
