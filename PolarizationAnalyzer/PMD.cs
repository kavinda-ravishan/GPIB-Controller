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

        static string MesureDGD(double wavelenght, int delay)
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
        }


        // declaring an event using built-in EventHandler
        public event EventHandler<PMDData> DGDMeasured;

        protected virtual void OnDGDMeasured(PMDData data)
        {
            DGDMeasured?.Invoke(this, data);
        }

        delegate void SetTextCallback(string text);

        private void PMDForm_DGDMeasured(object sender, PMDData e)
        {
            Console.WriteLine(e.waveLenght);
            Console.WriteLine(e.DGD);
            Console.WriteLine(e.PMD);
            Console.WriteLine();

            this.Invoke(new MethodInvoker(delegate ()
            {
                stringReadTextBox.Text += (e.waveLenght.ToString() + Environment.NewLine);
                stringReadTextBox.Text += (e.DGD.ToString() + Environment.NewLine);
                stringReadTextBox.Text += (e.PMD.ToString() + Environment.NewLine);
                stringReadTextBox.Text += (Environment.NewLine);
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
                string path = @"C:\Users\Kavinda Ravishan\source\repos\kavinda-ravishan\GPIB-Controller\DGD.xlsx";
                creat(path);
                Excel excel = new Excel(path, 1);
                excel.SelectWorkSheet(1);
                excel.WriteToCell(0, 0, "Wave Lenght");
                excel.WriteToCell(0, 1, "DGD");
                excel.WriteToCell(0, 2, "PMD");

                double start = 1550;
                double end = 1560;
                double stepSize = 1;
                double length = 17; // in Km
                double lengthSqrt = Math.Sqrt(length);

                int steps = (int)((end - start) / stepSize) + 3;

                double[] wavelenght = new double[steps];

                //find wavelenghts need to mesure
                for (int i = 0; i < steps; i++)
                {
                    wavelenght[i] = (start - stepSize) + (i * stepSize);
                }

                //for save PAT9300 JM information
                string[] jStrings = new string[steps];

                double[] DGDval = new double[2];

                PMDData[] data = new PMDData[steps - 2];
                double[,] DGDs = new double[steps - 2, 2];
                double[] PMDs = new double[steps - 2];

                int delay = 1000;

                //InitDGDMesure(start, 1000);

                for (int i = 0; i < steps; i++)
                {
                    if (i < 2)
                    {
                        //jStrings[i] = MesureDGD(wavelenght[i], delay);
                        jStrings[i] = Utility.text_J1;
                    }
                    else
                    {
                        //jStrings[i] = MesureDGD(wavelenght[i], delay);
                        jStrings[i] = Utility.text_J2;

                        DGDval = Utility.DGD(jStrings[i - 2], jStrings[i], wavelenght[i - 2], wavelenght[i]);//put jString here

                        data[i - 2].DGD = DGDval[0];
                        data[i - 2].waveLenght = DGDval[1];
                        data[i - 2].PMD = DGDval[0] / lengthSqrt;

                        excel.WriteToCell(i - 1, 0, data[i - 2].waveLenght.ToString());
                        excel.WriteToCell(i - 1, 1, data[i - 2].DGD.ToString());
                        excel.WriteToCell(i - 1, 2, data[i - 2].PMD.ToString());

                        OnDGDMeasured(data[i - 2]);
                    }
                }

                //Done();

                excel.Save();
                excel.Close();
            });
            thread.Start();
        }
    }
}
