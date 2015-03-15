using System.Collections.Generic;
namespace Point
{
    public class Path
    {
        public List<Point3D> Points
        {
            get;
            private set;
        }

        public Path()
        {
            this.Points = new List<Point3D>();
        }
    }
}
