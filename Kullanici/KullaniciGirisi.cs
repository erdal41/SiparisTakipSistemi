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
using SiparisTakipSistemi.Sistem;
using System.Threading;
using System.Data.Entity.Core.EntityClient;
using DevExpress.XtraBars;

namespace SiparisTakipSistemi.Kullanici
{
    public partial class KullaniciGirisi : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public KullaniciGirisi()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        Thread thread1;

        public void islem()
        {
            Loading loading = new Loading();
            loading.ShowDialog();
        }
        
        private void KullaniciGirisi_Load(object sender, EventArgs e)
        {
            Loading loading = new Loading();
            thread1 = new Thread(new ThreadStart(islem));
            thread1.Start();
            EntityConnection conn = new EntityConnection("name=SiparisTakipEntities");
            this.MinimumSize = new Size(391, 294);
            this.KeyPreview = true;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                thread1.Abort();
                if (Properties.Settings.Default.Durum == true)
                {
                    txt_KullaniciAdi.Text = Properties.Settings.Default.KullaniciAdi;
                    chk_BeniHatirla.Checked = Properties.Settings.Default.Durum;
                }
            }
            catch
            {
                thread1.Abort();
                MessageBox.Show("Sunucu Adresi yanlış, kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BaglantiDogrulama baglantiDogrulama = new BaglantiDogrulama();
                baglantiDogrulama.ShowDialog();
            }
        }

        private void Btn_Giris_Click(object sender, EventArgs e)
        {
            if (txt_KullaniciAdi.Text == "" || txt_KullaniciAdi.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_KullaniciAdi, "Kullanıcı adınızı giriniz.");
            }
            else if (txt_Sifre.Text == "" || txt_Sifre.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_Sifre, "Şifrenizi giriniz.");
            }
            else
            {
                var giris = (from k in db.Kullanicilar
                             where k.KullaniciAdi == txt_KullaniciAdi.Text && k.Sifre == txt_Sifre.Text
                             select new
                             {
                                 k.KullaniciID,
                                 k.KullaniciAdi,
                                 k.Sifre,
                                 k.KullaniciAdSoyad,
                             }).FirstOrDefault();

                if (giris == null)
                {
                    MessageBox.Show("Kullanıcı adı ya da parola hatalı, lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = txt_KullaniciAdi;
                }
                else
                {                    
                    if (chk_BeniHatirla.Checked)
                    {
                        Properties.Settings.Default.KullaniciAdi = txt_KullaniciAdi.Text;
                        Properties.Settings.Default.Durum = true;
                        Properties.Settings.Default.Save();

                        KullaniciSonGirisTarihi kullaniciSonGirisTarihi = new KullaniciSonGirisTarihi();
                        kullaniciSonGirisTarihi.KullaniciID = giris.KullaniciID;
                        kullaniciSonGirisTarihi.SonGirisTarihi = DateTime.Now;
                        db.KullaniciSonGirisTarihi.Add(kullaniciSonGirisTarihi);
                        //db.SaveChanges();
                        KullaniciBilgileri.KaydedenID = giris.KullaniciID;
                        KullaniciBilgileri.KaydedenAdi = giris.KullaniciAdSoyad;
                        KullaniciBilgileri.KullaniciAdi = giris.KullaniciAdi;
                        Anaform anaform = new Anaform();
                        anaform.Show();
                        anaform.bar_KullaniciAdSoyad.Caption = giris.KullaniciAdSoyad;
                        anaform.bar_SonGirilenTarih.Caption = DateTime.Now.ToString();
                        anaform.bar_SonGirilenTarih.Caption = DateTime.Now.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString();
                    }
                    else
                    {
                        Properties.Settings.Default.KullaniciAdi = "";
                        Properties.Settings.Default.Durum = false;
                        Properties.Settings.Default.Save();

                        KullaniciSonGirisTarihi kullaniciSonGirisTarihi = new KullaniciSonGirisTarihi();
                        kullaniciSonGirisTarihi.KullaniciID = giris.KullaniciID;
                        kullaniciSonGirisTarihi.SonGirisTarihi = DateTime.Now;
                        db.KullaniciSonGirisTarihi.Add(kullaniciSonGirisTarihi);
                        //db.SaveChanges();
                        KullaniciBilgileri.KaydedenID = giris.KullaniciID;
                        KullaniciBilgileri.KaydedenAdi = giris.KullaniciAdSoyad;
                        KullaniciBilgileri.KullaniciAdi = giris.KullaniciAdi;
                        Anaform anaform = new Anaform();
                        anaform.Show();
                        anaform.bar_KullaniciAdSoyad.Caption = giris.KullaniciAdSoyad;
                        anaform.bar_SonGirilenTarih.Caption = DateTime.Now.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString();
                    }
                }
                this.Hide();
            }
        }
        

        private void Btn_Cikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Txt_KullaniciAdi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_Sifre_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void KullaniciGirisi_Shown(object sender, EventArgs e)
        {
            if(chk_BeniHatirla.Checked)
            {
                txt_Sifre.Focus();
            }
            else
            {
                txt_KullaniciAdi.Focus();
            }            
        }

        private void Txt_KullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = txt_Sifre;
            }
        }

        private void Txt_Sifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_KullaniciAdi.Text == "" || txt_KullaniciAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_KullaniciAdi, "Kullanıcı adınızı giriniz.");
                }
                else if (txt_Sifre.Text == "" || txt_Sifre.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_Sifre, "Şifrenizi giriniz.");
                }
                else
                {
                    var giris = (from k in db.Kullanicilar
                                 where k.KullaniciAdi == txt_KullaniciAdi.Text && k.Sifre == txt_Sifre.Text
                                 select new
                                 {
                                     k.KullaniciID,
                                     k.KullaniciAdi,
                                     k.Sifre,
                                     k.KullaniciAdSoyad,
                                 }).FirstOrDefault();

                    if (giris == null)
                    {
                        MessageBox.Show("Kullanıcı adı ya da parola hatalı, lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.ActiveControl = txt_KullaniciAdi;
                    }
                    else
                    {
                        if (chk_BeniHatirla.Checked)
                        {
                            Properties.Settings.Default.KullaniciAdi = txt_KullaniciAdi.Text;
                            Properties.Settings.Default.Durum = true;
                            Properties.Settings.Default.Save();

                            KullaniciSonGirisTarihi kullaniciSonGirisTarihi = new KullaniciSonGirisTarihi();
                            kullaniciSonGirisTarihi.KullaniciID = giris.KullaniciID;
                            kullaniciSonGirisTarihi.SonGirisTarihi = DateTime.Now;
                            db.KullaniciSonGirisTarihi.Add(kullaniciSonGirisTarihi);
                            //db.SaveChanges();
                            KullaniciBilgileri.KaydedenID = giris.KullaniciID;
                            KullaniciBilgileri.KaydedenAdi = giris.KullaniciAdSoyad;
                            KullaniciBilgileri.KullaniciAdi = giris.KullaniciAdi;
                            Anaform anaform = new Anaform();
                            anaform.Show();
                            anaform.bar_KullaniciAdSoyad.Caption = giris.KullaniciAdSoyad;
                            anaform.bar_SonGirilenTarih.Caption = DateTime.Now.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString();
                        }
                        else
                        {
                            Properties.Settings.Default.KullaniciAdi = "";
                            Properties.Settings.Default.Durum = false;
                            Properties.Settings.Default.Save();

                            KullaniciSonGirisTarihi kullaniciSonGirisTarihi = new KullaniciSonGirisTarihi();
                            kullaniciSonGirisTarihi.KullaniciID = giris.KullaniciID;
                            kullaniciSonGirisTarihi.SonGirisTarihi = DateTime.Now;
                            db.KullaniciSonGirisTarihi.Add(kullaniciSonGirisTarihi);
                            //db.SaveChanges();
                            KullaniciBilgileri.KaydedenID = giris.KullaniciID;
                            KullaniciBilgileri.KaydedenAdi = giris.KullaniciAdSoyad;
                            KullaniciBilgileri.KullaniciAdi = giris.KullaniciAdi;
                            Anaform anaform = new Anaform();
                            anaform.Show();
                            anaform.bar_KullaniciAdSoyad.Caption = giris.KullaniciAdSoyad;
                            anaform.bar_SonGirilenTarih.Caption = DateTime.Now.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString(); 
                        }
                        this.Hide();
                    }
                }
            }
        }

        private void KullaniciGirisi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.KeyCode == Keys.D)
            {
                BaglantiDogrulama baglantiDogrulama = (BaglantiDogrulama)Application.OpenForms["BaglantiDogrulama"];
                if (Application.OpenForms["BaglantiDogrulama"] == null)
                {
                    BaglantiDogrulama yenipencere = new BaglantiDogrulama();
                    yenipencere.ShowDialog();
                }
                else
                {
                    baglantiDogrulama.BringToFront();
                }
            }
        }

        private void Txt_Sifre_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txt_Sifre.Properties.PasswordChar = '\0';
        }

        private void Txt_Sifre_Properties_MouseUp(object sender, MouseEventArgs e)
        {
            txt_Sifre.Properties.PasswordChar = '✺';
        }

        private void Txt_KullaniciAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}