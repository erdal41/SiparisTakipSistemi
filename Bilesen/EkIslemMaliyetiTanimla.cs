using SiparisTakipSistemi.Kullanici;
using SiparisTakipSistemi.Sistem;
using SiparisTakipSistemi.Urun;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SiparisTakipSistemi.Bilesen
{
    public partial class EkIslemMaliyetiTanimla : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public EkIslemMaliyetiTanimla()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        private void EkIslemMaliyetiTanimla_Load(object sender, EventArgs e)
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
                ekIslemMaliyetiListele();
                this.MinimumSize = new Size(816, 267);
            }
        }

        public void ekIslemMaliyetiListele()
        {
            BindingSource bindingSourceEIM = new BindingSource();
            var ekIslemMaliyeti = (from eim in db.EkIslemMaliyeti
                           select new
                           {
                               eim.EkIslemMaliyetiID,
                               eim.EkIslemMaliyetiAdi,
                               eim.EkIslemMaliyetiUzunluk,
                               eim.EkIslemMaliyetiFiyati,
                           }).ToList();
            if (ekIslemMaliyeti != null)
            {
                bindingSourceEIM.DataSource = ekIslemMaliyeti;
                grCtrl_EkIslemMaliyetiTablosu.DataSource = bindingSourceEIM;
                grView_EkIslemMaliyetiTablosu.ClearSelection();
            }
            else
            {
                MessageBox.Show("Ek İşlem Maliyeti listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_EkBilesenKaydet_Click(object sender, EventArgs e)
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
                if (txt_EkIslemMaliyetiAdi.Text == "" || txt_EkIslemMaliyetiAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkIslemMaliyetiAdi, "Ek İşlem Maliyet adını giriniz.");
                }
                else if (txt_EkIslemMaliyetiFiyati.Text == "" || txt_EkIslemMaliyetiFiyati.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkIslemMaliyetiFiyati, "Fiyat giriniz.");
                }
                else
                {
                    var ekIslemMaliyetiKontrol = (from eim in db.EkIslemMaliyeti
                                                  where eim.EkIslemMaliyetiAdi == txt_EkIslemMaliyetiAdi.Text
                                                  select eim).FirstOrDefault();
                    if (ekIslemMaliyetiKontrol != null)
                    {
                        MessageBox.Show("Aynı isim mevcut. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        EkIslemMaliyeti ekIslemMaliyeti = new EkIslemMaliyeti()
                        {
                            EkIslemMaliyetiAdi = txt_EkIslemMaliyetiAdi.Text,
                            EkIslemMaliyetiUzunluk = 1,
                            EkIslemMaliyetiFiyati = Convert.ToDecimal(txt_EkIslemMaliyetiFiyati.Text),
                            KaydedenID = KullaniciBilgileri.KaydedenID,
                            KayitTarihi = DateTime.Now,
                        };

                        db.EkIslemMaliyeti.Add(ekIslemMaliyeti);
                        db.SaveChanges();
                        ekIslemMaliyetiListele();
                        grView_EkIslemMaliyetiTablosu.MoveLast();
                        MessageBox.Show("Ek İşlem Maliyeti kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        temizle();
                        UrunTanimla urunTanimla = (UrunTanimla)Application.OpenForms["UrunTanimla"];
                        if (Application.OpenForms["UrunTanimla"] != null)
                        {
                            urunTanimla.ekIslemMaliyetiCMBListele();
                        }
                    }
                }
            }
        }

        private void Btn_EkBilesenGuncelle_Click(object sender, EventArgs e)
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
                int id = Convert.ToInt32(txt_EkIslemMaliyetiNo.Text);
                if (txt_EkIslemMaliyetiAdi.Text == "" || txt_EkIslemMaliyetiAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkIslemMaliyetiAdi, "Ek fiyat adını giriniz.");
                }
                else if (txt_EkIslemMaliyetiFiyati.Text == "" || txt_EkIslemMaliyetiFiyati.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkIslemMaliyetiFiyati, "Fiyat giriniz.");
                }
                else
                {
                    var ekIslemMaliyetiKontrol = (from eim in db.EkIslemMaliyeti
                                                  where eim.EkIslemMaliyetiID != id && eim.EkIslemMaliyetiAdi == txt_EkIslemMaliyetiAdi.Text
                                                  select eim).FirstOrDefault();
                    if (ekIslemMaliyetiKontrol == null)
                    {
                        var ekIslemMaliyeti = (from eim in db.EkIslemMaliyeti
                                          where eim.EkIslemMaliyetiID == id
                                          select eim).FirstOrDefault();
                        ekIslemMaliyeti.EkIslemMaliyetiAdi = txt_EkIslemMaliyetiAdi.Text;
                        ekIslemMaliyeti.EkIslemMaliyetiUzunluk = 1;
                        ekIslemMaliyeti.EkIslemMaliyetiFiyati = Convert.ToDecimal(txt_EkIslemMaliyetiFiyati.Text);
                        ekIslemMaliyeti.KaydedenID = KullaniciBilgileri.KaydedenID;
                        ekIslemMaliyeti.KayitTarihi = DateTime.Now;

                        DialogResult sonuc = MessageBox.Show("'" + ekIslemMaliyeti.EkIslemMaliyetiAdi + "'" + " " + "adlı ek işlem maliyetini güncellemek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            int focuedRowHandle = grView_EkIslemMaliyetiTablosu.FocusedRowHandle;
                            ekIslemMaliyetiListele();
                            grView_EkIslemMaliyetiTablosu.FocusedRowHandle = focuedRowHandle;

                            MessageBox.Show("Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            decimal urunBilesenleriAgirlik = 0;
                            decimal urunBilesenleriFiyat = 0;
                            decimal urunEkBilesenleriAgirlik = 0;
                            decimal urunEkBilesenleriFiyat = 0;
                            decimal urunEkMaliyetFiyat = 0;
                            SiparisTakipEntities db2 = new SiparisTakipEntities();
                            var urunGuncelle2 = (from ueb in db2.UrunEkBilesenleri
                                                 join u in db2.Urunler
                                                 on ueb.UrunID equals u.UrunID
                                                 join ebl in db2.EkBilesenler
                                                 on ueb.EkBilesenID equals ebl.EkBilesenID
                                                 where ueb.UrunID == u.UrunID
                                                 select ueb).ToList();
                            if (urunGuncelle2 != null)
                            {
                                foreach (var item in urunGuncelle2)
                                {
                                    var urunAgirlik = db2.UrunEkBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunEkBilesenleriAdetAgirlik);
                                    var urunBirimFiyati = db2.UrunEkBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunEkBilesenleriAdetTutari);
                                    urunEkBilesenleriFiyat = Convert.ToDecimal(urunBirimFiyati);
                                    urunEkBilesenleriAgirlik = Convert.ToDecimal(urunAgirlik);
                                }
                            }
                            else
                            {
                                MessageBox.Show("aha hata.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            decimal uzunluk = 0;
                            decimal ekFiyat = 0;
                            decimal urunEkFiyati = 0;
                            SiparisTakipEntities db3 = new SiparisTakipEntities();
                            var urunEkMaliyetGuncelle = (from uem in db3.UrunEkIslemMaliyetleri
                                                         join u in db3.Urunler
                                                         on uem.UrunID equals u.UrunID
                                                         join eim in db3.EkIslemMaliyeti
                                                         on uem.EkIslemMaliyetiID equals eim.EkIslemMaliyetiID
                                                         where uem.EkIslemMaliyetiID == eim.EkIslemMaliyetiID
                                                         select uem).ToList();
                            if (urunEkMaliyetGuncelle != null)
                            {
                                foreach (var item in urunEkMaliyetGuncelle)
                                {
                                    uzunluk = Convert.ToDecimal(item.UrunEkIslemMaliyetleriUzunluk);
                                    ekFiyat = Convert.ToDecimal(item.EkIslemMaliyeti.EkIslemMaliyetiFiyati);
                                    urunEkFiyati = uzunluk * ekFiyat;
                                    item.UrunEkIslemMaliyetleriFiyati = urunEkFiyati;
                                }
                            }
                            db3.SaveChanges();

                            SiparisTakipEntities db4 = new SiparisTakipEntities();
                            var urunGuncelle3 = (from uem in db4.UrunEkIslemMaliyetleri
                                                 join u in db4.Urunler
                                                 on uem.UrunID equals u.UrunID
                                                 join eim in db4.EkIslemMaliyeti
                                                 on uem.EkIslemMaliyetiID equals eim.EkIslemMaliyetiID
                                                 where uem.UrunID == u.UrunID
                                                 select uem).ToList();
                            if (urunGuncelle3 != null)
                            {
                                foreach (var item in urunGuncelle3)
                                {
                                    var urunBirimFiyati = db4.UrunEkIslemMaliyetleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunEkIslemMaliyetleriFiyati);
                                    urunEkMaliyetFiyat = Convert.ToDecimal(urunBirimFiyati);
                                }
                            }
                            else
                            {
                                MessageBox.Show("aha hata.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                            db4.SaveChanges();

                            SiparisTakipEntities db1 = new SiparisTakipEntities();
                            var urunGuncelle1 = (from ub in db1.UrunBilesenleri
                                                 join u in db1.Urunler
                                                 on ub.UrunID equals u.UrunID
                                                 join bl in db1.Bilesenler
                                                 on ub.BilesenID equals bl.BilesenID
                                                 where ub.UrunID == u.UrunID
                                                 select ub).ToList();
                            if (urunGuncelle1 != null)
                            {
                                foreach (var item in urunGuncelle1)
                                {
                                    var urunBirimFiyati = db1.UrunBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunBilesenleriAdetTutari);
                                    var urunAgirlik = db1.UrunBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunBilesenleriAdetAgirlik);
                                    urunBilesenleriFiyat = Convert.ToDecimal(urunBirimFiyati);
                                    urunBilesenleriAgirlik = Convert.ToDecimal(urunAgirlik);
                                    item.Urunler.UrunBirimFiyati = urunBilesenleriFiyat + urunEkBilesenleriFiyat + urunEkMaliyetFiyat;
                                    item.Urunler.UrunAgirlik = urunBilesenleriAgirlik + urunEkBilesenleriAgirlik;
                                }
                            }
                            else
                            {
                                MessageBox.Show("aha hata.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            db1.SaveChanges();

                            UrunTanimla urunTanimla = (UrunTanimla)Application.OpenForms["UrunTanimla"];
                            if (Application.OpenForms["UrunTanimla"] != null)
                            {
                                urunTanimla.urunListele();
                                urunTanimla.ekIslemMaliyetiDTWListele();
                            }
                            UrunListesi urunListesi = (UrunListesi)Application.OpenForms["UrunListesi"];
                            if (Application.OpenForms["UrunListesi"] != null)
                            {
                                urunListesi.urunListele();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ek Fiyat güncellenmedi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aynı ek fiyat adı zaten mevcut. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void Btn_EkBilesenSil_Click(object sender, EventArgs e)
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
                if (txt_EkIslemMaliyetiNo.Text != "" || txt_EkIslemMaliyetiNo.Text != String.Empty)
                {
                    int id = Convert.ToInt32(txt_EkIslemMaliyetiNo.Text);
                    var urunKontrol = (from uem in db.UrunEkIslemMaliyetleri
                                       join ef in db.EkIslemMaliyeti
                                       on uem.EkIslemMaliyetiID equals ef.EkIslemMaliyetiID
                                       where uem.EkIslemMaliyetiID == id
                                       select uem).FirstOrDefault();
                    if (urunKontrol != null)
                    {
                        MessageBox.Show("Silmek istediğiniz ek işlem maliyeti ürün için kullanılmış. Bu yüzden silemezsiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var ekIslemMaliyetiSil = (from eim in db.EkIslemMaliyeti
                                                  where eim.EkIslemMaliyetiID == id
                                                  select eim).FirstOrDefault();

                        DialogResult sonuc = MessageBox.Show("'" + ekIslemMaliyetiSil.EkIslemMaliyetiAdi + "'" + " " + "adlı ek işlem maliyetini siliyorsunuz." + "\n" + "DİKKAT! Ek işlem maliyetini silerseniz, ek işlem maliyetine ait tüm bilgiler silinecektir. Yine de silmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.EkIslemMaliyeti.Remove(ekIslemMaliyetiSil);
                            db.SaveChanges();
                            ekIslemMaliyetiListele();
                            MessageBox.Show("Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            temizle();
                        }
                        else
                        {
                            MessageBox.Show("Silinmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek ek işlem maliyetini seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void temizle()
        {
            txt_EkIslemMaliyetiNo.Text = string.Empty;
            txt_EkIslemMaliyetiAdi.Text = string.Empty;
            txt_EkIslemMaliyetiFiyati.Text = string.Empty;
            btn_EkIslemMaliyetiKaydet.Visible = true;
            btn_EkIslemMaliyetiGuncelle.Visible = false;
            btn_EkIslemMaliyetiSil.Visible = false;
            grView_EkIslemMaliyetiTablosu.ClearSelection();
        }

        private void Btn_Temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void GrView_EkIslemMaliyetiTablosu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (grView_EkIslemMaliyetiTablosu.RowCount > 0)
            {
                int[] secilenler = grView_EkIslemMaliyetiTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_EkIslemMaliyetiTablosu.GetRowCellValue(secilenler[0], "EkIslemMaliyetiID"));
                var ekIslemMaliyetiGetir = (from eim in db.EkIslemMaliyeti.AsNoTracking()
                                    where eim.EkIslemMaliyetiID == id
                                    select eim).FirstOrDefault();
                if (ekIslemMaliyetiGetir != null)
                {
                    txt_EkIslemMaliyetiNo.Text = ekIslemMaliyetiGetir.EkIslemMaliyetiID.ToString();
                    txt_EkIslemMaliyetiAdi.Text = ekIslemMaliyetiGetir.EkIslemMaliyetiAdi.ToString();
                    txt_EkIslemMaliyetiFiyati.Text = ekIslemMaliyetiGetir.EkIslemMaliyetiFiyati.ToString();

                    btn_EkIslemMaliyetiKaydet.Visible = false;
                    btn_EkIslemMaliyetiGuncelle.Visible = true;
                    btn_EkIslemMaliyetiSil.Visible = true;
                    btn_EkIslemMaliyetiSil.Location = new Point(91, 107);
                }
                else
                {
                    MessageBox.Show("Hata oluştu. Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Txt_EkIslemMaliyetiFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 44)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Txt_EkIslemMaliyetiAdi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
            txt_EkIslemMaliyetiAdi.Text = txt_EkIslemMaliyetiAdi.Text.ToUpper();
        }

        private void Txt_EkIslemMaliyetiFiyati_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void GrView_EkIslemMaliyetiTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_EkIslemMaliyetiTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void EkIslemMaliyetiTanimla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Anaform anaform = (Anaform)Application.OpenForms["Anaform"];
            if (Application.OpenForms["Anaform"] != null)
            {
                anaform.BringToFront();
            }
        }
    }
}