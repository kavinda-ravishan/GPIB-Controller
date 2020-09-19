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
            string PMD_LAS = txtbPMD_LASER.Text; //5;
            string PMD_TYP = txtbPMD_TYPE.Text; //1;
            string WAVE_START = txtbWAVE_START.Text; //1540;
            string WAVE_STOP = txtbWAVE_STOP.Text; //1550;
            string WAVE_STEP = txtbWAVE_STEP.Text; //0.1;
            string WAVE_SPEED = txtbWAVE_SPEED.Text; //1;
            string DELTA = txtbDELTA.Text; //0;
            string K_FACTOR = txtbK_FACTOR.Text; //0.1;
            string LENGTH = txtbLENGTH.Text; //1;

            string command =
                "PMD_LAS " + PMD_LAS + ";" +
                "PMD_TYP " + PMD_TYP + ";" +
                "WAVE_START " + WAVE_START + ";" +
                "WAVE_STOP " + WAVE_STOP + ";" +
                "WAVE_STEP " + WAVE_STEP + ";" +
                "WAVE_SPEED " + WAVE_SPEED + ";" +
                "DELTA " + DELTA + ";" +
                "K_FACTOR " + K_FACTOR + ";" +
                "LENGTH " + LENGTH + ";" +
                "PMD_START;X;";

            Console.WriteLine(command);

            try
            {
                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences(command));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
