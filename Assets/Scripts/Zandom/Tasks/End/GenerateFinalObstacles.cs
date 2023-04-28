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
        FinalLevel finalLevel = LevelGenerator.FinalLevel;
        GameObject gameObject = LevelGenerator.ZandomObjects.Get(obstacle.Name);
        Vector3 position = obstacle.GetFinalPosition();
        bool vertical = obstacle.Vertical;
        FinalRoom finalRoom = obstacle.Room.GeneratedRoom;
        finalLevel.CreateFinalObstacle(gameObject, position, vertical, finalRoom);
        if (LevelGenerator.taskWaitingTier > 0)
        {
            yield return null;
        }
    }
}
