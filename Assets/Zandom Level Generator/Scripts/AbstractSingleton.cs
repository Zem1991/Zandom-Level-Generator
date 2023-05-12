using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSingleton<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; protected set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else
        {
            Debug.LogWarning("Only one instance of " + GetType() + " may exist! Deleting this extra one.");
            Destroy(gameObject);
        }
    }

    public static bool CheckReference(T reference)
    {
        return reference != null
            && reference == Instance;
    }
}
