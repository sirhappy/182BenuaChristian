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
    public partial class DetailsWindow : Form
    {
        private Estimates estimates;
        public DetailsWindow(Estimates estimates)
        {
            this.estimates = estimates;
            InitializeComponent();
            estimates.NotifyOnPropertyChanged += Estimates_NotifyOnPropertyChanged;
            Estimates_NotifyOnPropertyChanged();
        }

        private void Estimates_NotifyOnPropertyChanged()
        {
            AmountLabel.Text = estimates.Count.ToString();
            xMinLabel.Text = estimates.MinValue.ToString("F3");
            xMaxLabel.Text = estimates.MaxValue.ToString("F3");
            DeviationLabel.Text = estimates.Deviation.ToString("F3");
            AverageLabel.Text = estimates.Average.ToString("F3");
        }
    }
}
