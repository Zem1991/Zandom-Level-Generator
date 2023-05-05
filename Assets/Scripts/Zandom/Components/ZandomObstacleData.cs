using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Zandom/Obstacle Data")]
public class ZandomObstacleData : ScriptableObject
{
    [Header("Generator Settings")]
    [Min(1)] public int amountMinimum = 1;
    [Min(1)] public int amountDesired = 10;
    public Vector2Int size = new(4, 4);

    [Header("Object to Spawn")]
    public GameObject gameObject;
}
