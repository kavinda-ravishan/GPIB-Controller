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
            PMD = new List<double>();
            histY = new List<double>();
            histX = new List<double>();
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
        List<double> histY;
        List<double> histX;
        int i;
        double max;
        double min;
        double data;

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

                    i = 0;
                    data = 0;
                    max = excel.ReadExcel(i + 2, 0);
                    min = excel.ReadExcel(i + 2, 0);

                    PMD.Clear();
                    histY.Clear();
                    histX.Clear();

                    while (true)
                    {
                        data = excel.ReadExcel(i + 2, 0);
                        if (data != -1)
                        {
                            PMD.Add(data);
                            if (max < excel.ReadExcel(i + 2, 0)) max = excel.ReadExcel(i + 2, 0);
                            if (min > excel.ReadExcel(i + 2, 0)) min = excel.ReadExcel(i + 2, 0);
                            
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                lblStatus.Text = i.ToString() + " : " + data.ToString();
                            }));
                        }
                        else break;
                        i++;
                    }
                    excel.Close();

                    double stepSize = System.Convert.ToDouble(txtBoxChartStepSize.Text);
                    double steps = (max - min) / stepSize;

                    double temp = min;

                    for (i = 0; i < steps; i++)
                    {
                        histY.Add(0);
                        histX.Add(temp - (stepSize / 2));
                        temp = temp + stepSize;

                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            lblStatus.Text = i.ToString();
                        }));
                    }

                    for (i = 0; i < PMD.Count; i++)
                    {
                        histY[(int)((PMD[i] - min) / stepSize)]++;

                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            lblStatus.Text = i.ToString();
                        }));
                    }

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        chart.Series["Data"].Points.Clear();
                        for (i = 0; i < histY.Count; i++)
                        {
                            chart.Series["Data"].Points.AddXY(histX[i], histY[i]);

                            lblStatus.Text = data.ToString();
                        }
                        lblStatus.Text = "---";
                    }));
                });
                thread.Start();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(PMD.Count != 0)
            {
                Thread thread = new Thread(() =>
                {
                    histY.Clear();
                    histX.Clear();

                    double stepSize = System.Convert.ToDouble(txtBoxChartStepSize.Text);
                    double steps = (max - min) / stepSize;

                    double temp = min;

                    for (i = 0; i < steps; i++)
                    {
                        histY.Add(0);
                        histX.Add(temp - (stepSize / 2));
                        temp = temp + stepSize;

                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            lblStatus.Text = i.ToString();
                        }));
                    }

                    for (i = 0; i < PMD.Count; i++)
                    {
                        histY[(int)((PMD[i] - min) / stepSize)]++;

                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            lblStatus.Text = i.ToString();
                        }));
                    }

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        chart.Series["Data"].Points.Clear();
                        for (i = 0; i < histY.Count; i++)
                        {
                            chart.Series["Data"].Points.AddXY(histX[i], histY[i]);
                        }
                        lblStatus.Text = "---";
                    }));
                });
                thread.Start();
            }
            else
            {
                MessageBox.Show("Please load PMD data !");
            }
        }
    }
}
