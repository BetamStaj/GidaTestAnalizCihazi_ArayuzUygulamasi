using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
            grafik.Titles[0].ForeColor = Color.White;
            var chart = grafik.ChartAreas[0];
            grafik.ChartAreas[0].AxisX.LineColor = Color.White;
            grafik.ChartAreas[0].AxisY.LineColor = Color.White;
            grafik.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            grafik.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            grafik.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.White;
            grafik.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.White;
            grafik.ChartAreas[0].BackColor = Color.FromArgb(41, 53, 65);
            grafik.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(41,53,65);
            grafik.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(41, 53, 65);
            chart.AxisX.Minimum = 1;
            chart.AxisX.Maximum = 18; // x ekseninin sınırları belirlendi.
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 1500; // y ekseninin sınırları belirlendi.
            chart.AxisY.Interval = 100; // y ekseninin araligi belirlendi.
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
            baglantiyiKes();
            Close();
            Application.Exit();
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

        //uyarı vermek için kullandığım fonksiyon
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
            ComPort.Write("s");
        }

        //foodType bilgisini tutan değişken
        string foodType = "";
        //analyze butonuna tıklandığında çalışacak olan yer
        private void analyzeBtn_Click_1(object sender, EventArgs e)
        {
            analyzeButonunuPasifYap();
            //eğer food type bilgisi seçilmemişse kullanıcıya bilgi veriyorum ve işlem yapmıyorum
            if(foodTypeComboBox.Text == "" && foodTypeInput.Text == "")
            {
                uyariVer("food type girilmedi","lütfen food type ını giriniz!");
                analyzeButonunuAktifYap();
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

                //cihaza 's' komutunu gönderiyorum
                ComPort.Write("s");

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

                //cihazdan gelen datayi aliyorum
                /*
                do
                {

                    asciCode = serialPort.ReadByte();
                    data += (char)asciCode;


                } while ((char)asciCode != '*');
                */
                for(int i = 0; i < 18; i++)
                {
                    data += serialPort.ReadLine() + "\n";
                }

                if (data.Contains("Pekspec"))
                {
                    Console.WriteLine("heyyyyhhhoooo");
                    int i = data.IndexOf('\r');
                    data = data.Remove(0,i+1);
                    data += serialPort.ReadLine();
                }


                Console.WriteLine(data);
                //datayi cizdirmek icin bir diziye atiyorum
                string[] cizilecekData = data.Split('\r');
                //string[] cizilecekData = data.Split('\n');


                for (int i = 0; i < cizilecekData.Length; i++)
                {

                    cizilecekData[i] = cizilecekData[i].Replace("\n", "").Replace("\r", "");

                }

                for(int i = 0; i < cizilecekData.Length; i++)
                {
                    Console.WriteLine(cizilecekData[i] + " - ");
                }


                //grafigi cizdirmek icin fonksiyona gonderiyorum
                grafigeCiz(cizilecekData);
                analyzeButonunuAktifYap();



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

        public void analyzeButonunuAktifYap()
        {
            analyzeBtn.Enabled = true;
        }
        public void analyzeButonunuPasifYap() {
            analyzeBtn.Enabled = false;
        }


        int sayac = 0;
        public void grafigeCiz(String[] cizilecekData)
        {

            Console.WriteLine("foodType: " + foodType);

            if (string.IsNullOrEmpty(foodType))
            {
                foodType = "Referans Verisi";
            }
            grafik.Series.Clear();

            string seriesName = $"{foodType}";
            Console.WriteLine("grafik.Series.IsUniqueName(foodType): " + grafik.Series.IsUniqueName(foodType));
            if (grafik.Series.IsUniqueName(foodType))
            {
                grafik.Series.Add(new Series(seriesName));
            }
            grafik.Series[seriesName].ChartType = SeriesChartType.Spline;
            grafik.Series[seriesName].BorderWidth = 1;
            grafik.Series[seriesName].Color = Color.Red;


            //    /*
            //    for(int i = 0; i < grafik.Series.Count; i++)
            //    {

            //        grafik.Series[i].Points.Clear();

            //    }
            //    */

            //    /*
            //    //grafigi temizliyorum

            /*
            foreach (var series in grafik.Series)
            {
                series.Points.Clear();
            }*/


            floatDiziyeDonustur(cizilecekData);
            Console.WriteLine("aralarindaki en buyuk data: " + enBuyuk);

            int aralik = (int)enBuyuk / 10;
            Console.WriteLine("yuvarlanmis hali: " + aralik);

            while (aralik%10 != 0)
            {
                aralik += 1;
            }

            Console.WriteLine("yuvarlanmis hali: " + aralik);
            grafik.ChartAreas[0].AxisY.Interval = aralik;

            grafik.ChartAreas[0].AxisY.Maximum = enBuyuk + aralik;



            System.Threading.Thread.Sleep(50);

            // grafigiTemizle();
            foreach (var series in grafik.Series)
            {
                series.Points.Clear();
            }
            

           System.Threading.Thread.Sleep(50);




            //chart.AxisY.Maximum = enBuyuk; // y ekseninin sınırları belirlendi.
           



            //    //Grafiğe çizdirirken datalarımı bir objeye atıyorum

            //    //eğer foodType boş ise bu demek oluyor ki GetReferans butonuna tıklandı ve referans verileri ekrana basılıyor
            if (foodType.Equals(""))
            {
                //foodType ını referansVerisi olarak giriyorum
                foodType = "referansVerisi";
            }

        //    //artık foodType'ın her türlü bir değere sahip
        //    //foodType'ına göre foods araylistinden Food objesini getiriyorum eğer o foodType adında bir obje yok ise
        //    //yeni bir Food objesi oluşturuyorum
            Food food = foundFood(foodType);

        //    //grafiği ekrana çizdiriyorum
            for (int i = 0; i < 18; i++)
            {
                //food objesinin datasına dataları ekliyorum
                food.datalar.Add(float.Parse(cizilecekData[i]));
                //grafiğe değeri çizdiriyorum
                //grafik.Series[sayac+""].Points.AddXY(i, float.Parse(cizilecekData[i])); // i değeri X eksenini, rastgele değeri ise Y eksenini gösterir.

                 grafik.Series[foodType].Points.AddXY(i, float.Parse(cizilecekData[i])); // i değeri X eksenini, rastgele değeri ise Y eksenini gösterir.
            }

            


        }

        float enBuyuk = 0;
        public float[] floatDiziyeDonustur(String[] dizi)
        {
            float[] donusturulmusDizi = new float[dizi.Length];
            enBuyuk = float.Parse(dizi[0]);
            for(int i = 0; i < dizi.Length-1; i++)
            {
                Console.WriteLine(": " + dizi[i].ToString());
                if (string.IsNullOrEmpty(dizi[i].ToString()))
                {
                    break;
                }
                donusturulmusDizi[i] = float.Parse(dizi[i].ToString());
                if(enBuyuk < donusturulmusDizi[i])
                {
                    enBuyuk = donusturulmusDizi[i];
                }
            }


            return donusturulmusDizi;
        }


        //aranan ada gore arraylisteki foodu buluyorum
        public Food foundFood(string foodName)
        {
            //foods araylistini dönüyorum
            foreach (Food food in foods)
            {
                
                //foodName lerine göre bir arama yapıyorum
                if (food.foodName.Equals(foodName))
                {
                    //o foodName ait objeyi döndürüyorum
                    return food;
                }
            }

            //eğer bu isme sahip bir food yoksa yeni food oluşturup onu dönüyorum
            Food newFood = new Food(foodName);
            //Food objelerimi tutan foods araylistime yeni Food objemi ekliyorum
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

            baglantiyiKes();

        }

        private void baglantiyiKes()
        {
            //objeyi kontrol ediyorum
            if (ComPort != null)
            {
                //eğer null değilse portu kapatiyorum
                ComPort.Close();
                connectBtn.Enabled = true;

                //butonlarımı pasif hale getiriyorum
                analyzeBtn.Enabled = false;
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

        //string olarak gönderdiğim yazıları dosyaya kaydediyor
        public void dosyayaKaydet(string kaydedilecekVeri)
        {

            using (StreamWriter sw = File.AppendText(kaydedilecekDosyaPathi))
            {
                sw.WriteLine(kaydedilecekVeri);
            }
        }

        private void plotexportBtn_Click(object sender, EventArgs e)
        {
            //gösterilecek olan foodType i alıyorum
            string foodName = foodTypeComboBox.Text;

            //Food objelerimi geziyorum
            foreach (Food food in foods)
            {

                //foodName ine göre bir arama yapıyorum
                if (food.foodName.Equals(foodName))
                {
                    Food.enBuyukData = enBuyuk;
                    //açacağım 2. ekrana Food objemi gönderiyorum
                    Form2 f2 = new Form2(food);
                    f2.ShowDialog();
                    return;
                }

            }

            //eğer Food objesi bulunmadıysa demek ki comboboxtaki foodType ı hatalı
            uyariVer("foodType hatali","comboboxta seçtiğiniz foodType hatali lütfen geçerli foodType ını giriniz!!");


        }

        //bağlantı hariç herşeyi sıfırlıyorum
        private void newmsrmntBtn_Click(object sender, EventArgs e)
        {

            //bir onay ekrani gosteriyorum resetlemeye emin misiniz diye?
            DialogResult result = MessageBox.Show("Baglanti haric her sey sifirlansin mi?", "Plot And Export", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //eğer onaylamazsa işlemi yapmadan bitiriyorum
            if (!result.Equals(DialogResult.OK))
            {
                return;
            }

            //eğer onaylamışsa aşağıdaki kodlar çalışacak

            //foodları tutan dizimi sıfırlorum
            foods = null;

            //grafigi temizliyorum
            foreach (var series in grafik.Series)
            {
                series.Points.Clear();
            }

            //saveData butonunda seçilen dosyanın kaydedileceği pathi resetliyorum
            kaydedilecekDosyaPathi = "";

            //bütün butonları pasif yapıyorum
            butonlariPasifYap();
            disconnectBtn.Enabled = true;
            dataSaveBtn.Enabled = true;

            //food Type ın girildiği inputu sıfırlıyorum
            foodTypeInput.Text = "";
            //comboboxtaki itemleri siliyorum
            foodTypeComboBox.Items.Clear();
            //comboboxun textini resetliyorum
            foodTypeComboBox.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foodType = "halil";
            ComPort.Write("s");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            grafik.Series.Clear();
        }
        private void grafigiTemizle()
        {
            grafik.Series.Clear();
        }
    }
}
