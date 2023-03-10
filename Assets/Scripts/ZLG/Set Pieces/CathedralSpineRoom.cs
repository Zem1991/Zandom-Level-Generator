using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            "...................." +
            "...................." +
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
