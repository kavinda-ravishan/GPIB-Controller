using System;
using System.Threading;
using System.Windows.Forms;

namespace PolarizationAnalyzer
{
    public partial class PMDForm : Form
    {
        public PMDForm()
        {
            InitializeComponent();
            DGDMeasured += PMDForm_DGDMeasured;
            threadRun = true;

            refJonesMat = CMath.UnitMatrix();
        }

        public Form RefToMainForm { get; set; }

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

        static string GetComplexString(ComplexCar complex)
        {
            if (complex.imag >= 0)
                return complex.real.ToString() + " +" + complex.imag.ToString() + " i";
            else
                return complex.real.ToString() + " " + complex.imag.ToString() + " i";
        }

        public struct PMDData
        {
            public double waveLenght;
            public double DGD;
            public double PMD;
            public int i;
        }

        public struct PMDSettings
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
        }

        PMDData[] data;
        PMDSettings settings;

        JonesMatCar refJonesMat;

        private static bool threadRun;

        // declaring an event using built-in EventHandler
        public event EventHandler<PMDData> DGDMeasured;

        protected virtual void OnDGDMeasured(PMDData data)
        {
            DGDMeasured?.Invoke(this, data);
        }

        private void PMDForm_DGDMeasured(object sender, PMDData e)
        {
            Console.WriteLine(e.waveLenght);
            Console.WriteLine(e.DGD);
            Console.WriteLine(e.PMD);
            Console.WriteLine();

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

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    //take user inputs
                    settings.start = System.Convert.ToDouble(txtBoxStart.Text);
                    settings.stop = System.Convert.ToDouble(txtBoxStop.Text); ;
                    settings.stepSize = System.Convert.ToDouble(txtBoxStep.Text);
                    settings.length = System.Convert.ToDouble(txtBoxLength.Text); // in Km
                    settings.laserPower = System.Convert.ToInt32(txtBoxLaserPower.Text);
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
                    string[] jStrings = new string[steps];
                    double[] DGDval = new double[2];
                    data = new PMDData[steps - 2];
                    double sumPMD = 0;
                    
                    int delay = 1000;

                    //Invoke methods for allow cross thread oparations
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        stringReadTextBox.Clear();
                    }));
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        chart.Series["PMD"].Points.Clear();
                    }));

                    //laser on
                    InitDGDMesure(settings.start, settings.laserPower);

                    threadRun = true;

                    for (int i = 0; i < steps; i++)
                    {
                        if (threadRun)
                        {
                            if (i < 2)
                            {
                                jStrings[i] = GetJonesMatrix(wavelenght[i], delay);
                                //jStrings[i] = Utility.text_J1;//for testing
                            }
                            else
                            {
                                jStrings[i] = GetJonesMatrix(wavelenght[i], delay);
                                //jStrings[i] = Utility.text_J1;//for testing

                                DGDval = Utility.DGD(jStrings[i - 2], jStrings[i], refJonesMat, wavelenght[i - 2], wavelenght[i]);//Meaure DGD for arg1 and arg2 jones matrices
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
                            }
                        }
                        else break;
                    }
                    //laser off
                    Done();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            thread.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (settings.length != 0)
            {
                string path = " ";

                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;
                // Show the FolderBrowserDialog.  
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    path = folderDlg.SelectedPath + "\\" + txtBoxFileName.Text + ".xlsx";

                    Thread thread = new Thread(() =>
                    {
                        try
                        {
                            creat(path);
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

                            excel.WriteToCell(2, 0, "Fiber lenght");
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

                            excel.WriteToCell(7, 1, "Wave Lenght (nm)");
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
                        catch(Exception ex)
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

        private void btnStop_Click(object sender, EventArgs e)
        {
            threadRun = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string path = " ";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Title = "Load excel file";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.DefaultExt = "xlsx";
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
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

                    int steps = (int)((settings.stop - settings.start) / settings.stepSize) + 3;
                    data = new PMDData[steps - 2];

                    for (int i = 0; i < steps - 2; i++)
                    {
                        data[i].i = System.Convert.ToInt32(excel.ReadExcel(i + 8, 0));
                        data[i].waveLenght = System.Convert.ToDouble(excel.ReadExcel(i + 8, 1));
                        data[i].DGD = System.Convert.ToDouble(excel.ReadExcel(i + 8, 2));
                        data[i].PMD = System.Convert.ToDouble(excel.ReadExcel(i + 8, 3));
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

                        for (int i = 0; i < data.Length; i++)
                        {

                            chart.Series["PMD"].Points.AddXY(data[i].waveLenght, data[i].PMD);

                            stringReadTextBox.Text += (data[i].waveLenght.ToString() + " nm" + Environment.NewLine);
                            stringReadTextBox.Text += ("DGD : " + data[i].DGD.ToString() + " ps" + Environment.NewLine);
                            stringReadTextBox.Text += ("PMD : " + data[i].PMD.ToString() + Environment.NewLine);
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

        private void picCloseButton_Click(object sender, EventArgs e)
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

        private void btnShowRefJonesMat_Click(object sender, EventArgs e)
        {
            lblJ11.Text = GetComplexString(refJonesMat.J11);
            lblJ12.Text = GetComplexString(refJonesMat.J12);
            lblJ21.Text = GetComplexString(refJonesMat.J21);
            lblJ22.Text = GetComplexString(refJonesMat.J22);
        }

        private void btnResetRefJonesMat_Click(object sender, EventArgs e)
        {
            refJonesMat = CMath.UnitMatrix();

            lblJ11.Text = GetComplexString(refJonesMat.J11);
            lblJ12.Text = GetComplexString(refJonesMat.J12);
            lblJ21.Text = GetComplexString(refJonesMat.J21);
            lblJ22.Text = GetComplexString(refJonesMat.J22);
        }

        private void btnMeasureRefJonesMat_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    InitDGDMesure(System.Convert.ToDouble(txtBoxStart.Text), System.Convert.ToInt32(txtBoxLaserPower.Text));
                    string jString = GetJonesMatrix(System.Convert.ToDouble(txtBoxStart.Text), 1000);
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
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            thread.Start();
        }
    }
}
