using System;

namespace Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D point = new Point3D(1.0, 1.0, 1.0);
            double distance = Distance.GetDistanceBetween2PointsIn3D(point, Point3D.O);
            Console.WriteLine("Distance between {0} and {1} : {2}", point, Point3D.O, distance);
            Path p = new Path();
            Path points = PathStorage.Load("../../load.txt");
            foreach (var po in points.Points)
            {
                Console.WriteLine(po);
            }
            PathStorage.Save("../../save.txt", points);
        }
    }
}
