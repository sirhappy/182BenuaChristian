using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3
{
    public partial class Form1 : Form
    {
        private List<long> PellSeries = new List<long>();
        public Form1()
        {
            InitializeComponent();
            PellSeries.Add(1);
            PellSeries.Add(2);
            label1.Text = "Pell series element is : 2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PellSeries.Add(PellSeries[PellSeries.Count - 1] * 2 + PellSeries[PellSeries.Count - 2]);
            if (PellSeries.Last() > 1e9)
            {
                MessageBox.Show("Lets begin from scratch", "Overflow happened", MessageBoxButtons.OK);
                PellSeries.Clear();
                PellSeries.Add(1);
                PellSeries.Add(2);
            }
            label1.Text = "Pell series element is : " +  PellSeries.Last().ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
