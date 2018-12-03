using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task9
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        private Satellite satellite;
        private int EarthRad = 50;
        private int tickNumber = 0;
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 20;
            timer.Enabled = true;
            timer.Tick += TimerOnTick;
            timer.Start();
            satellite = new Satellite(pictureBox1.Width / 2, pictureBox1.Height/2, Math.PI / 18 / 5, 10, Math.Min(pictureBox1.Width / 2, pictureBox1.Height / 2) - 40, 20, 2);
            this.Resize += OnResize;
        }

        private void OnResize(object sender, EventArgs e)
        {
            satellite.Center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            satellite.orbitSpiral.MaxValue = Math.Min(pictureBox1.Width / 2, pictureBox1.Height / 2) - 40;
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            (pictureBox1.Image)?.Dispose();
            Point center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            Point leftTopCorner = center - new Point(EarthRad, EarthRad) / 2;
            Bitmap currImage = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            using (var g = Graphics.FromImage(currImage))
            {
                g.FillEllipse(new SolidBrush(Color.Green), (float)leftTopCorner.X, (float)leftTopCorner.Y, EarthRad, EarthRad);
            }
            satellite.Draw(currImage, tickNumber);
            tickNumber++;
            pictureBox1.Image = currImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
