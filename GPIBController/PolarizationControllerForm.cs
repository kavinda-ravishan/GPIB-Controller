#define TESTMODE

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace GPIBController

{
    public partial class PolarizationControllerForm : Form
    {
        public PolarizationControllerForm()
        {
            InitializeComponent();
            ServoRotated += PolController_ServoRotated;
            refJonesMat = CMath.UnitMatrix();
            wavelengths = new List<double>();

            radioButtonJM.Checked = true;
        }

        private double sqrtFiberLength;
        private struct ServoAngle
        {
            public string servoA;
            public string servoB;
            public string servoC;
        }
        private struct PMDData
        {
            public ServoAngle ServoAngle;
            public double DGD;
            public double PMD;
        }
        private struct PMDCharacteristics
        {
            public int stepSize;
            public double wavelength;
            public double waveLengthStepSize;
            public double laserPower;
            public int delay;
            public double fiberLength;
            public int start;
            public int stop;
            public List<PMDData> PMDDatas;
        }
        private string[] portNames;
        private SerialPort serialPort;
        private ServoAngle servoAngle;
        private PMDCharacteristics pMDCharacteristics;
        private string ack;
        private static bool nextMeasurement;
        private static bool threadRun;
        private List<double> wavelengths;
        private CMath.JonesMatCar refJonesMat;

        private int progress;
        private int progressTotal;
        private float progressPercentage;
        private DateTime dateTimeStart;
        private int timePastSeonds;
        private int eta;
        private int seconds;
        private int minutes;
        private int hours;
        private string etaTime;
        private Utility.Methods method;

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

        private void PolController_ServoRotated(object sender, string e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                lblServoA.Text = servoAngle.servoA;
                lblServoB.Text = servoAngle.servoB;
                lblServoC.Text = servoAngle.servoC;
            }));

            PMDData pMD = new PMDData();
            CMath.JonesMatCar j1;
            CMath.JonesMatCar j2;

            try
            {
                if (Utility.Methods.JonesMat == method)
                {
#if (!TESTMODE)
                    j1 = Utility.JonesMatString2Car(
                        DeviceControl.GetJonesMatrix(pMDCharacteristics.wavelength - pMDCharacteristics.waveLengthStepSize, pMDCharacteristics.delay)
                        );
                    j2 = Utility.JonesMatString2Car(
                        DeviceControl.GetJonesMatrix(pMDCharacteristics.wavelength + pMDCharacteristics.waveLengthStepSize, pMDCharacteristics.delay)
                        );
#else
                    j1 = Utility.JonesMatString2Car(Utility.text_J1_1);//for testing
                    j2 = Utility.JonesMatString2Car(Utility.text_J1_2);//for testing
#endif
                }
                else if(Utility.Methods.Stokes == method)
                {
#if (!TESTMODE)
                    j1 = Utility.MesureStokes2JonesMat(pMDCharacteristics.wavelength - pMDCharacteristics.waveLengthStepSize, pMDCharacteristics.delay);
                    j2 = Utility.MesureStokes2JonesMat(pMDCharacteristics.wavelength + pMDCharacteristics.waveLengthStepSize, pMDCharacteristics.delay);
#else
                    j1 = Utility.JonesMatString2Car(Utility.text_J1);//for testing
                    j2 = Utility.JonesMatString2Car(Utility.text_J2);//for testing
#endif
                }
                else
                {
#if (!TESTMODE)
                    j1 = Utility.MesureTanPiDelta2JonesMat(pMDCharacteristics.wavelength - pMDCharacteristics.waveLengthStepSize, pMDCharacteristics.delay);
                    j2 = Utility.MesureTanPiDelta2JonesMat(pMDCharacteristics.wavelength + pMDCharacteristics.waveLengthStepSize, pMDCharacteristics.delay);
#else
                    j1 = Utility.JonesMatString2Car(Utility.text_J1);//for testing
                    j2 = Utility.JonesMatString2Car(Utility.text_J2);//for testing
#endif
                }

                double[] DGD = Utility.DGD(
                                             j1,
                                             j2,
                                             refJonesMat,
                                             pMDCharacteristics.wavelength - pMDCharacteristics.waveLengthStepSize,
                                             pMDCharacteristics.wavelength + pMDCharacteristics.waveLengthStepSize
                                             );

                pMD.DGD = DGD[0];
                pMD.PMD = DGD[0] / sqrtFiberLength;
                pMD.ServoAngle = servoAngle;

                pMDCharacteristics.PMDDatas.Add(pMD);
            }
            catch (Exception)// Due to Jones matrix filtr issue.
            {
                pMD.DGD = 0;
                pMD.PMD = 0;
                pMD.ServoAngle = servoAngle;

                pMDCharacteristics.PMDDatas.Add(pMD);
            }
            finally
            {
                progress++;
                progressPercentage = (progress * 100f) / progressTotal;
                timePastSeonds = (int)(DateTime.Now - dateTimeStart).TotalSeconds;
                eta = (int)((timePastSeonds * 100f) / progressPercentage) - timePastSeonds;

                seconds = eta % 60;
                hours = eta / 3600;
                minutes = (eta / 60) - (hours * 60);

                etaTime = hours + " Hrs : " + minutes + " Min : " + seconds + " Sec";

                this.Invoke(new MethodInvoker(delegate ()
                {
                    //update labels and chart
                    stringReadTextBox.Text += (pMDCharacteristics.wavelength.ToString() + " nm" + Environment.NewLine);
                    stringReadTextBox.Text += ("DGD : " + pMD.DGD.ToString() + " ps" + Environment.NewLine);
                    stringReadTextBox.Text += ("PMD : " + pMD.PMD.ToString() + Environment.NewLine);
                    stringReadTextBox.Text += (Environment.NewLine);

                    stringReadTextBox.SelectionStart = stringReadTextBox.Text.Length;
                    stringReadTextBox.ScrollToCaret();

                    lblProgress.Text = progress.ToString() + "/" + progressTotal.ToString() +
                    "  [ " + (int)progressPercentage + "% ]" +
                    "    " + etaTime;

                    progressBar.Value = (int)progressPercentage;
                }));
            }
        }

        public Form RefToMainForm { get; set; }

        private void SetupControlState(bool isPMDMeasurementStarted)
        {
            btnStop.Enabled = isPMDMeasurementStarted;

            btnStart.Enabled = !isPMDMeasurementStarted;
            btnFindPorts.Enabled = !isPMDMeasurementStarted;
            btnDisconnect.Enabled = !isPMDMeasurementStarted;
            btnWrite.Enabled = !isPMDMeasurementStarted;
            btnAdd.Enabled = !isPMDMeasurementStarted;
            btnClear.Enabled = !isPMDMeasurementStarted;
            btnResetRefJonesMat.Enabled = !isPMDMeasurementStarted;
            btnMeasureRefJonesMat.Enabled = !isPMDMeasurementStarted;
            btnShowRefJonesMat.Enabled = !isPMDMeasurementStarted;
            btnSave.Enabled = !isPMDMeasurementStarted;
            btnShowHIst.Enabled = !isPMDMeasurementStarted;

            txtBoxDelay.Enabled = !isPMDMeasurementStarted;
            txtBoxFiberLength.Enabled = !isPMDMeasurementStarted;
            txtBoxLaserPower.Enabled = !isPMDMeasurementStarted;
            txtBoxPath.Enabled = !isPMDMeasurementStarted;
            txtBoxServoA.Enabled = !isPMDMeasurementStarted;
            txtBoxServoB.Enabled = !isPMDMeasurementStarted;
            txtBoxServoC.Enabled = !isPMDMeasurementStarted;
            txtBoxStart.Enabled = !isPMDMeasurementStarted;
            txtBoxStepSize.Enabled = !isPMDMeasurementStarted;
            txtBoxStop.Enabled = !isPMDMeasurementStarted;
            txtBoxWavelength.Enabled = !isPMDMeasurementStarted;
            txtBoxWaveStep.Enabled = !isPMDMeasurementStarted;

            groupBox.Enabled = !isPMDMeasurementStarted;
        }

        private void BtnFindPorts_Click(object sender, EventArgs e)
        {
            cmbCOMPorts.Items.Clear();
            portNames = SerialPort.GetPortNames();

            foreach (string port in portNames)
            {
                cmbCOMPorts.Items.Add(port);
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (cmbCOMPorts.SelectedIndex > -1)
            {
                try
                {
                    serialPort = new SerialPort(portNames[cmbCOMPorts.SelectedIndex], 9600, Parity.None, 8, StopBits.One);
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    serialPort.Open();

                    btnDisconnect.Enabled = true;
                    btnConnect.Enabled = false;

                    //junk string send for clean arduino serial buffer
                    serialPort.WriteLine("!@#$%^&*()!");

                    servoAngle.servoA = "0";
                    servoAngle.servoB = "0";
                    servoAngle.servoC = "0";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            serialPort.Dispose();

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                try
                {
                    servoAngle.servoA = txtBoxServoA.Text;
                    servoAngle.servoB = txtBoxServoB.Text;
                    servoAngle.servoC = txtBoxServoC.Text;

                    serialPort.WriteLine("ABC" + servoAngle.servoA + ":" + servoAngle.servoB + ":" + servoAngle.servoC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                ack = serialPort.ReadLine();

                if (ack == "PMD\r")
                {
                    nextMeasurement = true;
                }

                this.Invoke(new MethodInvoker(delegate ()
                {
                    lblRData.Text = ack;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public event EventHandler<string> ServoRotated;

        protected virtual void OnServoRotated(string ack)
        {
            ServoRotated?.Invoke(this, ack);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (serialPort != null && wavelengths.Count != 0)
            {
                //all long running oparations done in separate threads for avoid ui freezing issue.
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            SetupControlState(true);
                            progressBar.Value = 0;
                        }));

                        if (radioButtonJM.Checked)
                        {
                            method = Utility.Methods.JonesMat;
                        }
                        else if (radioButtonS.Checked)
                        {
                            method = Utility.Methods.Stokes;
                        }
                        else
                        {
                            method = Utility.Methods.ExEyDelta;
                        }

                        pMDCharacteristics = new PMDCharacteristics
                        {
                            PMDDatas = new List<PMDData>(),

                            //Read user inputs
                            stepSize = System.Convert.ToInt32(txtBoxStepSize.Text),
                            wavelength = 0,
                            waveLengthStepSize = System.Convert.ToDouble(txtBoxWaveStep.Text),
                            laserPower = System.Convert.ToDouble(txtBoxLaserPower.Text),
                            delay = System.Convert.ToInt32(txtBoxDelay.Text),
                            fiberLength = System.Convert.ToDouble(txtBoxFiberLength.Text),
                            start = System.Convert.ToInt32(txtBoxStart.Text),
                            stop = System.Convert.ToInt32(txtBoxStop.Text)
                        };

                        sqrtFiberLength = Math.Sqrt(pMDCharacteristics.fiberLength);

                        progress = 0;
                        progressPercentage = 0;
                        progressTotal = ((pMDCharacteristics.stop - pMDCharacteristics.start) / pMDCharacteristics.stepSize) + 1;
                        progressTotal = progressTotal * progressTotal * progressTotal * wavelengths.Count;
                        dateTimeStart = DateTime.Now;
                        eta = 0;


                        threadRun = true;
#if (!TESTMODE)
                        DeviceControl.LaserOn(pMDCharacteristics.laserPower);
                        DeviceControl.InitDGDMesure(pMDCharacteristics.wavelength);
#endif
                        for (int i = 0; i < wavelengths.Count; i++)// loop go through all wavelenghts need to measure
                        {
                            pMDCharacteristics.wavelength = wavelengths[i];

                            for (int A = pMDCharacteristics.start; A <= pMDCharacteristics.stop; A += pMDCharacteristics.stepSize)
                            {
                                for (int B = pMDCharacteristics.start; B <= pMDCharacteristics.stop; B += pMDCharacteristics.stepSize)
                                {
                                    for (int C = pMDCharacteristics.start; C <= pMDCharacteristics.stop; C += pMDCharacteristics.stepSize)
                                    {
                                        servoAngle.servoA = A.ToString();
                                        servoAngle.servoB = B.ToString();
                                        servoAngle.servoC = C.ToString();

                                        serialPort.WriteLine("PMD" + servoAngle.servoA + ":" + servoAngle.servoB + ":" + servoAngle.servoC);//Prepare data string and send to arduino

                                        nextMeasurement = false;
                                        while (!nextMeasurement) { }//wait until arduino send rotate complete message

                                        OnServoRotated(ack);

                                        if (threadRun == false)
                                            break;
                                    }
                                    if (threadRun == false)
                                        break;
                                }
                                if (threadRun == false)
                                    break;
                            }
                            if (threadRun == false)
                                break;
                        }
#if (!TESTMODE)
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
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            threadRun = false;
            SetupControlState(false);
        }

        private void BtnSave_Click(object sender, EventArgs e)
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
                path = folderDlg.SelectedPath + "\\" + txtBoxPath.Text + ".xlsx";

                Thread thread = new Thread(() =>
                {
                    try
                    {
                        Excel.Creat(path);
                        Excel excel = new Excel(path, 1);
                        excel.SelectWorkSheet(1);

                        excel.WriteToCell(0, 0, "Wavelengths");
                        for (int i = 0; i < wavelengths.Count; i++)
                        {
                            excel.WriteToCell(0, i + 1, wavelengths[i].ToString());
                        }

                        excel.WriteToCell(1, 0, "PMD");
                        excel.WriteToCell(1, 1, "Servo A");
                        excel.WriteToCell(1, 2, "Servo B");
                        excel.WriteToCell(1, 3, "Servo C");

                        for (int i = 0; i < pMDCharacteristics.PMDDatas.Count; i++)
                        {
                            excel.WriteToCell(i + 2, 0, pMDCharacteristics.PMDDatas[i].PMD.ToString());
                            excel.WriteToCell(i + 2, 1, pMDCharacteristics.PMDDatas[i].ServoAngle.servoA.ToString());
                            excel.WriteToCell(i + 2, 2, pMDCharacteristics.PMDDatas[i].ServoAngle.servoB.ToString());
                            excel.WriteToCell(i + 2, 3, pMDCharacteristics.PMDDatas[i].ServoAngle.servoC.ToString());
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

        private void PicCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            RefToMainForm.Show();
        }

        private void BtnMeasureRefJonesMat_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
#if (!TESTMODE)
                    DeviceControl.LaserOn(System.Convert.ToInt32(txtBoxLaserPower.Text));
                    DeviceControl.InitDGDMesure(System.Convert.ToDouble(txtBoxWavelength.Text));
                    string jString = DeviceControl.GetJonesMatrix(System.Convert.ToDouble(txtBoxWavelength.Text), System.Convert.ToInt32(txtBoxDelay.Text));
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

        private void BtnResetRefJonesMat_Click(object sender, EventArgs e)
        {
            refJonesMat = CMath.UnitMatrix();

            lblJ11.Text = CMath.GetComplexString(refJonesMat.J11);
            lblJ12.Text = CMath.GetComplexString(refJonesMat.J12);
            lblJ21.Text = CMath.GetComplexString(refJonesMat.J21);
            lblJ22.Text = CMath.GetComplexString(refJonesMat.J22);
        }

        private void BtnShowRefJonesMat_Click(object sender, EventArgs e)
        {
            lblJ11.Text = CMath.GetComplexString(refJonesMat.J11);
            lblJ12.Text = CMath.GetComplexString(refJonesMat.J12);
            lblJ21.Text = CMath.GetComplexString(refJonesMat.J21);
            lblJ22.Text = CMath.GetComplexString(refJonesMat.J22);
        }

        private void btnShowHist_Click(object sender, EventArgs e)
        {
            this.Hide();
            HistogramForm newForm = new HistogramForm
            {
                RefToPolonForm = this
            };
            newForm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            wavelengths.Add(System.Convert.ToDouble(txtBoxWavelength.Text));

            listView.Items.Clear();
            for (int i = 0; i < wavelengths.Count; i++)
            {
                listView.Items.Add(wavelengths[i].ToString() + " nm", i);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            wavelengths.Clear();
            listView.Items.Clear();
        }
    }
}
