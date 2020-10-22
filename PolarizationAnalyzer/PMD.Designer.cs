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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.stringReadTextBox = new System.Windows.Forms.RichTextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtBoxStart = new System.Windows.Forms.TextBox();
            this.txtBoxStop = new System.Windows.Forms.TextBox();
            this.txtBoxStep = new System.Windows.Forms.TextBox();
            this.txtBoxLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMeanPMD = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // stringReadTextBox
            // 
            this.stringReadTextBox.Location = new System.Drawing.Point(862, 12);
            this.stringReadTextBox.Name = "stringReadTextBox";
            this.stringReadTextBox.ReadOnly = true;
            this.stringReadTextBox.Size = new System.Drawing.Size(214, 320);
            this.stringReadTextBox.TabIndex = 39;
            this.stringReadTextBox.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 338);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(163, 40);
            this.btnStart.TabIndex = 40;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(961, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 40);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(228, 338);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(163, 40);
            this.btnStop.TabIndex = 42;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "PMD";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(636, 320);
            this.chart.TabIndex = 43;
            this.chart.Text = "chart1";
            // 
            // txtBoxStart
            // 
            this.txtBoxStart.Location = new System.Drawing.Point(756, 12);
            this.txtBoxStart.Name = "txtBoxStart";
            this.txtBoxStart.Size = new System.Drawing.Size(64, 20);
            this.txtBoxStart.TabIndex = 44;
            this.txtBoxStart.Text = "1550";
            // 
            // txtBoxStop
            // 
            this.txtBoxStop.Location = new System.Drawing.Point(756, 48);
            this.txtBoxStop.Name = "txtBoxStop";
            this.txtBoxStop.Size = new System.Drawing.Size(64, 20);
            this.txtBoxStop.TabIndex = 45;
            this.txtBoxStop.Text = "1560";
            // 
            // txtBoxStep
            // 
            this.txtBoxStep.Location = new System.Drawing.Point(756, 89);
            this.txtBoxStep.Name = "txtBoxStep";
            this.txtBoxStep.Size = new System.Drawing.Size(64, 20);
            this.txtBoxStep.TabIndex = 46;
            this.txtBoxStep.Text = "1";
            // 
            // txtBoxLength
            // 
            this.txtBoxLength.Location = new System.Drawing.Point(756, 129);
            this.txtBoxLength.Name = "txtBoxLength";
            this.txtBoxLength.Size = new System.Drawing.Size(64, 20);
            this.txtBoxLength.TabIndex = 47;
            this.txtBoxLength.Text = "17";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(654, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Start wavelenght";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(654, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Stop  wavelenght";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(654, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Step size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(654, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Fiber length";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(826, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "nm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(826, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "nm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(826, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "nm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(826, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Km";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(654, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Mean PMD";
            // 
            // lblMeanPMD
            // 
            this.lblMeanPMD.AutoSize = true;
            this.lblMeanPMD.Location = new System.Drawing.Point(753, 207);
            this.lblMeanPMD.Name = "lblMeanPMD";
            this.lblMeanPMD.Size = new System.Drawing.Size(16, 13);
            this.lblMeanPMD.TabIndex = 57;
            this.lblMeanPMD.Text = "---";
            // 
            // PMDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 388);
            this.Controls.Add(this.lblMeanPMD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxLength);
            this.Controls.Add(this.txtBoxStep);
            this.Controls.Add(this.txtBoxStop);
            this.Controls.Add(this.txtBoxStart);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.stringReadTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PMDForm";
            this.Text = "PMD";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PMDForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox stringReadTextBox;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TextBox txtBoxStart;
        private System.Windows.Forms.TextBox txtBoxStop;
        private System.Windows.Forms.TextBox txtBoxStep;
        private System.Windows.Forms.TextBox txtBoxLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMeanPMD;
    }
}