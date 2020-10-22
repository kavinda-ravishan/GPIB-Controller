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
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(MsgPowerSrc(power))); // set power to 1000uW
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 1")); // turn on the laser
            Console.WriteLine("Set Source  WL - " + start.ToString());
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(MsgWaveLenghtSrc(start)));//change wavelength source
            Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("PO;X;"));//Optimizing the polarizer position in the module
        }

        static void Done()
        {
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
            public double end;
            public double stepSize;
            public double length; // in Km
            public double meanPMD;
            public double min;
            public double minWaveLength;
            public double max;
            public double maxWaveLength;
        }

        PMDData[] data;
        PMDSettings settings;

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

        private void PMDForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefToMainForm.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                settings.start = System.Convert.ToDouble(txtBoxStart.Text);
                settings.end = System.Convert.ToDouble(txtBoxEnd.Text); ;
                settings.stepSize = System.Convert.ToDouble(txtBoxStep.Text); ;
                settings.length = System.Convert.ToDouble(txtBoxLength.Text); ; // in Km
                settings.meanPMD = 0;

                double lengthSqrt = Math.Sqrt(settings.length);

                int steps = (int)((settings.end - settings.start) / settings.stepSize) + 3;

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

                this.Invoke(new MethodInvoker(delegate ()
                {
                    stringReadTextBox.Clear();
                }));
                this.Invoke(new MethodInvoker(delegate ()
                {
                    chart.Series["PMD"].Points.Clear();
                }));

                //InitDGDMesure(start, 1000);

                threadRun = true;

                for (int i = 0; i < steps; i++)
                {
                    if (threadRun)
                    {
                        if (i < 2)
                        {
                            //jStrings[i] = GetJonesMatrix(wavelenght[i], delay);
                            jStrings[i] = Utility.text_J1;
                        }
                        else
                        {
                            //jStrings[i] = GetJonesMatrix(wavelenght[i], delay);
                            jStrings[i] = Utility.text_J2;

                            DGDval = Utility.DGD(jStrings[i - 2], jStrings[i], wavelenght[i - 2], wavelenght[i]);//put jString here

                            data[i - 2].DGD = DGDval[0];
                            data[i - 2].waveLenght = DGDval[1];
                            data[i - 2].PMD = DGDval[0] / lengthSqrt;
                            data[i - 2].i = i - 1;
                            sumPMD = data[i - 2].PMD + sumPMD;
                            settings.meanPMD = sumPMD / data[i - 2].i;

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

                            OnDGDMeasured(data[i - 2]);
                        }
                    }
                    else break;
                }

                //Done();

            });
            thread.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                string path = @"C:\Users\Kavinda Ravishan\source\repos\kavinda-ravishan\GPIB-Controller\DGD.xlsx";
                creat(path);
                Excel excel = new Excel(path, 1);
                excel.SelectWorkSheet(1);

                excel.WriteToCell(0, 0, "From");
                excel.WriteToCell(0, 1, settings.start.ToString());
                excel.WriteToCell(0, 2, "nm");
                excel.WriteToCell(0, 3, "to");
                excel.WriteToCell(0, 4, settings.end.ToString());
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
            });
            thread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            threadRun = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                string path = @"C:\Users\Kavinda Ravishan\source\repos\kavinda-ravishan\GPIB-Controller\DGD.xlsx";
                Excel excel = new Excel(path, 1);
                excel.SelectWorkSheet(1);

                settings.start = System.Convert.ToDouble(excel.ReadExcel(0, 1));
                settings.end = System.Convert.ToDouble(excel.ReadExcel(0, 4));

                settings.stepSize = System.Convert.ToDouble(excel.ReadExcel(1, 1));

                settings.length = System.Convert.ToDouble(excel.ReadExcel(2, 1));

                settings.meanPMD = System.Convert.ToDouble(excel.ReadExcel(3, 1));

                settings.min = System.Convert.ToDouble(excel.ReadExcel(4, 1));
                settings.minWaveLength = System.Convert.ToDouble(excel.ReadExcel(4, 3));

                settings.max = System.Convert.ToDouble(excel.ReadExcel(5, 1));
                settings.maxWaveLength = System.Convert.ToDouble(excel.ReadExcel(5, 3));

                int steps = (int)((settings.end - settings.start) / settings.stepSize) + 3;
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
                    txtBoxEnd.Text = settings.end.ToString();
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
}
