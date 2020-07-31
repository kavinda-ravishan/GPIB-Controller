using NationalInstruments.NI4882;

namespace PolarizationAnalyzer
{
    partial class MainForm
    {
        private Device device;
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
            if (disposing)
            {
                if (device != null)
                {
                    device.Dispose();
                }
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.boardIdLabel = new System.Windows.Forms.Label();
            this.primaryAddressLabel = new System.Windows.Forms.Label();
            this.secondaryAddressLabel = new System.Windows.Forms.Label();
            this.secondaryAddressComboBox = new System.Windows.Forms.ComboBox();
            this.primaryAddressNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.boardIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.closeButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.stringReadLabel = new System.Windows.Forms.Label();
            this.readButton = new System.Windows.Forms.Button();
            this.stringToWriteLabel = new System.Windows.Forms.Label();
            this.writeButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.stringReadTextBox = new System.Windows.Forms.RichTextBox();
            this.stringToWriteTextBox = new System.Windows.Forms.TextBox();
            this.lblEyx = new System.Windows.Forms.Label();
            this.lblDelta = new System.Windows.Forms.Label();
            this.btnS0 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.primaryAddressNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardIdNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // boardIdLabel
            // 
            this.boardIdLabel.AutoSize = true;
            this.boardIdLabel.Location = new System.Drawing.Point(69, 15);
            this.boardIdLabel.Name = "boardIdLabel";
            this.boardIdLabel.Size = new System.Drawing.Size(52, 13);
            this.boardIdLabel.TabIndex = 0;
            this.boardIdLabel.Text = "Board ID:";
            // 
            // primaryAddressLabel
            // 
            this.primaryAddressLabel.AutoSize = true;
            this.primaryAddressLabel.Location = new System.Drawing.Point(36, 41);
            this.primaryAddressLabel.Name = "primaryAddressLabel";
            this.primaryAddressLabel.Size = new System.Drawing.Size(85, 13);
            this.primaryAddressLabel.TabIndex = 2;
            this.primaryAddressLabel.Text = "Primary Address:";
            // 
            // secondaryAddressLabel
            // 
            this.secondaryAddressLabel.AutoSize = true;
            this.secondaryAddressLabel.Location = new System.Drawing.Point(19, 68);
            this.secondaryAddressLabel.Name = "secondaryAddressLabel";
            this.secondaryAddressLabel.Size = new System.Drawing.Size(102, 13);
            this.secondaryAddressLabel.TabIndex = 4;
            this.secondaryAddressLabel.Text = "Secondary Address:";
            // 
            // secondaryAddressComboBox
            // 
            this.secondaryAddressComboBox.Location = new System.Drawing.Point(127, 65);
            this.secondaryAddressComboBox.Name = "secondaryAddressComboBox";
            this.secondaryAddressComboBox.Size = new System.Drawing.Size(56, 21);
            this.secondaryAddressComboBox.TabIndex = 5;
            // 
            // primaryAddressNumericUpDown
            // 
            this.primaryAddressNumericUpDown.Location = new System.Drawing.Point(127, 39);
            this.primaryAddressNumericUpDown.Name = "primaryAddressNumericUpDown";
            this.primaryAddressNumericUpDown.Size = new System.Drawing.Size(40, 20);
            this.primaryAddressNumericUpDown.TabIndex = 3;
            this.primaryAddressNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // boardIdNumericUpDown
            // 
            this.boardIdNumericUpDown.Location = new System.Drawing.Point(127, 13);
            this.boardIdNumericUpDown.Name = "boardIdNumericUpDown";
            this.boardIdNumericUpDown.Size = new System.Drawing.Size(40, 20);
            this.boardIdNumericUpDown.TabIndex = 1;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(102, 110);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "&Close";
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(22, 110);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 6;
            this.openButton.Text = "&Open";
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // stringReadLabel
            // 
            this.stringReadLabel.Location = new System.Drawing.Point(204, 5);
            this.stringReadLabel.Name = "stringReadLabel";
            this.stringReadLabel.Size = new System.Drawing.Size(75, 23);
            this.stringReadLabel.TabIndex = 16;
            this.stringReadLabel.Text = "String Read:";
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(127, 215);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(75, 23);
            this.readButton.TabIndex = 15;
            this.readButton.Text = "&Read";
            this.readButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // stringToWriteLabel
            // 
            this.stringToWriteLabel.Location = new System.Drawing.Point(22, 160);
            this.stringToWriteLabel.Name = "stringToWriteLabel";
            this.stringToWriteLabel.Size = new System.Drawing.Size(100, 23);
            this.stringToWriteLabel.TabIndex = 14;
            this.stringToWriteLabel.Text = "String to Write:";
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(27, 215);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(75, 23);
            this.writeButton.TabIndex = 13;
            this.writeButton.Text = "&Write";
            this.writeButton.Click += new System.EventHandler(this.WriteButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(27, 270);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(202, 202);
            this.pictureBox.TabIndex = 17;
            this.pictureBox.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(235, 298);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(301, 45);
            this.trackBar1.TabIndex = 19;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(235, 404);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(301, 45);
            this.trackBar2.TabIndex = 20;
            this.trackBar2.Scroll += new System.EventHandler(this.TrackBar2_Scroll);
            // 
            // stringReadTextBox
            // 
            this.stringReadTextBox.Location = new System.Drawing.Point(207, 31);
            this.stringReadTextBox.Name = "stringReadTextBox";
            this.stringReadTextBox.ReadOnly = true;
            this.stringReadTextBox.Size = new System.Drawing.Size(329, 152);
            this.stringReadTextBox.TabIndex = 21;
            this.stringReadTextBox.Text = "";
            // 
            // stringToWriteTextBox
            // 
            this.stringToWriteTextBox.Location = new System.Drawing.Point(25, 189);
            this.stringToWriteTextBox.Name = "stringToWriteTextBox";
            this.stringToWriteTextBox.Size = new System.Drawing.Size(511, 20);
            this.stringToWriteTextBox.TabIndex = 22;
            // 
            // lblEyx
            // 
            this.lblEyx.AutoSize = true;
            this.lblEyx.Location = new System.Drawing.Point(247, 271);
            this.lblEyx.Name = "lblEyx";
            this.lblEyx.Size = new System.Drawing.Size(13, 13);
            this.lblEyx.TabIndex = 23;
            this.lblEyx.Text = "--";
            // 
            // lblDelta
            // 
            this.lblDelta.AutoSize = true;
            this.lblDelta.Location = new System.Drawing.Point(247, 379);
            this.lblDelta.Name = "lblDelta";
            this.lblDelta.Size = new System.Drawing.Size(13, 13);
            this.lblDelta.TabIndex = 24;
            this.lblDelta.Text = "--";
            // 
            // btnS0
            // 
            this.btnS0.Location = new System.Drawing.Point(324, 232);
            this.btnS0.Name = "btnS0";
            this.btnS0.Size = new System.Drawing.Size(75, 23);
            this.btnS0.TabIndex = 25;
            this.btnS0.Text = "S0 Read";
            this.btnS0.Click += new System.EventHandler(this.BtnS0_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 501);
            this.Controls.Add(this.btnS0);
            this.Controls.Add(this.lblDelta);
            this.Controls.Add(this.lblEyx);
            this.Controls.Add(this.stringToWriteTextBox);
            this.Controls.Add(this.stringReadTextBox);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.stringReadLabel);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.stringToWriteLabel);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.secondaryAddressComboBox);
            this.Controls.Add(this.primaryAddressNumericUpDown);
            this.Controls.Add(this.boardIdNumericUpDown);
            this.Controls.Add(this.secondaryAddressLabel);
            this.Controls.Add(this.primaryAddressLabel);
            this.Controls.Add(this.boardIdLabel);
            this.Name = "MainForm";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.primaryAddressNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardIdNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label boardIdLabel;
        private System.Windows.Forms.Label primaryAddressLabel;
        private System.Windows.Forms.Label secondaryAddressLabel;
        private System.Windows.Forms.ComboBox secondaryAddressComboBox;
        private System.Windows.Forms.NumericUpDown primaryAddressNumericUpDown;
        private System.Windows.Forms.NumericUpDown boardIdNumericUpDown;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label stringReadLabel;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Label stringToWriteLabel;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.RichTextBox stringReadTextBox;
        private System.Windows.Forms.TextBox stringToWriteTextBox;
        private System.Windows.Forms.Label lblEyx;
        private System.Windows.Forms.Label lblDelta;
        private System.Windows.Forms.Button btnS0;
    }
}

