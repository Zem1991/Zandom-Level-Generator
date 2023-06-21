using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class SetPiece
    {
        public SetPiece(SetPieceData data)
        {
            Data = data;
            Layout = new char[Data.Size.x, Data.Size.z];
            string cleanLayout = Data.Layout.Replace("\n", "").Replace("\r", "");
            Queue<char> chars = new(cleanLayout);
            for (int row = 0; row < Size.y; row++)
            {
                for (int col = 0; col < Size.x; col++)
                {
                    char next = chars.Dequeue();
                    Layout[col, row] = next;
                }
            }
        }

        public SetPieceData Data { get; }
        public char[,] Layout { get; private set; }
        public Vector3Int Size { get => new(Layout.GetLength(0), 1, Layout.GetLength(1)); }
        public char Get(int x, int y) => Layout[x, y];

        public void Rotate90Negative()
        {
            SetPieceRotator setPieceRotator = new(this);
            Layout = setPieceRotator.Rotate90Negative();
        }
    }
}
