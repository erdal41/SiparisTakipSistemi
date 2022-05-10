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

namespace SiparisTakipSistemi.Kullanici
{
    public partial class SifreDogrula : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public SifreDogrula()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        public string secilenKullaniciAdi;
        public string girilenSifre1;
        public string girilenSifre2;

        private void Txt_Sifre_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txt_Sifre.Properties.PasswordChar = '\0';
        }

        private void Txt_Sifre_Properties_MouseUp(object sender, MouseEventArgs e)
        {
            txt_Sifre.Properties.PasswordChar = '✺';
        }

        private void Btn_Onayla_Click(object sender, EventArgs e)
        {
            if (txt_Sifre.Text == "" || txt_Sifre.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_Sifre, "Eski şifrenizi giriniz.");
            }
            else
            {
                SifreTanimla sifreTanimla = (SifreTanimla)Application.OpenForms["SifreTanimla"];
                YetkiTanimla yetkiTanimla = (YetkiTanimla)Application.OpenForms["YetkiTanimla"];
                if (Application.OpenForms["SifreTanimla"] != null)
                {
                    var sifreKontrol = (from k in db.Kullanicilar
                                        where k.KullaniciAdi == secilenKullaniciAdi && k.Sifre == txt_Sifre.Text
                                        select k).FirstOrDefault();
                    if (sifreKontrol != null)
                    {
                        var kullanici = (from k in db.Kullanicilar
                                         where k.KullaniciAdi == secilenKullaniciAdi
                                         select k).FirstOrDefault();
                        if (kullanici != null && girilenSifre1 == girilenSifre2)
                        {
                            kullanici.Sifre = girilenSifre1;
                            db.SaveChanges();
                            MessageBox.Show("Şifre değiştirme başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı Adı yanlış, Lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Yanlış şifre, lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }                
                else if (Application.OpenForms["YetkiTanimla"] != null)
                {

                }
            }
        }

        private void Txt_Sifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_Sifre.Text == "" || txt_Sifre.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_Sifre, "Eski şifrenizi giriniz.");
                }
                else
                {
                    var sifreKontrol = (from k in db.Kullanicilar
                                        where k.KullaniciAdi == secilenKullaniciAdi && k.Sifre == txt_Sifre.Text
                                        select k).FirstOrDefault();
                    if (sifreKontrol != null)
                    {
                        SifreTanimla sifreTanimla = new SifreTanimla();
                        var kullanici = (from k in db.Kullanicilar
                                         where k.KullaniciAdi == secilenKullaniciAdi
                                         select k).FirstOrDefault();
                        if (kullanici != null && girilenSifre1 == girilenSifre2)
                        {
                            kullanici.Sifre = girilenSifre1;
                            db.SaveChanges();
                            MessageBox.Show("Şifre değiştirme başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı Adı yanlış, Lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Yanlış şifre, lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}