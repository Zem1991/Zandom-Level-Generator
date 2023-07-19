using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.ResultObjects
{
    public class ZandomObstacle : MonoBehaviour
    {
        public void PseudoConstructor(Obstacle plan)
        {
            Obstacle = plan;
            name = plan.ToString();
        }

        public Obstacle Obstacle { get; private set; }
    }
}
