using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    public class Swarm
    {
        private static readonly Swarm instance = new Swarm();
        private Swarm() { }
        public static Swarm Instance
        {
            get
            {
                return instance;
            }
        }
        public void Run(double C1, double C2, double W, int swarmSize)
        {
            // initialization
            for (int i = 1; i< swarmSize; i++)
            {

            }
            //double C1 { get; set; } // pbp memory factor 0.5
            //double C2 { get; set; } // swarm factor 0.5
            //double W { get; set; } // inertial weight 0.5
        }
        public void Test()
        {
            Console.WriteLine("singletone works");
        }
        public Point BestPosition { get; set; }
        public Agent[] Bees; 
    }
}
