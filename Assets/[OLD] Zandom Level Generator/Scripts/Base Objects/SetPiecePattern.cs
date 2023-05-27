using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using ZandomLevelGenerator.Components;
using ZandomLevelGenerator.Helpers;

namespace ZandomLevelGenerator.BaseObjects
{
    public class SetPiecePattern
    {
        public ZandomSetPiece SetPiece { get; }
        public char[,] Layout { get; private set; }
        public Vector2Int Size { get => new(Layout.GetLength(0), Layout.GetLength(1)); }

        public SetPiecePattern(ZandomSetPiece setPiece)
        {
            SetPiece = setPiece;
            Layout = new char[SetPiece.size.x, SetPiece.size.y];
            string cleanLayout = SetPiece.layout.Replace("\n", "").Replace("\r", "");
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

        public char Get(int x, int y) => Layout[x, y];

        public void Rotate90Negative()
        {
            SetPieceRotator setPieceRotator = new(this);
            Layout = setPieceRotator.Rotate90Negative();
        }
    }
}
