using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    static class FitnessFunctions
    {
        public static double RosenbrocsSaddle(int x, int y)
        {
            return -(Math.Pow(1 - x, 2) + 100 * Math.Pow(y - x * x, 2));
        }
        public static double DeJongs(int x, int y)
        {
            return -(x * x + y * y);
        }
    }
}
