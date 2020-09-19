using System;
using System.Windows.Forms;

namespace PolarizationAnalyzer
{
    public partial class StoksForm : Form
    {
        public StoksForm()
        {
            InitializeComponent();
        }

        public Form RefToMainForm { get; set; }

        private void NewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefToMainForm.Show();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                stringReadTextBox.Clear();

                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("SB;"));
                string[] data = Utility.SB(Utility.InsertCommonEscapeSequences(Devices.devicePolarizationAnalyzer.ReadString()));
                //string[] data = SB(text_SB);

                for (int i = 0; i < 6; i++)
                {
                    stringReadTextBox.Text += (Utility.lables_SB + " - " + data[i] + Environment.NewLine);
                }
                //chart1.Series["S0"].Points.Add(Convert.ToDouble(data[3]));
                chart1.Series["S1"].Points.Add(Convert.ToDouble(data[0]));
                chart1.Series["S2"].Points.Add(Convert.ToDouble(data[1]));
                chart1.Series["S3"].Points.Add(Convert.ToDouble(data[2]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            while (true)
            {
                try
                {
                    string[] data = Utility.SB(Utility.InsertCommonEscapeSequences(Devices.devicePolarizationAnalyzer.ReadString()));
                    //string[] data = SB(text_SB);

                    for (int i = 0; i < 6; i++)
                    {
                        stringReadTextBox.Text += (Utility.lables_SB[i] + " - " + data[i] + Environment.NewLine);
                    }
                    //chart1.Series["S0"].Points.Add(Convert.ToDouble(data[3]));
                    chart1.Series["S1"].Points.Add(Convert.ToDouble(data[0]));
                    chart1.Series["S2"].Points.Add(Convert.ToDouble(data[1]));
                    chart1.Series["S3"].Points.Add(Convert.ToDouble(data[2]));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

                chart1.Update();
            }
          
        }
    }
}
