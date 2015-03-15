using System;

namespace Point
{
    public static class Distance
    {
        public static double GetDistanceBetween2PointsIn3D(Point3D first, Point3D second)
        {
            return Math.Sqrt((first.X - second.X) * (first.X - second.X) + (first.Y - second.Y) * (first.Y - second.Y) + (first.Z - second.Z) * (first.Z - second.Z));
        }
    }
}
