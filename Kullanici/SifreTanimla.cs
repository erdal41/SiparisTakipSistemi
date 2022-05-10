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
    public partial class SifreTanimla : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public SifreTanimla()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        private void SifreTanimla_Load(object sender, EventArgs e)
        {
            var yetkiKontrol = (from fy in db.FormYetkileri
                                join k in db.Kullanicilar
                                on fy.KullaniciID equals k.KullaniciID
                                where fy.KullaniciID == KullaniciBilgileri.KaydedenID && fy.Ac == false && fy.FormAdi == this.Text
                                select fy).FirstOrDefault();
            if (yetkiKontrol != null)
            {
                MessageBox.Show("Bu işlem için yetkiniz yoktur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void Btn_Kaydet_Click(object sender, EventArgs e)
        {
            var yetkiKontrol = (from fy in db.FormYetkileri
                                join k in db.Kullanicilar
                                on fy.KullaniciID equals k.KullaniciID
                                where fy.KullaniciID == KullaniciBilgileri.KaydedenID && fy.Ekle == false && fy.FormAdi == this.Text
                                select fy).FirstOrDefault();
            if (yetkiKontrol != null)
            {
                MessageBox.Show("Bu işlem için yetkiniz yoktur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                if (KullaniciBilgileri.KullaniciAdi != txt_KullaniciAdi.Text)
                {
                    err_HataDurumu.SetError(txt_KullaniciAdi, "Lütfen kendi kullanıcı adınızı giriniz.");
                }
                else if (txt_Sifre.Text != txt_SifreDogrula.Text)
                {
                    err_HataDurumu.SetError(txt_Sifre, "Şifreler uyuşmuyor, lütfen kontrol ediniz.");
                    err_HataDurumu.SetError(txt_SifreDogrula, "Şifreler uyuşmuyor, lütfen kontrol ediniz.");
                }
                else if (txt_Sifre.Text == "" || txt_Sifre.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_Sifre, "Bir şifre belirleyiniz.");

                }
                else if (txt_SifreDogrula.Text == "" || txt_SifreDogrula.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_SifreDogrula, "Belirlemiş olduğunuz şifreyi doğrulayınız.");
                }
                else
                {
                    SifreDogrula sifreDogrula = new SifreDogrula();
                    sifreDogrula.secilenKullaniciAdi = txt_KullaniciAdi.Text;
                    sifreDogrula.girilenSifre1 = txt_Sifre.Text;
                    sifreDogrula.girilenSifre2 = txt_SifreDogrula.Text;
                    sifreDogrula.ShowDialog();                    
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

        private void Txt_SifreDogrula_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txt_SifreDogrula.Properties.PasswordChar = '\0';
        }

        private void Txt_SifreDogrula_MouseUp(object sender, MouseEventArgs e)
        {
            txt_SifreDogrula.Properties.PasswordChar = '✺';
        }

        private void Txt_Sifre_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_SifreDogrula_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }        

        private void Txt_KullaniciAdi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_Sifre_Leave(object sender, EventArgs e)
        {
            if (txt_Sifre.Text.Length < 5)
            {
                err_HataDurumu.SetError(txt_Sifre, "Şifreniz minimum 6 karakter olmalı.");
                btn_Kaydet.Enabled = false;
            }
            else
            {
                err_HataDurumu.ClearErrors();
                btn_Kaydet.Enabled = true;
            }
        }
    }
}