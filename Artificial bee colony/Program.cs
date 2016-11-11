using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BEEEEEES!");
            Swarm.Instance.Run(0.5, 0.5, 0.5, 3);
           
            Console.WriteLine("Finished...");
            Console.ReadLine();
        }
    }
}
