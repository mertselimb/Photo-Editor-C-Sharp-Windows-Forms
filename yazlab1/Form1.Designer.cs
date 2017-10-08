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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ptbDisplay = new System.Windows.Forms.PictureBox();
            this.btnNegative = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnReOpen = new System.Windows.Forms.Button();
            this.btnCloseReOpen = new System.Windows.Forms.Button();
            this.btnRotataMinus90 = new System.Windows.Forms.Button();
            this.btnRotataPlus90 = new System.Windows.Forms.Button();
            this.btnGrayScale = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowse.Location = new System.Drawing.Point(418, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(134, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ptbDisplay
            // 
            this.ptbDisplay.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ptbDisplay.Location = new System.Drawing.Point(12, 12);
            this.ptbDisplay.Name = "ptbDisplay";
            this.ptbDisplay.Size = new System.Drawing.Size(400, 400);
            this.ptbDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbDisplay.TabIndex = 1;
            this.ptbDisplay.TabStop = false;
            // 
            // btnNegative
            // 
            this.btnNegative.Location = new System.Drawing.Point(418, 41);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.Size = new System.Drawing.Size(134, 23);
            this.btnNegative.TabIndex = 2;
            this.btnNegative.Text = "Negate";
            this.btnNegative.UseVisualStyleBackColor = true;
            this.btnNegative.Click += new System.EventHandler(this.btnNegative_Click);
            // 
            // btnHistogram
            // 
            this.btnHistogram.Location = new System.Drawing.Point(418, 70);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(134, 23);
            this.btnHistogram.TabIndex = 3;
            this.btnHistogram.Text = "Histogram";
            this.btnHistogram.UseVisualStyleBackColor = true;
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // btnReOpen
            // 
            this.btnReOpen.Location = new System.Drawing.Point(446, 388);
            this.btnReOpen.Name = "btnReOpen";
            this.btnReOpen.Size = new System.Drawing.Size(106, 23);
            this.btnReOpen.TabIndex = 4;
            this.btnReOpen.Text = "ReOpen";
            this.btnReOpen.UseVisualStyleBackColor = true;
            this.btnReOpen.Click += new System.EventHandler(this.btnReOpen_Click);
            // 
            // btnCloseReOpen
            // 
            this.btnCloseReOpen.Location = new System.Drawing.Point(418, 388);
            this.btnCloseReOpen.Name = "btnCloseReOpen";
            this.btnCloseReOpen.Size = new System.Drawing.Size(22, 23);
            this.btnCloseReOpen.TabIndex = 5;
            this.btnCloseReOpen.Text = "X";
            this.btnCloseReOpen.UseVisualStyleBackColor = true;
            this.btnCloseReOpen.Click += new System.EventHandler(this.btnCloseReOpen_Click);
            // 
            // btnRotataMinus90
            // 
            this.btnRotataMinus90.Location = new System.Drawing.Point(418, 99);
            this.btnRotataMinus90.Name = "btnRotataMinus90";
            this.btnRotataMinus90.Size = new System.Drawing.Size(65, 23);
            this.btnRotataMinus90.TabIndex = 6;
            this.btnRotataMinus90.Text = "-90";
            this.btnRotataMinus90.UseVisualStyleBackColor = true;
            this.btnRotataMinus90.Click += new System.EventHandler(this.btnRotataMinus90_Click);
            // 
            // btnRotataPlus90
            // 
            this.btnRotataPlus90.Location = new System.Drawing.Point(487, 99);
            this.btnRotataPlus90.Name = "btnRotataPlus90";
            this.btnRotataPlus90.Size = new System.Drawing.Size(65, 23);
            this.btnRotataPlus90.TabIndex = 7;
            this.btnRotataPlus90.Text = "+90";
            this.btnRotataPlus90.UseVisualStyleBackColor = true;
            this.btnRotataPlus90.Click += new System.EventHandler(this.btnRotataPlus90_Click);
            // 
            // btnGrayScale
            // 
            this.btnGrayScale.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGrayScale.Location = new System.Drawing.Point(418, 128);
            this.btnGrayScale.Name = "btnGrayScale";
            this.btnGrayScale.Size = new System.Drawing.Size(134, 23);
            this.btnGrayScale.TabIndex = 8;
            this.btnGrayScale.Text = "Grayscale";
            this.btnGrayScale.UseVisualStyleBackColor = false;
            this.btnGrayScale.Click += new System.EventHandler(this.btnGrayScale_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(564, 423);
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
            this.Text = "Mert Selimbeyoğlu 150202009";
            ((System.ComponentModel.ISupportInitialize)(this.ptbDisplay)).EndInit();
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
    }
}

