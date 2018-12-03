using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task7
{
    public partial class Form1 : Form
    {
        private bool decreasing = true;
        private Size mnSize = new Size(200, 200);
        private Size mxSize = new Size(800, 800);
        public Form1()
        {
            InitializeComponent();
            deincreaseButton.Click += DeincreaseButtonOnClick;
            this.Size = mxSize;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += OnResize;
            RepositionButton();
        }

        private void OnResize(object sender, EventArgs e)
        {
            RepositionForm();
            RepositionButton();
        }

        private void RepositionForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void RepositionButton()
        {
            if (decreasing)
            {
                deincreaseButton.Text = "Decrease size";
            }
            else
            {
                deincreaseButton.Text = "Increase size";
            }
            deincreaseButton.Location = new Point(this.Width / 2 - deincreaseButton.Width / 2, this.Height / 2 - deincreaseButton.Height / 2);
        }

        private void DeincreaseButtonOnClick(object sender, EventArgs e)
        {
            double dx = decreasing ? 2.0/3.0 : 3.0/2.0;
            this.Size = new Size((int)(this.Size.Width * dx), (int)(this.Size.Height * dx));
            if (this.Size.Width <= mnSize.Width || this.Size.Height <= mnSize.Height)
            {
                decreasing = false;
            }

            if (this.Size.Width > mxSize.Width || this.Size.Height > mxSize.Height)
            {
                decreasing = true;
            }
            RepositionButton();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
