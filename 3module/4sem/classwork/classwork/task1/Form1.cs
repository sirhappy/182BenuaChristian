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

        private string eventsContainer = "";

        public Form1()
        {
            InitializeComponent();
            this.Activated += (s, e) => { this.Text = "Activated"; eventsContainer += "Activated\n"; };
            this.Deactivate += (s, e) => { this.Text = "DeActivated"; eventsContainer += "DeActivated\n"; };
            this.FormClosed += (s, e) => { this.Text = "FormClosed"; eventsContainer += "FormClosed\n"; MessageBox.Show(eventsContainer); };
            this.FormClosing += (s, e) => { this.Text = "FormClosing"; eventsContainer += "FormClosing\n"; };
            this.Load += (s, e) => { this.Text = "Load"; eventsContainer += "Load\n"; };
            this.Paint += (s, e) => { this.Text = "Paint"; eventsContainer += "Paint\n"; };
            this.Resize += (s, e) => { this.Text = "Resize "; eventsContainer += "Resize\n"; };

        }
    }
}
