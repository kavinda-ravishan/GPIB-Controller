using System;
using System.Drawing;
using System.Windows.Forms;
using NationalInstruments.NI4882;

namespace PolarizationAnalyzer
{
    public partial class MainForm : Form
    {
        private string text_S0 = "VAL00 annnn.nnn;VAL01 annnn.nnn;VAL02 annnn.nnn;VAL03 annnn.nnn;VAL04 annnn.nnn;VAL05 annnn.nnn;VAL06 annnn.nnn;VAL07 annnn.nnn;VAL08 annnn.nnn;VAL09 annnn.nnn;VAL10 annnn.nnn;VAL11 annnn.nnn;VAL12 annnn.nnn;VAL13 annnn.nnn;VAL14 annnn.nnn;nnnn;Enn;";
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

        private void PolarizationEllipse(ref Point[] points, double Eyx, double delata_x)
        {
            delta = Math.PI * delata_x;//-PI and +PI

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
        private double delata_x;
        private double delta;

        private double t;
        private Point[] points;

        private int noPoints;

        public MainForm()
        {
            InitializeComponent();
            SetupControlState(false);
            InitsecondaryAddressComboBox();

            string[] data = S0(text_S0);
            
            for (int i = 0; i < 17; i++)
            {
                stringReadTextBox.Text += (lables_S0[i] + " - " + data[i] + Environment.NewLine);
            }

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

            delata_x = ((double)trackBar2.Value / 100) * 2 - 1;//-1 and 1


            PolarizationEllipse(ref points, Eyx, delata_x);
            DrawCall(ref frame, ref points);
            pictureBox.Image = frame;
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            Eyx = (double)trackBar1.Value / 100;//0 - 1

            delata_x = ((double)trackBar2.Value / 100) * 2 - 1;//-1 and 1
            lblDelta.Text = delata_x.ToString() + " Pi";

            PolarizationEllipse(ref points, Eyx, delata_x);
            DrawCall(ref frame, ref points);
            pictureBox.Image = frame;
        }
    }
}
