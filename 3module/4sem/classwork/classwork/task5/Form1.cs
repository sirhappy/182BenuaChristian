using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task5
{
    public partial class Form1 : Form
    {
        private CircleViewModel viewModel;

        public Form1()
        {
            InitializeComponent();
            circleRadiusUpDown.ValueChanged += CircleRadiusUpDown_ValueChanged;
            viewModel = new CircleViewModel(circlePictureBox);
            pickColorButton.Click += PickColorButton_Click;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            viewModel.Refresh();
        }

        private void PickColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                viewModel.penColor = dialog.Color;
            }
        }

        private void CircleRadiusUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numeric = (NumericUpDown)sender;

            try
            {
                viewModel.SetCircleRadius((double)numeric.Value);
            } catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
