namespace PolarizationAnalyzer
{
    partial class PMDForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.stringReadTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(165, 221);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(241, 40);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // stringReadTextBox
            // 
            this.stringReadTextBox.Location = new System.Drawing.Point(12, 12);
            this.stringReadTextBox.Name = "stringReadTextBox";
            this.stringReadTextBox.ReadOnly = true;
            this.stringReadTextBox.Size = new System.Drawing.Size(549, 203);
            this.stringReadTextBox.TabIndex = 39;
            this.stringReadTextBox.Text = "";
            // 
            // PMDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 273);
            this.Controls.Add(this.stringReadTextBox);
            this.Controls.Add(this.btnSend);
            this.Name = "PMDForm";
            this.Text = "PMD";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PMDForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox stringReadTextBox;
    }
}