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
            position1 *= Constants.MODULE_SIZE;
            position2 *= Constants.MODULE_SIZE;
            List<RoomPlan> rooms = new();
            RoomPlan room1 = SpineRoom(position1);
            RoomPlan room2 = SpineRoom(position2);
            rooms.Add(room1);
            rooms.Add(room2);
            if (DiabloCathedralSpine.CorridorLength > 0)
            {
                List<RoomPlan> corridors = SpineCorridor();
                rooms.AddRange(corridors);
            }
            //ApplyBorders applyBorders = new(levelGenerator);
            //foreach (RoomPlan item in rooms)
            //{
            //    applyBorders.Apply(item);
            //}
            return rooms;
        }

        private RoomPlan SpineRoom(Vector3Int position)
        {
            bool vertical = DiabloCathedralSpine.Vertical;
            SetPieceData setPieceData = DiabloCathedralSpine.ZandomLevelGenerator.ZandomSetPieceList.Get("Spine Room");
            SetPiece setPiece = new(setPieceData);
            if (vertical) setPiece.Rotate90Negative();
            return Build(setPiece, position, vertical);
        }

        private List<RoomPlan> SpineCorridor()
        {
            bool vertical = DiabloCathedralSpine.Vertical;
            List<RoomPlan> result = new();
            SetPieceData setPieceData = DiabloCathedralSpine.ZandomLevelGenerator.ZandomSetPieceList.Get("Spine Corridor");
            SetPiece setPiece = new(setPieceData);
            if (vertical) setPiece.Rotate90Negative();
            for (int i = 0; i < DiabloCathedralSpine.CorridorLength; i++)
            {
                int pos = DiabloCathedralSpine.FirstRoomPosition + 2 + i;
                Vector3Int position = DiabloCathedralSpine.CorridorPositions[i];
                position *= Constants.MODULE_SIZE;
                if (vertical) position.x += 3;
                else position.z += 3;
                RoomPlan room = Build(setPiece, position, vertical);
                result.Add(room);
            }
            return result;
        }

        private RoomPlan Build(SetPiece setPiece, Vector3Int position, bool verticalOrientation)
        {
            RoomPlanFactory factory = new(DiabloCathedralSpine.ZandomLevelGenerator.GeneratorCoroutine.Level);
            int roomId = factory.NextId();
            Vector3Int size = setPiece.Data.Size;
            Vector3Int halfSize = size / 2;
            Vector3Int start = position;
            start -= halfSize;
            RoomPlan result = factory.Create(roomId, start, size, verticalOrientation, null);
            return result;
        }
    }
}
