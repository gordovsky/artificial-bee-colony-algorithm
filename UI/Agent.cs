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
            Position = new Point(Swarm.Instance.Rnd.Next(-40,40), Swarm.Instance.Rnd.Next(-40,40));
            Fitness = GetFitness();
            Role = role;
        }

        public double GetFitness()
        {
            var x = Position.X;
            var y = Position.Y;
            var f = Swarm.Instance.Function(x, y);
            if (f > Swarm.Instance.Fitness)
            {
                Swarm.Instance.Fitness = f;
                Swarm.Instance.Position = Position;
                Console.WriteLine("New fitness :" + Swarm.Instance.Fitness + " coords: " + Position.X + "," + Position.Y);
            }
            return f;
        }

        public void Move(Point anotherPosition)
        {
            var r1 = Swarm.Instance.Rnd.Next(-Swarm.Instance.PatchSize, Swarm.Instance.PatchSize);
            var r2 = Swarm.Instance.Rnd.Next(-Swarm.Instance.PatchSize, Swarm.Instance.PatchSize);
            Position.X = anotherPosition.X + r1;
            Position.Y = anotherPosition.Y + r2;
            Fitness = GetFitness();
        }
        //public void GlobalSearch()
        //{
        //    var r1 = Swarm.Instance.Rnd.Next(-Swarm.Instance.PatchSize, Swarm.Instance.PatchSize);
        //    var r2 = Swarm.Instance.Rnd.Next(-Swarm.Instance.PatchSize, Swarm.Instance.PatchSize);
        //    Position.X = anotherPosition.X + r1;
        //    Position.Y = anotherPosition.Y + r2;
        //    Fitness = GetFitness();
        //}
        public void MoveRandom()
        {
            var r1 = Swarm.Instance.Rnd.Next(-40, 40);
            var r2 = Swarm.Instance.Rnd.Next(-40, 40);
            Position.X = r1;
            Position.Y = r2;
            Fitness = GetFitness();
        }
    }
}
