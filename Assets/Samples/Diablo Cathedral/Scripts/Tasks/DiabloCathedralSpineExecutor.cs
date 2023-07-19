using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Factories;

namespace ZandomLevelGenerator.Samples.DiabloCathedral.Tasks
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
                SpineRoom(position1, false),
                SpineRoom(position2, true),
            };
            if (DiabloCathedralSpine.CorridorLength > 0)
            {
                List<RoomPlan> corridors = SpineCorridor();
                rooms.AddRange(corridors);
            }
            return rooms;
        }

        private RoomPlan SpineRoom(Vector3Int position, bool rotate180)
        {
            SetPieceData setPieceData = DiabloCathedralSpine.ZandomLevelGenerator.ZandomSetPieceList.Get("Spine Room");
            SetPiece setPiece = new(DiabloCathedralSpine.ZandomLevelGenerator.ZandomTileset, setPieceData);
            if (rotate180)
            {
                //TODO: BETTER ROTATION PLS
                setPiece.Rotate90Negative();
                setPiece.Rotate90Negative();
            }
            bool vertical = DiabloCathedralSpine.Vertical;
            if (vertical)
            {
                setPiece.Rotate90Negative();
            }
            RoomPlan result = Build(setPiece, position);
            return result;
        }

        private List<RoomPlan> SpineCorridor()
        {
            List<RoomPlan> result = new();
            SetPieceData setPieceData = DiabloCathedralSpine.ZandomLevelGenerator.ZandomSetPieceList.Get("Spine Corridor");
            SetPiece setPiece = new(DiabloCathedralSpine.ZandomLevelGenerator.ZandomTileset, setPieceData);
            bool vertical = DiabloCathedralSpine.Vertical;
            if (vertical)
            {
                setPiece.Rotate90Negative();
            }
            for (int i = 0; i < DiabloCathedralSpine.CorridorLength; i++)
            {
                Vector3Int position = DiabloCathedralSpine.CorridorPositions[i];
                RoomPlan room = Build(setPiece, position);
                result.Add(room);
            }
            return result;
        }

        private RoomPlan Build(SetPiece setPiece, Vector3Int position)
        {
            bool vertical = DiabloCathedralSpine.Vertical;
            RoomPlanFactory factory = new(DiabloCathedralSpine.ZandomLevelGenerator.ZandomParameters, DiabloCathedralSpine.ZandomLevelGenerator.GeneratorCoroutine.Level);
            int roomId = factory.NextId();
            Vector3Int start = position;
            factory.TryCreate(roomId, start, setPiece, vertical, null, out RoomPlan result);
            return result;
        }
    }
}
