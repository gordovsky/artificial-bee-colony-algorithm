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
    class Agent : IAgent
    {
        double Speed { get; set; }
        Point PersonalBestPostition { get; set; }
        Point Position { get; set; }
        double C1 { get; set; } // pbp memory factor 0.5
        double C2 { get; set; } // swarm factor 0.5
        double W { get; set; } // inertial weight 0.5
        //Point globalBestPositiob;
        public Agent()
        {
            Manager.Instance.Add(this);
        }
        public void Fittness()
        {
        }
        private void RecalculateVelocity()
        {
            Random r1 = new Random();
            Random r2 = new Random();
            Speed = W * Speed + C1 * r1.Next(-1, 1) * (PersonalBestPostition - Position) + C2 * r2.Next(-1, 1) * (gbp - Position);
        }
    }
}
