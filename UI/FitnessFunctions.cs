using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    static class FitnessFunctions
    {
        public static double RosenbrocsSaddle(Point p)
        {
            double result = 0;
            for (int i = 0; i< p.Coords.Length - 1; i++)
                result += -(100 * Math.Pow(p.Coords[i+1] - p.Coords[i] * p.Coords[i], 2) + Math.Pow(1 - p.Coords[i], 2));
            return result;
        }
        public static double DeJongs(Point p)
        {
            double result = 0;
            for (int i = 0; i < p.Coords.Length; i++)
                result += -(p.Coords[i] * p.Coords[i]);
            return result;
        }
    }
}
