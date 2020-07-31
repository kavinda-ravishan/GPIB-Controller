using System;
using System.Drawing;
using System.Windows.Forms;
using NationalInstruments.NI4882;

namespace PolarizationAnalyzer
{
    public partial class MainForm : Form
    {
        private string text_S_1 = "VAL00 annnn.nnn;VAL01 annnn.nnn;VAL02 annnn.nnn;VAL03 annnn.nnn;VAL04 0.5;VAL05 annnn.nnn;VAL06 90.0;VAL07 annnn.nnn;VAL08 annnn.nnn;VAL09 annnn.nnn;VAL10 annnn.nnn;VAL11 annnn.nnn;VAL12 annnn.nnn;VAL13 annnn.nnn;VAL14 annnn.nnn;nnnn;Enn;";
        private string text_S0 = "VAL00  77.204;VAL01  16.427;VAL02   0.295;VAL03  39.486;VAL04   0.371;VAL05   0.121;VAL06  56.222;VAL07   0.000;VAL08  10.609;VAL09  -0.758;VAL10   0.363;VAL11   0.543;VAL12 -75.284;VAL13 -71.248;VAL14 -73.429;1000;E08\n";
        private string[] lables_S0 =
        {
            "elevation angle θ",
            "ellipticity angle η",
            "axis ratio tan | η |",
            "degree of polarization DOP",
            "tan ψ",
            "power ratio a",
            "phase difference ∆",
            "polarized power Ppol",
            "extinction ratio ER",
            "normalized Stokes parameter S1",
            "normalized Stokes parameter S2",
            "normalized Stokes parameter S3",
            "polarized power (dBm)",
            "total power",
            "unpolarized power(dBm)",
            "device status code",
            "error code"
        };

        private string[] S0(string data)
        {
            int x = 0;
            string[] values = new string[17];

            for (int i = 0; i < 15; i++)
            {
                values[i] = data.Substring(x + 5, 8);
                x = x + 14;
            }

            values[15] = data.Substring(x, 4);
            values[16] = data.Substring(x + 5, 3);

            return values;
        }

        private string[] S0_1(string data)
        {
            string[] VAL = data.Split(';');

            string[] values = new string[17];


            for (int i = 0; i < 15; i++)
            {
                values[i] = VAL[i].Split(' ')[1];
            }

            values[15] = VAL[VAL.Length - 3];
            values[16] = VAL[VAL.Length - 2];

            return values;
        }

        private void InitsecondaryAddressComboBox()
        {
            secondaryAddressComboBox.Items.Add("None");
            for (int i = 96; i <= 126; i++)
            {
                secondaryAddressComboBox.Items.Add(i);
            }
            secondaryAddressComboBox.SelectedIndex = 0;
        }

        private void SetupControlState(bool isSessionOpen)
        {
            boardIdNumericUpDown.Enabled = !isSessionOpen;
            primaryAddressNumericUpDown.Enabled = !isSessionOpen;
            secondaryAddressComboBox.Enabled = !isSessionOpen;
            openButton.Enabled = !isSessionOpen;
            closeButton.Enabled = isSessionOpen;
            stringToWriteTextBox.Enabled = isSessionOpen;
            writeButton.Enabled = isSessionOpen;
            readButton.Enabled = isSessionOpen;
            stringReadTextBox.Enabled = isSessionOpen;
        }

        private string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }

        private string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }

        Bitmap CreatBitMap(Color color, int rows, int cols)
        {
            Bitmap frame = new Bitmap(cols, rows);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    frame.SetPixel(i, j, color);
                }
            }
            return frame;
        }

        void DrowLinesOnBitmap(ref Bitmap frame, Point[] points, Color color)
        {
            Graphics g = Graphics.FromImage(frame);
            Pen pen = new Pen(color);
            g.DrawLines(pen, points);
            pen.Dispose();
            g.Dispose();
        }

        private void PolarizationEllipse(ref Point[] points, double Eyx, double delta)//Eyx(0 _ 1) delta(-pi _ pi)
        {

            t = 0;

            for (int i = 0; i < noPoints; i++)
            {
                t = (double)i / (noPoints - 1);
                points[i].X = (int)(Math.Round((Math.Sin(Omega * t) + 1) * 100)) + 1;
                points[i].Y = (int)(Math.Round((Eyx * Math.Sin((Omega * t) + delta) + 1) * 100)) + 1;
            }
        }
        private void PolarizationEllipse2(ref Point[] points, double Eyx, double delta)//Eyx(0 _ 1) delta(-180 _ 180)
        {
            delta = (delta * Math.PI) / 180;
            t = 0;

            for (int i = 0; i < noPoints; i++)
            {
                t = (double)i / (noPoints - 1);
                points[i].X = (int)(Math.Round((Math.Sin(Omega * t) + 1) * 100)) + 1;
                points[i].Y = (int)(Math.Round((Eyx * Math.Sin((Omega * t) + delta) + 1) * 100)) + 1;
            }
        }
        private void DrawCall(ref Bitmap frame, ref Point[] points)
        {
            frame = CreatBitMap(Color.White, pictureBox.Width, pictureBox.Height);
            DrowLinesOnBitmap(ref frame, points, Color.Black);
            frame.RotateFlip(RotateFlipType.Rotate180FlipX);
        }

        private Bitmap frame;

        private double Omega;
        private double Eyx;
        private double delta_x;
        private double delta;

        private double t;
        private Point[] points;

        private int noPoints;

        public MainForm()
        {
            InitializeComponent();
            SetupControlState(false);
            InitsecondaryAddressComboBox();

            noPoints = 20;
            points = new Point[noPoints];
            Omega = 2 * Math.PI * 1;
        }

        private void OpenButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Convert the Secondary Address Combo Text into a number.
                int currentSecondaryAddress = 0;
                if (secondaryAddressComboBox.SelectedIndex != 0)
                {
                    currentSecondaryAddress = (int)secondaryAddressComboBox.SelectedItem;
                }
                // Intialize the device
                device = new Device((int)boardIdNumericUpDown.Value, (byte)primaryAddressNumericUpDown.Value, (byte)currentSecondaryAddress);
                SetupControlState(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            try
            {
                device.Dispose();
                SetupControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WriteButton_Click(object sender, EventArgs e)
        {
            try
            {
                device.Write(ReplaceCommonEscapeSequences(stringToWriteTextBox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                stringReadTextBox.Text = InsertCommonEscapeSequences(device.ReadString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            Eyx = (double)trackBar1.Value / 100;//0 - 1
            lblEyx.Text = Eyx.ToString();

            delta_x = ((double)trackBar2.Value / 100) * 2 - 1;//-1 and 1
            delta = Math.PI * delta_x;//-PI and +PI

            PolarizationEllipse(ref points, Eyx, delta);
            DrawCall(ref frame, ref points);
            pictureBox.Image = frame;
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            Eyx = (double)trackBar1.Value / 100;//0 - 1

            delta_x = ((double)trackBar2.Value / 100) * 2 - 1;//-1 and 1
            lblDelta.Text = delta_x.ToString() + " Pi";
            delta = Math.PI * delta_x;//-PI and +PI

            PolarizationEllipse(ref points, Eyx, delta);
            DrawCall(ref frame, ref points);
            pictureBox.Image = frame;
        }

        private void BtnS0_Click(object sender, EventArgs e)
        {
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //stringReadTextBox.Text = InsertCommonEscapeSequences(device.ReadString());
                //------------------------Test Code--------------------------------------//
                stringReadTextBox.Enabled = true;
                stringReadTextBox.Clear();
                string[] data = S0(text_S0);
                
                //string[] data = S0(InsertCommonEscapeSequences(device.ReadString()));

                for (int i = 0; i < 17; i++)
                {
                    stringReadTextBox.Text += (lables_S0[i] + " - " + data[i] + Environment.NewLine);
                }

                delta = Convert.ToDouble(data[6]);
                Eyx = Convert.ToDouble(data[4]);

                PolarizationEllipse2(ref points, Eyx, delta);
                DrawCall(ref frame, ref points);
                pictureBox.Image = frame;
                //------------------------------End--------------------------------------//
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            
        }
    }
}

