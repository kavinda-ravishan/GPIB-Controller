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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoksForm));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.stringReadTextBox = new System.Windows.Forms.RichTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.picCloseButton = new System.Windows.Forms.PictureBox();
            this.lbltitle = new System.Windows.Forms.Label();
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
            chartArea4.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea4.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea4.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea4.BackColor = System.Drawing.Color.White;
            chartArea4.BorderColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea1";
            chartArea4.ShadowColor = System.Drawing.Color.Black;
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.BackColor = System.Drawing.Color.Transparent;
            legend4.BorderColor = System.Drawing.Color.Transparent;
            legend4.ForeColor = System.Drawing.Color.White;
            legend4.InterlacedRowsColor = System.Drawing.Color.Transparent;
            legend4.Name = "Legend1";
            legend4.ShadowColor = System.Drawing.Color.Black;
            legend4.TitleBackColor = System.Drawing.Color.White;
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(33, 46);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Blue;
            series4.LabelBackColor = System.Drawing.Color.Black;
            series4.LabelBorderColor = System.Drawing.Color.Black;
            series4.Legend = "Legend1";
            series4.MarkerBorderColor = System.Drawing.Color.Maroon;
            series4.MarkerColor = System.Drawing.Color.Maroon;
            series4.Name = "S1";
            series4.ShadowColor = System.Drawing.Color.Black;
            this.chart1.Series.Add(series4);
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
            chartArea5.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea5.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea5.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea5.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea5.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea5.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea5.BackColor = System.Drawing.Color.White;
            chartArea5.BorderColor = System.Drawing.Color.Transparent;
            chartArea5.Name = "ChartArea1";
            chartArea5.ShadowColor = System.Drawing.Color.Black;
            this.chart2.ChartAreas.Add(chartArea5);
            legend5.BackColor = System.Drawing.Color.Transparent;
            legend5.BorderColor = System.Drawing.Color.Transparent;
            legend5.ForeColor = System.Drawing.Color.White;
            legend5.InterlacedRowsColor = System.Drawing.Color.Transparent;
            legend5.Name = "Legend1";
            legend5.ShadowColor = System.Drawing.Color.Black;
            legend5.TitleBackColor = System.Drawing.Color.White;
            this.chart2.Legends.Add(legend5);
            this.chart2.Location = new System.Drawing.Point(33, 229);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Blue;
            series5.LabelBackColor = System.Drawing.Color.Black;
            series5.LabelBorderColor = System.Drawing.Color.Black;
            series5.Legend = "Legend1";
            series5.MarkerBorderColor = System.Drawing.Color.Maroon;
            series5.MarkerColor = System.Drawing.Color.Maroon;
            series5.Name = "S2";
            series5.ShadowColor = System.Drawing.Color.Black;
            this.chart2.Series.Add(series5);
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
            chartArea6.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea6.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea6.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea6.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea6.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea6.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea6.BackColor = System.Drawing.Color.White;
            chartArea6.BorderColor = System.Drawing.Color.Transparent;
            chartArea6.Name = "ChartArea1";
            chartArea6.ShadowColor = System.Drawing.Color.Black;
            this.chart3.ChartAreas.Add(chartArea6);
            legend6.BackColor = System.Drawing.Color.Transparent;
            legend6.BorderColor = System.Drawing.Color.Transparent;
            legend6.ForeColor = System.Drawing.Color.White;
            legend6.InterlacedRowsColor = System.Drawing.Color.Transparent;
            legend6.Name = "Legend1";
            legend6.ShadowColor = System.Drawing.Color.Black;
            legend6.TitleBackColor = System.Drawing.Color.White;
            this.chart3.Legends.Add(legend6);
            this.chart3.Location = new System.Drawing.Point(33, 408);
            this.chart3.Name = "chart3";
            this.chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Blue;
            series6.LabelBackColor = System.Drawing.Color.Black;
            series6.LabelBorderColor = System.Drawing.Color.Black;
            series6.Legend = "Legend1";
            series6.MarkerBorderColor = System.Drawing.Color.Maroon;
            series6.MarkerColor = System.Drawing.Color.Maroon;
            series6.Name = "S3";
            series6.ShadowColor = System.Drawing.Color.Black;
            this.chart3.Series.Add(series6);
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
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Orbitron", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.White;
            this.lbltitle.Location = new System.Drawing.Point(29, 14);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(319, 20);
            this.lbltitle.TabIndex = 51;
            this.lbltitle.Text = "Realtime Stokes parameter plotter";
            // 
            // StoksForm
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1109, 580);
            this.Controls.Add(this.lbltitle);
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
        private System.Windows.Forms.Label lbltitle;
    }
}