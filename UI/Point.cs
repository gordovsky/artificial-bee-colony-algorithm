using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    public class Point
    {
        public double[] Coords;  
        public Point(int dim)
        {
            double min = -5.12;
            double max = 5.12; 
            Coords = new double[dim];
            for (int i = 0; i< Coords.Length; i++)
            {
                Coords[i] = Swarm.GetInstance().Rnd.NextDouble() * (max - min) + min;
            }
        }
        public Point(double[] coords)
        {
            Coords = coords;
        }
    }
}
