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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMDForm));
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
            this.lblMin = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMaxWL = new System.Windows.Forms.Label();
            this.lblMinWL = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.picCloseButton = new System.Windows.Forms.PictureBox();
            this.lblJ11 = new System.Windows.Forms.Label();
            this.lblJ12 = new System.Windows.Forms.Label();
            this.lblJ21 = new System.Windows.Forms.Label();
            this.lblJ22 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnShowRefJonesMat = new System.Windows.Forms.Button();
            this.btnMeasureRefJonesMat = new System.Windows.Forms.Button();
            this.btnResetRefJonesMat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBoxLaserPower = new System.Windows.Forms.TextBox();
            this.lbltitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBoxFileName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseButton)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // stringReadTextBox
            // 
            this.stringReadTextBox.BackColor = System.Drawing.Color.DarkBlue;
            this.stringReadTextBox.ForeColor = System.Drawing.Color.White;
            this.stringReadTextBox.Location = new System.Drawing.Point(10, 10);
            this.stringReadTextBox.Name = "stringReadTextBox";
            this.stringReadTextBox.ReadOnly = true;
            this.stringReadTextBox.Size = new System.Drawing.Size(214, 421);
            this.stringReadTextBox.TabIndex = 39;
            this.stringReadTextBox.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Blue;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(657, 373);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(127, 40);
            this.btnStart.TabIndex = 40;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Blue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(10, 525);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Blue;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(790, 373);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(127, 40);
            this.btnStop.TabIndex = 42;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
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
            this.chart.Location = new System.Drawing.Point(12, 47);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "PMD";
            series1.ShadowColor = System.Drawing.Color.Black;
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(636, 366);
            this.chart.TabIndex = 43;
            this.chart.Text = "chart1";
            // 
            // txtBoxStart
            // 
            this.txtBoxStart.Location = new System.Drawing.Point(756, 45);
            this.txtBoxStart.Name = "txtBoxStart";
            this.txtBoxStart.Size = new System.Drawing.Size(101, 20);
            this.txtBoxStart.TabIndex = 44;
            this.txtBoxStart.Text = "1550";
            this.txtBoxStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxStop
            // 
            this.txtBoxStop.Location = new System.Drawing.Point(756, 83);
            this.txtBoxStop.Name = "txtBoxStop";
            this.txtBoxStop.Size = new System.Drawing.Size(101, 20);
            this.txtBoxStop.TabIndex = 45;
            this.txtBoxStop.Text = "1560";
            this.txtBoxStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxStep
            // 
            this.txtBoxStep.Location = new System.Drawing.Point(756, 124);
            this.txtBoxStep.Name = "txtBoxStep";
            this.txtBoxStep.Size = new System.Drawing.Size(101, 20);
            this.txtBoxStep.TabIndex = 46;
            this.txtBoxStep.Text = "1";
            this.txtBoxStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxLength
            // 
            this.txtBoxLength.Location = new System.Drawing.Point(756, 164);
            this.txtBoxLength.Name = "txtBoxLength";
            this.txtBoxLength.Size = new System.Drawing.Size(101, 20);
            this.txtBoxLength.TabIndex = 47;
            this.txtBoxLength.Text = "17";
            this.txtBoxLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(654, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Start wavelenght";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(654, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Stop wavelenght";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(654, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Step size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(654, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Fiber length";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(874, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "nm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(874, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "nm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(874, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "nm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(874, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Km";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(654, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Mean PMD";
            // 
            // lblMeanPMD
            // 
            this.lblMeanPMD.AutoSize = true;
            this.lblMeanPMD.BackColor = System.Drawing.Color.Black;
            this.lblMeanPMD.ForeColor = System.Drawing.Color.White;
            this.lblMeanPMD.Location = new System.Drawing.Point(753, 273);
            this.lblMeanPMD.Name = "lblMeanPMD";
            this.lblMeanPMD.Size = new System.Drawing.Size(16, 13);
            this.lblMeanPMD.TabIndex = 57;
            this.lblMeanPMD.Text = "---";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Black;
            this.lblMin.ForeColor = System.Drawing.Color.White;
            this.lblMin.Location = new System.Drawing.Point(753, 301);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(16, 13);
            this.lblMin.TabIndex = 59;
            this.lblMin.Text = "---";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(654, 301);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 58;
            this.label11.Text = "Min PMD";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.BackColor = System.Drawing.Color.Black;
            this.lblMax.ForeColor = System.Drawing.Color.White;
            this.lblMax.Location = new System.Drawing.Point(753, 330);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(16, 13);
            this.lblMax.TabIndex = 61;
            this.lblMax.Text = "---";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(654, 330);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 60;
            this.label13.Text = "Max PMD";
            // 
            // lblMaxWL
            // 
            this.lblMaxWL.AutoSize = true;
            this.lblMaxWL.BackColor = System.Drawing.Color.Black;
            this.lblMaxWL.ForeColor = System.Drawing.Color.White;
            this.lblMaxWL.Location = new System.Drawing.Point(874, 330);
            this.lblMaxWL.Name = "lblMaxWL";
            this.lblMaxWL.Size = new System.Drawing.Size(16, 13);
            this.lblMaxWL.TabIndex = 64;
            this.lblMaxWL.Text = "---";
            // 
            // lblMinWL
            // 
            this.lblMinWL.AutoSize = true;
            this.lblMinWL.BackColor = System.Drawing.Color.Black;
            this.lblMinWL.ForeColor = System.Drawing.Color.White;
            this.lblMinWL.Location = new System.Drawing.Point(874, 301);
            this.lblMinWL.Name = "lblMinWL";
            this.lblMinWL.Size = new System.Drawing.Size(16, 13);
            this.lblMinWL.TabIndex = 63;
            this.lblMinWL.Text = "---";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.Blue;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(124, 525);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 40);
            this.btnLoad.TabIndex = 65;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // picCloseButton
            // 
            this.picCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("picCloseButton.Image")));
            this.picCloseButton.Location = new System.Drawing.Point(1129, 12);
            this.picCloseButton.Name = "picCloseButton";
            this.picCloseButton.Size = new System.Drawing.Size(27, 24);
            this.picCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCloseButton.TabIndex = 66;
            this.picCloseButton.TabStop = false;
            this.picCloseButton.Click += new System.EventHandler(this.picCloseButton_Click);
            // 
            // lblJ11
            // 
            this.lblJ11.AutoSize = true;
            this.lblJ11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJ11.ForeColor = System.Drawing.Color.White;
            this.lblJ11.Location = new System.Drawing.Point(77, 492);
            this.lblJ11.Name = "lblJ11";
            this.lblJ11.Size = new System.Drawing.Size(16, 13);
            this.lblJ11.TabIndex = 68;
            this.lblJ11.Text = "---";
            // 
            // lblJ12
            // 
            this.lblJ12.AutoSize = true;
            this.lblJ12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJ12.ForeColor = System.Drawing.Color.White;
            this.lblJ12.Location = new System.Drawing.Point(408, 492);
            this.lblJ12.Name = "lblJ12";
            this.lblJ12.Size = new System.Drawing.Size(16, 13);
            this.lblJ12.TabIndex = 69;
            this.lblJ12.Text = "---";
            // 
            // lblJ21
            // 
            this.lblJ21.AutoSize = true;
            this.lblJ21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJ21.ForeColor = System.Drawing.Color.White;
            this.lblJ21.Location = new System.Drawing.Point(77, 579);
            this.lblJ21.Name = "lblJ21";
            this.lblJ21.Size = new System.Drawing.Size(16, 13);
            this.lblJ21.TabIndex = 70;
            this.lblJ21.Text = "---";
            // 
            // lblJ22
            // 
            this.lblJ22.AutoSize = true;
            this.lblJ22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJ22.ForeColor = System.Drawing.Color.White;
            this.lblJ22.Location = new System.Drawing.Point(408, 579);
            this.lblJ22.Name = "lblJ22";
            this.lblJ22.Size = new System.Drawing.Size(16, 13);
            this.lblJ22.TabIndex = 72;
            this.lblJ22.Text = "---";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(12, 430);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(154, 13);
            this.label15.TabIndex = 73;
            this.label15.Text = "Inverse reference jones matrix :";
            // 
            // btnShowRefJonesMat
            // 
            this.btnShowRefJonesMat.BackColor = System.Drawing.Color.Blue;
            this.btnShowRefJonesMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowRefJonesMat.ForeColor = System.Drawing.Color.White;
            this.btnShowRefJonesMat.Location = new System.Drawing.Point(657, 583);
            this.btnShowRefJonesMat.Name = "btnShowRefJonesMat";
            this.btnShowRefJonesMat.Size = new System.Drawing.Size(165, 40);
            this.btnShowRefJonesMat.TabIndex = 74;
            this.btnShowRefJonesMat.Text = "Show reference jones matrix";
            this.btnShowRefJonesMat.UseVisualStyleBackColor = false;
            this.btnShowRefJonesMat.Click += new System.EventHandler(this.btnShowRefJonesMat_Click);
            // 
            // btnMeasureRefJonesMat
            // 
            this.btnMeasureRefJonesMat.BackColor = System.Drawing.Color.Blue;
            this.btnMeasureRefJonesMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeasureRefJonesMat.ForeColor = System.Drawing.Color.White;
            this.btnMeasureRefJonesMat.Location = new System.Drawing.Point(657, 464);
            this.btnMeasureRefJonesMat.Name = "btnMeasureRefJonesMat";
            this.btnMeasureRefJonesMat.Size = new System.Drawing.Size(165, 40);
            this.btnMeasureRefJonesMat.TabIndex = 75;
            this.btnMeasureRefJonesMat.Text = "Measure reference jones matrix";
            this.btnMeasureRefJonesMat.UseVisualStyleBackColor = false;
            this.btnMeasureRefJonesMat.Click += new System.EventHandler(this.btnMeasureRefJonesMat_Click);
            // 
            // btnResetRefJonesMat
            // 
            this.btnResetRefJonesMat.BackColor = System.Drawing.Color.Blue;
            this.btnResetRefJonesMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetRefJonesMat.ForeColor = System.Drawing.Color.White;
            this.btnResetRefJonesMat.Location = new System.Drawing.Point(657, 524);
            this.btnResetRefJonesMat.Name = "btnResetRefJonesMat";
            this.btnResetRefJonesMat.Size = new System.Drawing.Size(165, 40);
            this.btnResetRefJonesMat.TabIndex = 76;
            this.btnResetRefJonesMat.Text = "Reset reference jones matrix";
            this.btnResetRefJonesMat.UseVisualStyleBackColor = false;
            this.btnResetRefJonesMat.Click += new System.EventHandler(this.btnResetRefJonesMat_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(12, 460);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 163);
            this.panel1.TabIndex = 77;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(874, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 80;
            this.label10.Text = "uW";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(654, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "Laer power";
            // 
            // txtBoxLaserPower
            // 
            this.txtBoxLaserPower.Location = new System.Drawing.Point(756, 202);
            this.txtBoxLaserPower.Name = "txtBoxLaserPower";
            this.txtBoxLaserPower.Size = new System.Drawing.Size(101, 20);
            this.txtBoxLaserPower.TabIndex = 78;
            this.txtBoxLaserPower.Text = "1000";
            this.txtBoxLaserPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Orbitron", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.White;
            this.lbltitle.Location = new System.Drawing.Point(8, 16);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(171, 20);
            this.lbltitle.TabIndex = 81;
            this.lbltitle.Text = "PMD analysis tool";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtBoxFileName);
            this.panel2.Controls.Add(this.stringReadTextBox);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnLoad);
            this.panel2.Location = new System.Drawing.Point(923, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 578);
            this.panel2.TabIndex = 82;
            // 
            // txtBoxFileName
            // 
            this.txtBoxFileName.Location = new System.Drawing.Point(10, 490);
            this.txtBoxFileName.Name = "txtBoxFileName";
            this.txtBoxFileName.Size = new System.Drawing.Size(214, 20);
            this.txtBoxFileName.TabIndex = 83;
            this.txtBoxFileName.Text = "data";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(7, 460);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 83;
            this.label14.Text = "File name :";
            // 
            // PMDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1168, 635);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBoxLaserPower);
            this.Controls.Add(this.btnResetRefJonesMat);
            this.Controls.Add(this.btnMeasureRefJonesMat);
            this.Controls.Add(this.btnShowRefJonesMat);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblJ22);
            this.Controls.Add(this.lblJ21);
            this.Controls.Add(this.lblJ12);
            this.Controls.Add(this.lblJ11);
            this.Controls.Add(this.picCloseButton);
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
            this.Controls.Add(this.txtBoxStop);
            this.Controls.Add(this.txtBoxStart);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PMDForm";
            this.Text = "PMD";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseButton)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMaxWL;
        private System.Windows.Forms.Label lblMinWL;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.PictureBox picCloseButton;
        private System.Windows.Forms.Label lblJ11;
        private System.Windows.Forms.Label lblJ12;
        private System.Windows.Forms.Label lblJ21;
        private System.Windows.Forms.Label lblJ22;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnShowRefJonesMat;
        private System.Windows.Forms.Button btnMeasureRefJonesMat;
        private System.Windows.Forms.Button btnResetRefJonesMat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBoxLaserPower;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBoxFileName;
    }
}