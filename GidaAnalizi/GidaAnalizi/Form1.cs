using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GidaAnalizi
{
    public partial class Form1 : Form
    {

        private SerialPort ComPort;

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;


            //threadlar içerisindeyken birbiriliyle iletişim kursunlar diye bunu false yapıyorum (bu kodu internetten buldum)
            CheckForIllegalCrossThreadCalls = false;


            //başlangıçta  Save Data ve Get Reference Butonlarını pasif hale getiriyorum
            getRefBtn.Enabled = false;
            dataSaveBtn.Enabled = false;

            portlariGuncelle();


            //grafigin ayarlarini yapiyorum
            grafik.Titles.Add("Food Analyze");
            var chart = grafik.ChartAreas[0];
            chart.AxisX.Minimum = 1;
            chart.AxisX.Maximum = 18; // x ekseninin sınırları belirlendi.
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 100; // y ekseninin sınırları belirlendi.
            chart.AxisY.Interval = 10; // y ekseninin araligi belirlendi.
            grafik.Series["D1"].Color = Color.Red;


            /*bu kısım test için var bu kısımlar silinecek
             -------------------------------------------*/

            var data = "1\n2\n3\n4\n5\n";

            Console.WriteLine(data);

            var formatliData = data.Split('\n');
            var orginData = "";
            for (var i = 0; i < formatliData.Length; i++)
            {
                orginData += formatliData[i];
                Console.WriteLine(Int32.Parse(orginData) + 88888);

            }
            Console.WriteLine(orginData);
            /*--------------------------------------------*/

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        //Connect butonuna basildiginda calisan yer
        private void connectBtn_Click(object sender, EventArgs e)
        {
            //hatalari bu değişken sayesinde takip edicem
            bool hataVarMi = false;

            //seçilen bir port var mı diye kontrol ediyorum
            if (comboBoxDevice.SelectedIndex != -1)
            {

                //portumu oluşturuyorum
                ComPort = new SerialPort(comboBoxDevice.Text, 9600, Parity.None, 8, StopBits.One);

                try
                {

                    //data gelirse eğer SerialPortDataReceived fonksiyonu çalışacak
                    ComPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived); ;

                    //portu açıyorum
                    ComPort.Open();

                    //diğer butonlarımı aktif hale getiriyorum
                    getRefBtn.Enabled = false;
                    dataSaveBtn.Enabled = true;

                }//hatalarimi kontrol ediyorum
                catch (UnauthorizedAccessException) { hataVarMi = true; }
                catch (System.IO.IOException) { hataVarMi = true; }
                catch (ArgumentException) { hataVarMi = true; }

                //kullaniciyi hataya karşı bilgilendiriyorum
                if (hataVarMi)
                {
                    MessageBox.Show("bağlandığınız portu kontrol ediniz..", "Porta bağlanmakta sorun yaşandı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }

            //eğer bağlantı gerçekleştiyse disconnect olmadan bağlanmasın diye connect butonunu pasif yapıyorum
            if (comboBoxDevice.SelectedIndex != -1 && ComPort.IsOpen)
            {
                connectBtn.Enabled = false;
            }

        }

        //Get Reference butonuna tıklandığında çalışan fonksiyon
        private void getRefBtn_Click(object sender, EventArgs e)
        {
            //Bu fonksiyonun amacı cihaza S komutunu göndermek. cihaz ise S kodunu aldığında cevap olarak
            // 18 satır 1 sutündan oluşan bir veri kümesi gönderecek.
            //bu datayı port_DataReceived fonksiyonunda alıcam

            Console.WriteLine();
            //cihaza komutu gönderiyorum
            ComPort.Write("S");
        }

        //cihazdan bir data geldiğinde burası çalışıyor
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (SerialPort)sender;

            if (serialPort.IsOpen)
            {

                //cihazdan gelen datayi aliyorum
                var data = serialPort.ReadLine();

                //eğer get referance butonuna tıklanırak 'S' komutu gönderildiyse buraya girecek
                if (refreshBtn.Enabled == true)
                {

                    //datayi cizdirmek icin bir diziye atiyorum
                    var cizilecekData = data.Split('\n');

                    //grafigi cizdirmek icin fonksiyona gonderiyorum
                    grafigeCiz(cizilecekData);

                    //dataya başlık ekliyorum
                    data = " referans verisi: \n" + data;

                    //datayi kaydediyorum
                    dosyayaKaydet(data);

                    //get referance butonunu pasif yapıyorum
                    refreshBtn.Enabled = false;
                    analyzeBtn.Enabled = true;

                }//eğer analyze butonuna tıklanılarak 'S' komutu gönderilirse burası çalışacak
                else if (analyzeBtn.Enabled == true)
                {

                }




            }
        }


        public void grafigeCiz(String[] cizilecekData)
        {
            foreach (var series in grafik.Series)
            {
                series.Points.Clear();
            }

            for (int i = 1; i <= 18; i++)
            {
                grafik.Series["D1"].Points.AddXY(i, Int32.Parse(cizilecekData[i])); // i değeri X eksenini, rastgele değeri ise Y eksenini gösterir.
                                                                                    // döngü calıstıgı sürece dataları okuyup rastgele yerine yazmamız gerekiyor.
            }


        }





        private void refreshBtn_Click(object sender, EventArgs e)
        {

            portlariGuncelle();

        }


        //disconnect butonuna tiklandiginda burasi calisiyor
        private void disconnectBtn_Click(object sender, EventArgs e)
        {

            //objeyi kontrol ediyorum
            if (ComPort != null)
            {
                //eğer null değilse portu kapatiyorum
                ComPort.Close();
                connectBtn.Enabled = true;

                //butonlarımı pasif hale getiriyorum
                getRefBtn.Enabled = false;
                dataSaveBtn.Enabled = false;
            }

        }


        private void portlariGuncelle()
        {
            //şuanki portları temizliyorum
            comboBoxDevice.Items.Clear();

            //pc ye bağlanan portları diziye atıyorum
            string[] ports = SerialPort.GetPortNames();

            //portları dönüp comboboca ekliyorum
            foreach (string port in ports)
            {
                comboBoxDevice.Items.Add(port);
            }
        }


        string kaydedilecekDosyaPathi = "";
        //Save data butonuna tıklandığında çalışacak olan fonksiyon
        private void dataSaveBtn_Click(object sender, EventArgs e)
        {
            //Save Data butonuna tıklandığında kaydedilecek olan verinin yeri ve adı belirlenmeli
            //burda bir file manager açılıp dosayanın nereye kaydedileceği ve adının ne olacağı belirleniliyor

            OpenFileDialog folderBrowser = new OpenFileDialog();

            //gösterilecek olan dosyaları gösteriyorum
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;



            //dosyayı açıyorum eğer bir path seçilirse if bloğunun içine girecek
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {


                //kaydedilecek olan dosyanin adini ve nereye kaydedileceği bilgilerini alıyorum
                kaydedilecekDosyaPathi = folderBrowser.FileName + ".txt";
                getRefBtn.Enabled = true;


            }
            else
            {
                getRefBtn.Enabled = false;
                kaydedilecekDosyaPathi = "";

            }




        }

        public void dosyayaKaydet(string kaydedilecekVeri)
        {

            using (StreamWriter sw = File.AppendText(kaydedilecekDosyaPathi))
            {
                sw.WriteLine(kaydedilecekVeri);
            }
        }

        private void analyzeBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
