using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class FinalRoom : MonoBehaviour
{
    public Room Room { get; private set; }
    public FinalRoom Parent { get; private set; }

    public void Setup(Room room, FinalRoom parent)
    {
        Room = room;
        Parent = parent;
        name = room.ToString();
    }

    public void Optimize()
    {
        gameObject.MeshCombine(true);
    }
}
