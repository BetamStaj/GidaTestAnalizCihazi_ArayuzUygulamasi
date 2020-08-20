namespace GidaAnalizi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.dataSaveBtn = new System.Windows.Forms.Button();
            this.getRefBtn = new System.Windows.Forms.Button();
            this.foodTypeComboBox = new System.Windows.Forms.ComboBox();
            this.foodTypeInput = new System.Windows.Forms.TextBox();
            this.analyzeBtn = new System.Windows.Forms.Button();
            this.plotexportBtn = new System.Windows.Forms.Button();
            this.newmsrmntBtn = new System.Windows.Forms.Button();
            this.grafik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grafik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(15, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 46);
            this.label1.TabIndex = 12;
            this.label1.Text = "Smart Food Analyzer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(11, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 30);
            this.label2.TabIndex = 13;
            this.label2.Text = "Device Connection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(61, 300);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 30);
            this.label3.TabIndex = 14;
            this.label3.Text = "Enter or Select Food Type";
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.comboBoxDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDevice.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Location = new System.Drawing.Point(205, 89);
            this.comboBoxDevice.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(151, 28);
            this.comboBoxDevice.TabIndex = 15;
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.disconnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectBtn.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.disconnectBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.disconnectBtn.Location = new System.Drawing.Point(24, 150);
            this.disconnectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(145, 39);
            this.disconnectBtn.TabIndex = 16;
            this.disconnectBtn.Text = "Disconnect";
            this.disconnectBtn.UseVisualStyleBackColor = false;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.connectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectBtn.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.connectBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.connectBtn.Location = new System.Drawing.Point(177, 150);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(203, 39);
            this.connectBtn.TabIndex = 17;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = false;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // dataSaveBtn
            // 
            this.dataSaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.dataSaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataSaveBtn.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataSaveBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.dataSaveBtn.Location = new System.Drawing.Point(24, 208);
            this.dataSaveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.dataSaveBtn.Name = "dataSaveBtn";
            this.dataSaveBtn.Size = new System.Drawing.Size(145, 42);
            this.dataSaveBtn.TabIndex = 18;
            this.dataSaveBtn.Text = "Save Data";
            this.dataSaveBtn.UseVisualStyleBackColor = false;
            this.dataSaveBtn.Click += new System.EventHandler(this.dataSaveBtn_Click);
            // 
            // getRefBtn
            // 
            this.getRefBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.getRefBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getRefBtn.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.getRefBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.getRefBtn.Location = new System.Drawing.Point(177, 208);
            this.getRefBtn.Margin = new System.Windows.Forms.Padding(4);
            this.getRefBtn.Name = "getRefBtn";
            this.getRefBtn.Size = new System.Drawing.Size(203, 42);
            this.getRefBtn.TabIndex = 19;
            this.getRefBtn.Text = "Get Reference";
            this.getRefBtn.UseVisualStyleBackColor = false;
            this.getRefBtn.Click += new System.EventHandler(this.getRefBtn_Click);
            // 
            // foodTypeComboBox
            // 
            this.foodTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.foodTypeComboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.foodTypeComboBox.FormattingEnabled = true;
            this.foodTypeComboBox.Location = new System.Drawing.Point(24, 354);
            this.foodTypeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.foodTypeComboBox.Name = "foodTypeComboBox";
            this.foodTypeComboBox.Size = new System.Drawing.Size(160, 24);
            this.foodTypeComboBox.TabIndex = 20;
            // 
            // foodTypeInput
            // 
            this.foodTypeInput.Location = new System.Drawing.Point(24, 399);
            this.foodTypeInput.Margin = new System.Windows.Forms.Padding(4);
            this.foodTypeInput.Name = "foodTypeInput";
            this.foodTypeInput.Size = new System.Drawing.Size(160, 22);
            this.foodTypeInput.TabIndex = 21;
            // 
            // analyzeBtn
            // 
            this.analyzeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.analyzeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.analyzeBtn.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.analyzeBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.analyzeBtn.Location = new System.Drawing.Point(232, 354);
            this.analyzeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.analyzeBtn.Name = "analyzeBtn";
            this.analyzeBtn.Size = new System.Drawing.Size(148, 48);
            this.analyzeBtn.TabIndex = 22;
            this.analyzeBtn.Text = "Analyze";
            this.analyzeBtn.UseVisualStyleBackColor = false;
            this.analyzeBtn.Click += new System.EventHandler(this.analyzeBtn_Click_1);
            // 
            // plotexportBtn
            // 
            this.plotexportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.plotexportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plotexportBtn.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.plotexportBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.plotexportBtn.Location = new System.Drawing.Point(83, 475);
            this.plotexportBtn.Margin = new System.Windows.Forms.Padding(4);
            this.plotexportBtn.Name = "plotexportBtn";
            this.plotexportBtn.Size = new System.Drawing.Size(216, 53);
            this.plotexportBtn.TabIndex = 23;
            this.plotexportBtn.Text = "Plot and Export";
            this.plotexportBtn.UseVisualStyleBackColor = false;
            this.plotexportBtn.Click += new System.EventHandler(this.plotexportBtn_Click);
            // 
            // newmsrmntBtn
            // 
            this.newmsrmntBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.newmsrmntBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newmsrmntBtn.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.newmsrmntBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.newmsrmntBtn.Location = new System.Drawing.Point(83, 551);
            this.newmsrmntBtn.Margin = new System.Windows.Forms.Padding(4);
            this.newmsrmntBtn.Name = "newmsrmntBtn";
            this.newmsrmntBtn.Size = new System.Drawing.Size(216, 54);
            this.newmsrmntBtn.TabIndex = 24;
            this.newmsrmntBtn.Text = "New Measurement";
            this.newmsrmntBtn.UseVisualStyleBackColor = false;
            this.newmsrmntBtn.Click += new System.EventHandler(this.newmsrmntBtn_Click);
            // 
            // grafik
            // 
            this.grafik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            chartArea2.Name = "ChartArea1";
            this.grafik.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.Name = "D1";
            this.grafik.Legends.Add(legend2);
            this.grafik.Location = new System.Drawing.Point(451, 89);
            this.grafik.Margin = new System.Windows.Forms.Padding(4);
            this.grafik.Name = "grafik";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "D1";
            series2.Name = "D1";
            this.grafik.Series.Add(series2);
            this.grafik.Size = new System.Drawing.Size(896, 551);
            this.grafik.TabIndex = 31;
            this.grafik.Text = "chart1";
            // 
            // refreshBtn
            // 
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.refreshBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshBtn.Image")));
            this.refreshBtn.Location = new System.Drawing.Point(367, 82);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(37, 38);
            this.refreshBtn.TabIndex = 30;
            this.refreshBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::GidaAnalizi.Properties.Resources.altKısım1;
            this.pictureBox5.Location = new System.Drawing.Point(-1, 686);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1363, 90);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 28;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::GidaAnalizi.Properties.Resources.cizgi3;
            this.pictureBox4.Location = new System.Drawing.Point(415, 59);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1, 587);
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::GidaAnalizi.Properties.Resources.cizgi2;
            this.pictureBox3.Location = new System.Drawing.Point(7, 444);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(393, 12);
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GidaAnalizi.Properties.Resources.cizgi2;
            this.pictureBox2.Location = new System.Drawing.Point(7, 268);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(393, 12);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Image = global::GidaAnalizi.Properties.Resources.yeniMinimize;
            this.minimizeBtn.Location = new System.Drawing.Point(1247, 9);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(43, 39);
            this.minimizeBtn.TabIndex = 11;
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
            this.CloseBtn.Location = new System.Drawing.Point(1303, 9);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(43, 39);
            this.CloseBtn.TabIndex = 10;
            this.CloseBtn.TabStop = false;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::GidaAnalizi.Properties.Resources.cizgi1;
            this.pictureBox1.Location = new System.Drawing.Point(-37, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(4239, 2);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1360, 774);
            this.Controls.Add(this.grafik);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.newmsrmntBtn);
            this.Controls.Add(this.plotexportBtn);
            this.Controls.Add(this.analyzeBtn);
            this.Controls.Add(this.foodTypeInput);
            this.Controls.Add(this.foodTypeComboBox);
            this.Controls.Add(this.getRefBtn);
            this.Controls.Add(this.dataSaveBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.comboBoxDevice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "d";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.grafik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button dataSaveBtn;
        private System.Windows.Forms.Button getRefBtn;
        private System.Windows.Forms.ComboBox foodTypeComboBox;
        private System.Windows.Forms.TextBox foodTypeInput;
        private System.Windows.Forms.Button analyzeBtn;
        private System.Windows.Forms.Button plotexportBtn;
        private System.Windows.Forms.Button newmsrmntBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafik;
    }
}

