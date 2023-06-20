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
            //Vector3Int moduleSize = ZandomLevelGenerator.ZandomParameters.ModuleSize;
            UseShorterVersion = ZandomLevelGenerator.ZandomParameters.SafetySize != Vector3Int.zero;
            MaxLength = UseShorterVersion ? 3 : 5;
            CorridorLength = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(0, MaxLength);
            MaxPosition = MaxLength - CorridorLength;
            FirstRoomPosition = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(0, MaxPosition);
            if (UseShorterVersion) FirstRoomPosition++;
            Vertical = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.NextBool();
            CorridorPositions = new();
            if (Vertical)
            {
                Room1Position = new(3, 0, FirstRoomPosition);
                Room2Position = new(3, 0, FirstRoomPosition + 2 + CorridorLength);
                for (int i = 0; i < CorridorLength; i++)
                {
                    Vector3Int corridorPos = new(3, 0, i);
                    CorridorPositions.Add(corridorPos);
                }
            }
            else
            {
                Room1Position = new(FirstRoomPosition, 0, 3);
                Room2Position = new(FirstRoomPosition + 2 + CorridorLength, 0, 3);
                for (int i = 0; i < CorridorLength; i++)
                {
                    Vector3Int corridorPos = new(i, 0, 3);
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
