using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Customizables
{
    public class TileSetObject : MonoBehaviour
    {
        [SerializeField] private char charCode;

        public char CharCode { get => charCode; }
    }
}
