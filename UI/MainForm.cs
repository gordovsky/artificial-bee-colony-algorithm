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


            int xmin = -10;
            int xmax = 10;

            int ymin = -10;
            int ymax = 10;
            
            InitializeGraph(xmin, xmax, ymin, ymax);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            label1.Text = "Iterations: " + Swarm.GetInstance().CurrentIteration;
            label2.Text = "Fittnes: " + Swarm.GetInstance().Fitness;
            
            //label3.Text = "Position: " + Swarm.Instance.Position.X + "," + Swarm.Instance.Position.Y;

            foreach (var curve in zedGraph.GraphPane.CurveList)
            {
                curve.Clear();
            }
            Swarm.GetInstance().Run();
            AddDataToGraph(zedGraph, Swarm.GetInstance().Agents.Where(a => a.Role == Agent.RoleTypes.Scout).Select(p => p.Position).ToList(), "Scout");
            AddDataToGraph(zedGraph, Swarm.GetInstance().Agents.Where(a => a.Role == Agent.RoleTypes.Employed).Select(p => p.Position).ToList(), "Employed");
            AddDataToGraph(zedGraph, Swarm.GetInstance().Agents.Where(a => a.Role == Agent.RoleTypes.Onlooker).Select(p => p.Position).ToList(), "Onlooker");

            zedGraph.AxisChange();
            
            zedGraph.Invalidate();
        }
        private void AddDataToGraph(ZedGraphControl zedGraph, List<ABC.Point> points, string label)
        {
            GraphPane myPane = zedGraph.GraphPane;
            if (points.Count > 1 && points[0].Coords.Length == 2)
            {
                foreach (var p in points)
                {
                    ((IPointListEdit)myPane.CurveList[label].Points).Add(p.Coords[0], p.Coords[1]);
                }
            }
            // force redraw
            zedGraph.Invalidate();
        }
        private void InitializeGraph(int xmin, int xmax, int ymin, int ymax)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && Swarm.GetInstance().Dimension == 2)
            {
                timer.Enabled = true;
            }
            else
            {
                while (Swarm.GetInstance().CurrentIteration < Swarm.GetInstance().Iterations || Math.Abs(Swarm.GetInstance().AverageFitness - Swarm.GetInstance().Fitness) <= 0.01)
                {
                    Swarm.GetInstance().Run();
                }
                Console.WriteLine("Finish...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)dimensionComboBox.SelectedItem == 2)
                checkBox1.Enabled = true;
            else
            {
                checkBox1.Enabled = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int scoutsCount = int.Parse(textBox1.Text);
            int employees = int.Parse(textBox2.Text);
            int onlookers = int.Parse(textBox3.Text);
            int bestPatches = int.Parse(textBox4.Text);
            int elitePatches = int.Parse(textBox5.Text);
            int dim = (int)dimensionComboBox.SelectedItem;

            int iterations = 100000;
            FitnessFunction func = FitnessFunctions.RosenbrocsSaddle;

            switch (comboBox1.SelectedItem.ToString())
            {
                case "RosenbrocsSaddle":
                    func = FitnessFunctions.RosenbrocsSaddle;
                    break;
                case "DeJongs":
                    func = FitnessFunctions.DeJongs;
                    break;
            }
            comboBox1.Enabled = false;
            dimensionComboBox.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            
            initializeButton.Enabled = false;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;


            Swarm.GetInstance().Initialize(func, dim, iterations, scoutsCount, employees, onlookers, bestPatches, elitePatches);
            

            sizeLabel.Text = "Swarm size: " + Swarm.GetInstance().Size;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
