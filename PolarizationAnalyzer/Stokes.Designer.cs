namespace PolarizationAnalyzer
{
    partial class StoksForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoksForm));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.stringReadTextBox = new System.Windows.Forms.RichTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.picCloseButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Maroon;
            this.chart1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkHorizontal;
            this.chart1.BackImageTransparentColor = System.Drawing.Color.Black;
            this.chart1.BackSecondaryColor = System.Drawing.Color.Black;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea7.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea7.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea7.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea7.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea7.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea7.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea7.BackColor = System.Drawing.Color.White;
            chartArea7.BorderColor = System.Drawing.Color.Transparent;
            chartArea7.Name = "ChartArea1";
            chartArea7.ShadowColor = System.Drawing.Color.Black;
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.BackColor = System.Drawing.Color.Transparent;
            legend7.BorderColor = System.Drawing.Color.Transparent;
            legend7.ForeColor = System.Drawing.Color.White;
            legend7.InterlacedRowsColor = System.Drawing.Color.Transparent;
            legend7.Name = "Legend1";
            legend7.ShadowColor = System.Drawing.Color.Black;
            legend7.TitleBackColor = System.Drawing.Color.White;
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(33, 46);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.Blue;
            series7.LabelBackColor = System.Drawing.Color.Black;
            series7.LabelBorderColor = System.Drawing.Color.Black;
            series7.Legend = "Legend1";
            series7.MarkerBorderColor = System.Drawing.Color.Maroon;
            series7.MarkerColor = System.Drawing.Color.Maroon;
            series7.Name = "S1";
            series7.ShadowColor = System.Drawing.Color.Black;
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(755, 160);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Blue;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(823, 266);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(113, 42);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Blue;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(984, 266);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(113, 42);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // stringReadTextBox
            // 
            this.stringReadTextBox.BackColor = System.Drawing.Color.DarkBlue;
            this.stringReadTextBox.ForeColor = System.Drawing.Color.White;
            this.stringReadTextBox.Location = new System.Drawing.Point(823, 46);
            this.stringReadTextBox.Name = "stringReadTextBox";
            this.stringReadTextBox.ReadOnly = true;
            this.stringReadTextBox.Size = new System.Drawing.Size(274, 208);
            this.stringReadTextBox.TabIndex = 22;
            this.stringReadTextBox.Text = "";
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Maroon;
            this.chart2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkHorizontal;
            this.chart2.BackImageTransparentColor = System.Drawing.Color.Black;
            this.chart2.BackSecondaryColor = System.Drawing.Color.Black;
            this.chart2.BorderlineColor = System.Drawing.Color.Black;
            chartArea8.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea8.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea8.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea8.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea8.BackColor = System.Drawing.Color.White;
            chartArea8.BorderColor = System.Drawing.Color.Transparent;
            chartArea8.Name = "ChartArea1";
            chartArea8.ShadowColor = System.Drawing.Color.Black;
            this.chart2.ChartAreas.Add(chartArea8);
            legend8.BackColor = System.Drawing.Color.Transparent;
            legend8.BorderColor = System.Drawing.Color.Transparent;
            legend8.ForeColor = System.Drawing.Color.White;
            legend8.InterlacedRowsColor = System.Drawing.Color.Transparent;
            legend8.Name = "Legend1";
            legend8.ShadowColor = System.Drawing.Color.Black;
            legend8.TitleBackColor = System.Drawing.Color.White;
            this.chart2.Legends.Add(legend8);
            this.chart2.Location = new System.Drawing.Point(33, 229);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series8.BorderWidth = 3;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Blue;
            series8.LabelBackColor = System.Drawing.Color.Black;
            series8.LabelBorderColor = System.Drawing.Color.Black;
            series8.Legend = "Legend1";
            series8.MarkerBorderColor = System.Drawing.Color.Maroon;
            series8.MarkerColor = System.Drawing.Color.Maroon;
            series8.Name = "S2";
            series8.ShadowColor = System.Drawing.Color.Black;
            this.chart2.Series.Add(series8);
            this.chart2.Size = new System.Drawing.Size(755, 160);
            this.chart2.TabIndex = 23;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            this.chart3.BackColor = System.Drawing.Color.Maroon;
            this.chart3.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkHorizontal;
            this.chart3.BackImageTransparentColor = System.Drawing.Color.Black;
            this.chart3.BackSecondaryColor = System.Drawing.Color.Black;
            this.chart3.BorderlineColor = System.Drawing.Color.Black;
            chartArea9.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea9.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea9.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea9.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea9.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea9.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea9.BackColor = System.Drawing.Color.White;
            chartArea9.BorderColor = System.Drawing.Color.Transparent;
            chartArea9.Name = "ChartArea1";
            chartArea9.ShadowColor = System.Drawing.Color.Black;
            this.chart3.ChartAreas.Add(chartArea9);
            legend9.BackColor = System.Drawing.Color.Transparent;
            legend9.BorderColor = System.Drawing.Color.Transparent;
            legend9.ForeColor = System.Drawing.Color.White;
            legend9.InterlacedRowsColor = System.Drawing.Color.Transparent;
            legend9.Name = "Legend1";
            legend9.ShadowColor = System.Drawing.Color.Black;
            legend9.TitleBackColor = System.Drawing.Color.White;
            this.chart3.Legends.Add(legend9);
            this.chart3.Location = new System.Drawing.Point(33, 408);
            this.chart3.Name = "chart3";
            this.chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series9.BorderWidth = 3;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.Blue;
            series9.LabelBackColor = System.Drawing.Color.Black;
            series9.LabelBorderColor = System.Drawing.Color.Black;
            series9.Legend = "Legend1";
            series9.MarkerBorderColor = System.Drawing.Color.Maroon;
            series9.MarkerColor = System.Drawing.Color.Maroon;
            series9.Name = "S3";
            series9.ShadowColor = System.Drawing.Color.Black;
            this.chart3.Series.Add(series9);
            this.chart3.Size = new System.Drawing.Size(755, 160);
            this.chart3.TabIndex = 24;
            this.chart3.Text = "chart3";
            // 
            // picCloseButton
            // 
            this.picCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("picCloseButton.Image")));
            this.picCloseButton.Location = new System.Drawing.Point(1070, 10);
            this.picCloseButton.Name = "picCloseButton";
            this.picCloseButton.Size = new System.Drawing.Size(27, 24);
            this.picCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCloseButton.TabIndex = 50;
            this.picCloseButton.TabStop = false;
            this.picCloseButton.Click += new System.EventHandler(this.picCloseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Orbitron", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 20);
            this.label1.TabIndex = 51;
            this.label1.Text = "Realtime Stokes parameter ploter";
            // 
            // StoksForm
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1109, 580);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCloseButton);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.stringReadTextBox);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StoksForm";
            this.Text = "Stokes";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RichTextBox stringReadTextBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.PictureBox picCloseButton;
        private System.Windows.Forms.Label label1;
    }
}