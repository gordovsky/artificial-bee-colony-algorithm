using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    static class FitnessFunctions
    {
        public static double RosenbrocsSaddle(double[] coords)
        {
            double result = 0;
            for (int i = 0; i< coords.Length - 1; i++)
                result += (100 * Math.Pow(coords[i+1] - coords[i] * coords[i], 2) + Math.Pow(coords[i] - 1, 2));
            return result;
        }
        public static double DeJongs(double[] coords)
        {
            double result = 0;
            for (int i = 0; i < coords.Length; i++)
                result += (coords[i] * coords[i]);
            return result;
        }
    }
}
