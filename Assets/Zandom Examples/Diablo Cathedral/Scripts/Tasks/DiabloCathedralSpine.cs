using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Tasks
{
    public class DiabloCathedralSpine : GeneratorTask
    {
        public DiabloCathedralSpine(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public bool UseShorterVersion { get; private set; }
        public int MaxLength { get; private set; }
        public int CorridorLength { get; private set; }
        public int MaxPosition { get; private set; }
        public int FirstRoomPosition { get; private set; }
        public bool Vertical { get; private set; }
        public Vector3Int Room1Position { get; private set; }
        public Vector3Int Room2Position { get; private set; }
        public List<Vector3Int> CorridorPositions { get; private set; }
        public List<RoomPlan> NewRooms { get; private set; }
        
        public override void RunContents()
        {
            Setup();
            Execute();
        }

        private void Setup()
        {
            UseShorterVersion = ZandomLevelGenerator.ZandomParameters.SafetySize != Vector3Int.zero;
            MaxLength = UseShorterVersion ? 3 : 5;
            CorridorLength = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(0, MaxLength);
            CorridorLength = 2; //!!
            MaxPosition = MaxLength - CorridorLength;
            FirstRoomPosition = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(0, MaxPosition);
            if (UseShorterVersion) FirstRoomPosition++;
            Vertical = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.NextBool();
            CorridorPositions = new();
            if (Vertical)
            {
                int levelSize = ZandomLevelGenerator.ZandomParameters.LevelSize.z;
                int moduleSize = ZandomLevelGenerator.ZandomParameters.ModuleSize.z;
                int room1Coord = FirstRoomPosition * moduleSize;
                int room1End = room1Coord + 20;
                int room2Coord = room1End + (CorridorLength * moduleSize);
                int roomOffset = (levelSize / 2) - 10;
                int corridorOffset = roomOffset + 3;
                Room1Position = new(roomOffset, 0, room1Coord);
                Room2Position = new(roomOffset, 0, room2Coord);
                for (int i = 0; i < CorridorLength; i++)
                {
                    int corridorCoord = room1End + (i * moduleSize) - 1;
                    Vector3Int corridorPos = new(corridorOffset, 0, corridorCoord);
                    CorridorPositions.Add(corridorPos);
                }
            }
            else
            {
                int levelSize = ZandomLevelGenerator.ZandomParameters.LevelSize.x;
                int moduleSize = ZandomLevelGenerator.ZandomParameters.ModuleSize.x;
                int room1Coord = FirstRoomPosition * moduleSize;
                int room1End = room1Coord + 20;
                int room2Coord = room1End + (CorridorLength * moduleSize);
                int roomOffset = (levelSize / 2) - 10;
                int corridorOffset = roomOffset + 3;
                Room1Position = new(room1Coord, 0, roomOffset);
                Room2Position = new(room2Coord, 0, roomOffset);
                for (int i = 0; i < CorridorLength; i++)
                {
                    int corridorCoord = room1End + (i * moduleSize) - 1;
                    Vector3Int corridorPos = new(corridorCoord, 0, corridorOffset);
                    CorridorPositions.Add(corridorPos);
                }
            }
        }

        private void Execute()
        {
            DiabloCathedralSpineExecutor executor = new(this);
            List<RoomPlan> newRooms = executor.Run();
            NewRooms = newRooms;
        }
    }
}
