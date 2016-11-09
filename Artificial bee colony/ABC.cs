using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    public class Manager
    {
        public static readonly Instance = new Manager();
        Manager();
        List<IAgent> agents = new List<IAgent>();
        public void AddAgent(IAgent agent)
        {

        }
    }
    class Swarm
    {
        Point BestPosition { get; set; }
        Agent[] Bees; 
        public Swarm()
        {

        }
    }
    public class Point
    {
        int X;
        int Y;
        public Point() { }
    }

}
