using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Examples.DiabloCathedral.Styles;
using ZandomLevelGenerator.Tasks.Common;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Tasks
{
    public class PlaceChallengeEncounter : GeneratorTask
    {
        public PlaceChallengeEncounter(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public override void RunContents()
        {
            string objectName = "Challenge Encounter";
            PlaceObstaclesParameters parameters = new DiabloCathedralPlaceChallengeEncounterParameters().CreateParameters();
            PlaceObstacles placeObstacles = new(ZandomLevelGenerator, objectName, parameters);
            placeObstacles.RunContents();
        }
    }
}
