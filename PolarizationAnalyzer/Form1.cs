using System;
using System.Windows.Forms;
using NationalInstruments.NI4882;

namespace PolarizationAnalyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetupControlState1(false);
            SetupControlState2(false);
            InitsecondaryAddressComboBox1();
            InitsecondaryAddressComboBox2();
        }
        private string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }
        private string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }

        //----------------- device 1 -------------------------------------//

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

        private string ErrorCheck(string Error)
        {
            string[] ErrorList =
            {
"E00 no error",
"E01 incorrect command or wrong character",
"E02 string of characters too long (> 250 characters without terminator)",
"E03 command buffer overflow(>8 commands without trigger command X; or[GET])",
"E04 incorrect parameter format",
"E05 parameter outside the allowed range",
"E06 parameter has too many digits after the decimal point",
"E07 optical power too high",
"E08 incorrect operating wavelength or incorrect optical head calibration (degree of polarization measured >100 %)",
"E09 no PAN9300 module(in the activated slot)",
"E10 no POL 9320-Modul(in the activated slot)",
"E12 no PAN-IR module",
"E13 no tunable laser",
"E14 incorrect type of PAN set",
"E15 type of PMD not set",
"E16 no reference Jones matrix available",
"E17 incorrect start wavelength",
"E18 incorrect stop wavelength",
"E19 incorrect wavelength step",
"E20 incorrect wavelength speed",
"E21 incorrect length of fiber",
"E22 incorrect K-factor",
"E23 incorrect value for delta_mm",
"E24 no PMD data available",
"E25 no PMD file available",
"E26 no turbo mode available for PAN9300",
"E29 no tunable laser for PMD measurements available",
"E30 No or wrong authorization code",
"E31 No turbo file existent",
"E33 Power below limit setting",
"E34 Insufficient measured points",
"E35 Unable to calculate ER",
"E36 Not sufficient fiber stress",
"E37 No typical PMF behavior(Warning only)",
"E38 Bad linear eigenmodes(Warning only)",
"E39 Error loading calibration file*.set",
"E46 No PAN-NIR",
"E47 No PAN-FIR",
"E99 1. Status request after switching the unit on or voltage failure of the unit",
"EEE"
        };
            string ErrorNo;

            int i;
            for (i = 0; i < ErrorList.Length-1; i++)
            {
                ErrorNo = ErrorList[i].Substring(0, 3);

                if(ErrorNo == Error) break;
            }
            return ErrorList[i];
        }

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
            values[16] = ErrorCheck(data.Substring(x + 5, 3));

            return values;
        }

        private void SetupControlState1(bool isSessionOpen)
        {
            boardIdNumericUpDown1.Enabled = !isSessionOpen;
            primaryAddressNumericUpDown1.Enabled = !isSessionOpen;
            secondaryAddressComboBox1.Enabled = !isSessionOpen;
            openButton1.Enabled = !isSessionOpen;
            closeButton1.Enabled = isSessionOpen;
            stringToWriteTextBox1.Enabled = isSessionOpen;
            writeButton1.Enabled = isSessionOpen;
            readButton1.Enabled = isSessionOpen;
            stringReadTextBox1.Enabled = isSessionOpen;
        }

        private void InitsecondaryAddressComboBox1()
        {
            secondaryAddressComboBox1.Items.Add("None");
            for (int i = 96; i <= 126; i++)
            {
                secondaryAddressComboBox1.Items.Add(i);
            }
            secondaryAddressComboBox1.SelectedIndex = 0;
        }

        private void OpenButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Convert the Secondary Address Combo Text into a number.
                int currentSecondaryAddress = 0;
                if (secondaryAddressComboBox1.SelectedIndex != 0)
                {
                    currentSecondaryAddress = (int)secondaryAddressComboBox1.SelectedItem;
                }
                // Intialize the device
                device1 = new Device((int)boardIdNumericUpDown1.Value, (byte)primaryAddressNumericUpDown1.Value, (byte)currentSecondaryAddress);
                SetupControlState1(true);
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
                device1.Dispose();
                SetupControlState1(false);
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
                device1.Write(ReplaceCommonEscapeSequences(stringToWriteTextBox1.Text));
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
                stringReadTextBox1.Text = InsertCommonEscapeSequences(device1.ReadString());
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

        private void BtnS0_Click(object sender, EventArgs e)
        {       
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                stringReadTextBox1.Enabled = true;
                stringReadTextBox1.Clear();

                device1.Write(ReplaceCommonEscapeSequences("S0;"));
                string[] data = S0(InsertCommonEscapeSequences(device1.ReadString()));
                //string[] data = S0(text_S0);

                for (int i = 0; i < 17; i++)
                {
                    stringReadTextBox1.Text += (lables_S0[i] + " - " + data[i] + Environment.NewLine);
                }

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

        //----------------- device 2 -------------------------------------//

        private void SetupControlState2(bool isSessionOpen)
        {
            boardIdNumericUpDown2.Enabled = !isSessionOpen;
            primaryAddressNumericUpDown2.Enabled = !isSessionOpen;
            secondaryAddressComboBox2.Enabled = !isSessionOpen;
            openButton2.Enabled = !isSessionOpen;
            closeButton2.Enabled = isSessionOpen;
            stringToWriteTextBox2.Enabled = isSessionOpen;
            writeButton2.Enabled = isSessionOpen;
            readButton2.Enabled = isSessionOpen;
            stringReadTextBox2.Enabled = isSessionOpen;
        }

        private void InitsecondaryAddressComboBox2()
        {
            secondaryAddressComboBox2.Items.Add("None");
            for (int i = 96; i <= 126; i++)
            {
                secondaryAddressComboBox2.Items.Add(i);
            }
            secondaryAddressComboBox2.SelectedIndex = 0;
        }

        private void OpenButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Convert the Secondary Address Combo Text into a number.
                int currentSecondaryAddress = 0;
                if (secondaryAddressComboBox2.SelectedIndex != 0)
                {
                    currentSecondaryAddress = (int)secondaryAddressComboBox2.SelectedItem;
                }
                // Intialize the device
                device2 = new Device((int)boardIdNumericUpDown2.Value, (byte)primaryAddressNumericUpDown2.Value, (byte)currentSecondaryAddress);
                SetupControlState2(true);
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

        private void CloseButton2_Click(object sender, EventArgs e)
        {
            try
            {
                device2.Dispose();
                SetupControlState2(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WriteButton2_Click(object sender, EventArgs e)
        {
            try
            {
                device2.Write(ReplaceCommonEscapeSequences(stringToWriteTextBox2.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReadButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                stringReadTextBox2.Text = InsertCommonEscapeSequences(device2.ReadString());
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

