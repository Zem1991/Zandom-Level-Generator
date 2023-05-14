using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;

public class CathedralSpineCorridor : SetPiece
{
    protected override string GetString()
    {
        return
            ".........." +
            ".........." +
            "..#....#.." +
            ".........." +
            ".........." +
            ".........." +
            ".........." +
            ".........." +
            ".........." +
            ".........." +
            ".........." +
            "..#....#.." +
            ".........." +
            "..........";
    }

    protected override void CreateLayout()
    {
        Layout = new char[10, 14];
        //Layout = new char[10, 20];
    }

    protected override bool AddBorders()
    {
        return false;
    }
}
