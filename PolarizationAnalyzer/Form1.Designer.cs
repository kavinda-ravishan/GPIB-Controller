using NationalInstruments.NI4882;

namespace PolarizationAnalyzer
{
    partial class MainForm
    {
        private Device device1;
        private Device device2;
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
                if (device1 != null)
                {
                    device1.Dispose();
                }
                if (device2 != null)
                {
                    device2.Dispose();
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
            this.boardIdLabel1 = new System.Windows.Forms.Label();
            this.primaryAddressLabel1 = new System.Windows.Forms.Label();
            this.secondaryAddressLabel1 = new System.Windows.Forms.Label();
            this.secondaryAddressComboBox1 = new System.Windows.Forms.ComboBox();
            this.primaryAddressNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.boardIdNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.closeButton1 = new System.Windows.Forms.Button();
            this.openButton1 = new System.Windows.Forms.Button();
            this.stringReadLabel1 = new System.Windows.Forms.Label();
            this.readButton1 = new System.Windows.Forms.Button();
            this.stringToWriteLabel1 = new System.Windows.Forms.Label();
            this.writeButton1 = new System.Windows.Forms.Button();
            this.stringReadTextBox1 = new System.Windows.Forms.RichTextBox();
            this.stringToWriteTextBox1 = new System.Windows.Forms.TextBox();
            this.btnS0 = new System.Windows.Forms.Button();
            this.stringToWriteTextBox2 = new System.Windows.Forms.TextBox();
            this.stringReadTextBox2 = new System.Windows.Forms.RichTextBox();
            this.stringReadLabel2 = new System.Windows.Forms.Label();
            this.readButton2 = new System.Windows.Forms.Button();
            this.stringToWriteLabel2 = new System.Windows.Forms.Label();
            this.writeButton2 = new System.Windows.Forms.Button();
            this.closeButton2 = new System.Windows.Forms.Button();
            this.openButton2 = new System.Windows.Forms.Button();
            this.secondaryAddressComboBox2 = new System.Windows.Forms.ComboBox();
            this.primaryAddressNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.boardIdNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.secondaryAddressLabel2 = new System.Windows.Forms.Label();
            this.primaryAddressLabel2 = new System.Windows.Forms.Label();
            this.boardIdLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.primaryAddressNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardIdNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.primaryAddressNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardIdNumericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // boardIdLabel1
            // 
            this.boardIdLabel1.AutoSize = true;
            this.boardIdLabel1.Location = new System.Drawing.Point(91, 39);
            this.boardIdLabel1.Name = "boardIdLabel1";
            this.boardIdLabel1.Size = new System.Drawing.Size(52, 13);
            this.boardIdLabel1.TabIndex = 0;
            this.boardIdLabel1.Text = "Board ID:";
            // 
            // primaryAddressLabel1
            // 
            this.primaryAddressLabel1.AutoSize = true;
            this.primaryAddressLabel1.Location = new System.Drawing.Point(58, 65);
            this.primaryAddressLabel1.Name = "primaryAddressLabel1";
            this.primaryAddressLabel1.Size = new System.Drawing.Size(85, 13);
            this.primaryAddressLabel1.TabIndex = 2;
            this.primaryAddressLabel1.Text = "Primary Address:";
            // 
            // secondaryAddressLabel1
            // 
            this.secondaryAddressLabel1.AutoSize = true;
            this.secondaryAddressLabel1.Location = new System.Drawing.Point(41, 92);
            this.secondaryAddressLabel1.Name = "secondaryAddressLabel1";
            this.secondaryAddressLabel1.Size = new System.Drawing.Size(102, 13);
            this.secondaryAddressLabel1.TabIndex = 4;
            this.secondaryAddressLabel1.Text = "Secondary Address:";
            // 
            // secondaryAddressComboBox1
            // 
            this.secondaryAddressComboBox1.Location = new System.Drawing.Point(149, 89);
            this.secondaryAddressComboBox1.Name = "secondaryAddressComboBox1";
            this.secondaryAddressComboBox1.Size = new System.Drawing.Size(56, 21);
            this.secondaryAddressComboBox1.TabIndex = 5;
            // 
            // primaryAddressNumericUpDown1
            // 
            this.primaryAddressNumericUpDown1.Location = new System.Drawing.Point(149, 63);
            this.primaryAddressNumericUpDown1.Name = "primaryAddressNumericUpDown1";
            this.primaryAddressNumericUpDown1.Size = new System.Drawing.Size(40, 20);
            this.primaryAddressNumericUpDown1.TabIndex = 3;
            this.primaryAddressNumericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // boardIdNumericUpDown1
            // 
            this.boardIdNumericUpDown1.Location = new System.Drawing.Point(149, 37);
            this.boardIdNumericUpDown1.Name = "boardIdNumericUpDown1";
            this.boardIdNumericUpDown1.Size = new System.Drawing.Size(40, 20);
            this.boardIdNumericUpDown1.TabIndex = 1;
            // 
            // closeButton1
            // 
            this.closeButton1.Location = new System.Drawing.Point(124, 134);
            this.closeButton1.Name = "closeButton1";
            this.closeButton1.Size = new System.Drawing.Size(75, 23);
            this.closeButton1.TabIndex = 7;
            this.closeButton1.Text = "&Close";
            this.closeButton1.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // openButton1
            // 
            this.openButton1.Location = new System.Drawing.Point(44, 134);
            this.openButton1.Name = "openButton1";
            this.openButton1.Size = new System.Drawing.Size(75, 23);
            this.openButton1.TabIndex = 6;
            this.openButton1.Text = "&Open";
            this.openButton1.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // stringReadLabel1
            // 
            this.stringReadLabel1.Location = new System.Drawing.Point(226, 29);
            this.stringReadLabel1.Name = "stringReadLabel1";
            this.stringReadLabel1.Size = new System.Drawing.Size(75, 23);
            this.stringReadLabel1.TabIndex = 16;
            this.stringReadLabel1.Text = "String Read:";
            // 
            // readButton1
            // 
            this.readButton1.Location = new System.Drawing.Point(149, 239);
            this.readButton1.Name = "readButton1";
            this.readButton1.Size = new System.Drawing.Size(75, 23);
            this.readButton1.TabIndex = 15;
            this.readButton1.Text = "&Read";
            this.readButton1.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // stringToWriteLabel1
            // 
            this.stringToWriteLabel1.Location = new System.Drawing.Point(44, 184);
            this.stringToWriteLabel1.Name = "stringToWriteLabel1";
            this.stringToWriteLabel1.Size = new System.Drawing.Size(100, 23);
            this.stringToWriteLabel1.TabIndex = 14;
            this.stringToWriteLabel1.Text = "String to Write:";
            // 
            // writeButton1
            // 
            this.writeButton1.Location = new System.Drawing.Point(49, 239);
            this.writeButton1.Name = "writeButton1";
            this.writeButton1.Size = new System.Drawing.Size(75, 23);
            this.writeButton1.TabIndex = 13;
            this.writeButton1.Text = "&Write";
            this.writeButton1.Click += new System.EventHandler(this.WriteButton_Click);
            // 
            // stringReadTextBox1
            // 
            this.stringReadTextBox1.Location = new System.Drawing.Point(229, 55);
            this.stringReadTextBox1.Name = "stringReadTextBox1";
            this.stringReadTextBox1.ReadOnly = true;
            this.stringReadTextBox1.Size = new System.Drawing.Size(329, 152);
            this.stringReadTextBox1.TabIndex = 21;
            this.stringReadTextBox1.Text = "";
            // 
            // stringToWriteTextBox1
            // 
            this.stringToWriteTextBox1.Location = new System.Drawing.Point(47, 213);
            this.stringToWriteTextBox1.Name = "stringToWriteTextBox1";
            this.stringToWriteTextBox1.Size = new System.Drawing.Size(511, 20);
            this.stringToWriteTextBox1.TabIndex = 22;
            // 
            // btnS0
            // 
            this.btnS0.Location = new System.Drawing.Point(483, 239);
            this.btnS0.Name = "btnS0";
            this.btnS0.Size = new System.Drawing.Size(75, 23);
            this.btnS0.TabIndex = 25;
            this.btnS0.Text = "S0 Read";
            this.btnS0.Click += new System.EventHandler(this.BtnS0_Click);
            // 
            // stringToWriteTextBox2
            // 
            this.stringToWriteTextBox2.Location = new System.Drawing.Point(668, 213);
            this.stringToWriteTextBox2.Name = "stringToWriteTextBox2";
            this.stringToWriteTextBox2.Size = new System.Drawing.Size(511, 20);
            this.stringToWriteTextBox2.TabIndex = 39;
            // 
            // stringReadTextBox2
            // 
            this.stringReadTextBox2.Location = new System.Drawing.Point(850, 55);
            this.stringReadTextBox2.Name = "stringReadTextBox2";
            this.stringReadTextBox2.ReadOnly = true;
            this.stringReadTextBox2.Size = new System.Drawing.Size(329, 152);
            this.stringReadTextBox2.TabIndex = 38;
            this.stringReadTextBox2.Text = "";
            // 
            // stringReadLabel2
            // 
            this.stringReadLabel2.Location = new System.Drawing.Point(847, 29);
            this.stringReadLabel2.Name = "stringReadLabel2";
            this.stringReadLabel2.Size = new System.Drawing.Size(75, 23);
            this.stringReadLabel2.TabIndex = 37;
            this.stringReadLabel2.Text = "String Read:";
            // 
            // readButton2
            // 
            this.readButton2.Location = new System.Drawing.Point(770, 239);
            this.readButton2.Name = "readButton2";
            this.readButton2.Size = new System.Drawing.Size(75, 23);
            this.readButton2.TabIndex = 36;
            this.readButton2.Text = "&Read";
            this.readButton2.Click += new System.EventHandler(this.ReadButton2_Click);
            // 
            // stringToWriteLabel2
            // 
            this.stringToWriteLabel2.Location = new System.Drawing.Point(665, 184);
            this.stringToWriteLabel2.Name = "stringToWriteLabel2";
            this.stringToWriteLabel2.Size = new System.Drawing.Size(100, 23);
            this.stringToWriteLabel2.TabIndex = 35;
            this.stringToWriteLabel2.Text = "String to Write:";
            // 
            // writeButton2
            // 
            this.writeButton2.Location = new System.Drawing.Point(670, 239);
            this.writeButton2.Name = "writeButton2";
            this.writeButton2.Size = new System.Drawing.Size(75, 23);
            this.writeButton2.TabIndex = 34;
            this.writeButton2.Text = "&Write";
            this.writeButton2.Click += new System.EventHandler(this.WriteButton2_Click);
            // 
            // closeButton2
            // 
            this.closeButton2.Location = new System.Drawing.Point(745, 134);
            this.closeButton2.Name = "closeButton2";
            this.closeButton2.Size = new System.Drawing.Size(75, 23);
            this.closeButton2.TabIndex = 33;
            this.closeButton2.Text = "&Close";
            this.closeButton2.Click += new System.EventHandler(this.CloseButton2_Click);
            // 
            // openButton2
            // 
            this.openButton2.Location = new System.Drawing.Point(665, 134);
            this.openButton2.Name = "openButton2";
            this.openButton2.Size = new System.Drawing.Size(75, 23);
            this.openButton2.TabIndex = 32;
            this.openButton2.Text = "&Open";
            this.openButton2.Click += new System.EventHandler(this.OpenButton2_Click);
            // 
            // secondaryAddressComboBox2
            // 
            this.secondaryAddressComboBox2.Location = new System.Drawing.Point(770, 89);
            this.secondaryAddressComboBox2.Name = "secondaryAddressComboBox2";
            this.secondaryAddressComboBox2.Size = new System.Drawing.Size(56, 21);
            this.secondaryAddressComboBox2.TabIndex = 31;
            // 
            // primaryAddressNumericUpDown2
            // 
            this.primaryAddressNumericUpDown2.Location = new System.Drawing.Point(770, 63);
            this.primaryAddressNumericUpDown2.Name = "primaryAddressNumericUpDown2";
            this.primaryAddressNumericUpDown2.Size = new System.Drawing.Size(40, 20);
            this.primaryAddressNumericUpDown2.TabIndex = 29;
            this.primaryAddressNumericUpDown2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // boardIdNumericUpDown2
            // 
            this.boardIdNumericUpDown2.Location = new System.Drawing.Point(770, 37);
            this.boardIdNumericUpDown2.Name = "boardIdNumericUpDown2";
            this.boardIdNumericUpDown2.Size = new System.Drawing.Size(40, 20);
            this.boardIdNumericUpDown2.TabIndex = 27;
            // 
            // secondaryAddressLabel2
            // 
            this.secondaryAddressLabel2.AutoSize = true;
            this.secondaryAddressLabel2.Location = new System.Drawing.Point(662, 92);
            this.secondaryAddressLabel2.Name = "secondaryAddressLabel2";
            this.secondaryAddressLabel2.Size = new System.Drawing.Size(102, 13);
            this.secondaryAddressLabel2.TabIndex = 30;
            this.secondaryAddressLabel2.Text = "Secondary Address:";
            // 
            // primaryAddressLabel2
            // 
            this.primaryAddressLabel2.AutoSize = true;
            this.primaryAddressLabel2.Location = new System.Drawing.Point(679, 65);
            this.primaryAddressLabel2.Name = "primaryAddressLabel2";
            this.primaryAddressLabel2.Size = new System.Drawing.Size(85, 13);
            this.primaryAddressLabel2.TabIndex = 28;
            this.primaryAddressLabel2.Text = "Primary Address:";
            // 
            // boardIdLabel2
            // 
            this.boardIdLabel2.AutoSize = true;
            this.boardIdLabel2.Location = new System.Drawing.Point(712, 39);
            this.boardIdLabel2.Name = "boardIdLabel2";
            this.boardIdLabel2.Size = new System.Drawing.Size(52, 13);
            this.boardIdLabel2.TabIndex = 26;
            this.boardIdLabel2.Text = "Board ID:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 300);
            this.Controls.Add(this.stringToWriteTextBox2);
            this.Controls.Add(this.stringReadTextBox2);
            this.Controls.Add(this.stringReadLabel2);
            this.Controls.Add(this.readButton2);
            this.Controls.Add(this.stringToWriteLabel2);
            this.Controls.Add(this.writeButton2);
            this.Controls.Add(this.closeButton2);
            this.Controls.Add(this.openButton2);
            this.Controls.Add(this.secondaryAddressComboBox2);
            this.Controls.Add(this.primaryAddressNumericUpDown2);
            this.Controls.Add(this.boardIdNumericUpDown2);
            this.Controls.Add(this.secondaryAddressLabel2);
            this.Controls.Add(this.primaryAddressLabel2);
            this.Controls.Add(this.boardIdLabel2);
            this.Controls.Add(this.btnS0);
            this.Controls.Add(this.stringToWriteTextBox1);
            this.Controls.Add(this.stringReadTextBox1);
            this.Controls.Add(this.stringReadLabel1);
            this.Controls.Add(this.readButton1);
            this.Controls.Add(this.stringToWriteLabel1);
            this.Controls.Add(this.writeButton1);
            this.Controls.Add(this.closeButton1);
            this.Controls.Add(this.openButton1);
            this.Controls.Add(this.secondaryAddressComboBox1);
            this.Controls.Add(this.primaryAddressNumericUpDown1);
            this.Controls.Add(this.boardIdNumericUpDown1);
            this.Controls.Add(this.secondaryAddressLabel1);
            this.Controls.Add(this.primaryAddressLabel1);
            this.Controls.Add(this.boardIdLabel1);
            this.Name = "MainForm";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.primaryAddressNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardIdNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.primaryAddressNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardIdNumericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label boardIdLabel1;
        private System.Windows.Forms.Label primaryAddressLabel1;
        private System.Windows.Forms.Label secondaryAddressLabel1;
        private System.Windows.Forms.ComboBox secondaryAddressComboBox1;
        private System.Windows.Forms.NumericUpDown primaryAddressNumericUpDown1;
        private System.Windows.Forms.NumericUpDown boardIdNumericUpDown1;
        private System.Windows.Forms.Button closeButton1;
        private System.Windows.Forms.Button openButton1;
        private System.Windows.Forms.Label stringReadLabel1;
        private System.Windows.Forms.Button readButton1;
        private System.Windows.Forms.Label stringToWriteLabel1;
        private System.Windows.Forms.Button writeButton1;
        private System.Windows.Forms.RichTextBox stringReadTextBox1;
        private System.Windows.Forms.TextBox stringToWriteTextBox1;
        private System.Windows.Forms.Button btnS0;
        private System.Windows.Forms.TextBox stringToWriteTextBox2;
        private System.Windows.Forms.RichTextBox stringReadTextBox2;
        private System.Windows.Forms.Label stringReadLabel2;
        private System.Windows.Forms.Button readButton2;
        private System.Windows.Forms.Label stringToWriteLabel2;
        private System.Windows.Forms.Button writeButton2;
        private System.Windows.Forms.Button closeButton2;
        private System.Windows.Forms.Button openButton2;
        private System.Windows.Forms.ComboBox secondaryAddressComboBox2;
        private System.Windows.Forms.NumericUpDown primaryAddressNumericUpDown2;
        private System.Windows.Forms.NumericUpDown boardIdNumericUpDown2;
        private System.Windows.Forms.Label secondaryAddressLabel2;
        private System.Windows.Forms.Label primaryAddressLabel2;
        private System.Windows.Forms.Label boardIdLabel2;
    }
}

