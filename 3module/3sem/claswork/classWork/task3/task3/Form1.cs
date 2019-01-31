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
        public static Random rnd = new Random();
        private int counter = 0;
        private int clickCounter = 0;
        private Color[] arr = new Color[2] {Color.White, Color.Red};

        public Form1()
        {
            InitializeComponent();
            this.MouseEnter += (object sender, EventArgs e) => { this.Text = ("MyForm " + counter++); }
            ;
            this.MouseClick += (sender, args) => this.BackColor = this.arr[(++clickCounter) % 2];

            this.MouseDoubleClick += (sender, args) => this.Size = new Size(rnd.Next(100, 1000), rnd.Next(100, 1000));
        }
    }
}
