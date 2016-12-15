using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using ZedGraph;

namespace ABC
{
    public delegate double FitnessFunction(Point point);
    class Swarm
    {
        private static Swarm instance;
        private static object syncRoot = new object();
        private Swarm()
        {
            Agents = new List<Agent>();
            Rnd = new Random();
            BestPatches = new List<Point>();
            ElitePatches = new List<Point>();
            Trail = new Dictionary<Point, double>();
        }
        public static Swarm GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Swarm();
                    }
                }
            }
            return instance;
        }
        
        public void Initialize(FitnessFunction func, int dim = 2, int iterations = 100000, 
                        int scoutsCount = 10, int bestAgentsCount = 5, int eliteAgentsCount = 2,
                        int bestPatchesCount = 3, int elitePatchesCount = 2, int patchSize = 1)
        {
            PatchSize = patchSize;
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

            var topAgent = Agents.OrderBy(a => a.Fitness).Reverse().First();
            Position = topAgent.Position;
            Fitness = topAgent.Fitness;
            AverageFitness = Agents.Sum(a => a.Fitness)/Size;
            

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


            var BestPatchesList = Trail
                            .OrderBy(a => a.Value)
                            .Reverse()
                            .Take(BestPatchesCount);


            var emp = Agents.Where(x => x.Role == Agent.RoleTypes.Employed).ToList();
            var lookers = Agents.Where(x => x.Role == Agent.RoleTypes.Onlooker).ToList();



            int c1 = 0;
            int c2 = 0;
            foreach(var p in BestPatches)
            {
                var ag = Agents.Where(x => x.Role == Agent.RoleTypes.Employed)
                    .Skip(c1 * BestAgentsCount)
                    .Take(BestAgentsCount); //.ToList()
                    //.ForEach(a => a.Search(p));
                foreach (var a in ag)
                {
                    a.Search(p);
                }
                c1++;
            }
            foreach (var p in ElitePatches)
            {
                var ag = Agents.Where(x => x.Role == Agent.RoleTypes.Onlooker)
                    .Skip(c2 * EliteAgentsCount)
                    .Take(EliteAgentsCount); //.ToList()
                    //.ForEach(a => a.Search(p));
                foreach (var a in ag)
                {
                    a.Search(p);
                }
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
        public double PatchSize { get; set; }
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
