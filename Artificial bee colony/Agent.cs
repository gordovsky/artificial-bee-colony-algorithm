using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    //public interface IAgent
    //{
    //    //double Speed { get; }
    //    int[] Vector { get; set; }
    //    Point PersonalBestPostition { get; set; }
    //    Point Position { get; set; }
    //    public double Fitness { get; set; }
    //    double C1 { get; set; } 
    //    double C2 { get; set; } 
    //    double Inert { get; set; }
    //} 
    public class Agent //: IAgent
    {
        //public double Speed { get; set; }
        public int[] Vector { get; set; }
        public Point Position { get; set; }
        public Point BestPostition { get; set; }
        //public double Fitness { get; set; }
        public double BestFitness { get; set; }
        public double C1 { get; set; } // personal best position memory factor 0.5
        public double C2 { get; set; } // swarm factor 0.5
        public double Inert { get; set; } // inertial weight 0.5
        //Point globalBestPositiob;
        public Agent(double c1, double c2, double inert)
        {
            C1 = c1;
            C2 = c2;
            Inert = inert;
            Vector = new int[2] { 0, 0 };
            Position = new Point(Swarm.Instance.Rnd.Next(-20,30), Swarm.Instance.Rnd.Next(-20,30));
            BestFitness = GetFitness();
            BestPostition = Position;
        }
        public double GetFitness()
        {
            var x = Position.X;
            var y = Position.Y;
            return -(x * x + y * y);// -0.1 * Math.Abs(1 - x) - 0.1 * Math.Abs(1 - y));
        }
        
        public void RecalculateSpeed()
        {
            var r1 = Swarm.Instance.Rnd.Next(-1, 1);
            var r2 = Swarm.Instance.Rnd.Next(-1, 1);
            //Speed = W * Speed + C1 * r1.Next(-1, 1) * (PersonalBestPostition - Position) + C2 * r2.Next(-1, 1) * (gbp - Position);
            //Speed = Inert * Speed + C1 * r1 * (PersonalBestPostition.DistanceTo(Position)) + C2 * r2 * (Swarm.Instance.BestPosition.DistanceTo(Position));
            Vector[0] = (int)(Inert * Vector[0] + C1 * r1 * (BestPostition.X - Position.X) + 
                        C2 * r2 * (Swarm.Instance.BestPosition.X - Position.X));
            Vector[1] = (int)(Inert * Vector[0] + C1 * r1 * (BestPostition.Y - Position.Y) + 
                        C2 * r2 * (Swarm.Instance.BestPosition.Y - Position.Y));
        }
        public void Move()
        {
            Position.X = Position.X + Vector[0];
            Position.Y = Position.Y + Vector[1];
        }
    }
}
