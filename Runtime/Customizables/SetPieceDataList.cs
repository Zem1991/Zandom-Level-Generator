using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZemReusables;

namespace ZandomLevelGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Level Generator/Set Piece Data List")]
    public class SetPieceDataList : PseudoDictionaryScriptableObject<string, SetPieceData>
    {

    }
}
