using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator
{
    [RequireComponent(typeof(ZandomLevelGenerator))]
    public class ZandomLevelGeneratorAutoRun : MonoBehaviour
    {
        private void Start()
        {
            ZandomLevelGenerator zandomLevelGenerator = GetComponent<ZandomLevelGenerator>();
            zandomLevelGenerator.TryGenerate();
            Destroy(this);
        }
    }
}
