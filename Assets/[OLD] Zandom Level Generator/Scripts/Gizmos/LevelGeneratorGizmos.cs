using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.Gizmos
{
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
            StartLocation();
            PointsOfInterest();
        }

        private void SizeBounds()
        {
            Vector3 size = new(Constants.LEVEL_SIZE_MAX, 0, Constants.LEVEL_SIZE_MAX);
            Vector3 center = size / 2F;
            center += levelGenerator.transform.position;
            center.x -= 0.5F;
            center.z -= 0.5F;
            DrawCube(Constants.SizeBoundsColor, center, size);
            size += new Vector3(2, 0, 2);
            DrawCube(Constants.SizeBoundsColor, center, size);
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
            DrawCube(Constants.SafetyBoundsColor, center, size);
        }

        private void AllStates()
        {
            if (levelGenerator.State == null) return;
            int startIndex = (int)ZandomStateName.STEP01;
            int endIndex = (int)ZandomStateName.END;
            int currentIndex = (int)levelGenerator.StateName;
            for (int i = startIndex; i <= endIndex; i++)
            {
                State(i, Constants.StateBoxColor, i <= currentIndex);
            }
        }

        private void State(int index, Color color, bool visited)
        {
            index--;
            int offset = 2;
            int sizeUnit = 4;
            int xCoord = index * (sizeUnit + offset) + offset;
            Vector3 center = levelGenerator.transform.position;
            center += new Vector3(xCoord, 0, -sizeUnit);
            Vector3 size = new(sizeUnit, 0, sizeUnit);
            DrawCube(color, center, size, !visited);
        }

        private void StartLocation()
        {
            StartLocation startLocation = levelGenerator?.Level?.StartLocation;
            if (startLocation == null) return;
            Vector3 center = levelGenerator.transform.position;
            center += levelGenerator.Level.StartLocation.Position;
            float radius = Constants.EntranceSafetyRadius;
            DrawSphere(Constants.EntranceZoneColor, center, radius);
        }

        private void PointsOfInterest()
        {
            List<PointOfInterest> pointsOfInterest = levelGenerator?.Level?.PointsOfInterest;
            if (pointsOfInterest == null) return;
            foreach (var item in pointsOfInterest)
            {
                Vector3 center = levelGenerator.transform.position;
                center += item.Position;
                float radius = Constants.ExitSafetyRadius;
                DrawSphere(Constants.ExitZoneColor, center, radius);
            }
        }

        private void DrawCube(Color color, Vector3 center, Vector3 size, bool wireframe = true)
        {
            UnityEngine.Gizmos.color = color;
            if (wireframe) UnityEngine.Gizmos.DrawWireCube(center, size);
            else UnityEngine.Gizmos.DrawCube(center, size);
        }

        private void DrawSphere(Color color, Vector3 center, float radius, bool wireframe = true)
        {
            UnityEngine.Gizmos.color = color;
            if (wireframe) UnityEngine.Gizmos.DrawWireSphere(center, radius);
            else UnityEngine.Gizmos.DrawSphere(center, radius);
        }
    }
}
