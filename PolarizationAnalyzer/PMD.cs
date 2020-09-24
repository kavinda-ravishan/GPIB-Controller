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
            /*
            string PMD_LAS = txtbPMD_LASER.Text; //5;
            string PMD_TYP = txtbPMD_TYPE.Text; //1;
            string WAVE_START = txtbWAVE_START.Text; //1540;
            string WAVE_STOP = txtbWAVE_STOP.Text; //1550;
            string WAVE_STEP = txtbWAVE_STEP.Text; //0.1;
            string WAVE_SPEED = txtbWAVE_SPEED.Text; //1;
            string LENGTH = txtbLENGTH.Text; //1;

            string command =
                "PMD_LAS " + PMD_LAS + ";" +
                "PMD_TYP " + PMD_TYP + ";" +
                "WAVE_START " + WAVE_START + ";" +
                "WAVE_STOP " + WAVE_STOP + ";" +
                "WAVE_STEP " + WAVE_STEP + ";" +
                "WAVE_SPEED " + WAVE_SPEED + ";" +
                "LENGTH " + LENGTH + ";" +
                "PMD_START;X;";

            Console.WriteLine(command);
            */

            try
            {
                //:OUTPut 0 //turn on laser
                //:POWer + 10.00000000E-004   //power 1000uW
                //:WAVElength + 1.55000000E-006 //wave length 1550.000 nm
                //L 1550.00;X; //PAT9000B wavelenght
                //:OUTPut 1 //turn on laser
                //JM;X; //Mesure JM
                //Read

                //:OUTPut 0 //turn on laser
                //:POWer + 10.00000000E-004   //power 1000uW
                //:WAVElength + 1.55001000E-006 //wave length 1550.010 nm
                //L 1550.01;X; //PAT9000B wavelenght
                //:OUTPut 1 //turn on laser
                //JM;X; //Mesure JM
                //Read
                //:OUTPut 0 //turn on laser


                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 0"));
                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":POWer +10.00000000E-004"));
                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":WAVElength +1.55000000E-006"));
                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("L 1550.00;X;"));
                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 1"));
                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("JM;X;"));
                Console.WriteLine(Devices.devicePolarizationAnalyzer.ReadString());

                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 0"));
                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":POWer +10.00000000E-004"));
                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":WAVElength +1.55100000E-006"));
                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("L 1551.00;X;"));
                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 1"));
                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("JM;X;"));
                Console.WriteLine(Devices.devicePolarizationAnalyzer.ReadString());

                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 0"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
