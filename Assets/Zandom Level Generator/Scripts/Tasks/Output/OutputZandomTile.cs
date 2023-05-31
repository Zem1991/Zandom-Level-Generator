using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Tools.Factories;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tasks.Output
{
    public class OutputZandomTile : GeneratorTask
    {
        public OutputZandomTile(ZandomLevelGenerator zandomLevelGenerator, TilePlan plan) : base(zandomLevelGenerator)
        {
            Plan = plan;
        }

        public TilePlan Plan { get; }

        public override void RunContents()
        {
            string modelName = Plan.Code;
            GameObject model = ZandomLevelGenerator.ZandomTileset.Get(modelName);
            ZandomTileFactory factory = new(Plan.Level);
            factory.Create(Plan, model);
        }
    }
}
