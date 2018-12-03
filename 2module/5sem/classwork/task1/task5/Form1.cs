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
        string[] originArr = new string[]{ "first", "second", "third" };
        private List<String> linesInTextBox = new List<String>();
        public Form1()
        {
            InitializeComponent();
            linesInTextBox = new List<string>(originArr);
            textBox1.TextChanged += TextBox1OnTextChanged;
            button1.Click += Button1OnClick;
            UpdateTextBox();
            button2.Click += Button2OnClick;
        }

        private void Button2OnClick(object sender, EventArgs e)
        {
            MessageBox.Show(getFormedText(" ").Replace("\r", " "), "Text in array", MessageBoxButtons.OK);
        }

        private string getFormedText(string delim)
        {
            string formedText = "";
            for (int i = 0; i < linesInTextBox.Count; ++i)
            {
                formedText += linesInTextBox[i] + delim;
            }

            return formedText;
        }

        private void UpdateTextBox()
        {
            textBox1.Text = getFormedText("\r\n");
        }

        private void Button1OnClick(object sender, EventArgs e)
        {
            linesInTextBox = new List<string>(originArr);
            UpdateTextBox();
        }

        private void TextBox1OnTextChanged(object sender, EventArgs e)
        {
            int numberOnLine = 0;
            linesInTextBox = new List<string>();
            linesInTextBox.Add("");
            for (int i = 0; i < textBox1.Text.Length; ++i)
            {
                if (textBox1.Text[i] == '\n')
                {
                    linesInTextBox.Add("");
                }
                else
                {
                    linesInTextBox[linesInTextBox.Count - 1] += textBox1.Text[i];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
