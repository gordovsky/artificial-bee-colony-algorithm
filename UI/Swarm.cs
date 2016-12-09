using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using ZedGraph;

namespace ABC
{
    public delegate double FitnessFunction(Point point);
    public class Swarm
    {
        private static readonly Swarm instance = new Swarm();
        private Swarm()
        {
            Agents = new List<Agent>();
            Rnd = new Random();
            BestPatches = new List<Point>();
            ElitePatches = new List<Point>();
            Trail = new Dictionary<Point, double>();
        }
        public static Swarm Instance
        {
            get
            {
                return instance;
            }
        }
        
        public void Initialize(FitnessFunction func, int dim = 2, int iterations = 100000, 
                        int scoutsCount = 10, int bestAgentsCount = 5, int eliteAgentsCount = 2,
                        int bestPatchesCount = 2, int elitePatchesCount = 3)
        {
            //PatchSize = patchSize;
            Size = scoutsCount + bestAgentsCount * bestPatchesCount + eliteAgentsCount * elitePatchesCount;
            Iterations = iterations;
            BestAgentsCount = bestAgentsCount;
            EliteAgentsCount = eliteAgentsCount;
            BestPatchesCount = bestPatchesCount;
            ElitePatchesCount = elitePatchesCount;
            FitFunction = FitnessFunctions.RosenbrocsSaddle;
            Dimension = dim;
            CurrentIteration = 0;

            // first agents initialization
            for (int i = 0; i < scoutsCount; i++) { Agents.Add(new Agent(Agent.RoleTypes.Scout)); }

            for (int i = 0; i < bestAgentsCount * bestPatchesCount; i++) { Agents.Add(new Agent(Agent.RoleTypes.Employed)); }
            for (int i = 0; i < eliteAgentsCount * elitePatchesCount; i++) { Agents.Add(new Agent(Agent.RoleTypes.Onlooker)); }

            var topScout = Agents.Where(a => a.Role == Agent.RoleTypes.Scout)
                            .OrderBy(a => a.Fitness)
                            .Reverse().First();

            Fitness = topScout.Fitness;
            AverageFitness = Agents.Sum(a => a.Fitness)/Size;
            Position = topScout.Position;

            Console.WriteLine("Fitness: " + Fitness + "Iteration" + CurrentIteration);
        }
        public void Run()
        {
            AverageFitness = Agents.Sum(a => a.Fitness) / Size;

            var BestPatches = Trail
                            .OrderBy(a => a.Value)
                            .Reverse()
                            .Take(BestPatchesCount)
                            .Select(s => s.Key);
            var ElitePatches = Trail
                            .OrderBy(a => a.Value)
                            .Reverse()
                            .Skip(BestPatchesCount)
                            .Take(ElitePatchesCount)
                            .Select(s => s.Key);



            int c1 = 0;
            int c2 = 0;
            foreach(var patch in BestPatches)
            {
                Agents.Where(x => x.Role == Agent.RoleTypes.Employed).Skip(c1* BestPatchesCount).Take(BestAgentsCount).ToList().ForEach(a => a.Search(patch));
                c1++;
            }
            foreach (var patch in ElitePatches)
            {
                Agents.Where(x => x.Role == Agent.RoleTypes.Onlooker).Skip(c2* ElitePatchesCount).Take(EliteAgentsCount).ToList().ForEach(a => a.Search(patch));
                c2++;
            }

            Agents.Where(x => x.Role == Agent.RoleTypes.Scout).ToList().ForEach(a => a.GlobalSearch());
            CurrentIteration += 1;
        }

        public int Dimension;
        public Dictionary<Point, double> Trail { get; set; }
        public FitnessFunction FitFunction { get; set; }
        public int Iterations { get; set; }
        public int CurrentIteration { get; set; }
        public Point Position { get; set; }
        public double Fitness { get; set; }
        public double AverageFitness { get; set; }
        public int Size { get; set; }
        //public int PatchSize { get; set; }
        public List<Point> BestPatches { get; set; }
        public int BestPatchesCount { get; set; }
        public List<Point> ElitePatches { get; set; }
        public int ElitePatchesCount { get; set; }
        public List<Agent> Agents { get; set; }
        public int BestAgentsCount { get; set; }
        public int EliteAgentsCount { get; set; }
        public Random Rnd { get; }
    }
}
