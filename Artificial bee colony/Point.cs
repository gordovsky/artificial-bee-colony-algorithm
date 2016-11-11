using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        //public double DistanceTo(Point point)
        //{
        //    var x = X - point.X;
        //    var y = Y - point.Y;
        //    return x * x + y * y;
        //}
        
    }

}
