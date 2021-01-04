//#define TESTMODE

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace GPIBController
{
    public partial class PMDForm : Form
    {
        public PMDForm()
        {
            InitializeComponent();
            DGDMeasured += PMDForm_DGDMeasured;
            threadRun = true;

            refJonesMat = CMath.UnitMatrix();

            radioButtonJM.Checked = true;
        }

        public Form RefToMainForm { get; set; }

        public struct PMDData
        {
            public double waveLenght;
            public double DGD;
            public double PMD;
            public int i;
        }
        private struct PMDSettings
        {
            public double start;
            public double stop;
            public double stepSize;
            public double length; // in Km
            public double meanPMD;
            public double min;
            public double minWaveLength;
            public double max;
            public double maxWaveLength;
            public int laserPower;
            public int delay;
        }
        private PMDData[] data;
        private PMDSettings settings;
        private CMath.JonesMatCar refJonesMat;
        private static bool threadRun;

        // declaring an event using built-in EventHandler
        public event EventHandler<PMDData> DGDMeasured;

        private void SetupControlState(bool isPMDMeasurementStarted)
        {
            btnStop.Enabled = isPMDMeasurementStarted;

            btnStart.Enabled = !isPMDMeasurementStarted;
            btnResetRefJonesMat.Enabled = !isPMDMeasurementStarted;
            btnMeasureRefJonesMat.Enabled = !isPMDMeasurementStarted;
            btnShowRefJonesMat.Enabled = !isPMDMeasurementStarted;
            btnSave.Enabled = !isPMDMeasurementStarted;
            btnLoad.Enabled = !isPMDMeasurementStarted;

            txtBoxDelay.Enabled = !isPMDMeasurementStarted;
            txtBoxLength.Enabled = !isPMDMeasurementStarted;
            txtBoxLaserPower.Enabled = !isPMDMeasurementStarted;
            txtBoxFileName.Enabled = !isPMDMeasurementStarted;
            txtBoxStart.Enabled = !isPMDMeasurementStarted;
            txtBoxStop.Enabled = !isPMDMeasurementStarted;

            groupBox.Enabled = !isPMDMeasurementStarted;
        }

        protected virtual void OnDGDMeasured(PMDData data)
        {
            DGDMeasured?.Invoke(this, data);
        }

        private void PMDForm_DGDMeasured(object sender, PMDData e)
        {
            //Console.WriteLine(e.waveLenght);
            //Console.WriteLine(e.DGD);
            //Console.WriteLine(e.PMD);
            //Console.WriteLine();

            this.Invoke(new MethodInvoker(delegate ()
            {
                //update labels and chart
                stringReadTextBox.Text += (e.waveLenght.ToString() + " nm" + Environment.NewLine);
                stringReadTextBox.Text += ("DGD : " + e.DGD.ToString() + " ps" + Environment.NewLine);
                stringReadTextBox.Text += ("PMD : " + e.PMD.ToString() + Environment.NewLine);
                stringReadTextBox.Text += (Environment.NewLine);

                stringReadTextBox.SelectionStart = stringReadTextBox.Text.Length;
                stringReadTextBox.ScrollToCaret();

                chart.Series["PMD"].Points.AddXY(e.waveLenght, e.PMD);

                lblMeanPMD.Text = settings.meanPMD.ToString();
                lblMin.Text = settings.min.ToString();
                lblMinWL.Text = " | " + settings.minWaveLength.ToString() + " nm";
                lblMax.Text = settings.max.ToString();
                lblMaxWL.Text = " | " + settings.maxWaveLength.ToString() + " nm";
            }));
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //all long runnog oparations done in separate threads for avoid ui freezing issue.
            Thread thread = new Thread(() =>
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        SetupControlState(true);
                    }));

                    //take user inputs
                    settings.start = System.Convert.ToDouble(txtBoxStart.Text);
                    settings.stop = System.Convert.ToDouble(txtBoxStop.Text); ;
                    settings.stepSize = System.Convert.ToDouble(txtBoxStep.Text);
                    settings.length = System.Convert.ToDouble(txtBoxLength.Text); // in Km
                    settings.laserPower = System.Convert.ToInt32(txtBoxLaserPower.Text);
                    settings.delay = System.Convert.ToInt32(txtBoxDelay.Text);
                    settings.meanPMD = 0;

                    double lengthSqrt = Math.Sqrt(settings.length);

                    //calculate number of steps needed
                    int steps = (int)((settings.stop - settings.start) / settings.stepSize) + 3;

                    double[] wavelenght = new double[steps];

                    //find wavelenghts need to mesure
                    for (int i = 0; i < steps; i++)
                    {
                        wavelenght[i] = (settings.start - settings.stepSize) + (i * settings.stepSize);
                    }

                    //for save PAT9300 JM information
                    CMath.JonesMatCar[] jMat = new CMath.JonesMatCar[steps];
                    double[] DGDval = new double[2];
                    data = new PMDData[steps - 2];
                    double sumPMD = 0;

                    //Invoke methods for allow cross thread oparations
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        stringReadTextBox.Clear();
                    }));
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        chart.Series["PMD"].Points.Clear();
                    }));
#if(!TESTMODE)
                    //laser on
                    DeviceControl.LaserOn(settings.laserPower);
                    DeviceControl.InitDGDMesure(settings.start);
#endif
                    threadRun = true;

                    for (int i = 0; i < steps; i++)
                    {
                        if (threadRun)
                        {
                            if (i < 2)
                            {
#if (!TESTMODE)
                                if (radioButtonJM.Checked)
                                {
                                    jMat[i] = Utility.JonesMatString2Car(DeviceControl.GetJonesMatrix(wavelenght[i], settings.delay));
                                }
                                if (radioButtonS.Checked)
                                {
                                    jMat[i] = Utility.MesureStokes2JonesMat(wavelenght[i], settings.delay);
                                }
                                else
                                {
                                    jMat[i] = Utility.MesureTanPiDelta2JonesMat(wavelenght[i], settings.delay);
                                }
#else
                                jStrings[i] = Utility.text_J1;//for testing
#endif
                            }
                            else
                            {
#if (!TESTMODE)
                                if (radioButtonJM.Checked)
                                {
                                    jMat[i] = Utility.JonesMatString2Car(DeviceControl.GetJonesMatrix(wavelenght[i], settings.delay));
                                }
                                if (radioButtonS.Checked)
                                {
                                    jMat[i] = Utility.MesureStokes2JonesMat(wavelenght[i], settings.delay);
                                }
                                else
                                {
                                    jMat[i] = Utility.MesureTanPiDelta2JonesMat(wavelenght[i], settings.delay);
                                }
#else
                                jStrings[i] = Utility.text_J1;//for testing
#endif

                                DGDval = Utility.DGD(
                                    jMat[i - 2],
                                    jMat[i], 
                                    refJonesMat, 
                                    wavelenght[i - 2], 
                                    wavelenght[i]);//Meaure DGD for arg1 and arg2 jones matrices

                                data[i - 2].DGD = DGDval[0];
                                data[i - 2].waveLenght = DGDval[1];
                                data[i - 2].PMD = DGDval[0] / lengthSqrt;
                                data[i - 2].i = i - 1;

                                sumPMD = data[i - 2].PMD + sumPMD;
                                settings.meanPMD = sumPMD / data[i - 2].i;

                                //for find minimum and maximum values
                                if (data[i - 2].i == 1)
                                {
                                    settings.min = data[i - 2].PMD;
                                    settings.max = data[i - 2].PMD;

                                    settings.minWaveLength = data[i - 2].waveLenght;
                                    settings.maxWaveLength = data[i - 2].waveLenght;
                                }
                                else
                                {
                                    if (settings.min > data[i - 2].PMD)
                                    {
                                        settings.min = data[i - 2].PMD;
                                        settings.minWaveLength = data[i - 2].waveLenght;
                                    }
                                    if (settings.max < data[i - 2].PMD)
                                    {
                                        settings.max = data[i - 2].PMD;
                                        settings.maxWaveLength = data[i - 2].waveLenght;
                                    }
                                }
                                //call event for show update chart and labels
                                OnDGDMeasured(data[i - 2]);
#if (TESTMODE)
                                Thread.Sleep(1000);
#endif
                            }
                        }
                        else break;
                    }
#if (!TESTMODE)
                    //laser off
                    DeviceControl.LaserOff();
#endif
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        SetupControlState(false);
                    }));
                }
            });
            thread.Start();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (settings.length != 0)
            {
                string path = " ";

                FolderBrowserDialog folderDlg = new FolderBrowserDialog
                {
                    ShowNewFolderButton = true
                };
                // Show the FolderBrowserDialog.  
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    path = folderDlg.SelectedPath + "\\" + txtBoxFileName.Text + ".xlsx";

                    Thread thread = new Thread(() =>
                    {
                        try
                        {
                            Excel.Creat(path);
                            Excel excel = new Excel(path, 1);
                            excel.SelectWorkSheet(1);

                            excel.WriteToCell(0, 0, "From");
                            excel.WriteToCell(0, 1, settings.start.ToString());
                            excel.WriteToCell(0, 2, "nm");
                            excel.WriteToCell(0, 3, "to");
                            excel.WriteToCell(0, 4, settings.stop.ToString());
                            excel.WriteToCell(0, 5, "nm");

                            excel.WriteToCell(1, 0, "Step size");
                            excel.WriteToCell(1, 1, settings.stepSize.ToString());
                            excel.WriteToCell(1, 2, "nm");

                            excel.WriteToCell(2, 0, "Fiber length");
                            excel.WriteToCell(2, 1, settings.length.ToString());
                            excel.WriteToCell(2, 2, "Km");

                            excel.WriteToCell(3, 0, "Mean PMD");
                            excel.WriteToCell(3, 1, settings.meanPMD.ToString());

                            excel.WriteToCell(4, 0, "Minimum PMD");
                            excel.WriteToCell(4, 1, settings.min.ToString());
                            excel.WriteToCell(4, 2, "at");
                            excel.WriteToCell(4, 3, settings.minWaveLength.ToString());
                            excel.WriteToCell(4, 4, "nm");

                            excel.WriteToCell(5, 0, "Maximum PMD");
                            excel.WriteToCell(5, 1, settings.max.ToString());
                            excel.WriteToCell(5, 2, "at");
                            excel.WriteToCell(5, 3, settings.maxWaveLength.ToString());
                            excel.WriteToCell(5, 4, "nm");

                            excel.WriteToCell(7, 1, "Wave Length (nm)");
                            excel.WriteToCell(7, 2, "DGD (ps)");
                            excel.WriteToCell(7, 3, "PMD");

                            for (int i = 0; i < data.Length; i++)
                            {
                                excel.WriteToCell(i + 8, 0, data[i].i.ToString());
                                excel.WriteToCell(i + 8, 1, data[i].waveLenght.ToString());
                                excel.WriteToCell(i + 8, 2, data[i].DGD.ToString());
                                excel.WriteToCell(i + 8, 3, data[i].PMD.ToString());
                            }
                            excel.Save();
                            excel.Close();

                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                stringReadTextBox.Text += ("Excel created." + Environment.NewLine);
                                stringReadTextBox.Text += (Environment.NewLine);
                                stringReadTextBox.SelectionStart = stringReadTextBox.Text.Length;
                                stringReadTextBox.ScrollToCaret();
                            }));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    });
                    thread.Start();
                }
            }
            else
            {
                MessageBox.Show("No data available.");
            }

        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            threadRun = false;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
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

                    settings.start = System.Convert.ToDouble(excel.ReadExcel(0, 1));
                    settings.stop = System.Convert.ToDouble(excel.ReadExcel(0, 4));

                    settings.stepSize = System.Convert.ToDouble(excel.ReadExcel(1, 1));

                    settings.length = System.Convert.ToDouble(excel.ReadExcel(2, 1));

                    settings.meanPMD = System.Convert.ToDouble(excel.ReadExcel(3, 1));

                    settings.min = System.Convert.ToDouble(excel.ReadExcel(4, 1));
                    settings.minWaveLength = System.Convert.ToDouble(excel.ReadExcel(4, 3));

                    settings.max = System.Convert.ToDouble(excel.ReadExcel(5, 1));
                    settings.maxWaveLength = System.Convert.ToDouble(excel.ReadExcel(5, 3));

                    List<double> waveLenghts = new List<double>();
                    List<double> DGDs = new List<double>();
                    List<double> PMDs = new List<double>();

                    int i = 0;
                    while (true)
                    {
                        if (excel.ReadExcel(i + 8, 0) != -1)
                        {
                            waveLenghts.Add(excel.ReadExcel(i + 8, 1));
                            DGDs.Add(excel.ReadExcel(i + 8, 2));
                            PMDs.Add(excel.ReadExcel(i + 8, 3));

                            //this.Invoke(new MethodInvoker(delegate ()
                            //{
                                //lblStatus.Text = i.ToString() + " : " + data.ToString();
                            //}));
                        }
                        else break;
                        i++;
                    }

                    excel.Close();

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        txtBoxStart.Text = settings.start.ToString();
                        txtBoxStop.Text = settings.stop.ToString();
                        txtBoxStep.Text = settings.stepSize.ToString();
                        txtBoxLength.Text = settings.length.ToString();

                        lblMeanPMD.Text = settings.meanPMD.ToString();
                        lblMin.Text = settings.min.ToString();
                        lblMinWL.Text = " | " + settings.minWaveLength.ToString() + " nm";
                        lblMax.Text = settings.max.ToString();
                        lblMaxWL.Text = " | " + settings.maxWaveLength.ToString() + " nm";

                        stringReadTextBox.Clear();

                        chart.Series["PMD"].Points.Clear();

                        for (i = 0; i < waveLenghts.Count; i++)
                        {

                            chart.Series["PMD"].Points.AddXY(waveLenghts[i], PMDs[i]);

                            stringReadTextBox.Text += (waveLenghts[i].ToString() + " nm" + Environment.NewLine);
                            stringReadTextBox.Text += ("DGD : " + DGDs[i].ToString() + " ps" + Environment.NewLine);
                            stringReadTextBox.Text += ("PMD : " + PMDs[i].ToString() + Environment.NewLine);
                            stringReadTextBox.Text += (Environment.NewLine);

                            stringReadTextBox.SelectionStart = stringReadTextBox.Text.Length;
                            stringReadTextBox.ScrollToCaret();
                        }


                        stringReadTextBox.Text += ("Excel loaded." + Environment.NewLine);
                        stringReadTextBox.Text += (Environment.NewLine);
                        stringReadTextBox.SelectionStart = stringReadTextBox.Text.Length;
                        stringReadTextBox.ScrollToCaret();
                    }));
                });
                thread.Start();
            }
        }

        private void PicCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            RefToMainForm.Show();
        }

        //For allow user to drag the window by click and holding
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

        private void BtnShowRefJonesMat_Click(object sender, EventArgs e)
        {
            lblJ11.Text = CMath.GetComplexString(refJonesMat.J11);
            lblJ12.Text = CMath.GetComplexString(refJonesMat.J12);
            lblJ21.Text = CMath.GetComplexString(refJonesMat.J21);
            lblJ22.Text = CMath.GetComplexString(refJonesMat.J22);
        }

        private void BtnResetRefJonesMat_Click(object sender, EventArgs e)
        {
            refJonesMat = CMath.UnitMatrix();

            lblJ11.Text = CMath.GetComplexString(refJonesMat.J11);
            lblJ12.Text = CMath.GetComplexString(refJonesMat.J12);
            lblJ21.Text = CMath.GetComplexString(refJonesMat.J21);
            lblJ22.Text = CMath.GetComplexString(refJonesMat.J22);
        }

        private void BtnMeasureRefJonesMat_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
#if (!TESTMODE)
                    DeviceControl.LaserOn(System.Convert.ToInt32(txtBoxLaserPower.Text));
                    DeviceControl.InitDGDMesure(System.Convert.ToDouble(txtBoxStart.Text));
                    string jString = DeviceControl.GetJonesMatrix(System.Convert.ToDouble(txtBoxStart.Text), System.Convert.ToInt32(txtBoxDelay.Text));
                    DeviceControl.LaserOff();

                    double[] jMatValues = Utility.JonesString2Double(jString);
#else
                    double[] jMatValues = Utility.JonesString2Double(Utility.text_J1);//for testing
#endif
                    CMath.JonesMatPol matPol = Utility.JonesDoubleArray2JonesMat(jMatValues);
                    refJonesMat = CMath.Inverse(CMath.Pol2Car(matPol));

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        //update labels
                        lblJ11.Text = CMath.GetComplexString(refJonesMat.J11);
                        lblJ12.Text = CMath.GetComplexString(refJonesMat.J12);
                        lblJ21.Text = CMath.GetComplexString(refJonesMat.J21);
                        lblJ22.Text = CMath.GetComplexString(refJonesMat.J22);
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            thread.Start();
        }
    }
}
