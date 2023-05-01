using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    public Dictionary<int, FinalRoom> Rooms { get; private set; } = new();
    public Dictionary<Vector2Int, GameObject> Tiles { get; private set; } = new();
    public Dictionary<int, GameObject> Obstacles { get; private set; } = new();

    public void Clear()
    {
        foreach (var item in Rooms)
        {
            Destroy(item.Value.gameObject);
        }
        foreach (var item in Tiles)
        {
            Destroy(item.Value.gameObject);
        }
        foreach (var item in Obstacles)
        {
            Destroy(item.Value.gameObject);
        }
        Tiles = new();
        Rooms = new();
        Obstacles = new();
    }

    public FinalRoom CreateFinalRoom(Room origin, FinalRoom parent)
    {
        FinalRoom prefab = ZLGPrefabs.Instance.finalRoom;
        Transform transform = this.transform;
        //Transform transform = parent?.transform;
        //if (!transform) transform = this.transform;
        FinalRoom result = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        result.Setup(origin, parent);
        origin.GeneratedRoom = result;
        Rooms.Add(origin.Id, result);
        return result;
    }

    public GameObject CreateFinalTile(Tile origin, GameObject prefab, Vector3 position, bool vertical, FinalRoom parent)
    {
        Vector3 rotationEuler = new();
        if (vertical) rotationEuler.y = 90F;
        Quaternion rotation = Quaternion.Euler(rotationEuler);
        Transform transform = parent.transform;
        GameObject result = Instantiate(prefab, position, rotation, transform);
        result.name = $"\'{origin.Type}\' {origin.Coordinates}";
        origin.GeneratedTile = result;
        Tiles.Add(origin.Coordinates, result);
        return result;
    }

    public GameObject CreateFinalObstacle(Obstacle origin, GameObject prefab, Vector3 position, bool vertical, FinalRoom parent)
    {
        Vector3 rotationEuler = new();
        if (vertical) rotationEuler.y = 90F;
        Quaternion rotation = Quaternion.Euler(rotationEuler);
        Transform transform = parent.transform;
        GameObject result = Instantiate(prefab, position, rotation, transform);
        result.name = $"{origin.Id} {origin.Name}";
        origin.GeneratedObstacle = result;
        Obstacles.Add(origin.Id, result);
        return result;
    }

    public void Optimize()
    {
        foreach (FinalRoom room in Rooms.Values)
        {
            room.Optimize();
        }
    }
}
