using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace GidaAnalizi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;

            //başlangıçta  Save Data ve Get Reference Butonlarını pasif hale getiriyorum
            getRefBtn.Enabled = false;
            dataSaveBtn.Enabled = false;

            //pc ye bağlanan portları diziye atıyorum
            string[] ports = SerialPort.GetPortNames();

            //portları dönüp comboboca ekliyorum
            foreach (string port in ports)
            {
                comboBoxDevice.Items.Add(port);
            }




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

        private void connectBtn_Click(object sender, EventArgs e)
        {

            //cihaza bağlanıyorum

        }

        private void comboBoxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxDevice.Items.Add("yeni eklendi");

        }

        private void refreshBtn_Click(object sender, EventArgs e)
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
    }
}
