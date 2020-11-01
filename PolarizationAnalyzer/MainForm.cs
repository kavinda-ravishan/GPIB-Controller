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

            LaserSourceTextBoxSuggestAppend();
        }

        private void PicCloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close this application ?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

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

        #region Polarization Analyzer

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
            //stringReadTextBox1.Enabled = isSessionOpen;
            btnJM.Enabled = isSessionOpen;
            btnS0.Enabled = isSessionOpen;
            btnSB.Enabled = isSessionOpen;
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
                Devices.devicePolarizationAnalyzer = new Device((int)boardIdNumericUpDown1.Value, (byte)primaryAddressNumericUpDown1.Value, (byte)currentSecondaryAddress);
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
                Devices.devicePolarizationAnalyzer.Dispose();
                Devices.devicePolarizationAnalyzer = null;
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
                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences(stringToWriteTextBox1.Text));
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
                stringReadTextBox1.Text = Utility.InsertCommonEscapeSequences(Devices.devicePolarizationAnalyzer.ReadString());
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

                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("S0;"));
                string[] data = Utility.S0_filter(Utility.DataSeparator(Utility.InsertCommonEscapeSequences(Devices.devicePolarizationAnalyzer.ReadString())));
                //string[] data = Utility.S0_filter(Utility.DataSeparator(Utility.text_S0)); //for testing

                for (int i = 0; i < data.Length; i++)
                {
                    stringReadTextBox1.Text += (Utility.Lables_S0[i] + " -> " + data[i] + Environment.NewLine);
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

        private void BtnSB_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                stringReadTextBox1.Enabled = true;
                stringReadTextBox1.Clear();

                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("SB;"));
                string[] data = Utility.SB_filter(Utility.DataSeparator(Utility.InsertCommonEscapeSequences(Devices.devicePolarizationAnalyzer.ReadString())));
                //string[] data = Utility.SB_filter(Utility.DataSeparator(Utility.text_SB));//for testing

                for (int i = 0; i < data.Length; i++)
                {
                    stringReadTextBox1.Text += (Utility.Lables_SB[i] + " -> " + data[i] + Environment.NewLine);
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

        private void BtnJM_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                stringReadTextBox1.Enabled = true;
                stringReadTextBox1.Clear();

                Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("JM;"));
                string[] data = Utility.JM_filter(Utility.DataSeparator(Utility.InsertCommonEscapeSequences(Devices.devicePolarizationAnalyzer.ReadString())));
                //string[] data = Utility.JM_filter(Utility.DataSeparator(Utility.text_J1));//for testing

                for (int i = 0; i < data.Length; i++)
                {
                    stringReadTextBox1.Text += (Utility.Lables_JM[i] + " -> " + data[i] + Environment.NewLine);
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

        #endregion

        #region Laser Source

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
            //stringReadTextBox2.Enabled = isSessionOpen;
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

        //Display and append suggestions
        private void LaserSourceTextBoxSuggestAppend()
        {
            stringToWriteTextBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            stringToWriteTextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            ItemsLaserSource(DataCollection);
            stringToWriteTextBox2.AutoCompleteCustomSource = DataCollection;
        }

        //predefined commands for laser source
        private void ItemsLaserSource(AutoCompleteStringCollection col)
        {
            col.Add(":WAVElength?");
            col.Add(":WAVElength +1.55000000E-006");
            col.Add(":POWer?");
            col.Add(":POWer +7.50000000E-004");
            col.Add(":OUTPut?");
            col.Add(":OUTPut 1");
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
                Devices.deviceLaserSource = new Device((int)boardIdNumericUpDown2.Value, (byte)primaryAddressNumericUpDown2.Value, (byte)currentSecondaryAddress);
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
                Devices.deviceLaserSource.Dispose();
                Devices.deviceLaserSource = null;
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
                Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(stringToWriteTextBox2.Text));
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
                stringReadTextBox2.Text = Utility.InsertCommonEscapeSequences(Devices.deviceLaserSource.ReadString());
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

        #endregion

        #region Common
        private void BtnFindDevices_Click(object sender, EventArgs e)
        {
            try
            {
                Board board = new Board(0);
                board.SendInterfaceClear();
                AddressCollection addressCollection = board.FindListeners();

                richTextBoxDevices.Clear();
                for (int i = 0; i < addressCollection.Count; i++)
                {
                    richTextBoxDevices.Text += (
                        "Primary Address : " + addressCollection[i].PrimaryAddress + " , " +
                        "Secondary Address : " + addressCollection[i].SecondaryAddress +
                        Environment.NewLine);
                }
                board.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPMD_Click(object sender, EventArgs e)
        {
            if ((Devices.devicePolarizationAnalyzer != null) & (Devices.deviceLaserSource != null))
            {
                this.Hide();
                PMDForm newForm = new PMDForm
                {
                    RefToMainForm = this
                };
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Device not initialized");
            }
        }

        private void BtnStokes_Click(object sender, EventArgs e)
        {
            if (Devices.devicePolarizationAnalyzer != null)
            {
                this.Hide();
                StoksForm newForm = new StoksForm
                {
                    RefToMainForm = this
                };
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Device not initialized");
            }
        }
        #endregion

        private void BtnPolController_Click(object sender, EventArgs e)
        {
            if (Devices.devicePolarizationAnalyzer != null && Devices.deviceLaserSource != null)
            {
                this.Hide();
                polController newForm = new polController
                {
                    RefToMainForm = this
                };
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Device not initialized");
            }
        }
    }
}

