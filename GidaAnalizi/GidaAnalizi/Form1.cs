using System;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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

        //cihazdan bir data geldiğinde burası çalışıyor
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (SerialPort)sender;

            if (serialPort.IsOpen) { 
            
            var data = serialPort.ReadExisting();
            

            Console.WriteLine(data);
            //şimdilik test amaçlı ekrana bastırıyorum
            textBox1.Text = data;

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

        string KaydedilecekDataninPathi;
        string kaydedilecekDosyaninAdi;
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
                kaydedilecekDosyaninAdi = folderBrowser.FileName + ".txt";
                KaydedilecekDataninPathi = Path.GetDirectoryName(folderBrowser.FileName);
                getRefBtn.Enabled = true;
            }
            else
            {
                getRefBtn.Enabled = false;
                kaydedilecekDosyaninAdi = "";
                KaydedilecekDataninPathi = "";
            }
        }
    }
}
