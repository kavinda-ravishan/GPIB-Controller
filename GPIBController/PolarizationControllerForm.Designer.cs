namespace GPIBController
{
    partial class PolarizationControllerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PolarizationControllerForm));
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbCOMPorts = new System.Windows.Forms.ComboBox();
            this.btnFindPorts = new System.Windows.Forms.Button();
            this.txtBoxServoA = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.lblRData = new System.Windows.Forms.Label();
            this.txtBoxServoB = new System.Windows.Forms.TextBox();
            this.txtBoxServoC = new System.Windows.Forms.TextBox();
            this.txtBoxStepSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblServoA = new System.Windows.Forms.Label();
            this.lblServoB = new System.Windows.Forms.Label();
            this.lblServoC = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxWavelength = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.lbltitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picCloseButton = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxWaveStep = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxLaserPower = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxDelay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxFiberLength = new System.Windows.Forms.TextBox();
            this.btnResetRefJonesMat = new System.Windows.Forms.Button();
            this.btnMeasureRefJonesMat = new System.Windows.Forms.Button();
            this.btnShowRefJonesMat = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lblJ22 = new System.Windows.Forms.Label();
            this.lblJ21 = new System.Windows.Forms.Label();
            this.lblJ12 = new System.Windows.Forms.Label();
            this.lblJ11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShowHIst = new System.Windows.Forms.Button();
            this.stringReadTextBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBoxStart = new System.Windows.Forms.TextBox();
            this.txtBoxStop = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.radioButtonJM = new System.Windows.Forms.RadioButton();
            this.radioButtonS = new System.Windows.Forms.RadioButton();
            this.radioButtonED = new System.Windows.Forms.RadioButton();
            this.groupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseButton)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Blue;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.Location = new System.Drawing.Point(169, 93);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(78, 40);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Blue;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(45, 93);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(78, 40);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // cmbCOMPorts
            // 
            this.cmbCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCOMPorts.FormattingEnabled = true;
            this.cmbCOMPorts.Location = new System.Drawing.Point(45, 45);
            this.cmbCOMPorts.Name = "cmbCOMPorts";
            this.cmbCOMPorts.Size = new System.Drawing.Size(114, 21);
            this.cmbCOMPorts.TabIndex = 5;
            // 
            // btnFindPorts
            // 
            this.btnFindPorts.BackColor = System.Drawing.Color.Blue;
            this.btnFindPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPorts.ForeColor = System.Drawing.Color.White;
            this.btnFindPorts.Location = new System.Drawing.Point(169, 43);
            this.btnFindPorts.Name = "btnFindPorts";
            this.btnFindPorts.Size = new System.Drawing.Size(78, 23);
            this.btnFindPorts.TabIndex = 4;
            this.btnFindPorts.Text = "Find Ports";
            this.btnFindPorts.UseVisualStyleBackColor = false;
            this.btnFindPorts.Click += new System.EventHandler(this.BtnFindPorts_Click);
            // 
            // txtBoxServoA
            // 
            this.txtBoxServoA.Location = new System.Drawing.Point(45, 191);
            this.txtBoxServoA.Name = "txtBoxServoA";
            this.txtBoxServoA.Size = new System.Drawing.Size(33, 20);
            this.txtBoxServoA.TabIndex = 8;
            this.txtBoxServoA.Text = "0";
            this.txtBoxServoA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnWrite
            // 
            this.btnWrite.BackColor = System.Drawing.Color.Blue;
            this.btnWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWrite.ForeColor = System.Drawing.Color.White;
            this.btnWrite.Location = new System.Drawing.Point(45, 227);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(195, 34);
            this.btnWrite.TabIndex = 11;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = false;
            this.btnWrite.Click += new System.EventHandler(this.BtnWrite_Click);
            // 
            // lblRData
            // 
            this.lblRData.AutoSize = true;
            this.lblRData.ForeColor = System.Drawing.Color.White;
            this.lblRData.Location = new System.Drawing.Point(123, 304);
            this.lblRData.Name = "lblRData";
            this.lblRData.Size = new System.Drawing.Size(16, 13);
            this.lblRData.TabIndex = 11;
            this.lblRData.Text = "---";
            // 
            // txtBoxServoB
            // 
            this.txtBoxServoB.Location = new System.Drawing.Point(126, 191);
            this.txtBoxServoB.Name = "txtBoxServoB";
            this.txtBoxServoB.Size = new System.Drawing.Size(33, 20);
            this.txtBoxServoB.TabIndex = 9;
            this.txtBoxServoB.Text = "0";
            this.txtBoxServoB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxServoC
            // 
            this.txtBoxServoC.Location = new System.Drawing.Point(207, 191);
            this.txtBoxServoC.Name = "txtBoxServoC";
            this.txtBoxServoC.Size = new System.Drawing.Size(33, 20);
            this.txtBoxServoC.TabIndex = 10;
            this.txtBoxServoC.Text = "0";
            this.txtBoxServoC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxStepSize
            // 
            this.txtBoxStepSize.Location = new System.Drawing.Point(653, 187);
            this.txtBoxStepSize.Name = "txtBoxStepSize";
            this.txtBoxStepSize.Size = new System.Drawing.Size(100, 20);
            this.txtBoxStepSize.TabIndex = 13;
            this.txtBoxStepSize.Text = "10";
            this.txtBoxStepSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(544, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Step size";
            // 
            // lblServoA
            // 
            this.lblServoA.AutoSize = true;
            this.lblServoA.ForeColor = System.Drawing.Color.White;
            this.lblServoA.Location = new System.Drawing.Point(608, 333);
            this.lblServoA.Name = "lblServoA";
            this.lblServoA.Size = new System.Drawing.Size(16, 13);
            this.lblServoA.TabIndex = 16;
            this.lblServoA.Text = "---";
            // 
            // lblServoB
            // 
            this.lblServoB.AutoSize = true;
            this.lblServoB.ForeColor = System.Drawing.Color.White;
            this.lblServoB.Location = new System.Drawing.Point(668, 333);
            this.lblServoB.Name = "lblServoB";
            this.lblServoB.Size = new System.Drawing.Size(16, 13);
            this.lblServoB.TabIndex = 17;
            this.lblServoB.Text = "---";
            // 
            // lblServoC
            // 
            this.lblServoC.AutoSize = true;
            this.lblServoC.ForeColor = System.Drawing.Color.White;
            this.lblServoC.Location = new System.Drawing.Point(729, 333);
            this.lblServoC.Name = "lblServoC";
            this.lblServoC.Size = new System.Drawing.Size(16, 13);
            this.lblServoC.TabIndex = 18;
            this.lblServoC.Text = "---";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Blue;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(695, 266);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(111, 35);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(308, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Wavelength";
            // 
            // txtBoxWavelength
            // 
            this.txtBoxWavelength.Location = new System.Drawing.Point(379, 46);
            this.txtBoxWavelength.Name = "txtBoxWavelength";
            this.txtBoxWavelength.Size = new System.Drawing.Size(100, 20);
            this.txtBoxWavelength.TabIndex = 20;
            this.txtBoxWavelength.Text = "1550";
            this.txtBoxWavelength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Blue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(25, 455);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 34);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "File name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Location = new System.Drawing.Point(83, 423);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.Size = new System.Drawing.Size(172, 20);
            this.txtBoxPath.TabIndex = 23;
            this.txtBoxPath.Text = "data";
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Orbitron", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.White;
            this.lbltitle.Location = new System.Drawing.Point(41, 10);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(258, 20);
            this.lbltitle.TabIndex = 82;
            this.lbltitle.Text = "Polarization Controller Tool";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 87;
            this.pictureBox1.TabStop = false;
            // 
            // picCloseButton
            // 
            this.picCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("picCloseButton.Image")));
            this.picCloseButton.Location = new System.Drawing.Point(1113, 10);
            this.picCloseButton.Name = "picCloseButton";
            this.picCloseButton.Size = new System.Drawing.Size(27, 24);
            this.picCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCloseButton.TabIndex = 88;
            this.picCloseButton.TabStop = false;
            this.picCloseButton.Click += new System.EventHandler(this.PicCloseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(544, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 90;
            this.label4.Text = "Wavelngth step size";
            // 
            // txtBoxWaveStep
            // 
            this.txtBoxWaveStep.Location = new System.Drawing.Point(653, 46);
            this.txtBoxWaveStep.Name = "txtBoxWaveStep";
            this.txtBoxWaveStep.Size = new System.Drawing.Size(100, 20);
            this.txtBoxWaveStep.TabIndex = 89;
            this.txtBoxWaveStep.Text = "1";
            this.txtBoxWaveStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(544, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 92;
            this.label5.Text = "Laser power";
            // 
            // txtBoxLaserPower
            // 
            this.txtBoxLaserPower.Location = new System.Drawing.Point(653, 98);
            this.txtBoxLaserPower.Name = "txtBoxLaserPower";
            this.txtBoxLaserPower.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLaserPower.TabIndex = 91;
            this.txtBoxLaserPower.Text = "1000";
            this.txtBoxLaserPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(544, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 94;
            this.label6.Text = "Delay";
            // 
            // txtBoxDelay
            // 
            this.txtBoxDelay.Location = new System.Drawing.Point(653, 124);
            this.txtBoxDelay.Name = "txtBoxDelay";
            this.txtBoxDelay.Size = new System.Drawing.Size(100, 20);
            this.txtBoxDelay.TabIndex = 93;
            this.txtBoxDelay.Text = "1000";
            this.txtBoxDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(544, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 96;
            this.label7.Text = "Fiber length";
            // 
            // txtBoxFiberLength
            // 
            this.txtBoxFiberLength.Location = new System.Drawing.Point(653, 72);
            this.txtBoxFiberLength.Name = "txtBoxFiberLength";
            this.txtBoxFiberLength.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFiberLength.TabIndex = 95;
            this.txtBoxFiberLength.Text = "14";
            this.txtBoxFiberLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnResetRefJonesMat
            // 
            this.btnResetRefJonesMat.BackColor = System.Drawing.Color.Blue;
            this.btnResetRefJonesMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetRefJonesMat.ForeColor = System.Drawing.Color.White;
            this.btnResetRefJonesMat.Location = new System.Drawing.Point(663, 459);
            this.btnResetRefJonesMat.Name = "btnResetRefJonesMat";
            this.btnResetRefJonesMat.Size = new System.Drawing.Size(171, 40);
            this.btnResetRefJonesMat.TabIndex = 104;
            this.btnResetRefJonesMat.Text = "Reset reference Jones matrix";
            this.btnResetRefJonesMat.UseVisualStyleBackColor = false;
            this.btnResetRefJonesMat.Click += new System.EventHandler(this.BtnResetRefJonesMat_Click);
            // 
            // btnMeasureRefJonesMat
            // 
            this.btnMeasureRefJonesMat.BackColor = System.Drawing.Color.Blue;
            this.btnMeasureRefJonesMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeasureRefJonesMat.ForeColor = System.Drawing.Color.White;
            this.btnMeasureRefJonesMat.Location = new System.Drawing.Point(663, 399);
            this.btnMeasureRefJonesMat.Name = "btnMeasureRefJonesMat";
            this.btnMeasureRefJonesMat.Size = new System.Drawing.Size(171, 40);
            this.btnMeasureRefJonesMat.TabIndex = 103;
            this.btnMeasureRefJonesMat.Text = "Measure reference Jones matrix";
            this.btnMeasureRefJonesMat.UseVisualStyleBackColor = false;
            this.btnMeasureRefJonesMat.Click += new System.EventHandler(this.BtnMeasureRefJonesMat_Click);
            // 
            // btnShowRefJonesMat
            // 
            this.btnShowRefJonesMat.BackColor = System.Drawing.Color.Blue;
            this.btnShowRefJonesMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowRefJonesMat.ForeColor = System.Drawing.Color.White;
            this.btnShowRefJonesMat.Location = new System.Drawing.Point(663, 518);
            this.btnShowRefJonesMat.Name = "btnShowRefJonesMat";
            this.btnShowRefJonesMat.Size = new System.Drawing.Size(171, 40);
            this.btnShowRefJonesMat.TabIndex = 102;
            this.btnShowRefJonesMat.Text = "Show reference Jones matrix";
            this.btnShowRefJonesMat.UseVisualStyleBackColor = false;
            this.btnShowRefJonesMat.Click += new System.EventHandler(this.BtnShowRefJonesMat_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(15, 379);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(157, 13);
            this.label15.TabIndex = 101;
            this.label15.Text = "Inverse reference Jones matrix :";
            // 
            // lblJ22
            // 
            this.lblJ22.AutoSize = true;
            this.lblJ22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJ22.ForeColor = System.Drawing.Color.White;
            this.lblJ22.Location = new System.Drawing.Point(414, 514);
            this.lblJ22.Name = "lblJ22";
            this.lblJ22.Size = new System.Drawing.Size(16, 13);
            this.lblJ22.TabIndex = 100;
            this.lblJ22.Text = "---";
            // 
            // lblJ21
            // 
            this.lblJ21.AutoSize = true;
            this.lblJ21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJ21.ForeColor = System.Drawing.Color.White;
            this.lblJ21.Location = new System.Drawing.Point(83, 514);
            this.lblJ21.Name = "lblJ21";
            this.lblJ21.Size = new System.Drawing.Size(16, 13);
            this.lblJ21.TabIndex = 99;
            this.lblJ21.Text = "---";
            // 
            // lblJ12
            // 
            this.lblJ12.AutoSize = true;
            this.lblJ12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJ12.ForeColor = System.Drawing.Color.White;
            this.lblJ12.Location = new System.Drawing.Point(414, 427);
            this.lblJ12.Name = "lblJ12";
            this.lblJ12.Size = new System.Drawing.Size(16, 13);
            this.lblJ12.TabIndex = 98;
            this.lblJ12.Text = "---";
            // 
            // lblJ11
            // 
            this.lblJ11.AutoSize = true;
            this.lblJ11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJ11.ForeColor = System.Drawing.Color.White;
            this.lblJ11.Location = new System.Drawing.Point(83, 427);
            this.lblJ11.Name = "lblJ11";
            this.lblJ11.Size = new System.Drawing.Size(16, 13);
            this.lblJ11.TabIndex = 97;
            this.lblJ11.Text = "---";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(18, 395);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 163);
            this.panel1.TabIndex = 105;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.btnShowHIst);
            this.panel2.Controls.Add(this.stringReadTextBox);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtBoxPath);
            this.panel2.Location = new System.Drawing.Point(861, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 512);
            this.panel2.TabIndex = 106;
            // 
            // btnShowHIst
            // 
            this.btnShowHIst.BackColor = System.Drawing.Color.Blue;
            this.btnShowHIst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHIst.ForeColor = System.Drawing.Color.White;
            this.btnShowHIst.Location = new System.Drawing.Point(143, 455);
            this.btnShowHIst.Name = "btnShowHIst";
            this.btnShowHIst.Size = new System.Drawing.Size(112, 34);
            this.btnShowHIst.TabIndex = 123;
            this.btnShowHIst.Text = "Show histogram";
            this.btnShowHIst.UseVisualStyleBackColor = false;
            this.btnShowHIst.Click += new System.EventHandler(this.btnShowHist_Click);
            // 
            // stringReadTextBox
            // 
            this.stringReadTextBox.BackColor = System.Drawing.Color.DarkBlue;
            this.stringReadTextBox.ForeColor = System.Drawing.Color.White;
            this.stringReadTextBox.Location = new System.Drawing.Point(25, 15);
            this.stringReadTextBox.Name = "stringReadTextBox";
            this.stringReadTextBox.ReadOnly = true;
            this.stringReadTextBox.Size = new System.Drawing.Size(230, 387);
            this.stringReadTextBox.TabIndex = 39;
            this.stringReadTextBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(759, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "Km";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(759, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 111;
            this.label9.Text = "ms";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(759, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 110;
            this.label10.Text = "uW";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(759, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 109;
            this.label11.Text = "nm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(485, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 108;
            this.label12.Text = "nm";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(213, 153);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 115;
            this.label14.Text = "C";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(134, 153);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 13);
            this.label16.TabIndex = 114;
            this.label16.Text = "B";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(53, 153);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 13);
            this.label17.TabIndex = 113;
            this.label17.Text = "A";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(729, 312);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 13);
            this.label18.TabIndex = 118;
            this.label18.Text = "C";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(668, 312);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 13);
            this.label19.TabIndex = 117;
            this.label19.Text = "B";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(608, 312);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 13);
            this.label20.TabIndex = 116;
            this.label20.Text = "A";
            // 
            // txtBoxStart
            // 
            this.txtBoxStart.Location = new System.Drawing.Point(579, 161);
            this.txtBoxStart.Name = "txtBoxStart";
            this.txtBoxStart.Size = new System.Drawing.Size(62, 20);
            this.txtBoxStart.TabIndex = 119;
            this.txtBoxStart.Text = "60";
            this.txtBoxStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxStop
            // 
            this.txtBoxStop.Location = new System.Drawing.Point(691, 161);
            this.txtBoxStop.Name = "txtBoxStop";
            this.txtBoxStop.Size = new System.Drawing.Size(62, 20);
            this.txtBoxStop.TabIndex = 120;
            this.txtBoxStop.Text = "120";
            this.txtBoxStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(544, 164);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(30, 13);
            this.label21.TabIndex = 121;
            this.label21.Text = "From";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(656, 164);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(20, 13);
            this.label22.TabIndex = 122;
            this.label22.Text = "To";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(759, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 123;
            this.label13.Text = "Degrees";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Black;
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(759, 164);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 13);
            this.label23.TabIndex = 124;
            this.label23.Text = "Degrees";
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(379, 75);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(100, 136);
            this.listView.TabIndex = 125;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Blue;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(547, 266);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(111, 35);
            this.btnStart.TabIndex = 126;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Blue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(311, 75);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 136);
            this.btnAdd.TabIndex = 127;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Blue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(311, 226);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(168, 35);
            this.btnClear.TabIndex = 128;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.ForeColor = System.Drawing.Color.White;
            this.lblProgress.Location = new System.Drawing.Point(308, 304);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(16, 13);
            this.lblProgress.TabIndex = 129;
            this.lblProgress.Text = "---";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(8, 356);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(847, 14);
            this.progressBar.TabIndex = 130;
            // 
            // radioButtonJM
            // 
            this.radioButtonJM.AutoSize = true;
            this.radioButtonJM.ForeColor = System.Drawing.Color.White;
            this.radioButtonJM.Location = new System.Drawing.Point(6, 13);
            this.radioButtonJM.Name = "radioButtonJM";
            this.radioButtonJM.Size = new System.Drawing.Size(74, 17);
            this.radioButtonJM.TabIndex = 131;
            this.radioButtonJM.TabStop = true;
            this.radioButtonJM.Text = "Jones Mat";
            this.radioButtonJM.UseVisualStyleBackColor = true;
            // 
            // radioButtonS
            // 
            this.radioButtonS.AutoSize = true;
            this.radioButtonS.ForeColor = System.Drawing.Color.White;
            this.radioButtonS.Location = new System.Drawing.Point(99, 13);
            this.radioButtonS.Name = "radioButtonS";
            this.radioButtonS.Size = new System.Drawing.Size(58, 17);
            this.radioButtonS.TabIndex = 132;
            this.radioButtonS.TabStop = true;
            this.radioButtonS.Text = "Stokes";
            this.radioButtonS.UseVisualStyleBackColor = true;
            // 
            // radioButtonED
            // 
            this.radioButtonED.AutoSize = true;
            this.radioButtonED.ForeColor = System.Drawing.Color.White;
            this.radioButtonED.Location = new System.Drawing.Point(179, 13);
            this.radioButtonED.Name = "radioButtonED";
            this.radioButtonED.Size = new System.Drawing.Size(74, 17);
            this.radioButtonED.TabIndex = 133;
            this.radioButtonED.TabStop = true;
            this.radioButtonED.Text = "ExEyDelta";
            this.radioButtonED.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.radioButtonJM);
            this.groupBox.Controls.Add(this.radioButtonED);
            this.groupBox.Controls.Add(this.radioButtonS);
            this.groupBox.Location = new System.Drawing.Point(547, 219);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(259, 35);
            this.groupBox.TabIndex = 134;
            this.groupBox.TabStop = false;
            // 
            // PolarizationControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1150, 570);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtBoxStop);
            this.Controls.Add(this.txtBoxStart);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnResetRefJonesMat);
            this.Controls.Add(this.btnMeasureRefJonesMat);
            this.Controls.Add(this.btnShowRefJonesMat);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblJ22);
            this.Controls.Add(this.lblJ21);
            this.Controls.Add(this.lblJ12);
            this.Controls.Add(this.lblJ11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBoxFiberLength);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxDelay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxLaserPower);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxWaveStep);
            this.Controls.Add(this.picCloseButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxWavelength);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblServoC);
            this.Controls.Add(this.lblServoB);
            this.Controls.Add(this.lblServoA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxStepSize);
            this.Controls.Add(this.txtBoxServoC);
            this.Controls.Add(this.txtBoxServoB);
            this.Controls.Add(this.lblRData);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.txtBoxServoA);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmbCOMPorts);
            this.Controls.Add(this.btnFindPorts);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1150, 570);
            this.MinimumSize = new System.Drawing.Size(1150, 570);
            this.Name = "PolarizationControllerForm";
            this.Text = "Polarization controller";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseButton)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbCOMPorts;
        private System.Windows.Forms.Button btnFindPorts;
        private System.Windows.Forms.TextBox txtBoxServoA;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label lblRData;
        private System.Windows.Forms.TextBox txtBoxServoB;
        private System.Windows.Forms.TextBox txtBoxServoC;
        private System.Windows.Forms.TextBox txtBoxStepSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServoA;
        private System.Windows.Forms.Label lblServoB;
        private System.Windows.Forms.Label lblServoC;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxWavelength;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picCloseButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxWaveStep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxLaserPower;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxDelay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxFiberLength;
        private System.Windows.Forms.Button btnResetRefJonesMat;
        private System.Windows.Forms.Button btnMeasureRefJonesMat;
        private System.Windows.Forms.Button btnShowRefJonesMat;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblJ22;
        private System.Windows.Forms.Label lblJ21;
        private System.Windows.Forms.Label lblJ12;
        private System.Windows.Forms.Label lblJ11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox stringReadTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtBoxStart;
        private System.Windows.Forms.TextBox txtBoxStop;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnShowHIst;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.RadioButton radioButtonJM;
        private System.Windows.Forms.RadioButton radioButtonS;
        private System.Windows.Forms.RadioButton radioButtonED;
        private System.Windows.Forms.GroupBox groupBox;
    }
}