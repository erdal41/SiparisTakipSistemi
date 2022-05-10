using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace SiparisTakipSistemi.Sistem
{
    public partial class BaglantiDogrulama : DevExpress.XtraEditors.XtraForm
    {
        public BaglantiDogrulama()
        {
            InitializeComponent();
        }

        private void Btn_Kaydet_Click(object sender, EventArgs e)
        {
            string connectionString1 = string.Format(@"data source={0};initial catalog=SiparisTakip;persist security info=True;user id=sa;password=Erdal4157+;multipleactiveresultsets=True;application name=EntityFramework", txt_SunucuAdresi.Text);
            string connectionString2 = string.Format(@"metadata=res://*/SiparisTakip.csdl|res://*/SiparisTakip.ssdl|res://*/SiparisTakip.msl;provider=System.Data.SqlClient;provider connection string= ""data source={0};initial catalog=SiparisTakip;persist security info=True;user id=sa;password=Erdal4157+;MultipleActiveResultSets=True;App=EntityFramework""", txt_SunucuAdresi.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString1);
                if (helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("SiparisTakipEntities", connectionString2);

                    MessageBox.Show("Yeni bağlantı oluşturuldu. Sistem yeniden başlayacak.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Bağlantı başarısız. Sistem yöneticisi ile iletişime geçiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Sunucu Adresi yanlış, lütfen kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Yenile_Click(object sender, EventArgs e)
        {
            SifreDogrulama sifreDogrulama = (SifreDogrulama)Application.OpenForms["SifreDogrulama"];
            if (Application.OpenForms["SifreDogrulama"] == null)
            {
                SifreDogrulama yenipencere = new SifreDogrulama();
                yenipencere.ShowDialog();
            }
            else
            {
                sifreDogrulama.BringToFront();
            }
        }         
    }
}