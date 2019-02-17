using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4
{

    public static class RandomContainer
    {
        private static Random rnd = new Random();

        public static double NextDouble(double mn, double mx)
        {
            return rnd.NextDouble() * (mx - mn) + mn;
        }

        public static int Next(int mn, int mx)
        {
            return rnd.Next(mn, mx);
        }
    }

    public class Estimates
    {
        public double MinValue { get; private set; }
        public double MaxValue { get; private set; }

        private List<double> values;

        public Estimates(int mn, int mx)
        {
            MinValue = mn;
            MaxValue = mx;
            values = new List<double>();
            values.Add(RandomContainer.NextDouble(MinValue, MaxValue));
            values.Add(RandomContainer.NextDouble(MinValue, MaxValue));
        }

        public void Add()
        {
            values.Add(RandomContainer.NextDouble(MinValue, MaxValue));
            NotifyOnPropertyChanged?.Invoke();
        }

        public int Count => values.Count;

        private double Sum => (double)values.Aggregate((a, b) => a + b);

        public double Average => Sum / values.Count;

        private double SquareSum => (double)values.Aggregate((a, b) => a + b * b);

        public double Deviation => Math.Sqrt(SquareSum / (values.Count - 1) - Sum * Sum / (values.Count - 1) / (values.Count));

        public event Action NotifyOnPropertyChanged;
    }

    public partial class Form1 : Form
    {
        Estimates estimates = new Estimates(0, 1);

        public Form1()
        {
            InitializeComponent();
            ShowDetailsButton.Click += ShowDetailsButton_Click;
            AddButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            estimates.Add();
        }

        private void ShowDetailsButton_Click(object sender, EventArgs e)
        {
            DetailsWindow w = new DetailsWindow(estimates);
            w.Show();
        }
    }
}
