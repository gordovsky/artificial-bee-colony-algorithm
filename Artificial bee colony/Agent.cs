using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    public interface IAgent
    {
        double Speed { get; }
        Point PersonalBestPostition { get; }
        Point Position { get; }
        double C1 { get; } 
        double C2 { get; } 
        double W { get; }
    } 
    public class Agent : IAgent
    {
        public double Speed { get; set; }
        public Point PersonalBestPostition { get; set; }
        public Point Position { get; set; }
        public double C1 { get; set; } // pbp memory factor 0.5
        public double C2 { get; set; } // swarm factor 0.5
        public double W { get; set; } // inertial weight 0.5
        //Point globalBestPositiob;
        public Agent()
        {
            //Manager.Instance.Add(this);
        }
        public void Fittness()
        {
        }
        private void RecalculateVelocity()
        {
            Random r1 = new Random();
            Random r2 = new Random();
            //Speed = W * Speed + C1 * r1.Next(-1, 1) * (PersonalBestPostition - Position) + C2 * r2.Next(-1, 1) * (gbp - Position);
            Speed = W * Speed + C1 * r1.Next(-1, 1) * (PersonalBestPostition.Distance(Position)) + C2 * r2.Next(-1, 1) * (Swarm.Instance.BestPosition.Distance(Position));
        }
    }
}
