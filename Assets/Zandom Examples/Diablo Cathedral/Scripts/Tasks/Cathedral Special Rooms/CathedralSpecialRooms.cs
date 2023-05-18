using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Task;

namespace ZandomLevelGenerator.Examples.DiabloCathedral
{
    public class CathedralSpecialRooms : LevelGeneratorTask
    {
        public CathedralSpecialRooms(LevelGenerator levelGenerator) : base(levelGenerator)
        {
        }

        public override IEnumerator Run()
        {
            List<Room> Rooms = new(LevelGenerator.Level.Rooms.Values);
            foreach (var item in Rooms)
            {
                if (!item.IsEnclosed()) continue;
                item.Type = RoomType.SPECIAL;
            }
            if (LevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
            {
                yield return null;
            }
        }
    }
}
