using System;
using System.Collections;
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
        private ArrayList foods;


        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;


            //threadlar içerisindeyken birbiriliyle iletişim kursunlar diye bunu false yapıyorum (bu kodu internetten buldum)
            CheckForIllegalCrossThreadCalls = false;

            //başlangıçta  Butonları pasif hale getiriyorum
            butonlariPasifYap();

            //portlari tariyorum
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

        //başlangıçta  Butonları pasif hale getiriyorum
        private void butonlariPasifYap()
        {
            getRefBtn.Enabled = false;
            dataSaveBtn.Enabled = false;
            analyzeBtn.Enabled = false;
            plotexportBtn.Enabled = false;
            disconnectBtn.Enabled = false;
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
                    disconnectBtn.Enabled = true;
                    newmsrmntBtn.Enabled = true;

                }//hatalarimi kontrol ediyorum
                catch (UnauthorizedAccessException) { hataVarMi = true; }
                catch (System.IO.IOException) { hataVarMi = true; }
                catch (ArgumentException) { hataVarMi = true; }

                //kullaniciyi hataya karşı bilgilendiriyorum
                if (hataVarMi)
                {
                    uyariVer("Porta bağlanmakta sorun yaşandı", "bağlandığınız portu kontrol ediniz..");
                }

            }
            else
            {
                uyariVer("porta bağlanmadı","lütfen bir port seçiniz");
            }

            //eğer bağlantı gerçekleştiyse disconnect olmadan bağlanmasın diye connect butonunu pasif yapıyorum
            if (comboBoxDevice.SelectedIndex != -1 && ComPort.IsOpen)
            {
                connectBtn.Enabled = false;
            }

        }

        public void uyariVer(string baslik, string aciklama)
        {
            MessageBox.Show(aciklama, baslik, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //Get Reference butonuna tıklandığında çalışan fonksiyon
        private void getRefBtn_Click(object sender, EventArgs e)
        {
            //Bu fonksiyonun amacı cihaza S komutunu göndermek. cihaz ise S kodunu aldığında cevap olarak
            // 18 satır 1 sutündan oluşan bir veri kümesi gönderecek.
            //bu datayı port_DataReceived fonksiyonunda alıcam
            
            //cihaza komutu gönderiyorum
            ComPort.Write("S");
        }

        //foodType bilgisini tutan değişken
        string foodType = "";
        //analyze butonuna tıklandığında çalışacak olan yer
        private void analyzeBtn_Click_1(object sender, EventArgs e)
        {
            //eğer food type bilgisi seçilmemişse kullanıcıya bilgi veriyorum ve işlem yapmıyorum
            if(foodTypeComboBox.Text == "" && foodTypeInput.Text == "")
            {
                uyariVer("food type girilmedi","lütfen food type ını giriniz!");
            }
            else //food type ı input olarak mı yoksa comboboxtan mı seçtiğini bulmaya çalışıyorum
            {
                //eğer input olarak girmediyse food type ı  comboboxtan alıyorum
                if(foodTypeInput.Text == "")
                {
                    foodType = foodTypeComboBox.Text;

                }
                else//eğer input olarak girdiyse food type ı inputtan alıyorum ayrıca comboboxa ekliyorum
                {
                    foodType = foodTypeInput.Text;
                    foodTypeInput.Text = "";

                    if (!foodTypeComboBox.Items.Contains(foodType))
                    {
                        foodTypeComboBox.Items.Add(foodType);
                    }

                    foodTypeComboBox.Text = foodType;


                }

                //cihaza 'S' komutunu gönderiyorum
                ComPort.Write("S");

                //plotExport butonunu aktif hale getiriyorum
                plotexportBtn.Enabled = true;
            }           

        }

        //cihazdan bir data geldiğinde burası çalışıyor
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (SerialPort)sender;
           
            if (serialPort.IsOpen)
            {

                //gelen data:
                //1#2#3#4#5#6#7#8#9#10#11#12#13#14#15#16#17#18*
                //bu şekilde


                var data = "";
                int asciCode = 0;

                //cihazdan gelen datayi aliyorum
                do
                {

                    asciCode = serialPort.ReadByte();
                    data += (char)asciCode;


                } while ((char)asciCode != '*');

                //datanin sonunda yıldız karakteri var mı diye kontrol ediyorum
                if (data[data.Length-1] != '*')
                {
                    //uyarı verip işlemi bitiriyorum
                    uyariVer("data alinmadi","cihazdan data duzgun gelmedi!");
                    return;
                }

                //sondaki yıldızı çıkarıyorum
                data = data.Remove(data.Length-1);

                //datayi cizdirmek icin bir diziye atiyorum
                string[] cizilecekData = data.Split('#');

                foreach(string k in cizilecekData)
                {
                    Console.Write(k+" ");
                }
                Console.WriteLine("");
                


                //grafigi cizdirmek icin fonksiyona gonderiyorum
                grafigeCiz(cizilecekData);



                String dosyayaKaydedilecekData = "";
                string formatliData = "";
                for (int i = 0; i < cizilecekData.Length; i++)
                {
                    formatliData = formatliData + cizilecekData[i] + " ";
                }


                //eğer get referance butonuna tıklanırak 'S' komutu gönderildiyse buraya girecek
                if (getRefBtn.Enabled == true)
                {

                    //get referance butonuna tıklandığı için datayı dosyaya kaydetmeden önce başlık olarak referans verisi yazıyorum
                    dosyayaKaydedilecekData = "- - - referans verisi - - - \n" ;
                    
                    //formatli datayı dosyaya keydedilecek dataya ekliyorum
                    dosyayaKaydedilecekData += formatliData;



                    //get referance butonunu pasif yapıyorum analyze butonunu aktif hale getiriyorum
                    getRefBtn.Enabled = false;
                    analyzeBtn.Enabled = true;

                }//eğer analyze butonuna tıklanılarak 'S' komutu gönderilirse burası çalışacak
                else if (analyzeBtn.Enabled == true)
                {
                    //analyze butonuna tıklandığı için datayı dosyaya kaydetmeden önce food type ını başlık olarak ekliyorum
                    dosyayaKaydedilecekData = "- - - "+ foodType +" - - -\n";
                    
                    
                    //formatli datayı dosyaya keydedilecek dataya ekliyorum
                    dosyayaKaydedilecekData += formatliData; 

                }


                //datayi kaydediyorum
                dosyayaKaydet(dosyayaKaydedilecekData);




            }
        }


        public void grafigeCiz(String[] cizilecekData)
        {

            //grafigi temizliyorum
            foreach (var series in grafik.Series)
            {
                series.Points.Clear();
            }


            if (foodType.Equals(""))
            {
                foodType = "referansVerisi";
            }

            Food food = foundFood(foodType);
                

            for (int i = 0; i < 18; i++)
            {
                
                food.datalar.Add(Int64.Parse(cizilecekData[i]));   
                grafik.Series["D1"].Points.AddXY(i, Int64.Parse(cizilecekData[i])); // i değeri X eksenini, rastgele değeri ise Y eksenini gösterir.
                                                                                    // döngü calıstıgı sürece dataları okuyup rastgele yerine yazmamız gerekiyor.
            }

        }


        //aranan ada gore arraylisteki foodu buluyorum
        public Food foundFood(string foodName)
        {
            //foods araylistini dönüyorum
            foreach (Food food in foods)
            {
                
                if (food.foodName.Equals(foodName))
                {
                    return food;
                }
            }

            //eğer bu isme sahip bir food yoksa yeni food oluşturup onu dönüyorum
            Food newFood = new Food(foodName);
            foods.Add(newFood);
            
            return newFood;

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
                disconnectBtn.Enabled = false;
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

            //foodları tutan arraylistimi oluşturuyorum
            foods = new ArrayList();


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

        private void plotexportBtn_Click(object sender, EventArgs e)
        {

            string foodName = foodTypeComboBox.Text;

            foreach (Food food in foods)
            {

                if (food.foodName.Equals(foodName))
                {
                    Form2 f2 = new Form2(food);
                    f2.ShowDialog();
                    return;
                }

            }

            uyariVer("foodType hatali","comboboxta seçtiğiniz foodType hatali lütfen geçerli foodType ını giriniz!!");


        }

        //bağlantı hariç herşeyi sıfırlıyorum
        private void newmsrmntBtn_Click(object sender, EventArgs e)
        {
            //foodları tutan dizimi sıfırlorum
            foods = null;

            //grafigi temizliyorum
            foreach (var series in grafik.Series)
            {
                series.Points.Clear();
            }

            kaydedilecekDosyaPathi = "";

            butonlariPasifYap();
            disconnectBtn.Enabled = true;
            dataSaveBtn.Enabled = true;

            foodTypeInput.Text = "";

            foodTypeComboBox.Items.Clear();
            foodTypeComboBox.Text = "";

        }
    }
}
