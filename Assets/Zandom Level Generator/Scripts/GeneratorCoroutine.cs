using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator
{
    public class GeneratorCoroutine
    {
        public GeneratorCoroutine(ZandomLevelGenerator zandomLevelGenerator)
        {
            ZandomLevelGenerator = zandomLevelGenerator;
        }

        public Action OnFinish { get; set; }
        public ZandomLevelGenerator ZandomLevelGenerator { get; }

        public IEnumerator Run()
        {

        }
    }
}
