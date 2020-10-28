﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace PolarizationAnalyzer
{
    public partial class polController : Form
    {
        public polController()
        {
            InitializeComponent();
            ServoRotated += PolController_ServoRotated;
        }

        double sqrtFiberLength;

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

        static string GetComplexString(ComplexCar complex)
        {
            if (complex.imag >= 0)
                return complex.real.ToString() + " +" + complex.imag.ToString() + " i";
            else
                return complex.real.ToString() + " " + complex.imag.ToString() + " i";
        }

        static void creat(string path)
        {
            Excel excel = new Excel();
            excel.CreatNewFile();
            excel.SaveAs(path);
            excel.Close();
        }

        static string MsgWaveLenghtSrc(double waveLenght = 1551.120)
        {
            return ":WAVElength " + waveLenght.ToString() + "nm";
        }

        static string MsgPowerSrc(double power = 1000)
        {
            return ":POWer " + power.ToString() + "uW";
        }

        static string MsgWaveLenghtPol(double waveLenght = 1551.12)
        {
            return "L " + waveLenght.ToString() + ";X;";
        }

        static void InitDGDMesure(double start, double power)
        {
            Console.WriteLine("Set Source Power - " + power.ToString());
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(MsgPowerSrc(power))); // set power to 1000uW
            Console.WriteLine("Laser is ON !");
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 1")); // turn on the laser
            Console.WriteLine("Set Source  WL - " + start.ToString());
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(MsgWaveLenghtSrc(start)));//change wavelength source
            Console.WriteLine("Set PAT9000 WL - " + start.ToString());
            Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences(MsgWaveLenghtPol(start)));//change wavelength pol
            Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("PO;X;"));//Optimizing the polarizer position in the module
        }

        static void Done()
        {
            Console.WriteLine("Laser is Off !");
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 0")); // turn off the laser
        }

        static string GetJonesMatrix(double wavelenght, int delay)
        {
            string jString;

            Console.WriteLine("Set Source  WL - " + wavelenght.ToString());
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(MsgWaveLenghtSrc(wavelenght)));//change wavelength source

            Console.WriteLine("Set PAT9000 WL - " + wavelenght.ToString());
            Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences(MsgWaveLenghtPol(wavelenght)));//change wavelength pol
            System.Threading.Thread.Sleep(delay);

            Console.WriteLine("Read JM        - " + wavelenght.ToString());
            Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("K 0;JM;X"));
            jString = Utility.InsertCommonEscapeSequences(Devices.devicePolarizationAnalyzer.ReadString());//put JM data here
            Console.WriteLine();
            return jString;
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

            string jStringw1 = GetJonesMatrix(pMDCharacteristics.waveLength - pMDCharacteristics.waveLengthStepSize, pMDCharacteristics.delay);
            //string jStringw1 = Utility.text_J1_1;//for testing
            string jStringw2 = GetJonesMatrix(pMDCharacteristics.waveLength + pMDCharacteristics.waveLengthStepSize, pMDCharacteristics.delay);
            //string jStringw2 = Utility.text_J1_2;//for testing

            double[] DGD = Utility.DGD(
                jStringw1, 
                jStringw2, 
                refJonesMat, 
                pMDCharacteristics.waveLength - pMDCharacteristics.waveLengthStepSize, 
                pMDCharacteristics.waveLength + pMDCharacteristics.waveLengthStepSize
                );

            pMD.DGD = DGD[0];
            pMD.PMD = DGD[0] / sqrtFiberLength;
            pMD.ServoAngle = servoAngle;

            pMDCharacteristics.PMDDatas.Add(pMD);
        }

        public struct ServoAngle
        {
            public string servoA;
            public string servoB;
            public string servoC;
        }
        public struct PMDData
        {
            public ServoAngle ServoAngle;
            public double DGD;
            public double PMD;
        }
        public struct PMDCharacteristics
        {
            public int stepSize;
            public double waveLength;
            public double waveLengthStepSize;
            public double laserPower;
            public int delay;
            public double fiberLength;
            public List<PMDData> PMDDatas;
        }
        private string[] portNames;
        private SerialPort serialPort;
        ServoAngle servoAngle;
        PMDCharacteristics pMDCharacteristics;
        string ack;
        bool nextMeasurement;
        bool threadRun;

        JonesMatCar refJonesMat;

        public Form RefToMainForm { get; set; }

        private void btnFindPorts_Click(object sender, EventArgs e)
        {
            cmbCOMPorts.Items.Clear();
            portNames = SerialPort.GetPortNames();

            foreach (string port in portNames)
            {
                cmbCOMPorts.Items.Add(port);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
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

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            serialPort.Dispose();

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        private void btnWrite_Click(object sender, EventArgs e)
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                pMDCharacteristics = new PMDCharacteristics();
                pMDCharacteristics.PMDDatas = new List<PMDData>();

                int stepSize = System.Convert.ToInt32(txtBoxStepSize.Text);

                pMDCharacteristics.stepSize = stepSize;
                pMDCharacteristics.waveLength = System.Convert.ToDouble(txtBoxWavelength.Text);
                pMDCharacteristics.waveLengthStepSize = System.Convert.ToDouble(txtBoxWaveStep.Text);
                pMDCharacteristics.laserPower = System.Convert.ToDouble(txtBoxLaserPower.Text);
                pMDCharacteristics.delay = System.Convert.ToInt32(txtBoxDelay.Text);
                pMDCharacteristics.fiberLength = System.Convert.ToDouble(txtBoxFiberLength.Text);

                sqrtFiberLength = Math.Sqrt(pMDCharacteristics.fiberLength);

                InitDGDMesure(pMDCharacteristics.waveLength, pMDCharacteristics.laserPower);

                Thread thread = new Thread(() =>
                {
                    threadRun = true;
                    for (int A = 0; A <= 180; A = A + stepSize)
                    {
                        for (int B = 0; B <= 180; B = B + stepSize)
                        {
                            for (int C = 0; C <= 180; C = C + stepSize)
                            {
                                servoAngle.servoA = A.ToString();
                                servoAngle.servoB = B.ToString();
                                servoAngle.servoC = C.ToString();

                                serialPort.WriteLine("PMD" + servoAngle.servoA + ":" + servoAngle.servoB + ":" + servoAngle.servoC);

                                nextMeasurement = false;
                                while (!nextMeasurement) { }
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
                    Done();
                });
                thread.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            threadRun = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = " ";

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderDlg.SelectedPath + "\\" + txtBoxPath.Text + ".xlsx";

                Thread thread = new Thread(() =>
                {
                    try
                    {
                        creat(path);
                        Excel excel = new Excel(path, 1);
                        excel.SelectWorkSheet(1);

                        excel.WriteToCell(0, 0, "Wavelength");
                        excel.WriteToCell(1, 0, pMDCharacteristics.waveLength.ToString());

                        excel.WriteToCell(1, 0, "DGD");
                        excel.WriteToCell(1, 1, "Servo A");
                        excel.WriteToCell(1, 2, "Servo B");
                        excel.WriteToCell(1, 3, "Servo C");

                        for (int i = 0; i < pMDCharacteristics.PMDDatas.Count; i++)
                        {
                            excel.WriteToCell(i + 2, 0, pMDCharacteristics.PMDDatas[i].DGD.ToString());
                            excel.WriteToCell(i + 2, 1, pMDCharacteristics.PMDDatas[i].ServoAngle.servoA.ToString());
                            excel.WriteToCell(i + 2, 2, pMDCharacteristics.PMDDatas[i].ServoAngle.servoB.ToString());
                            excel.WriteToCell(i + 2, 3, pMDCharacteristics.PMDDatas[i].ServoAngle.servoC.ToString());
                        }
                        excel.Save();
                        excel.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
                thread.Start();
            }
        }

        private void picCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            RefToMainForm.Show();
        }

        private void btnMeasureRefJonesMat_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    InitDGDMesure(System.Convert.ToDouble(txtBoxWavelength.Text), System.Convert.ToInt32(txtBoxLaserPower.Text));
                    string jString = GetJonesMatrix(System.Convert.ToDouble(txtBoxWavelength.Text), System.Convert.ToInt32(txtBoxDelay.Text));
                    Done();

                    double[] jMatValues = Utility.JonesString2Double(jString);
                    //double[] jMatValues = Utility.JonesString2Double(Utility.text_J1);//for testing

                    JonesMatPol matPol = Utility.JonesDoubleArray2JonesMat(jMatValues);
                    refJonesMat = CMath.Inverse(CMath.Pol2Car(matPol));

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        //update labels
                        lblJ11.Text = GetComplexString(refJonesMat.J11);
                        lblJ12.Text = GetComplexString(refJonesMat.J12);
                        lblJ21.Text = GetComplexString(refJonesMat.J21);
                        lblJ22.Text = GetComplexString(refJonesMat.J22);
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            thread.Start();
        }

        private void btnResetRefJonesMat_Click(object sender, EventArgs e)
        {
            refJonesMat = CMath.UnitMatrix();

            lblJ11.Text = GetComplexString(refJonesMat.J11);
            lblJ12.Text = GetComplexString(refJonesMat.J12);
            lblJ21.Text = GetComplexString(refJonesMat.J21);
            lblJ22.Text = GetComplexString(refJonesMat.J22);
        }

        private void btnShowRefJonesMat_Click(object sender, EventArgs e)
        {
            lblJ11.Text = GetComplexString(refJonesMat.J11);
            lblJ12.Text = GetComplexString(refJonesMat.J12);
            lblJ21.Text = GetComplexString(refJonesMat.J21);
            lblJ22.Text = GetComplexString(refJonesMat.J22);
        }
    }
}
