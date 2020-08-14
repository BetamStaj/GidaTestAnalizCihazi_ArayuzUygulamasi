using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GidaAnalizi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private Food food;
        public Form2(Food food)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            this.food = food;




            //grafigin ayarlarini yapiyorum
            grafik.Titles.Add("Food Analyze");
            var chart = grafik.ChartAreas[0];
            chart.AxisX.Minimum = 1;
            chart.AxisX.Maximum = food.datalar.Count; // x ekseninin sınırları belirlendi.
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 100; // y ekseninin sınırları belirlendi.
            chart.AxisY.Interval = 10; // y ekseninin araligi belirlendi.
            grafik.Series["D1"].Color = Color.Red;


            grafigeCiz(food.datalar);


        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();          
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            //this.chart1.SaveImage("C:\\Users\\ribat\\OneDrive\\Masaüstü\\deniyorum.png", ChartImageFormat.Png);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png|JPeg Image|*.jpg";
            saveFileDialog.Title = "Grafigi Kaydet";
            saveFileDialog.FileName = "Sonuc.png";

            DialogResult result = saveFileDialog.ShowDialog();
            saveFileDialog.RestoreDirectory = true;

            if (result == DialogResult.OK && saveFileDialog.FileName != "")
            {
                try
                {
                    if (saveFileDialog.CheckPathExists)
                    {
                        if (saveFileDialog.FilterIndex == 2)
                        {
                            grafik.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                        }
                        else if (saveFileDialog.FilterIndex == 1)
                        {
                            grafik.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                        }

                    }
                    else
                    {
                        MessageBox.Show("yol bulunamadi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        public void grafigeCiz(ArrayList datalar)
        {

            foreach (var series in grafik.Series)
            {
                series.Points.Clear();
            }

            
            for (int i = 0; i < datalar.Count; i++)
            {

                grafik.Series["D1"].Points.AddXY(i, datalar[i]); // i değeri X eksenini, rastgele değeri ise Y eksenini gösterir.
                                                                                    // döngü calıstıgı sürece dataları okuyup rastgele yerine yazmamız gerekiyor.
            }

        }


        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
