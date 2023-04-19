using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorGizmos
{
    private readonly LevelGenerator levelGenerator;

    public LevelGeneratorGizmos(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    public void OnDrawGizmos()
    {
        SizeBounds();
        SafetyBounds();
    }

    private void SizeBounds()
    {
        Vector3 size = new(Constants.LEVEL_SIZE_MAX, 0, Constants.LEVEL_SIZE_MAX);
        Vector3 center = size / 2F;
        center += levelGenerator.transform.position;
        center.x -= 0.5F;
        center.z -= 0.5F;
        DrawBounds(Color.green, size, center);
        size += new Vector3(2, 0, 2);
        DrawBounds(Color.green, size, center);
    }

    private void SafetyBounds()
    {
        if (!levelGenerator.ZandomParameters.avoidSizeBoundaries) return;
        int subtract = Constants.MODULE_SIZE * 2;
        int sizeInt = Constants.LEVEL_SIZE_MAX - subtract;
        Vector3 size = new(sizeInt, 0, sizeInt);
        Vector3 center = size / 2F;
        center += levelGenerator.transform.position;
        center.x += Constants.MODULE_SIZE - 0.5F;
        center.z += Constants.MODULE_SIZE - 0.5F;
        DrawBounds(Color.yellow, size, center);
    }

    private void DrawBounds(Color color, Vector3 size, Vector3 center)
    {
        Gizmos.color = color;
        Gizmos.DrawWireCube(center, size);
    }
}
