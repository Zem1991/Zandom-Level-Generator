using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    public Dictionary<int, FinalRoom> Rooms { get; } = new();

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

    public void Optimize()
    {
        foreach (FinalRoom room in Rooms.Values)
        {
            room.Optimize();
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 size = new(Constants.LEVEL_SIZE, 0, Constants.LEVEL_SIZE);
        Vector3 center = size / 2F;
        center += transform.position;
        center.x -= 0.5F;
        center.z -= 0.5F;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(center, size);
        size += new Vector3(2, 0, 2);
        Gizmos.DrawWireCube(center, size);
    }
}
