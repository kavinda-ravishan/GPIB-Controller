using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PolarizationAnalyzer
{
    public partial class StoksForm : Form
    {
        private List<double> S1 = new List<double>();
        private List<double> S2 = new List<double>();
        private List<double> S3 = new List<double>();

        public StoksForm()
        {
            InitializeComponent();
        }

        public Form RefToMainForm { get; set; }

        private void StoksForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefToMainForm.Show();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("SB;"));
                timer.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //string[] data = Utility.SB_filter(Utility.DataSeparator(Utility.InsertCommonEscapeSequences(Devices.devicePolarizationAnalyzer.ReadString())));
                string[] data = Utility.SB_filter(Utility.DataSeparator(Utility.text_SB));//for testing

                stringReadTextBox.Clear();
                for (int i = 0; i < 6; i++)
                {
                    stringReadTextBox.Text += (Utility.Lables_SB[i] + " - " + data[i] + Environment.NewLine);
                }

                if (S1.Count < 20)
                {
                    S1.Add(Convert.ToDouble(data[0]));
                    S2.Add(Convert.ToDouble(data[1]));
                    S3.Add(Convert.ToDouble(data[2]));
                }
                else
                {
                    S1.Add(Convert.ToDouble(data[0]));
                    S2.Add(Convert.ToDouble(data[1]));
                    S3.Add(Convert.ToDouble(data[2]));
                    S1.RemoveAt(0);
                    S2.RemoveAt(0);
                    S3.RemoveAt(0);
                }

                chart1.Series["S1"].Points.Clear();
                chart2.Series["S2"].Points.Clear();
                chart3.Series["S3"].Points.Clear();

                for (int i = 0; i < S1.Count; i++)
                {
                    chart1.Series["S1"].Points.Add(S1[i]);
                    chart2.Series["S2"].Points.Add(S2[i]);
                    chart3.Series["S3"].Points.Add(S3[i]);
                }
                //chart1.Update();
                //chart2.Update();
                //chart3.Update();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
