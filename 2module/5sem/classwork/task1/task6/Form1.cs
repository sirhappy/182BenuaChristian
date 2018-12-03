using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1OnClick;
        }

        private void Button1OnClick(object sender, EventArgs e)
        {
            int number;
            if (!int.TryParse(textBox1.Text, out number))
            {
                MessageBox.Show("It's not a natural number", "ERROR", MessageBoxButtons.OK);
                return;
            }
            List<char> arr = new List<char>();
            for (int i = 0; i < textBox1.Text.Length; ++i)
            {
                arr.Add(textBox1.Text[i]);
            }
            arr.Sort();
            textBox1.Text = new String(arr.ToArray());
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
