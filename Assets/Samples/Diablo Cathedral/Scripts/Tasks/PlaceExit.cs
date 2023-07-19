using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Tasks.Common;

namespace ZandomLevelGenerator.Samples.DiabloCathedral.Tasks
{
    public class PlaceExit : GeneratorTask
    {
        public PlaceExit(ZandomLevelGenerator zandomLevelGenerator, PlaceObstaclesParameters parameters) : base(zandomLevelGenerator)
        {
            Parameters = parameters;
        }

        public PlaceObstaclesParameters Parameters { get; }

        public override void RunContents()
        {
            string objectName = "Exit";
            PlaceObstacles placeObstacles = new(ZandomLevelGenerator, objectName, Parameters);
            placeObstacles.RunContents();
        }
    }
}
