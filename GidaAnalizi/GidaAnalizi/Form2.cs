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
            grafik.Titles[0].ForeColor = Color.White;
            var chart = grafik.ChartAreas[0];
            grafik.ChartAreas[0].AxisX.LineColor = Color.White;
            grafik.ChartAreas[0].AxisY.LineColor = Color.White;
            grafik.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            grafik.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            grafik.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.White;
            grafik.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.White;
            grafik.ChartAreas[0].BackColor = Color.FromArgb(41, 53, 65);
            grafik.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(41, 53, 65);
            grafik.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(41, 53, 65);
            chart.AxisX.Minimum = 1;
            chart.AxisX.Maximum = 18; // x ekseninin sınırları belirlendi.
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 1000; // y ekseninin sınırları belirlendi.
            chart.AxisY.Interval = 100; // y ekseninin araligi belirlendi.


            grafigeCiz();

            foodName.Text = food.foodName;


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


        public void grafigeCiz()
        {
            
            foreach (var series in grafik.Series)
            {
                series.Points.Clear();
            }
            
            
            for (int j =0;j< food.datalar.Count/18;j++)
            {
                string seriesName = $"{food.foodName} - {j+1}";
                grafik.Series.Add(new Series(seriesName));
                grafik.Series[seriesName].ChartType = SeriesChartType.Spline;
                grafik.Series[seriesName].BorderWidth = 2;

                for (int i = 0; i < 18; i++)
                {
                    grafik.Series[seriesName].Points.AddXY(i, food.datalar[i + (j * 18)]); // i değeri X eksenini, rastgele değeri ise Y eksenini gösterir.
               
                }

            }
        }


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Food cizilecekFood = new Food(food.foodName);

            float toplam = 0;
            int kacTaneFoodVar = food.datalar.Count / 18;
            for (int i = 0; i < 18; i++)
            {

                for(int j = 0; j < kacTaneFoodVar; j++)
                {

                    toplam += float.Parse( food.datalar[i + (j * 18)].ToString() );
                    
                }

                cizilecekFood.datalar.Add(toplam/kacTaneFoodVar);

            }


                string seriesName = $"{food.foodName}";
                grafik.Series.Add(new Series(seriesName));
                grafik.Series[seriesName].ChartType = SeriesChartType.Spline;
                grafik.Series[seriesName].BorderWidth = 5;
                grafik.Series[seriesName].Color = Color.White;

            Console.WriteLine("s:" + cizilecekFood.datalar.Count);
                for (int i = 0; i < cizilecekFood.datalar.Count; i++)
                {
                    grafik.Series[seriesName].Points.AddXY(i, food.datalar[i]); // i değeri X eksenini, rastgele değeri ise Y eksenini gösterir.
                }

            ortalamasiBtn.Enabled = false;


        }
    }
}
