using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDistanceFinder
{
    public int Find(Room r1, Room r2)
    {
        Room earlier = r1;
        Room later = r2;
        if (r1.Age > r2.Age)
        {
            earlier = r2;
            later = r1;
        }
        int steps = 0;
        while (earlier.Age < later.Age)
        {
            later = later.Parent;
            steps++;
        }
        if (earlier != later)
        {
            while (earlier.Parent != later.Parent)
            {
                earlier = earlier.Parent;
                later = later.Parent;
                steps++;
                steps++;
            }
            steps++;
        }
        return steps;
    }
}
