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
            this.SuspendLayout();
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(136, 60);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 60);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbCOMPorts
            // 
            this.cmbCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCOMPorts.FormattingEnabled = true;
            this.cmbCOMPorts.Location = new System.Drawing.Point(12, 12);
            this.cmbCOMPorts.Name = "cmbCOMPorts";
            this.cmbCOMPorts.Size = new System.Drawing.Size(114, 21);
            this.cmbCOMPorts.TabIndex = 5;
            // 
            // btnFindPorts
            // 
            this.btnFindPorts.Location = new System.Drawing.Point(136, 10);
            this.btnFindPorts.Name = "btnFindPorts";
            this.btnFindPorts.Size = new System.Drawing.Size(78, 23);
            this.btnFindPorts.TabIndex = 4;
            this.btnFindPorts.Text = "Find Ports";
            this.btnFindPorts.UseVisualStyleBackColor = true;
            this.btnFindPorts.Click += new System.EventHandler(this.btnFindPorts_Click);
            // 
            // txtBoxServoA
            // 
            this.txtBoxServoA.Location = new System.Drawing.Point(12, 106);
            this.txtBoxServoA.Name = "txtBoxServoA";
            this.txtBoxServoA.Size = new System.Drawing.Size(33, 20);
            this.txtBoxServoA.TabIndex = 8;
            this.txtBoxServoA.Text = "0";
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(12, 155);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(195, 23);
            this.btnWrite.TabIndex = 11;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // lblRData
            // 
            this.lblRData.AutoSize = true;
            this.lblRData.Location = new System.Drawing.Point(98, 226);
            this.lblRData.Name = "lblRData";
            this.lblRData.Size = new System.Drawing.Size(16, 13);
            this.lblRData.TabIndex = 11;
            this.lblRData.Text = "---";
            // 
            // txtBoxServoB
            // 
            this.txtBoxServoB.Location = new System.Drawing.Point(93, 106);
            this.txtBoxServoB.Name = "txtBoxServoB";
            this.txtBoxServoB.Size = new System.Drawing.Size(33, 20);
            this.txtBoxServoB.TabIndex = 9;
            this.txtBoxServoB.Text = "0";
            // 
            // txtBoxServoC
            // 
            this.txtBoxServoC.Location = new System.Drawing.Point(174, 106);
            this.txtBoxServoC.Name = "txtBoxServoC";
            this.txtBoxServoC.Size = new System.Drawing.Size(33, 20);
            this.txtBoxServoC.TabIndex = 10;
            this.txtBoxServoC.Text = "0";
            // 
            // txtBoxStepSize
            // 
            this.txtBoxStepSize.Location = new System.Drawing.Point(364, 10);
            this.txtBoxStepSize.Name = "txtBoxStepSize";
            this.txtBoxStepSize.Size = new System.Drawing.Size(100, 20);
            this.txtBoxStepSize.TabIndex = 13;
            this.txtBoxStepSize.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Step size";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(296, 103);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblServoA
            // 
            this.lblServoA.AutoSize = true;
            this.lblServoA.Location = new System.Drawing.Point(296, 155);
            this.lblServoA.Name = "lblServoA";
            this.lblServoA.Size = new System.Drawing.Size(16, 13);
            this.lblServoA.TabIndex = 16;
            this.lblServoA.Text = "---";
            // 
            // lblServoB
            // 
            this.lblServoB.AutoSize = true;
            this.lblServoB.Location = new System.Drawing.Point(356, 155);
            this.lblServoB.Name = "lblServoB";
            this.lblServoB.Size = new System.Drawing.Size(16, 13);
            this.lblServoB.TabIndex = 17;
            this.lblServoB.Text = "---";
            // 
            // lblServoC
            // 
            this.lblServoC.AutoSize = true;
            this.lblServoC.Location = new System.Drawing.Point(417, 155);
            this.lblServoC.Name = "lblServoC";
            this.lblServoC.Size = new System.Drawing.Size(16, 13);
            this.lblServoC.TabIndex = 18;
            this.lblServoC.Text = "---";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(389, 104);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Wavelength";
            // 
            // txtBoxWavelength
            // 
            this.txtBoxWavelength.Location = new System.Drawing.Point(364, 36);
            this.txtBoxWavelength.Name = "txtBoxWavelength";
            this.txtBoxWavelength.Size = new System.Drawing.Size(100, 20);
            this.txtBoxWavelength.TabIndex = 20;
            this.txtBoxWavelength.Text = "1550";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Path";
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Location = new System.Drawing.Point(364, 63);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPath.TabIndex = 23;
            this.txtBoxPath.Text = "data";
            // 
            // polController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 262);
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
            this.Name = "polController";
            this.Text = "Polarization controller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.polController_FormClosed);
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
    }
}