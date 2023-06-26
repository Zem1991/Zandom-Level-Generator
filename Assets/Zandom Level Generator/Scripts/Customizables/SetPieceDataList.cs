using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZemReusables;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom2/SetPieceDataList")]
    public class SetPieceDataList : PseudoDictionaryScriptableObject<string, SetPieceData>
    {

    }
}
