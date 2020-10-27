namespace PolarizationAnalyzer
{
    partial class polController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(polController));
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
            this.btnStart = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Blue;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.Location = new System.Drawing.Point(162, 93);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(78, 40);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Blue;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(38, 93);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(78, 40);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbCOMPorts
            // 
            this.cmbCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCOMPorts.FormattingEnabled = true;
            this.cmbCOMPorts.Location = new System.Drawing.Point(38, 45);
            this.cmbCOMPorts.Name = "cmbCOMPorts";
            this.cmbCOMPorts.Size = new System.Drawing.Size(114, 21);
            this.cmbCOMPorts.TabIndex = 5;
            // 
            // btnFindPorts
            // 
            this.btnFindPorts.BackColor = System.Drawing.Color.Blue;
            this.btnFindPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPorts.ForeColor = System.Drawing.Color.White;
            this.btnFindPorts.Location = new System.Drawing.Point(162, 43);
            this.btnFindPorts.Name = "btnFindPorts";
            this.btnFindPorts.Size = new System.Drawing.Size(78, 23);
            this.btnFindPorts.TabIndex = 4;
            this.btnFindPorts.Text = "Find Ports";
            this.btnFindPorts.UseVisualStyleBackColor = false;
            this.btnFindPorts.Click += new System.EventHandler(this.btnFindPorts_Click);
            // 
            // txtBoxServoA
            // 
            this.txtBoxServoA.Location = new System.Drawing.Point(38, 152);
            this.txtBoxServoA.Name = "txtBoxServoA";
            this.txtBoxServoA.Size = new System.Drawing.Size(33, 20);
            this.txtBoxServoA.TabIndex = 8;
            this.txtBoxServoA.Text = "0";
            // 
            // btnWrite
            // 
            this.btnWrite.BackColor = System.Drawing.Color.Blue;
            this.btnWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWrite.ForeColor = System.Drawing.Color.White;
            this.btnWrite.Location = new System.Drawing.Point(38, 188);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(195, 34);
            this.btnWrite.TabIndex = 11;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = false;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // lblRData
            // 
            this.lblRData.AutoSize = true;
            this.lblRData.ForeColor = System.Drawing.Color.White;
            this.lblRData.Location = new System.Drawing.Point(124, 259);
            this.lblRData.Name = "lblRData";
            this.lblRData.Size = new System.Drawing.Size(16, 13);
            this.lblRData.TabIndex = 11;
            this.lblRData.Text = "---";
            // 
            // txtBoxServoB
            // 
            this.txtBoxServoB.Location = new System.Drawing.Point(119, 152);
            this.txtBoxServoB.Name = "txtBoxServoB";
            this.txtBoxServoB.Size = new System.Drawing.Size(33, 20);
            this.txtBoxServoB.TabIndex = 9;
            this.txtBoxServoB.Text = "0";
            // 
            // txtBoxServoC
            // 
            this.txtBoxServoC.Location = new System.Drawing.Point(200, 152);
            this.txtBoxServoC.Name = "txtBoxServoC";
            this.txtBoxServoC.Size = new System.Drawing.Size(33, 20);
            this.txtBoxServoC.TabIndex = 10;
            this.txtBoxServoC.Text = "0";
            // 
            // txtBoxStepSize
            // 
            this.txtBoxStepSize.Location = new System.Drawing.Point(390, 43);
            this.txtBoxStepSize.Name = "txtBoxStepSize";
            this.txtBoxStepSize.Size = new System.Drawing.Size(100, 20);
            this.txtBoxStepSize.TabIndex = 13;
            this.txtBoxStepSize.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(319, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Step size";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Blue;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(322, 136);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 35);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblServoA
            // 
            this.lblServoA.AutoSize = true;
            this.lblServoA.ForeColor = System.Drawing.Color.White;
            this.lblServoA.Location = new System.Drawing.Point(337, 190);
            this.lblServoA.Name = "lblServoA";
            this.lblServoA.Size = new System.Drawing.Size(16, 13);
            this.lblServoA.TabIndex = 16;
            this.lblServoA.Text = "---";
            // 
            // lblServoB
            // 
            this.lblServoB.AutoSize = true;
            this.lblServoB.ForeColor = System.Drawing.Color.White;
            this.lblServoB.Location = new System.Drawing.Point(397, 190);
            this.lblServoB.Name = "lblServoB";
            this.lblServoB.Size = new System.Drawing.Size(16, 13);
            this.lblServoB.TabIndex = 17;
            this.lblServoB.Text = "---";
            // 
            // lblServoC
            // 
            this.lblServoC.AutoSize = true;
            this.lblServoC.ForeColor = System.Drawing.Color.White;
            this.lblServoC.Location = new System.Drawing.Point(458, 190);
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
            this.btnStop.Location = new System.Drawing.Point(415, 137);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 35);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(319, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Wavelength";
            // 
            // txtBoxWavelength
            // 
            this.txtBoxWavelength.Location = new System.Drawing.Point(390, 69);
            this.txtBoxWavelength.Name = "txtBoxWavelength";
            this.txtBoxWavelength.Size = new System.Drawing.Size(100, 20);
            this.txtBoxWavelength.TabIndex = 20;
            this.txtBoxWavelength.Text = "1550";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Blue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(325, 249);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 34);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(319, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Path";
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Location = new System.Drawing.Point(390, 96);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.Size = new System.Drawing.Size(100, 20);
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
            this.lbltitle.Size = new System.Drawing.Size(171, 20);
            this.lbltitle.TabIndex = 82;
            this.lbltitle.Text = "PMD analysis tool";
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
            this.picCloseButton.Location = new System.Drawing.Point(499, 10);
            this.picCloseButton.Name = "picCloseButton";
            this.picCloseButton.Size = new System.Drawing.Size(27, 24);
            this.picCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCloseButton.TabIndex = 88;
            this.picCloseButton.TabStop = false;
            this.picCloseButton.Click += new System.EventHandler(this.picCloseButton_Click);
            // 
            // polController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(538, 306);
            this.Controls.Add(this.picCloseButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxPath);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxWavelength);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblServoC);
            this.Controls.Add(this.lblServoB);
            this.Controls.Add(this.lblServoA);
            this.Controls.Add(this.btnStart);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "polController";
            this.Text = "Polarization controller";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseButton)).EndInit();
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
        private System.Windows.Forms.Button btnStart;
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
    }
}