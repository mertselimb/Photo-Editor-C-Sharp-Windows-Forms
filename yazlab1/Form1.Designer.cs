namespace yazlab1
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ptbDisplay = new System.Windows.Forms.PictureBox();
            this.btnNegative = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnReOpen = new System.Windows.Forms.Button();
            this.btnCloseReOpen = new System.Windows.Forms.Button();
            this.btnRotataMinus90 = new System.Windows.Forms.Button();
            this.btnRotataPlus90 = new System.Windows.Forms.Button();
            this.btnGrayScale = new System.Windows.Forms.Button();
            this.btnRedChannel = new System.Windows.Forms.Button();
            this.btnGreenChannel = new System.Windows.Forms.Button();
            this.btnBlueChannel = new System.Windows.Forms.Button();
            this.btnGoStart = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMirrorRight = new System.Windows.Forms.Button();
            this.btnMirrorLeft = new System.Windows.Forms.Button();
            this.btnScale = new System.Windows.Forms.Button();
            this.textX = new System.Windows.Forms.RichTextBox();
            this.textY = new System.Windows.Forms.RichTextBox();
            this.red = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.green = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.blue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowse.Location = new System.Drawing.Point(1098, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(176, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ptbDisplay
            // 
            this.ptbDisplay.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ptbDisplay.Location = new System.Drawing.Point(12, 11);
            this.ptbDisplay.Name = "ptbDisplay";
            this.ptbDisplay.Size = new System.Drawing.Size(1080, 720);
            this.ptbDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbDisplay.TabIndex = 1;
            this.ptbDisplay.TabStop = false;
            // 
            // btnNegative
            // 
            this.btnNegative.Location = new System.Drawing.Point(1098, 43);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.Size = new System.Drawing.Size(176, 23);
            this.btnNegative.TabIndex = 2;
            this.btnNegative.Text = "Negate";
            this.btnNegative.UseVisualStyleBackColor = true;
            this.btnNegative.Click += new System.EventHandler(this.btnNegative_Click);
            // 
            // btnHistogram
            // 
            this.btnHistogram.Location = new System.Drawing.Point(1098, 286);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(176, 23);
            this.btnHistogram.TabIndex = 3;
            this.btnHistogram.Text = "Histogram";
            this.btnHistogram.UseVisualStyleBackColor = true;
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // btnReOpen
            // 
            this.btnReOpen.Location = new System.Drawing.Point(1126, 679);
            this.btnReOpen.Name = "btnReOpen";
            this.btnReOpen.Size = new System.Drawing.Size(148, 23);
            this.btnReOpen.TabIndex = 4;
            this.btnReOpen.Text = "ReOpen";
            this.btnReOpen.UseVisualStyleBackColor = true;
            this.btnReOpen.Click += new System.EventHandler(this.btnReOpen_Click);
            // 
            // btnCloseReOpen
            // 
            this.btnCloseReOpen.Location = new System.Drawing.Point(1098, 679);
            this.btnCloseReOpen.Name = "btnCloseReOpen";
            this.btnCloseReOpen.Size = new System.Drawing.Size(22, 23);
            this.btnCloseReOpen.TabIndex = 5;
            this.btnCloseReOpen.Text = "X";
            this.btnCloseReOpen.UseVisualStyleBackColor = true;
            this.btnCloseReOpen.Click += new System.EventHandler(this.btnCloseReOpen_Click);
            // 
            // btnRotataMinus90
            // 
            this.btnRotataMinus90.Location = new System.Drawing.Point(1098, 72);
            this.btnRotataMinus90.Name = "btnRotataMinus90";
            this.btnRotataMinus90.Size = new System.Drawing.Size(85, 23);
            this.btnRotataMinus90.TabIndex = 6;
            this.btnRotataMinus90.Text = "-90";
            this.btnRotataMinus90.UseVisualStyleBackColor = true;
            this.btnRotataMinus90.Click += new System.EventHandler(this.btnRotataMinus90_Click);
            // 
            // btnRotataPlus90
            // 
            this.btnRotataPlus90.Location = new System.Drawing.Point(1189, 72);
            this.btnRotataPlus90.Name = "btnRotataPlus90";
            this.btnRotataPlus90.Size = new System.Drawing.Size(85, 23);
            this.btnRotataPlus90.TabIndex = 7;
            this.btnRotataPlus90.Text = "+90";
            this.btnRotataPlus90.UseVisualStyleBackColor = true;
            this.btnRotataPlus90.Click += new System.EventHandler(this.btnRotataPlus90_Click);
            // 
            // btnGrayScale
            // 
            this.btnGrayScale.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGrayScale.Location = new System.Drawing.Point(1098, 101);
            this.btnGrayScale.Name = "btnGrayScale";
            this.btnGrayScale.Size = new System.Drawing.Size(176, 23);
            this.btnGrayScale.TabIndex = 8;
            this.btnGrayScale.Text = "Grayscale";
            this.btnGrayScale.UseVisualStyleBackColor = false;
            this.btnGrayScale.Click += new System.EventHandler(this.btnGrayScale_Click);
            // 
            // btnRedChannel
            // 
            this.btnRedChannel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRedChannel.Location = new System.Drawing.Point(1098, 130);
            this.btnRedChannel.Name = "btnRedChannel";
            this.btnRedChannel.Size = new System.Drawing.Size(176, 23);
            this.btnRedChannel.TabIndex = 9;
            this.btnRedChannel.Text = "Red channel";
            this.btnRedChannel.UseVisualStyleBackColor = false;
            this.btnRedChannel.Click += new System.EventHandler(this.btnRedChannel_Click);
            // 
            // btnGreenChannel
            // 
            this.btnGreenChannel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGreenChannel.Location = new System.Drawing.Point(1098, 188);
            this.btnGreenChannel.Name = "btnGreenChannel";
            this.btnGreenChannel.Size = new System.Drawing.Size(176, 23);
            this.btnGreenChannel.TabIndex = 10;
            this.btnGreenChannel.Text = "Green channel";
            this.btnGreenChannel.UseVisualStyleBackColor = false;
            this.btnGreenChannel.Click += new System.EventHandler(this.btnGreenChannel_Click);
            // 
            // btnBlueChannel
            // 
            this.btnBlueChannel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBlueChannel.Location = new System.Drawing.Point(1098, 159);
            this.btnBlueChannel.Name = "btnBlueChannel";
            this.btnBlueChannel.Size = new System.Drawing.Size(176, 23);
            this.btnBlueChannel.TabIndex = 11;
            this.btnBlueChannel.Text = "Blue channel";
            this.btnBlueChannel.UseVisualStyleBackColor = false;
            this.btnBlueChannel.Click += new System.EventHandler(this.btnBlueChannel_Click);
            // 
            // btnGoStart
            // 
            this.btnGoStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGoStart.Location = new System.Drawing.Point(1098, 650);
            this.btnGoStart.Name = "btnGoStart";
            this.btnGoStart.Size = new System.Drawing.Size(176, 23);
            this.btnGoStart.TabIndex = 12;
            this.btnGoStart.Text = "Clean all and start again";
            this.btnGoStart.UseVisualStyleBackColor = false;
            this.btnGoStart.Click += new System.EventHandler(this.btnGoStart_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.Location = new System.Drawing.Point(1098, 621);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(176, 23);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Undo";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(1098, 708);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(176, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMirrorRight
            // 
            this.btnMirrorRight.Location = new System.Drawing.Point(1189, 217);
            this.btnMirrorRight.Name = "btnMirrorRight";
            this.btnMirrorRight.Size = new System.Drawing.Size(85, 34);
            this.btnMirrorRight.TabIndex = 15;
            this.btnMirrorRight.Text = "Mirror Right";
            this.btnMirrorRight.UseVisualStyleBackColor = true;
            this.btnMirrorRight.Click += new System.EventHandler(this.btnMirrorRight_Click);
            // 
            // btnMirrorLeft
            // 
            this.btnMirrorLeft.Location = new System.Drawing.Point(1098, 217);
            this.btnMirrorLeft.Name = "btnMirrorLeft";
            this.btnMirrorLeft.Size = new System.Drawing.Size(85, 34);
            this.btnMirrorLeft.TabIndex = 16;
            this.btnMirrorLeft.Text = "Mirror Left";
            this.btnMirrorLeft.UseVisualStyleBackColor = true;
            this.btnMirrorLeft.Click += new System.EventHandler(this.btnMirrorLeft_Click);
            // 
            // btnScale
            // 
            this.btnScale.Location = new System.Drawing.Point(1198, 257);
            this.btnScale.Name = "btnScale";
            this.btnScale.Size = new System.Drawing.Size(76, 23);
            this.btnScale.TabIndex = 17;
            this.btnScale.Text = "Scale";
            this.btnScale.UseVisualStyleBackColor = true;
            this.btnScale.Click += new System.EventHandler(this.btnScale_Click);
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(1098, 257);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(44, 23);
            this.textX.TabIndex = 18;
            this.textX.Text = "";
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(1148, 257);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(44, 23);
            this.textY.TabIndex = 19;
            this.textY.Text = "";
            // 
            // red
            // 
            this.red.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.red.BackColor = System.Drawing.Color.Transparent;
            this.red.BorderlineColor = System.Drawing.SystemColors.Window;
            chartArea1.Name = "Red";
            this.red.ChartAreas.Add(chartArea1);
            this.red.Enabled = false;
            legend1.Name = "Legend1";
            this.red.Legends.Add(legend1);
            this.red.Location = new System.Drawing.Point(-39, 737);
            this.red.Name = "red";
            this.red.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.red.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red};
            series1.ChartArea = "Red";
            series1.Legend = "Legend1";
            series1.Name = "main";
            this.red.Series.Add(series1);
            this.red.Size = new System.Drawing.Size(540, 93);
            this.red.TabIndex = 20;
            this.red.Text = "chart1";
            // 
            // green
            // 
            this.green.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "Green";
            this.green.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.green.Legends.Add(legend2);
            this.green.Location = new System.Drawing.Point(404, 737);
            this.green.Name = "green";
            this.green.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.green.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))))};
            series2.ChartArea = "Green";
            series2.Legend = "Legend1";
            series2.Name = "main";
            this.green.Series.Add(series2);
            this.green.Size = new System.Drawing.Size(540, 96);
            this.green.TabIndex = 21;
            this.green.Text = "chart2";
            // 
            // blue
            // 
            this.blue.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "Blue";
            this.blue.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.blue.Legends.Add(legend3);
            this.blue.Location = new System.Drawing.Point(842, 737);
            this.blue.Name = "blue";
            series3.ChartArea = "Blue";
            series3.Legend = "Legend1";
            series3.Name = "main";
            this.blue.Series.Add(series3);
            this.blue.Size = new System.Drawing.Size(540, 96);
            this.blue.TabIndex = 22;
            this.blue.Text = "chart3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1280, 810);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.green);
            this.Controls.Add(this.red);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.textX);
            this.Controls.Add(this.btnScale);
            this.Controls.Add(this.btnMirrorLeft);
            this.Controls.Add(this.btnMirrorRight);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnGoStart);
            this.Controls.Add(this.btnBlueChannel);
            this.Controls.Add(this.btnGreenChannel);
            this.Controls.Add(this.btnRedChannel);
            this.Controls.Add(this.btnGrayScale);
            this.Controls.Add(this.btnRotataPlus90);
            this.Controls.Add(this.btnRotataMinus90);
            this.Controls.Add(this.btnCloseReOpen);
            this.Controls.Add(this.btnReOpen);
            this.Controls.Add(this.btnHistogram);
            this.Controls.Add(this.btnNegative);
            this.Controls.Add(this.ptbDisplay);
            this.Controls.Add(this.btnBrowse);
            this.Name = "Form1";
            this.Text = "Yazlab 1";
            ((System.ComponentModel.ISupportInitialize)(this.ptbDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox ptbDisplay;
        private System.Windows.Forms.Button btnNegative;
        private System.Windows.Forms.Button btnHistogram;
        private System.Windows.Forms.Button btnReOpen;
        private System.Windows.Forms.Button btnCloseReOpen;
        private System.Windows.Forms.Button btnRotataMinus90;
        private System.Windows.Forms.Button btnRotataPlus90;
        private System.Windows.Forms.Button btnGrayScale;
        private System.Windows.Forms.Button btnRedChannel;
        private System.Windows.Forms.Button btnGreenChannel;
        private System.Windows.Forms.Button btnBlueChannel;
        private System.Windows.Forms.Button btnGoStart;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMirrorRight;
        private System.Windows.Forms.Button btnMirrorLeft;
        private System.Windows.Forms.Button btnScale;
        private System.Windows.Forms.RichTextBox textX;
        private System.Windows.Forms.RichTextBox textY;
        private System.Windows.Forms.DataVisualization.Charting.Chart red;
        private System.Windows.Forms.DataVisualization.Charting.Chart green;
        private System.Windows.Forms.DataVisualization.Charting.Chart blue;
    }
}

