using ABC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Swarm.Instance.Initialize(10, 10, 5, 2, 3, 10, 100000, zedGraph);
            
            int xmin = -100;
            int xmax = 100;

            int ymin = -100;
            int ymax = 100;
            
            InitializeGraph(xmin, xmax, ymin, ymax);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            label1.Text = "Iterations: " + Swarm.Instance.CurrentIteration;
            label2.Text = "Fittnes: " + Swarm.Instance.Fitness;
            label3.Text = "Position: " + Swarm.Instance.Position.X + "," + Swarm.Instance.Position.Y;

            foreach (var curve in zedGraph.GraphPane.CurveList)
            {
                curve.Clear();
            }
            Swarm.Instance.Run();
            AddDataToGraph(zedGraph, Swarm.Instance.Agents.Where(a => a.Role == Agent.RoleTypes.Scout).Select(p => p.Position).ToList(), "Scout");
            AddDataToGraph(zedGraph, Swarm.Instance.Agents.Where(a => a.Role == Agent.RoleTypes.Employed).Select(p => p.Position).ToList(), "Employed");
            AddDataToGraph(zedGraph, Swarm.Instance.Agents.Where(a => a.Role == Agent.RoleTypes.Onlooker).Select(p => p.Position).ToList(), "Onlooker");

            zedGraph.AxisChange();
            
            zedGraph.Invalidate();
        }
        public void AddDataToGraph(ZedGraphControl zedGraph, List<ABC.Point> points, string label)
        {
            GraphPane myPane = zedGraph.GraphPane;

            foreach (var p in points)
            {
                ((IPointListEdit)myPane.CurveList[label].Points).Add(p.X, p.Y);
            }
            // force redraw
            zedGraph.Invalidate();
        }
        public void InitializeGraph(int xmin, int xmax, int ymin, int ymax)
        {
            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();

            LineItem Scout = pane.AddCurve("Scout", new PointPairList(), Color.Blue, SymbolType.Diamond);
            LineItem Onlooker = pane.AddCurve("Onlooker", new PointPairList(), Color.Green, SymbolType.Triangle);
            LineItem Employed = pane.AddCurve("Employed", new PointPairList(), Color.Red, SymbolType.Star);

            Scout.Line.IsVisible = false;
            Onlooker.Line.IsVisible = false;
            Employed.Line.IsVisible = false;

            Scout.Symbol.Fill.Color = Color.Red;
            Onlooker.Symbol.Fill.Color = Color.Blue;
            Employed.Symbol.Fill.Color = Color.Purple;

            Scout.Symbol.Fill.Type = FillType.Solid;
            Onlooker.Symbol.Fill.Type = FillType.Solid;
            Employed.Symbol.Fill.Type = FillType.Solid;

            Scout.Symbol.Size = 7;
            Onlooker.Symbol.Size = 7;
            Employed.Symbol.Size = 7;

            pane.XAxis.Scale.Min = xmin;
            pane.XAxis.Scale.Max = xmax;

            pane.YAxis.Scale.Min = ymin;
            pane.YAxis.Scale.Max = ymax;

            zedGraph.AxisChange();
            zedGraph.Invalidate();
            zedGraph.Refresh();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

        //private void label3_Click(object sender, EventArgs e)
        //{

        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
