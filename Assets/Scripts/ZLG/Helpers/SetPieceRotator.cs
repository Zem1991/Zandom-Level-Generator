using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPieceRotator
{
    private SetPiece setPiece;

    public SetPieceRotator(SetPiece setPiece)
    {
        this.setPiece = setPiece;
    }

    public char[,] Layout { get; private set; }

    public void Rotate90Negative()
    {
        char[,] originalLayout = setPiece.Layout;
        int lengthX = originalLayout.GetLength(0);
        int lengthY = originalLayout.GetLength(1);

        char[,] result = new char[lengthY, lengthX];
        for (int i = 0; i < lengthY; i++)
        {
            for (int j = 0; j < lengthX; j++)
            {
                //Negative 90
                result[i, j] = originalLayout[j, lengthY - i - 1];
            }
        }
        Layout = result;
    }

    ////TODO: test this one?
    //public void Rotate90Positive()
    //{
    //    char[,] originalLayout = setPiece.Layout;
    //    int lengthX = originalLayout.GetLength(0);
    //    int lengthY = originalLayout.GetLength(1);

    //    char[,] result = new char[lengthY, lengthX];
    //    for (int i = 0; i < lengthY; i++)
    //    {
    //        for (int j = 0; j < lengthX; j++)
    //        {
    //            //Positive 90
    //            result[i, j] = originalLayout[lengthY - j - 1, i];   
    //        }
    //    }
    //    Layout = result;
    //}
}
