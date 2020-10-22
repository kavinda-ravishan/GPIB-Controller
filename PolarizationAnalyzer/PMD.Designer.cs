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
            this.txtBoxEnd = new System.Windows.Forms.TextBox();
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
            this.lblMin = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMaxWL = new System.Windows.Forms.Label();
            this.lblMinWL = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // stringReadTextBox
            // 
            this.stringReadTextBox.Location = new System.Drawing.Point(942, 12);
            this.stringReadTextBox.Name = "stringReadTextBox";
            this.stringReadTextBox.ReadOnly = true;
            this.stringReadTextBox.Size = new System.Drawing.Size(214, 320);
            this.stringReadTextBox.TabIndex = 39;
            this.stringReadTextBox.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(657, 338);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(127, 40);
            this.btnStart.TabIndex = 40;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(950, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(790, 338);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(127, 40);
            this.btnStop.TabIndex = 42;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chart
            // 
            chartArea1.AxisX.Title = "Wavelength (nm)";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Title = "PMD";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.chart.Size = new System.Drawing.Size(636, 366);
            this.chart.TabIndex = 43;
            this.chart.Text = "chart1";
            // 
            // txtBoxStart
            // 
            this.txtBoxStart.Location = new System.Drawing.Point(756, 12);
            this.txtBoxStart.Name = "txtBoxStart";
            this.txtBoxStart.Size = new System.Drawing.Size(101, 20);
            this.txtBoxStart.TabIndex = 44;
            this.txtBoxStart.Text = "1550";
            this.txtBoxStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxEnd
            // 
            this.txtBoxEnd.Location = new System.Drawing.Point(756, 48);
            this.txtBoxEnd.Name = "txtBoxEnd";
            this.txtBoxEnd.Size = new System.Drawing.Size(101, 20);
            this.txtBoxEnd.TabIndex = 45;
            this.txtBoxEnd.Text = "1560";
            this.txtBoxEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxStep
            // 
            this.txtBoxStep.Location = new System.Drawing.Point(756, 89);
            this.txtBoxStep.Name = "txtBoxStep";
            this.txtBoxStep.Size = new System.Drawing.Size(101, 20);
            this.txtBoxStep.TabIndex = 46;
            this.txtBoxStep.Text = "1";
            this.txtBoxStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxLength
            // 
            this.txtBoxLength.Location = new System.Drawing.Point(756, 129);
            this.txtBoxLength.Name = "txtBoxLength";
            this.txtBoxLength.Size = new System.Drawing.Size(101, 20);
            this.txtBoxLength.TabIndex = 47;
            this.txtBoxLength.Text = "17";
            this.txtBoxLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "End wavelenght";
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
            this.label5.Location = new System.Drawing.Point(874, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "nm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(874, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "nm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(874, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "nm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(874, 132);
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
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(753, 235);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(16, 13);
            this.lblMin.TabIndex = 59;
            this.lblMin.Text = "---";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(654, 235);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 58;
            this.label11.Text = "Min PMD";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(753, 264);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(16, 13);
            this.lblMax.TabIndex = 61;
            this.lblMax.Text = "---";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(654, 264);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 60;
            this.label13.Text = "Max PMD";
            // 
            // lblMaxWL
            // 
            this.lblMaxWL.AutoSize = true;
            this.lblMaxWL.Location = new System.Drawing.Point(874, 264);
            this.lblMaxWL.Name = "lblMaxWL";
            this.lblMaxWL.Size = new System.Drawing.Size(16, 13);
            this.lblMaxWL.TabIndex = 64;
            this.lblMaxWL.Text = "---";
            // 
            // lblMinWL
            // 
            this.lblMinWL.AutoSize = true;
            this.lblMinWL.Location = new System.Drawing.Point(874, 235);
            this.lblMinWL.Name = "lblMinWL";
            this.lblMinWL.Size = new System.Drawing.Size(16, 13);
            this.lblMinWL.TabIndex = 63;
            this.lblMinWL.Text = "---";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1056, 338);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 40);
            this.btnLoad.TabIndex = 65;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // PMDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 388);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblMaxWL);
            this.Controls.Add(this.lblMinWL);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.label11);
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
            this.Controls.Add(this.txtBoxEnd);
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
        private System.Windows.Forms.TextBox txtBoxEnd;
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
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMaxWL;
        private System.Windows.Forms.Label lblMinWL;
        private System.Windows.Forms.Button btnLoad;
    }
}