using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : MonoBehaviour
{
    public void Setup(Room room, FinalRoom parent)
    {
        Room = room;
        Parent = parent;
        name = $"Room #{room.Id}";
    }

    public Room Room { get; private set; }
    public FinalRoom Parent { get; private set; }
}
