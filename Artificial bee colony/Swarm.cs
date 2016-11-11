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
        private Swarm()
        {
            Agents = new List<Agent>();
            Rnd = new Random(); 
        }
        public static Swarm Instance
        {
            get
            {
                return instance;
            }
        }
        public void Run(double c1, double c2, double inert, int swarmSize)
        {
            // initialization
            for (int i = 0; i< swarmSize; i++)
            {
                Swarm.Instance.Agents.Add(new Agent(c1, c2, inert));
                if (Swarm.Instance.BestPosition == null)
                {
                    Swarm.Instance.BestPosition = Agents[i].Position;
                    Swarm.Instance.BestFitness = Agents[i].GetFitness();
                }
            }
            // searching
            for (int i = 0; i< 40; i++) 
            {
                for(int k = 0; k < Swarm.Instance.Agents.Count(); k++ )
                {
                    Agents[k].RecalculateSpeed();
                    Agents[k].Move();

                    Console.WriteLine("Agent's fitness: " + Agents[k].GetFitness());

                    if (Agents[k].GetFitness() > Swarm.Instance.BestFitness)
                    {
                        Agents[k].BestFitness = Agents[k].GetFitness();
                        Agents[k].BestPostition = Agents[k].Position;
                        Swarm.Instance.BestFitness = Agents[k].GetFitness();
                        Swarm.Instance.BestPosition = Agents[k].Position;

                        //Console.WriteLine(Swarm.Instance.BestFitness);
                    }
                }
            }
        }
        public Point BestPosition { get; set; }
        public double BestFitness { get; set; }
        public List<Agent> Agents { get; set; }
        public Random Rnd { get; }
    }
}
