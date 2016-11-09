using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artificial_bee_colony
{
    class Swarm
    {
        Point bestPosition;
        Agent[] bees; 
        public Swarm()
        {

        }
    }
    class Point
    {
        int x;
        int y;
        public Point() { }
    }
    class Agent
    {
        double velocity;
        Point personalBestPostition;
        //Point globalBestPositiob;
        public Agent()
        {

        }
        private void recalculateVelocity()
        {

        }
    }
}
