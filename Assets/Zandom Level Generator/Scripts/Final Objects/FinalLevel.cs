using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZemReusables;

namespace ZandomLevelGenerator.FinalObjects
{
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
            Transform transform = this.transform;
            //Transform transform = parent?.transform;
            //if (!transform) transform = this.transform;
            FinalRoom result = GameObjectInstantiator.Instantiate<FinalRoom>(transform.position, transform);
            result.Setup(origin, parent);
            origin.GeneratedRoom = result;

            int key = origin.Id;
            bool oldVersion = Rooms.TryGetValue(key, out FinalRoom oldResult);
            if (oldVersion)
            {
                Destroy(oldResult.gameObject);
                Rooms.Remove(key);
            }
            Rooms.Add(key, result);
            return result;
        }

        public GameObject CreateFinalTile(Tile origin, GameObject prefab, Vector3 position, bool vertical, FinalRoom parent)
        {
            Vector3 rotationEuler = new();
            if (vertical) rotationEuler.y = 90F;
            Quaternion rotation = Quaternion.Euler(rotationEuler);
            Transform transform = parent.transform;
            GameObject result = Instantiate(prefab, position, rotation, transform);
            result.name = $"{origin.Coordinates} \'{origin.Type}\'";
            origin.GeneratedTile = result;

            Vector2Int key = origin.Coordinates;
            bool oldVersion = Tiles.TryGetValue(key, out GameObject oldResult);
            if (oldVersion)
            {
                Destroy(oldResult.gameObject);
                Tiles.Remove(key);
            }
            Tiles.Add(key, result);
            return result;
        }

        public GameObject CreateFinalObstacle(Obstacle origin, GameObject prefab, Vector3 position, bool vertical, FinalRoom parent)
        {
            Vector3 rotationEuler = new();
            if (vertical) rotationEuler.y = 90F;
            Quaternion rotation = Quaternion.Euler(rotationEuler);
            Transform transform = parent.transform;
            GameObject result = Instantiate(prefab, position, rotation, transform);
            result.name = $"Obstacle #{origin.Id} \'{origin.ZandomObstacleData.gameObject.name}\'";
            origin.GeneratedObstacle = result;

            int key = origin.Id;
            bool oldVersion = Obstacles.TryGetValue(key, out GameObject oldResult);
            if (oldVersion)
            {
                Destroy(oldResult.gameObject);
                Obstacles.Remove(key);
            }
            Obstacles.Add(key, result);
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
}
