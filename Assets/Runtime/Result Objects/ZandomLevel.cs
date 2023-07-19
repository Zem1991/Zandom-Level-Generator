using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.ResultObjects
{
    public class ZandomLevel : MonoBehaviour
    {
        //public void PseudoConstructor(LevelPlan levelPlan)
        public void PseudoConstructor()
        {
            //LevelPlan = levelPlan;
            Clear();
        }

        //public LevelPlan LevelPlan { get; private set; }

        private void Clear()
        {
            List<GameObject> allChildren = GetComponentsInChildren<GameObject>().ToList();
            allChildren.Remove(gameObject);
            foreach (var item in allChildren)
            {
                Destroy(item);
            }
        }
    }
}
