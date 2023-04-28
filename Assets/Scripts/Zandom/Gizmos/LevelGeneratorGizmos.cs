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
        AllStates();
    }

    private void SizeBounds()
    {
        Vector3 size = new(Constants.LEVEL_SIZE_MAX, 0, Constants.LEVEL_SIZE_MAX);
        Vector3 center = size / 2F;
        center += levelGenerator.transform.position;
        center.x -= 0.5F;
        center.z -= 0.5F;
        DrawCube(Color.green, center, size);
        size += new Vector3(2, 0, 2);
        DrawCube(Color.green, center, size);
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
        DrawCube(Color.yellow, center, size);
    }

    private void AllStates()
    {
        if (levelGenerator.State == null) return;
        int startIndex = (int)ZandomStateName.STEP01;
        int endIndex = (int)ZandomStateName.END;
        int currentIndex = (int)levelGenerator.StateName;
        for (int i = startIndex; i <= endIndex; i++)
        {
            State(i, Color.white, i <= currentIndex);
        }
    }

    private void State(int index, Color color, bool visited)
    {
        index--;
        int offset = 2;
        int sizeUnit = 4;
        int xCoord = index * (sizeUnit + offset) + offset;
        Vector3 center = new(xCoord, 0, -sizeUnit);
        Vector3 size = new(sizeUnit, 0, sizeUnit);
        DrawCube(color, center, size, !visited);
    }

    private void DrawCube(Color color, Vector3 center, Vector3 size, bool wireframe = true)
    {
        Gizmos.color = color;
        if (wireframe) Gizmos.DrawWireCube(center, size);
        else Gizmos.DrawCube(center, size);
    }
}
