using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task8
{
    public partial class Form1 : Form
    {
        private int x = 0, y = 0;
        private const int width = 100, height = 100;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = SystemColors.ActiveCaptionText;
            Paint += OnPaint;
            trackBar1.Scroll += TrackBar1OnScroll;
            
        }

        private void TrackBar1OnScroll(object sender, EventArgs e)
        {
            x = trackBar1.Value;
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            trackBar1.Maximum =  -width + this.Bounds.Size.Width - 15;
            e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlDark), x,y, width, height);
            this.TransparencyKey = SystemColors.ControlDark;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
