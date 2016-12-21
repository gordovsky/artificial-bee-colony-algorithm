using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;

namespace ABC
{
    public class Agent //: IAgent
    {
        public Point Position { get; set; }
        public double Fitness { get; set; }
        public RoleTypes Role { get; set; }
        public enum RoleTypes
        {
            Scout,
            Onlooker,
            Employed
        }

        public Agent(RoleTypes role)
        {
            Position = new Point(Swarm.GetInstance().Dimension);
            Role = role;
            Fitness = GetFitness(Position.Coords);
        }

        public double GetFitness(double[] coords)
        {
            double currentFit = Swarm.GetInstance().FitFunction(coords);
            if (currentFit < Swarm.GetInstance().Fitness)
            {
                Console.WriteLine("New fitness :" + Swarm.GetInstance().Fitness + "   Iteration:" + Swarm.GetInstance().CurrentIteration);
                Swarm.GetInstance().Fitness = currentFit;
                Swarm.GetInstance().Position.Coords = coords;
                if (!Swarm.GetInstance().Trail.ContainsKey(Position.Coords))
                {
                    var newPoint = new double[Swarm.GetInstance().Dimension];
                    for (int i = 0; i < Swarm.GetInstance().Dimension; i++)
                    {
                        newPoint[i] = Position.Coords[i];
                    }
                    Swarm.GetInstance().Trail.Add(newPoint, currentFit);
                }
            }
            Swarm.GetInstance().FittnessCallsCounter++;
            return currentFit;
        }

        public void Search(double[] coords)
        {
            var randomIndex = Swarm.GetInstance().Rnd.Next(0, Swarm.GetInstance().Dimension);

            double min = coords[randomIndex] - (Swarm.GetInstance().PatchSize / 2);
            double max = coords[randomIndex] + Swarm.GetInstance().PatchSize / 2;
            var newcoord = Swarm.GetInstance().Rnd.NextDouble() * (max - min) + min;
            this.Position.Coords[randomIndex] = newcoord;
            Fitness = GetFitness(Position.Coords);
        }
        public void GlobalSearch()
        {
            double min = -5.12;
            double max = 5.12;
            var gap = Math.Sqrt(Swarm.GetInstance().Dimension * Math.Pow((Swarm.GetInstance().PatchSize / 2), 2));
            for (int i = 0; i < Swarm.GetInstance().Dimension; i++)
            {
                Position.Coords[i] = Swarm.GetInstance().Rnd.NextDouble() * (max - min) + min;
                var s = Swarm.GetInstance().Trail.Select(x => x.Key[i]).ToList();
                do
                {
                    Position.Coords[i] = Swarm.GetInstance().Rnd.NextDouble() * (max - min) + min;
                } while (!s.Any(z => Math.Abs(z - Position.Coords[i]) <= gap));
            }
            Fitness = GetFitness(Position.Coords);
        }
    }
}
