using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;

namespace SiparisTakipSistemi.Sistem
{
    public partial class SifreDogrulama : DevExpress.XtraEditors.XtraForm
    {
        public SifreDogrulama()
        {
            InitializeComponent();
        }

        string sifre = "12345";

        [Obsolete]
        private void Btn_SifreDogrula_Click(object sender, EventArgs e)
        {
            if (txt_Sifre.Text == sifre)
            {
                string bilgisayarAdi = Dns.GetHostName();
                string ipAdresi = Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString();
                BaglantiDogrulama baglantiDogrulama = (BaglantiDogrulama)Application.OpenForms["BaglantiDogrulama"];
                if (Application.OpenForms["BaglantiDogrulama"] != null)
                {
                    baglantiDogrulama.txt_SunucuAdi.Text = bilgisayarAdi;
                    baglantiDogrulama.txt_SunucuAdresi.Text = ipAdresi;
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Şifre hatalı, kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SifreDogrulama_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(234, 116);
        }
    }
}