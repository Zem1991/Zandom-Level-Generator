using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRooms : LevelGeneratorTask
{
    public FinalRooms(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override void Run()
    {
        //LevelPostGen levelLayout = levelStyle.LevelLayout;
        foreach (Room room in LevelGenerator.Level.Rooms.Values)
        {
            Run(room);
            //FinalRoom finalRoom = Run(room);
            //levelLayout.AddRoom(finalRoom);
        }
    }

    public FinalRoom Run(Room room)
    {
        FinalRoom prefab = ZLGPrefabs.Instance.finalRoom;
        FinalRoom parent = room.Parent?.GeneratedRoom;
        Transform parentTransform = parent ? parent.transform : LevelGenerator.FinalLevel.transform;
        FinalRoom finalRoom = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity, parentTransform);
        finalRoom.Setup(room, parent);
        //finalRoom.transform.SetAsFirstSibling();
        room.GeneratedRoom = finalRoom;
        return finalRoom;
    }
}
