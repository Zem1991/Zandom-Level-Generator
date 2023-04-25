using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    public Dictionary<int, FinalRoom> Rooms { get; private set; } = new();

    public void Clear()
    {
        foreach (var item in Rooms)
        {
            Destroy(item.Value.gameObject);
        }
        Rooms = new();
    }

    public FinalRoom CreateFinalRoom(Room room, FinalRoom parent)
    {
        Transform transform = this.transform;
        //Transform transform = parent?.transform;
        //if (!transform) transform = this.transform;
        FinalRoom prefab = ZLGPrefabs.Instance.finalRoom;
        FinalRoom finalRoom = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        finalRoom.Setup(room, parent);
        room.GeneratedRoom = finalRoom;
        //finalRoom.transform.SetAsFirstSibling();
        Rooms.Add(room.Id, finalRoom);
        return finalRoom;
    }

    public void CreateFinalObstacle(GameObject prefab, Vector3 position, bool vertical, FinalRoom parent)
    {
        Transform transform = parent.transform;
        Vector3 rotationEuler = new();
        if (vertical) rotationEuler.y = 90F;
        Quaternion rotation = Quaternion.Euler(rotationEuler);
        Instantiate(prefab, position, rotation, transform);
    }

    public void Optimize()
    {
        foreach (FinalRoom room in Rooms.Values)
        {
            room.Optimize();
        }
    }
}
