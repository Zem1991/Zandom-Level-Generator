using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.Checks
{
    public class SpecialRoomSumChecker : LevelGeneratorCheck
    {
        public SpecialRoomSumChecker(LevelGenerator levelGenerator)
        {
            Rooms = levelGenerator.Level.Rooms.Values;
            Count = Get();
        }

        private IEnumerable<Room> Rooms { get; }
        public int Count { get; }

        public bool CheckMin(int minimum)
        {
            return Count >= minimum;
        }

        public bool CheckMax(int maximum)
        {
            return Count <= maximum;
        }

        private int Get()
        {
            List<Room> result = new();
            foreach (var item in Rooms)
            {
                if (item.Type != RoomType.SPECIAL) continue;
                result.Add(item);
            }
            return result.Count;
        }
    }
}
