namespace GidaAnalizi
{
    partial class Form2
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
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grafik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.foodName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::GidaAnalizi.Properties.Resources.altKısım1;
            this.pictureBox5.Location = new System.Drawing.Point(0, 752);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1453, 90);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 29;
            this.pictureBox5.TabStop = false;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Image = global::GidaAnalizi.Properties.Resources.yeniMinimize;
            this.minimizeBtn.Location = new System.Drawing.Point(1328, 7);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(43, 39);
            this.minimizeBtn.TabIndex = 31;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Image = global::GidaAnalizi.Properties.Resources.yeniClose1;
            this.CloseBtn.Location = new System.Drawing.Point(1385, 7);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(43, 39);
            this.CloseBtn.TabIndex = 30;
            this.CloseBtn.TabStop = false;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::GidaAnalizi.Properties.Resources.cizgi1;
            this.pictureBox1.Location = new System.Drawing.Point(-1365, 52);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(4239, 2);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // grafik
            // 
            this.grafik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            chartArea1.Name = "ChartArea1";
            this.grafik.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.grafik.Legends.Add(legend1);
            this.grafik.Location = new System.Drawing.Point(16, 114);
            this.grafik.Margin = new System.Windows.Forms.Padding(4);
            this.grafik.Name = "grafik";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "D1";
            this.grafik.Series.Add(series1);
            this.grafik.Size = new System.Drawing.Size(1412, 631);
            this.grafik.TabIndex = 33;
            this.grafik.Text = "chart1";
            this.grafik.Click += new System.EventHandler(this.chart1_Click);
            this.grafik.DoubleClick += new System.EventHandler(this.chart1_DoubleClick);
            // 
            // foodName
            // 
            this.foodName.AutoSize = true;
            this.foodName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.foodName.Location = new System.Drawing.Point(702, 58);
            this.foodName.Name = "foodName";
            this.foodName.Size = new System.Drawing.Size(101, 36);
            this.foodName.TabIndex = 34;
            this.foodName.Text = "label1";
            this.foodName.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1444, 841);
            this.Controls.Add(this.foodName);
            this.Controls.Add(this.grafik);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.pictureBox5);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafik;
        private System.Windows.Forms.Label foodName;
    }
}