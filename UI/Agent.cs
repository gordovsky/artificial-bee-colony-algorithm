﻿using System;
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
            if (role == RoleTypes.Scout)
            {
                if (!Swarm.GetInstance().Trail.ContainsKey(Position))
                    Swarm.GetInstance().Trail.Add(Position, GetFitness());
            }
            Fitness = GetFitness();
        }

        public double GetFitness()
        {
            var f = Swarm.GetInstance().FitFunction(Position);
            if (f > Swarm.GetInstance().Fitness)
            {
                Swarm.GetInstance().Fitness = f;
                Swarm.GetInstance().Position = Position;
                if (!Swarm.GetInstance().Trail.ContainsKey(Position))
                    Swarm.GetInstance().Trail.Add(Position, GetFitness());
                Console.WriteLine("New fitness :" + Swarm.GetInstance().Fitness + "Iteration:" + Swarm.GetInstance().CurrentIteration);
            }
            return f;
        }

        public void Search(Point position)
        {
            for (int i = 0; i < Swarm.GetInstance().Dimension; i++)
            {
                double min = -(Swarm.GetInstance().PatchSize/2);
                double max = Swarm.GetInstance().PatchSize / 2;
                Position.Coords[i] = position.Coords[i] + Swarm.GetInstance().Rnd.NextDouble() * (max - min) + min;// position.Coords[i] + r.NextDouble() * Swarm.GetInstance().PatchSize - Swarm.GetInstance().PatchSize/2;
            }
            Fitness = GetFitness();
        }
        public void GlobalSearch()
        {
            double min = -5.12;
            double max = 5.12;
            for (int i = 0; i < Swarm.GetInstance().Dimension; i++)
            {
                //var r = new Random();
                Position.Coords[i] = Swarm.GetInstance().Rnd.NextDouble() * (max - min) + min;
                var s = Swarm.GetInstance().Trail.Select(x => x.Key.Coords[i]).ToList();
                do
                {
                    var r = new Random();
                    Position.Coords[i] = Swarm.GetInstance().Rnd.NextDouble() * (max - min) + min;
                } while (!s.Any(z => Math.Abs(z - Position.Coords[i]) <= Math.Sqrt(Swarm.GetInstance().Dimension) * Swarm.GetInstance().PatchSize / 2));
            }
            if (!Swarm.GetInstance().Trail.ContainsKey(Position))
                Swarm.GetInstance().Trail.Add(Position, GetFitness());
            Fitness = GetFitness();
        }
    }
}
