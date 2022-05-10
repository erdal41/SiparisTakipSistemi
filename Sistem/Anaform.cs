using DevExpress.Utils;
using DevExpress.XtraBars;
using SiparisTakipSistemi.Bilesen;
using SiparisTakipSistemi.Kullanici;
using SiparisTakipSistemi.KutuProfil;
using SiparisTakipSistemi.Maliyet;
using SiparisTakipSistemi.Sac;
using SiparisTakipSistemi.Urun;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SiparisTakipSistemi.Sistem
{
    public partial class Anaform : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public Anaform()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        private void Bar_SacIslemleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            SacTanimla sacTanimla = (SacTanimla)Application.OpenForms["SacTanimla"];
            if (Application.OpenForms["SacTanimla"] == null)
            {
                SacTanimla yenipencere = new SacTanimla();
                yenipencere.Show();
            }
            else
            {
                sacTanimla.BringToFront();
            }
        }

        private void Bar_BilesenIslemleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            BilesenTanimla bilesenTanimla = (BilesenTanimla)Application.OpenForms["BilesenTanimla"];
            if (Application.OpenForms["BilesenTanimla"] == null)
            {
                BilesenTanimla yenipencere = new BilesenTanimla();
                yenipencere.Show();
            }
            else
            {
                bilesenTanimla.BringToFront();
            }
        }

        private void Bar_KutuProfilIslemleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            KutuProfilTanimla kutuProfilTanimla = (KutuProfilTanimla)Application.OpenForms["KutuProfilTanimla"];
            if (Application.OpenForms["KutuProfilTanimla"] == null)
            {
                KutuProfilTanimla yenipencere = new KutuProfilTanimla();
                yenipencere.Show();
            }
            else
            {
                kutuProfilTanimla.BringToFront();
            }
        }

        private void Bar_EkBilesenIslemleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            EkBilesenTanimla ekBilesenTanimla = (EkBilesenTanimla)Application.OpenForms["EkBilesenTanimla"];
            if (Application.OpenForms["EkBilesenTanimla"] == null)
            {
                EkBilesenTanimla yenipencere = new EkBilesenTanimla();
                yenipencere.Show();
            }
            else
            {
                ekBilesenTanimla.BringToFront();
            }
        }

        private void Bar_UrunIslemleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            UrunTanimla urunTanimla = (UrunTanimla)Application.OpenForms["UrunTanimla"];
            if (Application.OpenForms["UrunTanimla"] == null)
            {
                UrunTanimla yenipencere = new UrunTanimla();
                yenipencere.Show();
            }
            else
            {
                urunTanimla.BringToFront();
            }
        }

        private void Bar_UrunListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            UrunListesi urunListesi = (UrunListesi)Application.OpenForms["UrunListesi"];
            if (Application.OpenForms["UrunListesi"] == null)
            {
                UrunListesi yenipencere = new UrunListesi();
                yenipencere.Show();
            }
            else
            {
                urunListesi.BringToFront();
            }
        }

        private void Bar_MaliyetIslemleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            MaliyetTanimla maliyetTanimla = (MaliyetTanimla)Application.OpenForms["MaliyetTanimla"];
            if (Application.OpenForms["MaliyetTanimla"] == null)
            {
                MaliyetTanimla yenipencere = new MaliyetTanimla();
                yenipencere.Show();
            }
            else
            {
                maliyetTanimla.BringToFront();
            }
        }

        private void Bar_MaliyetListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            MaliyetListesi maliyetListesi = (MaliyetListesi)Application.OpenForms["MaliyetListesi"];
            if (Application.OpenForms["MaliyetListesi"] == null)
            {
                MaliyetListesi yenipencere = new MaliyetListesi();
                yenipencere.Show();
            }
            else
            {
                maliyetListesi.BringToFront();
            }
        }

        private void Bar_Cikis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Bar_SunucuDogrula_ItemClick(object sender, ItemClickEventArgs e)
        {
            BaglantiDogrulama baglantiDogrulama = (BaglantiDogrulama)Application.OpenForms["BaglantiDogrulama"];
            if (Application.OpenForms["BaglantiDogrulama"] == null)
            {
                BaglantiDogrulama yenipencere = new BaglantiDogrulama();
                yenipencere.Show();
            }
            else
            {
                baglantiDogrulama.BringToFront();
            }
        }

        private void Anaform_Load(object sender, EventArgs e)
        {
            //var kullaniciKontrol = (from fy in db.FormYetkileri
            //                       join k in db.Kullanicilar
            //                       on fy.KullaniciID equals k.KullaniciID
            //                       where fy.KullaniciID == KullaniciBilgileri.KaydedenID && fy.Ac == false
            //                        select fy).FirstOrDefault();
            //if (kullaniciKontrol != null)
            //{

            //    foreach (var satir in db.FormYetkileri.ToList())
            //    {
            //        if (satir.Ac == false)
            //        {
            //            foreach (BarItem menuItem in bar_MainMenu.Items)
            //            {
            //                if (menuItem.Caption == satir.FormAdi)
            //                {
            //                    menuItem.Enabled = false;
            //                }                            
            //            }
            //        }
            //    }
            //}
        }

        private void Anaform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Bar_KullaniciIslemleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            KullaniciTanimla kullaniciTanimla = (KullaniciTanimla)Application.OpenForms["KullaniciTanimla"];
            if (Application.OpenForms["KullaniciTanimla"] == null)
            {
                KullaniciTanimla yenipencere = new KullaniciTanimla();
                yenipencere.Show();
            }
            else
            {
                kullaniciTanimla.BringToFront();
            }
        }

        private void Bar_YetkiTanimla_ItemClick(object sender, ItemClickEventArgs e)
        {
            YetkiTanimla yetkiTanimla = (YetkiTanimla)Application.OpenForms["YetkiTanimla"];
            if (Application.OpenForms["YetkiTanimla"] == null)
            {
                YetkiTanimla yenipencere = new YetkiTanimla();
                yenipencere.Show();
            }
            else
            {
                yetkiTanimla.BringToFront();
            }
        }

        private void Bar_SifreDegistirme_ItemClick(object sender, ItemClickEventArgs e)
        {
            SifreTanimla sifreTanimla = (SifreTanimla)Application.OpenForms["SifreTanimla"];
            if (Application.OpenForms["SifreTanimla"] == null)
            {
                SifreTanimla yenipencere = new SifreTanimla();
                yenipencere.Show();
            }
            else
            {
                sifreTanimla.BringToFront();
            }
        }

        private void Bar_EkIslemMaliyetleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            EkIslemMaliyetiTanimla ekIslemMaliyetiTanimla = (EkIslemMaliyetiTanimla)Application.OpenForms["EkIslemMaliyetiTanimla"];
            if (Application.OpenForms["EkIslemMaliyetiTanimla"] == null)
            {
                EkIslemMaliyetiTanimla yenipencere = new EkIslemMaliyetiTanimla();
                yenipencere.Show();
            }
            else
            {
                ekIslemMaliyetiTanimla.BringToFront();
            }
        }

        private void Bar_EkMaliyetIslemleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            EkMaliyetTanimla ekMaliyetTanimla = (EkMaliyetTanimla)Application.OpenForms["EkMaliyetTanimla"];
            if (Application.OpenForms["EkMaliyetTanimla"] == null)
            {
                EkMaliyetTanimla yenipencere = new EkMaliyetTanimla();
                yenipencere.Show();
            }
            else
            {
                ekMaliyetTanimla.BringToFront();
            }
        }
    }
}