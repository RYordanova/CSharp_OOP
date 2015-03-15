using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    public static class PathStorage
    {
        public static void Save(string filePath, Path points)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < points.Points.Count; i++)
                {
                    writer.WriteLine(points.Points[i]);
                }
            }
        }

        public static Path Load(string filePath)
        {
            Path points = new Path();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    double[] coords = line.Split(new char[] { ' ', '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                    Point3D point = new Point3D(coords[0], coords[1], coords[2]);
                    points.Points.Add(point);
                }
            }
            return points;
        }
    }
}
