using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPIBController
{
    public partial class HistogramForm : Form
    {
        public HistogramForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        public Form RefToPolonForm { get; set; }
        List<double> PMD;

        private void picCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            RefToPolonForm.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string path = " ";

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Load excel file",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xlsx",
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;

                Thread thread = new Thread(() =>
                {
                    Excel excel = new Excel(path, 1);
                    excel.SelectWorkSheet(1);

                    PMD = new List<double>();

                    int i = 0;
                    double data = 0;
                    double max = excel.ReadExcel(i + 2, 0);
                    double min = excel.ReadExcel(i + 2, 0);

                    while (true)
                    {
                        data = excel.ReadExcel(i + 2, 0);
                        if (data != -1)
                        {
                            PMD.Add(data);
                            if (max < excel.ReadExcel(i + 2, 0)) max = excel.ReadExcel(i + 2, 0);
                            if (min > excel.ReadExcel(i + 2, 0)) min = excel.ReadExcel(i + 2, 0);
                        }
                        else break;
                        i++;
                    }
                    excel.Close();

                    double stepSize = System.Convert.ToDouble(txtBoxChartStepSize.Text);
                    double steps = (max - min) / stepSize;

                    List<double> histY = new List<double>();
                    List<double> histX = new List<double>();

                    double temp = min;

                    for (i = 0; i < steps; i++)
                    {
                        histY.Add(0);
                        histX.Add(temp - (stepSize / 2));
                        temp = temp + stepSize;
                    }

                    for (i = 0; i < PMD.Count; i++)
                    {
                        histY[(int)((PMD[i] - min) / stepSize)]++;
                    }

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        chart.Series["Data"].Points.Clear();
                        for (i = 0; i < histY.Count; i++)
                        {
                            chart.Series["Data"].Points.AddXY(histX[i], histY[i]);
                        }
                    }));
                });
                thread.Start();
            }
        }
    }
}
