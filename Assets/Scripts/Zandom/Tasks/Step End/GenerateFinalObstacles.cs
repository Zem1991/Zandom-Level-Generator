using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFinalObstacles : LevelGeneratorTask
{
    public GenerateFinalObstacles(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override IEnumerator Run()
    {
        //LevelPostGen levelLayout = levelStyle.LevelLayout;
        foreach (Obstacle obstacle in LevelGenerator.Level.Obstacles)
        {
            yield return Run(obstacle);
        }
    }

    public IEnumerator Run(Obstacle obstacle)
    {
        GameObject currentGenerated = obstacle.GeneratedObstacle;
        if (currentGenerated)
        {
            yield break;
        }

        FinalLevel finalLevel = LevelGenerator.FinalLevel;
        GameObject prefab = LevelGenerator.ZandomObjects.Get(obstacle.Name);
        Vector3 position = finalLevel.transform.position + obstacle.CenterPosition;
        bool vertical = obstacle.Vertical;
        FinalRoom finalRoom = obstacle.Room.GeneratedRoom;

        finalLevel.CreateFinalObstacle(obstacle, prefab, position, vertical, finalRoom);
        if (LevelGenerator.taskWaitingTier > 0)
        {
            yield return null;
        }
    }
}
