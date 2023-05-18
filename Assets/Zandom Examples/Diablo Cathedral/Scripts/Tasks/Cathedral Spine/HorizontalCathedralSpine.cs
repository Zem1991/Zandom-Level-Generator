using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;

namespace ZandomLevelGenerator.Examples.DiabloCathedral
{
    public class HorizontalCathedralSpine : AxisCathedralSpine
    {
        public HorizontalCathedralSpine(LevelGenerator levelGenerator, int firstRoomPosition, int corridorLength) : base(levelGenerator, firstRoomPosition, corridorLength)
        {
        }

        protected override Vector2Int GetPositionRoom1()
        {
            return new(firstRoomPosition, 3);
        }

        protected override Vector2Int GetPositionRoom2()
        {
            return new(firstRoomPosition + 2 + corridorLength, 3);
        }

        protected override Vector2Int GetPositionCorridor(int index)
        {
            return new(index, 3);
        }
    
        protected override Room Build(Vector2Int position, SetPiece setPiece)
        {
            return new CathedralSpineExecutor(levelGenerator).Run(position, setPiece, false);
        }
    }
}
