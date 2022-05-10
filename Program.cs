using SiparisTakipSistemi.Kullanici;
using SiparisTakipSistemi.Sistem;
using System;
using System.Windows.Forms;

namespace SiparisTakipSistemi
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
            Application.Run(new KullaniciGirisi());
        }
    }
}
