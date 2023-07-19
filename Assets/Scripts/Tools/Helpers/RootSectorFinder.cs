using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class RootSectorFinder
    {
        public int Find(SectorPlan sector1, SectorPlan sector2, out SectorPlan root)
        {
            int steps = 0;
            root = null;
            //Sorts both given sectors, so we can work better.
            SectorPlan earlier = sector1;
            SectorPlan later = sector2;
            if (sector1.GenerationAge > sector2.GenerationAge)
            {
                earlier = sector2;
                later = sector1;
            }
            //Goes up a parent until both ages are equal.
            while (earlier.GenerationAge < later.GenerationAge)
            {
                later = later.Parent;
                steps++;
            }
            //Goes up twice until both sectors find a common parent.
            while (earlier != later)
            {
                earlier = earlier.Parent;
                later = later.Parent;
                steps++;
                steps++;
            }
            //If no common parent was found, then return -1 instead.
            if (earlier != later)
            {
                steps = -1;
            }
            else
            {
                root = earlier;
            }
            return steps;
        }
    }
}
