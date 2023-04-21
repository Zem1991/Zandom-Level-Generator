using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Using two lists instead of a dictionary because those are natively serializable inside Unity's inspector.
/// </summary>
[CreateAssetMenu(menuName = "Zandom/Objects")]
public class ZandomObjects : ScriptableObject
{
    [Header("Room")]
    [SerializeField] private List<string> names = new();
    [SerializeField] private List<GameObject> finalObjects = new();

    public GameObject Get(string name)
    {
        int index = names.IndexOf(name);
        return finalObjects[index];
    }
}
