using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Factories;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Tasks
{
    public class DiabloCathedralSpineExecutor
    {
        public DiabloCathedralSpineExecutor(DiabloCathedralSpine diabloCathedralSpine)
        {
            DiabloCathedralSpine = diabloCathedralSpine;
        }

        public DiabloCathedralSpine DiabloCathedralSpine { get; }

        public List<RoomPlan> Run()
        {
            Vector3Int position1 = DiabloCathedralSpine.Room1Position;
            Vector3Int position2 = DiabloCathedralSpine.Room2Position;
            List<RoomPlan> rooms = new()
            {
                SpineRoom(position1),
                SpineRoom(position2),
            };
            if (DiabloCathedralSpine.CorridorLength > 0)
            {
                List<RoomPlan> corridors = SpineCorridor();
                rooms.AddRange(corridors);
            }
            return rooms;
        }

        private RoomPlan SpineRoom(Vector3Int position)
        {
            SetPieceData setPieceData = DiabloCathedralSpine.ZandomLevelGenerator.ZandomSetPieceList.Get("Spine Room");
            SetPiece setPiece = new(DiabloCathedralSpine.ZandomLevelGenerator.ZandomTileset, setPieceData);
            RoomPlan result = Build(setPiece, position);
            return result;
        }

        private List<RoomPlan> SpineCorridor()
        {
            List<RoomPlan> result = new();
            SetPieceData setPieceData = DiabloCathedralSpine.ZandomLevelGenerator.ZandomSetPieceList.Get("Spine Corridor");
            SetPiece setPiece = new(DiabloCathedralSpine.ZandomLevelGenerator.ZandomTileset, setPieceData);
            for (int i = 0; i < DiabloCathedralSpine.CorridorLength; i++)
            {
                Vector3Int position = DiabloCathedralSpine.CorridorPositions[i];
                RoomPlan room = Build(setPiece, position);
                result.Add(room);
            }
            return result;
        }

        private RoomPlan Build(SetPiece setPieceBase, Vector3Int position)
        {
            SetPiece setPieceCopy = new(setPieceBase.TileSet, setPieceBase.Data);
            bool vertical = DiabloCathedralSpine.Vertical;
            if (vertical) setPieceCopy.Rotate90Negative();
            RoomPlanFactory factory = new(DiabloCathedralSpine.ZandomLevelGenerator.ZandomParameters, DiabloCathedralSpine.ZandomLevelGenerator.GeneratorCoroutine.Level);
            int roomId = factory.NextId();
            Vector3Int start = position;
            factory.TryCreate(roomId, start, setPieceCopy, vertical, null, out RoomPlan result);
            return result;
        }
    }
}
