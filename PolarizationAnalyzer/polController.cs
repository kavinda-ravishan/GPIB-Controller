using System;
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

        static void creat(string path)
        {
            Excel excel = new Excel();
            excel.CreatNewFile();
            excel.SaveAs(path);
            excel.Close();
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

            pMD.DGD = 0;
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
        }
        public struct PMDCharacteristics
        {
            public int stepSize;
            public double waveLength;
            public List<PMDData> PMDDatas;
        }
        private string[] portNames;
        private SerialPort serialPort;
        ServoAngle servoAngle;
        PMDCharacteristics pMDCharacteristics;
        string ack;
        bool nextMeasurement;
        bool threadRun;

        public Form RefToMainForm { get; set; }

        private void polController_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
            RefToMainForm.Show();
        }

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
                    OnServoRotated(ack);
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
            pMDCharacteristics = new PMDCharacteristics();
            pMDCharacteristics.PMDDatas = new List<PMDData>();

            int stepSize = System.Convert.ToInt32(txtBoxStepSize.Text);

            pMDCharacteristics.stepSize = stepSize;
            pMDCharacteristics.waveLength = System.Convert.ToDouble(txtBoxWavelength.Text);

            if (serialPort != null)
            {
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
                                if (threadRun == false)
                                    break;
                            }
                            if (threadRun == false)
                                break;
                        }
                        if (threadRun == false)
                            break;
                    }
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
    }
}
