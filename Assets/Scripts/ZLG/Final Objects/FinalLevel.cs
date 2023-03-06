using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Vector3 size = new(Level.SIZE, 0, Level.SIZE);
        Vector3 center = size / 2F;
        center += transform.position;
        center.x -= 0.5F;
        center.z -= 0.5F;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(center, size);
        size += new Vector3(2, 0, 2);
        Gizmos.DrawWireCube(center, size);
    }
}
