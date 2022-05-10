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
using System.Globalization;
using SiparisTakipSistemi.Sistem;

namespace SiparisTakipSistemi.Kullanici
{
    public partial class KullaniciTanimla : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public KullaniciTanimla()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        private void KullaniciTanimla_Load(object sender, EventArgs e)
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
            else
            {
                kullaniciListele();
            }
        }

        private void kullaniciListele()
        {
            BindingSource bindingSourceKullanicilar = new BindingSource();
            var kullanici = (from k in db.Kullanicilar
                             select new
                             {
                                 k.KullaniciID,
                                 k.KullaniciAdi,
                                 k.Sifre,
                                 k.KullaniciAdSoyad
                             }).ToList();
            if (kullanici != null)
            {
                bindingSourceKullanicilar.DataSource = kullanici;
                grCtrl_KullaniciTablosu.DataSource = bindingSourceKullanicilar;
            }
            else
            {
                MessageBox.Show("Kullanıcılar listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_KullaniciKaydet_Click(object sender, EventArgs e)
        {
            var yetkiKontrol = (from fy in db.FormYetkileri
                                join k in db.Kullanicilar
                                on fy.KullaniciID equals k.KullaniciID
                                where fy.KullaniciID == KullaniciBilgileri.KaydedenID && fy.Ekle == false && fy.FormAdi == this.Text
                                select fy).FirstOrDefault();
            if (yetkiKontrol != null)
            {
                MessageBox.Show("Bu işlem için yetkiniz yoktur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txt_KullaniciAdi.Text == "")
                {
                    err_HataDurumu.SetError(txt_KullaniciAdi, "Kullanıcı adı alanını boş geçemezsiniz.");
                }
                else if (txt_Sifre.Text == "")
                {
                    err_HataDurumu.SetError(txt_Sifre, "Şifre alanını boş geçemezsiniz.");
                }
                else if (txt_PersonelAdSoyad.Text == "")
                {
                    err_HataDurumu.SetError(txt_PersonelAdSoyad, "Personel ad soyad alanını boş geçemezsiniz.");
                }
                else
                {
                    if (db.Kullanicilar.Any(a => a.KullaniciAdi == txt_KullaniciAdi.Text))
                    {
                        MessageBox.Show("Kullanıcı adı daha önce kullanılmış, lütfen başka kullanıcı adı giriniz.");
                    }
                    else
                    {
                        Kullanicilar kullanicilar = new Kullanicilar()
                        {
                            KullaniciAdi = txt_KullaniciAdi.Text,
                            Sifre = txt_Sifre.Text,
                            KullaniciAdSoyad = txt_PersonelAdSoyad.Text,
                            KaydedenID = KullaniciBilgileri.KaydedenID,
                            KayitTarihi = DateTime.Now,
                        };
                        db.Kullanicilar.Add(kullanicilar);

                        DialogResult sonuc = MessageBox.Show("'" + txt_KullaniciAdi.Text + "'" + " " + " " + "kullanıcısını kaydetmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            kullaniciListele();
                            temizle();

                            var formlar = (from fy in db.FormYetkileri
                                           group fy by fy.FormAdi into g
                                           select new
                                           {
                                               g.Key,
                                           }).ToList();
                            foreach (var form in formlar)
                            {
                                FormYetkileri formYetkileri = new FormYetkileri()
                                {
                                    KullaniciID = kullanicilar.KullaniciID,
                                    FormAdi = form.Key,
                                    Ac = false,
                                    Ekle = false,
                                    Guncelle = false,
                                    Sil = false,
                                    KaydedenID = KullaniciBilgileri.KaydedenID,
                                    KayitTarihi = DateTime.Now,
                                };
                                db.FormYetkileri.Add(formYetkileri);
                                db.SaveChanges();
                            }

                            MessageBox.Show("Kullanıcı kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı kaydedilmedi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void Btn_KullaniciGuncelle_Click(object sender, EventArgs e)
        {
            var yetkiKontrol = (from fy in db.FormYetkileri
                                join k in db.Kullanicilar
                                on fy.KullaniciID equals k.KullaniciID
                                where fy.KullaniciID == KullaniciBilgileri.KaydedenID && fy.Guncelle == false && fy.FormAdi == this.Text
                                select fy).FirstOrDefault();
            if (yetkiKontrol != null)
            {
                MessageBox.Show("Bu işlem için yetkiniz yoktur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txt_KullaniciAdi.Text == "")
                {
                    err_HataDurumu.SetError(txt_KullaniciAdi, "Kullanıcı adı giriniz.");
                }
                else if (txt_Sifre.Text == "")
                {
                    err_HataDurumu.SetError(txt_Sifre, "Şifre giriniz.");
                }
                else if (txt_PersonelAdSoyad.Text == "")
                {
                    err_HataDurumu.SetError(txt_PersonelAdSoyad, "Personel ad soyad giriniz.");
                }
                else
                {
                    int id = Convert.ToInt32(txt_KullaniciNo.Text);
                    var kullaniciKontrol = (from k in db.Kullanicilar
                                            where (k.KullaniciAdi == txt_KullaniciAdi.Text && k.KullaniciID == id) || (k.KullaniciAdi != txt_KullaniciAdi.Text && k.KullaniciID == id)
                                            select k).FirstOrDefault();
                    if (kullaniciKontrol != null && kullaniciKontrol.KullaniciID == id)
                    {
                        Kullanicilar kullanicilar = new Kullanicilar();
                        var guncelle = db.Kullanicilar.Where(s => s.KullaniciID == id).FirstOrDefault();
                        guncelle.KullaniciAdi = txt_KullaniciAdi.Text;
                        guncelle.Sifre = txt_Sifre.Text;
                        guncelle.KullaniciAdSoyad = txt_PersonelAdSoyad.Text;
                        guncelle.KaydedenID = KullaniciBilgileri.KaydedenID;
                        guncelle.KayitTarihi = DateTime.Now;

                        DialogResult sonuc = MessageBox.Show("'" + guncelle.KullaniciAdSoyad + "'" + " " + " " + "kullanıcısını güncellemek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            int focuedRowHandle = grView_KullaniciTablosu.FocusedRowHandle;
                            kullaniciListele();
                            grView_KullaniciTablosu.FocusedRowHandle = focuedRowHandle;
                            MessageBox.Show("Kullanıcı güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı güncellenmedi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı daha önce kullanılmış, lütfen başka kullanıcı adı giriniz.");
                    }
                }
            }
        }

        private void Btn_KullaniciSil_Click(object sender, EventArgs e)
        {
            var yetkiKontrol = (from fy in db.FormYetkileri
                                join k in db.Kullanicilar
                                on fy.KullaniciID equals k.KullaniciID
                                where fy.KullaniciID == KullaniciBilgileri.KaydedenID && fy.Sil == false && fy.FormAdi == this.Text
                                select fy).FirstOrDefault();
            if (yetkiKontrol != null)
            {
                MessageBox.Show("Bu işlem için yetkiniz yoktur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(txt_KullaniciNo.Text);
                var sil = (from k in db.Kullanicilar
                           where k.KullaniciID == id
                           select k).FirstOrDefault();

                db.KullaniciSonGirisTarihi.RemoveRange(db.KullaniciSonGirisTarihi.Where(k => k.KullaniciID == id));
                db.FormYetkileri.RemoveRange(db.FormYetkileri.Where(k => k.KullaniciID == id));

                DialogResult sonuc = MessageBox.Show("'" + sil.KullaniciAdi + "'" + " " + "kullanıcısını silmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sonuc == DialogResult.Yes)
                {
                    db.Kullanicilar.Remove(sil);
                    db.SaveChanges();
                    kullaniciListele();
                    temizle();
                    MessageBox.Show("Kullanıcı silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kullanıcı silinemedi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void temizle()
        {
            txt_KullaniciNo.Text = string.Empty;
            txt_KullaniciAdi.Text = string.Empty;
            txt_Sifre.Text = string.Empty;
            txt_PersonelAdSoyad.Text = string.Empty;
            btn_KullaniciGuncelle.Visible = false;
            btn_KullaniciSil.Visible = false;
            btn_KullaniciKaydet.Visible = true;
            grView_KullaniciTablosu.ClearSelection();
            txt_Sifre.Properties.Buttons[0].Enabled = true;
        }
        private void Btn_Temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void GrView_KullaniciTablosu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (grView_KullaniciTablosu.RowCount > 0)
            {
                int[] secilenler = grView_KullaniciTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_KullaniciTablosu.GetRowCellValue(secilenler[0], "KullaniciID"));
                var kullaniciGetir = (from k in db.Kullanicilar.AsNoTracking()
                                      where k.KullaniciID == id
                                      select new
                                      {
                                          k.KullaniciID,
                                          k.KullaniciAdi,
                                          k.Sifre,
                                          k.KullaniciAdSoyad,
                                      }).FirstOrDefault();
                if (kullaniciGetir != null)
                {
                    txt_KullaniciNo.Text = kullaniciGetir.KullaniciID.ToString();
                    txt_KullaniciAdi.Text = kullaniciGetir.KullaniciAdi;
                    txt_Sifre.Text = kullaniciGetir.Sifre;
                    txt_PersonelAdSoyad.Text = kullaniciGetir.KullaniciAdSoyad;

                    btn_KullaniciKaydet.Visible = false;
                    btn_KullaniciGuncelle.Visible = true;
                    btn_KullaniciSil.Visible = true;
                    btn_KullaniciSil.Location = new Point(85, 147);
                    txt_Sifre.Properties.Buttons[0].Enabled = false;
                }
                else
                {
                    MessageBox.Show("Hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void Txt_KullaniciAdi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
            txt_KullaniciAdi.Text = txt_KullaniciAdi.Text.ToLower();
        }

        private void Txt_Sifre_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_PersonelAdSoyad_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
            txt_PersonelAdSoyad.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt_PersonelAdSoyad.Text);
        }

        private void GrView_KullaniciTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_KullaniciTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        public BindingSource bindingSourceFyetkileri = new BindingSource();
        private void GrView_KullaniciTablosu_DoubleClick(object sender, EventArgs e)
        {
            if (grView_KullaniciTablosu.RowCount > 0)
            {
                int[] secilenler = grView_KullaniciTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_KullaniciTablosu.GetRowCellValue(secilenler[0], "KullaniciID"));
                var kullaniciKontrol = (from fy in db.FormYetkileri.AsNoTracking()
                                        join k in db.Kullanicilar
                                        on fy.KullaniciID equals k.KullaniciID
                                        where fy.KullaniciID == id
                                        select fy).FirstOrDefault();
                if (kullaniciKontrol != null)
                {
                    YetkiTanimla yetkiTanimla = new YetkiTanimla();
                    yetkiTanimla.Show();
                    yetkiTanimla.txt_KullaniciAdi.Text = kullaniciKontrol.Kullanicilar.KullaniciAdi;
                    yetkiTanimla.secilenKullaniciID = kullaniciKontrol.Kullanicilar.KullaniciID;
                    yetkiTanimla.yetkiListele();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hata, sistem yöneticisi ile iletişime geçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Btn_SifreDegistir_Click(object sender, EventArgs e)
        {
            SifreTanimla sifreTanimla = new SifreTanimla();
            sifreTanimla.ShowDialog();
        }

        private void Txt_Sifre_Leave(object sender, EventArgs e)
        {
            if (txt_Sifre.Text.Length < 6)
            {
                err_HataDurumu.SetError(txt_Sifre, "Şifreniz minimum 6 karakter olmalı.");
                btn_KullaniciKaydet.Enabled = false;
            }
            else
            {
                err_HataDurumu.ClearErrors();
                btn_KullaniciKaydet.Enabled = true;
            }
        }

        private void Txt_KullaniciAdi_Leave(object sender, EventArgs e)
        {
            if (txt_KullaniciAdi.Text.Length < 5)
            {
                err_HataDurumu.SetError(txt_KullaniciAdi, "Kullanıcı adınız minimum 5 karakter olmalı.");
                btn_KullaniciKaydet.Enabled = false;
            }
            else
            {
                err_HataDurumu.ClearErrors();
                btn_KullaniciKaydet.Enabled = true;
            }
        }
    }
}
