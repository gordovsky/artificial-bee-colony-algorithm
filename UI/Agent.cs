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
            Position = new Point(Swarm.Instance.Dimension);
            Role = role;
            if (role == RoleTypes.Scout)
            {
                if (!Swarm.Instance.Trail.ContainsKey(Position))
                    Swarm.Instance.Trail.Add(Position, GetFitness());
            }
            Fitness = GetFitness();
        }

        public double GetFitness()
        {
            var f = Swarm.Instance.FitFunction(Position);
            if (f > Swarm.Instance.Fitness)
            {
                Swarm.Instance.Fitness = f;
                Swarm.Instance.Position = Position;
                if (!Swarm.Instance.Trail.ContainsKey(Position))
                    Swarm.Instance.Trail.Add(Position, GetFitness());
                Console.WriteLine("New fitness :" + Swarm.Instance.Fitness + "Iteration:" + Swarm.Instance.CurrentIteration);
            }
            return f;
        }

        public void Search(Point anotherPosition)
        {
            double patchSize = 1;
            for (int i = 0; i < Swarm.Instance.Dimension; i++)
            {
                Position.Coords[i] = anotherPosition.Coords[i] + Swarm.Instance.Rnd.NextDouble() * patchSize - patchSize/2;
            }
            Fitness = GetFitness();
        }
        public void GlobalSearch()
        {
            double min = -5.12;
            double max = 5.12;
            for (int i = 0; i < Swarm.Instance.Dimension; i++)
            {
                var s = Swarm.Instance.Trail.Select(x => x.Key.Coords[i]).ToList();
                do
                {
                    var r = new Random();
                    Position.Coords[i] = Swarm.Instance.Rnd.NextDouble() * (max - min) + min;
                } while (!s.Any(z => Math.Abs(z - Position.Coords[i]) <= Math.Sqrt(Swarm.Instance.Dimension)*0.5));
            }
            if (!Swarm.Instance.Trail.ContainsKey(Position))
                Swarm.Instance.Trail.Add(Position, GetFitness());
            Fitness = GetFitness();
        }
    }
}
