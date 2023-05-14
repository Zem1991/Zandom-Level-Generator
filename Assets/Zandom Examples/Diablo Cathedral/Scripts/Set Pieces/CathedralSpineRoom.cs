using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;

public class CathedralSpineRoom : SetPiece
{
    protected override string GetString()
    {
        return
            "...................." +
            "...................." +
            "...................." +
            "...................." +
            "....##........##...." +
            "....##........##...." +
            "...................." +
            "...................." +
            "...................." +
            ".....SS..SS..SS....." +
            ".....SS..SS..SS....." +
            "...................." +
            "...................." +
            "...................." +
            "....##........##...." +
            "....##........##...." +
            "...................." +
            "...................." +
            "...................." +
            "....................";
    }

    protected override void CreateLayout()
    {
        Layout = new char[20, 20];
    }

    protected override bool AddBorders()
    {
        return true;
    }
}
