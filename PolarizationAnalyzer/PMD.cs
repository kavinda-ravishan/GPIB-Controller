using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolarizationAnalyzer
{
    public partial class PMDForm : Form
    {
        public PMDForm()
        {
            InitializeComponent();
        }

        public Form RefToMainForm { get; set; }

        private void PMDForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefToMainForm.Show();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 1"));//:OUTPut 1 //turn on laser
                stringReadTextBox.Text += (":OUTPut 1" + Environment.NewLine);


                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":POWer +10.00000000E-004"));//:POWer +10.00000000E-004 //power 1000uW
                stringReadTextBox.Text += (":POWer +10.00000000E-004" + Environment.NewLine);

                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":WAVElength +1.55000000E-006"));//:WAVElength +1.55000000E-006 //wave length 1550.000 nm
                stringReadTextBox.Text += (":WAVElength +1.55000000E-006" + Environment.NewLine);

                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("L 1550.00;X;"));//L 1550.00;X; //Change PAT9000B oparation wavelenght to 1550.00nm
                stringReadTextBox.Text += ("L 1550.00;X;" + Environment.NewLine);

                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("JM;X;"));//JM;X; //Mesure JM
                stringReadTextBox.Text += ("JM;X;" + Environment.NewLine);

                stringReadTextBox.Text += (Devices.devicePolarizationAnalyzer.ReadString() + Environment.NewLine);//Read


                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":WAVElength +1.55100000E-006"));//:WAVElength +1.55100000E-006 //wave length 1551.000 nm
                stringReadTextBox.Text += (": WAVElength +1.55100000E-006" + Environment.NewLine);

                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("L 1551.00;X;"));//L 1551.00;X; //Change PAT9000B oparation wavelenght to 1551.00nm
                stringReadTextBox.Text += ("L 1551.00;X;" + Environment.NewLine);

                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("JM;X;"));//JM;X; //Mesure JM
                stringReadTextBox.Text += ("JM;X;" + Environment.NewLine);

                stringReadTextBox.Text += (Devices.devicePolarizationAnalyzer.ReadString() + Environment.NewLine);//Read

                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 0"));//:OUTPut 0 //turn on laser
                stringReadTextBox.Text += (":OUTPut 0" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
