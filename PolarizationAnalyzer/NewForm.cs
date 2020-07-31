using System;
using System.Windows.Forms;

namespace PolarizationAnalyzer
{
    public partial class NewForm : Form
    {
        public NewForm()
        {
            InitializeComponent();
        }

        public Form RefToMainForm { get; set; }

        private void NewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefToMainForm.Show();
        }
    }
}
