using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace task2
{
    public partial class Form1 : Form
    {
        public Timer timer = new Timer();
        public double step = 0.1;
        public bool ended = false;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Cheshire Cat";
            label1.ForeColor = Color.BlueViolet;
            timer.Interval = 500;
            timer.Tick += TimerOnTick;
            timer.Enabled = true;
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            if (label1.Text.Length > 0 && step > 0)
            {
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
            }
            else if (!ended)
            {
                if (this.Opacity <= 0)
                {
                    step *= -1;
                    label1.Text = "Cat is gone";
                }

                this.Opacity -= step;
                

                if (this.Opacity >= 1)
                {
                    ended = true;
                }
            }
            
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
