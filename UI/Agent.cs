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
            Fitness = GetFitness();
            if (!Swarm.GetInstance().Trail.ContainsKey(Position))
                Swarm.GetInstance().Trail.Add(Position, Fitness);
            
        }

        public double GetFitness()
        {
            double currentFit = Swarm.GetInstance().FitFunction(Position);
            var swf = Swarm.GetInstance().Fitness;
            var BestPatchesList = Swarm.GetInstance().Trail.OrderBy(p => p.Value).Take(3);
            if (currentFit < Swarm.GetInstance().Fitness)
            {
                Swarm.GetInstance().Fitness = Swarm.GetInstance().FitFunction(Position);
                Swarm.GetInstance().Position = Position;
                if (!Swarm.GetInstance().Trail.ContainsKey(Position))
                    Swarm.GetInstance().Trail.Add(Position, currentFit);
                Console.WriteLine("New fitness :" + Swarm.GetInstance().Fitness + "   Iteration:" + Swarm.GetInstance().CurrentIteration);
            }
            return currentFit;
        }

        public void Search(Point position)
        {
            var randomIndex = Swarm.GetInstance().Rnd.Next(0, Swarm.GetInstance().Dimension);

            double min = position.Coords[randomIndex] - (Swarm.GetInstance().PatchSize / 2);
            double max = position.Coords[randomIndex] + Swarm.GetInstance().PatchSize / 2;

            Position.Coords[randomIndex] = Swarm.GetInstance().Rnd.NextDouble() * (max - min) + min;
            Fitness = GetFitness();
        }
        public void GlobalSearch()
        {
            double min = -5.12;
            double max = 5.12;
            var gap = Math.Sqrt(Swarm.GetInstance().Dimension * Math.Pow((Swarm.GetInstance().PatchSize / 2), 2));
            for (int i = 0; i < Swarm.GetInstance().Dimension; i++)
            {
                Position.Coords[i] = Swarm.GetInstance().Rnd.NextDouble() * (max - min) + min;
                var s = Swarm.GetInstance().Trail.Select(x => x.Key.Coords[i]).ToList();
                do
                {
                    var r = new Random();
                    Position.Coords[i] = Swarm.GetInstance().Rnd.NextDouble() * (max - min) + min;
                } while (!s.Any(z => Math.Abs(z - Position.Coords[i]) <= gap));
            }
            if (!Swarm.GetInstance().Trail.ContainsKey(Position))
                Swarm.GetInstance().Trail.Add(Position, GetFitness());
            Fitness = GetFitness();
        }
    }
}
