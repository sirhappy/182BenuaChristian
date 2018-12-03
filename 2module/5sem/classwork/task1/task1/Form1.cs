using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1OnClick;
            button2.Click += Button2OnClick;
        }

        private void Button2OnClick(object sender, EventArgs e)
        {
            button2.Visible = false;
            button2.Enabled = false;
            button1.Visible = true;
            button1.Enabled = true;
        }

        private void Button1OnClick(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Where is the button?";
            StartPosition = FormStartPosition.CenterScreen;
            button1.Visible = false;
        }
    }
}
