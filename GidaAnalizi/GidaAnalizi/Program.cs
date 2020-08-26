using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GidaAnalizi
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Console.WriteLine("?");
                Application.Run(new Form1());

            }
            catch (Exception e)
            {
                Console.WriteLine("HATA: "+e.Message);
            }
        }
    }
}
