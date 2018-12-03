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
    public partial class Form1 : Form
    {
        public int selectedIndex = 0;
        string[] originArr = new string[7] { "first", "second", "third", "forth", "fifth", "sixth", "seventh" };

        public Form1()
        {
            InitializeComponent();
            listBox1.Items.AddRange(originArr);
            listBox1.SelectedIndexChanged += ListBox1OnSelectedIndexChanged;
           
            button2.Click += Button2OnClick;
            button1.Click += Button1OnClick;
        }

        private void Button1OnClick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(originArr);
            listBox1.Refresh();
        }

        private void Button2OnClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("List is empty or nothing is selected, you can't delete anything ", "Error", MessageBoxButtons.OK);
                return;
            }

            

            listBox1.Items.RemoveAt(selectedIndex);
            listBox1.Refresh();
        }

        private void ListBox1OnSelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listBox1.SelectedIndex;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
