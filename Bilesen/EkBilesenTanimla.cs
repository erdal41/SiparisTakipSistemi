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
using SiparisTakipSistemi.Urun;
using DevExpress.XtraGrid.Views.Base;
using SiparisTakipSistemi.Kullanici;
using SiparisTakipSistemi.Sistem;

namespace SiparisTakipSistemi.Bilesen
{
    public partial class EkBilesenTanimla : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public EkBilesenTanimla()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        private void EkBilesenTanimla_Load(object sender, EventArgs e)
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
                ekBilesenListele();
                this.MinimumSize = new Size(1002, 327);
            }
        }

        public void ekBilesenListele()
        {
            BindingSource ekBilesenBS = new BindingSource();
            var ekBilesen = (from eb in db.EkBilesenler
                             select new
                             {
                                 eb.EkBilesenID,
                                 eb.EkBilesenAdi,
                                 eb.EkBilesenBirimi,
                                 eb.EkBilesenAgirlik,
                                 eb.EkBilesenAdetFiyati,
                             });
            if (ekBilesen != null)
            {
                ekBilesenBS.DataSource = ekBilesen.ToList();
                grCtrl_EkBilesenTablosu.DataSource = ekBilesenBS; 
            }
            else
            {
                MessageBox.Show("Ek Bileşenler listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txt_EkBilesenAdi.Text == "" || txt_EkBilesenAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkBilesenAdi, "Ek bileşen adını giriniz.");
                }
                else if (txt_EkBilesenAgirlik.Text == "" || txt_EkBilesenAgirlik.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkBilesenAgirlik, "Ağırlık giriniz.");
                }
                else if (txt_EkBilesenAdetFiyati.Text == "" || txt_EkBilesenAdetFiyati.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkBilesenAdetFiyati, "Adet fiyatını giriniz.");
                }
                else
                {
                    var ekBilesenKontrol = (from ebl in db.EkBilesenler
                                            where ebl.EkBilesenAdi == txt_EkBilesenAdi.Text
                                            select ebl).FirstOrDefault();
                    if (ekBilesenKontrol != null)
                    {
                        MessageBox.Show("Aynı ek bileşen adı mevcut. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        EkBilesenler ekBilesenler = new EkBilesenler()
                        {
                            EkBilesenAdi = txt_EkBilesenAdi.Text,
                            EkBilesenAdet = 1,
                            EkBilesenBirimi = txt_EkBilesenBirimi.Text,
                            EkBilesenAgirlik = Convert.ToDecimal(txt_EkBilesenAgirlik.Text),
                            EkBilesenAdetFiyati = Convert.ToDecimal(txt_EkBilesenAdetFiyati.Text),
                            KaydedenID = KullaniciBilgileri.KaydedenID,
                            KayitTarihi = DateTime.Now,
                        };
                        db.EkBilesenler.Add(ekBilesenler);
                        db.SaveChanges();
                        ekBilesenListele();
                        grView_EkBilesenTablosu.MoveLast();
                        MessageBox.Show("Ek Bileşen kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        temizle();
                        UrunTanimla urunTanimla = (UrunTanimla)Application.OpenForms["UrunTanimla"];
                        if (Application.OpenForms["UrunTanimla"] != null)
                        {
                            urunTanimla.ekBilesenCMBListele();
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
                int id = Convert.ToInt32(txt_EkBilesenNo.Text);
                if (txt_EkBilesenAdi.Text == "" || txt_EkBilesenAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkBilesenAdi, "Ek bileşen adını giriniz.");
                }
                else if (txt_EkBilesenAgirlik.Text == "" || txt_EkBilesenAgirlik.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkBilesenAgirlik, "Ağırlık giriniz.");
                }
                else if (txt_EkBilesenAdetFiyati.Text == "" || txt_EkBilesenAdetFiyati.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkBilesenAdetFiyati, "Adet fiyatını giriniz.");
                }
                else
                {
                    var ekBilesenKontrol = (from ebl in db.EkBilesenler
                                            where ebl.EkBilesenID != id && ebl.EkBilesenAdi == txt_EkBilesenAdi.Text
                                            select ebl).FirstOrDefault();
                    if (ekBilesenKontrol == null)
                    {
                        var ekBilesen = (from ebl in db.EkBilesenler
                                         where ebl.EkBilesenID == id
                                         select ebl).FirstOrDefault();
                        ekBilesen.EkBilesenAdi = txt_EkBilesenAdi.Text;
                        ekBilesen.EkBilesenAdet = 1;
                        ekBilesen.EkBilesenBirimi = txt_EkBilesenBirimi.Text;
                        ekBilesen.EkBilesenAgirlik = Convert.ToDecimal(txt_EkBilesenAgirlik.Text);
                        ekBilesen.EkBilesenAdetFiyati = Convert.ToDecimal(txt_EkBilesenAdetFiyati.Text);
                        ekBilesen.KaydedenID = KullaniciBilgileri.KaydedenID;
                        ekBilesen.KayitTarihi = DateTime.Now;

                        DialogResult sonuc = MessageBox.Show("'" + ekBilesen.EkBilesenAdi + "'" + " " + "adlı ek bileşeni güncellemek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            int focuedRowHandle = grView_EkBilesenTablosu.FocusedRowHandle;
                            ekBilesenListele();
                            grView_EkBilesenTablosu.FocusedRowHandle = focuedRowHandle;
                            MessageBox.Show("Ek Bileşen güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            decimal urunBilesenleriAgirlik = 0;
                            decimal urunBilesenleriFiyat = 0;
                            decimal urunEkBilesenleriAgirlik = 0;
                            decimal urunEkBilesenleriFiyat = 0;
                            decimal urunEkMaliyetFiyat = 0;
                            decimal adet = 0;
                            decimal ekBilesenAgirlik = 0;
                            decimal ekBilesenAdetFiyati = 0;
                            decimal adetAgirlik = 0;
                            decimal adetTutari = 0;
                            SiparisTakipEntities db2 = new SiparisTakipEntities();
                            var urunEkBilesenGuncelle = (from ueb in db2.UrunEkBilesenleri
                                                         join u in db2.Urunler
                                                         on ueb.UrunID equals u.UrunID
                                                         join ebl in db2.EkBilesenler
                                                         on ueb.EkBilesenID equals ebl.EkBilesenID
                                                         where ueb.EkBilesenID == ebl.EkBilesenID
                                                         select ueb).ToList();
                            if (urunEkBilesenGuncelle != null)
                            {
                                foreach (var item in urunEkBilesenGuncelle)
                                {
                                    adet = Convert.ToDecimal(item.UrunEkBilesenleriAdet);
                                    ekBilesenAgirlik = Convert.ToDecimal(item.EkBilesenler.EkBilesenAgirlik);
                                    ekBilesenAdetFiyati = Convert.ToDecimal(item.EkBilesenler.EkBilesenAdetFiyati);
                                    adetAgirlik = adet * ekBilesenAgirlik;
                                    adetTutari = adet * ekBilesenAdetFiyati;
                                    item.UrunEkBilesenleriAdetAgirlik = adetAgirlik;
                                    item.UrunEkBilesenleriAdetTutari = adetTutari;
                                }
                            }
                            db2.SaveChanges();

                            SiparisTakipEntities db3 = new SiparisTakipEntities();
                            var urunGuncelle2 = (from ueb in db3.UrunEkBilesenleri
                                                 join u in db3.Urunler
                                                 on ueb.UrunID equals u.UrunID
                                                 join ebl in db3.EkBilesenler
                                                 on ueb.EkBilesenID equals ebl.EkBilesenID
                                                 where ueb.UrunID == u.UrunID
                                                 select ueb).ToList();
                            if (urunGuncelle2 != null)
                            {
                                foreach (var item in urunGuncelle2)
                                {
                                    var urunAgirlik = db3.UrunEkBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunEkBilesenleriAdetAgirlik);
                                    var urunBirimFiyati = db3.UrunEkBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunEkBilesenleriAdetTutari);
                                    urunEkBilesenleriFiyat = Convert.ToDecimal(urunBirimFiyati);
                                    urunEkBilesenleriAgirlik = Convert.ToDecimal(urunAgirlik);
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
                                urunTanimla.ekBilesenDTWListele();
                            }
                            UrunListesi urunListesi = (UrunListesi)Application.OpenForms["UrunListesi"];
                            if (Application.OpenForms["UrunListesi"] != null)
                            {
                                urunListesi.urunListele();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ek Bileşen güncellenmedi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aynı ek bileşen adı zaten mevcut. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (txt_EkBilesenNo.Text != "" || txt_EkBilesenNo.Text != String.Empty)
                {
                    int id = Convert.ToInt32(txt_EkBilesenNo.Text);
                    var urunKontrol = (from ueb in db.UrunEkBilesenleri
                                       join ebl in db.EkBilesenler
                                       on ueb.EkBilesenID equals ebl.EkBilesenID
                                       where ueb.EkBilesenID == id
                                       select ueb).FirstOrDefault();
                    if (urunKontrol != null)
                    {
                        MessageBox.Show("Silmek istediğiniz ek bileşen ürün için kullanılmış. Bu yüzden bileşeni silemezsiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var ekBilesenSil = (from ebl in db.EkBilesenler
                                            where ebl.EkBilesenID == id
                                            select ebl).FirstOrDefault();

                        DialogResult sonuc = MessageBox.Show("'" + ekBilesenSil.EkBilesenAdi + "'" + " " + "adlı ek bileşeni siliyorsunuz." + "\n" + "DİKKAT! Ek Bileşeni silerseniz, ek bileşene ait tüm bilgiler silinecektir. Yine de silmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.EkBilesenler.Remove(ekBilesenSil);
                            db.SaveChanges();
                            ekBilesenListele();
                            MessageBox.Show("Ek Bileşen silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            temizle();
                        }
                        else
                        {
                            MessageBox.Show("Ek Bileşen silinmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek ek bileşeni seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void temizle()
        {
            txt_EkBilesenNo.Text = string.Empty;
            txt_EkBilesenAdi.Text = string.Empty;
            txt_EkBilesenAgirlik.Text = string.Empty;
            txt_EkBilesenAdetFiyati.Text = string.Empty;
            btn_EkBilesenKaydet.Visible = true;
            btn_EkBilesenGuncelle.Visible = false;
            btn_EkBilesenSil.Visible = false;
            grView_EkBilesenTablosu.ClearSelection();
        }

        private void Btn_Temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void GrView_EkBilesenTablosu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (grView_EkBilesenTablosu.RowCount > 0)
            {
                int[] secilenler = grView_EkBilesenTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_EkBilesenTablosu.GetRowCellValue(secilenler[0], "EkBilesenID"));
                var ekBilesenGetir = (from ebl in db.EkBilesenler.AsNoTracking()
                                      where ebl.EkBilesenID == id
                                      select new
                                      {
                                          ebl.EkBilesenID,
                                          ebl.EkBilesenAdi,
                                          ebl.EkBilesenBirimi,
                                          ebl.EkBilesenAgirlik,
                                          ebl.EkBilesenAdetFiyati,
                                      }).FirstOrDefault();
                if (ekBilesenGetir != null)
                {
                    txt_EkBilesenNo.Text = ekBilesenGetir.EkBilesenID.ToString();
                    txt_EkBilesenAdi.Text = ekBilesenGetir.EkBilesenAdi.ToString();
                    txt_EkBilesenBirimi.Text = ekBilesenGetir.EkBilesenBirimi.ToString();
                    txt_EkBilesenAgirlik.Text = ekBilesenGetir.EkBilesenAgirlik.ToString();
                    txt_EkBilesenAdetFiyati.Text = ekBilesenGetir.EkBilesenAdetFiyati.ToString();

                    btn_EkBilesenKaydet.Visible = false;
                    btn_EkBilesenGuncelle.Visible = true;
                    btn_EkBilesenSil.Visible = true;
                    btn_EkBilesenSil.Location = new Point(103, 106);
                }
                else
                {
                    MessageBox.Show("Hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Txt_EkBilesenAgirlik_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Txt_EkBilesenAdetFiyati_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Txt_EkBilesenAdi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
            txt_EkBilesenAdi.Text = txt_EkBilesenAdi.Text.ToUpper();
        }

        private void Txt_EkBilesenAdetFiyati_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_EkBilesenAgirlik_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void GrView_EkBilesenTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_EkBilesenTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void EkBilesenTanimla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Anaform anaform = (Anaform)Application.OpenForms["Anaform"];
            if (Application.OpenForms["Anaform"] != null)
            {
                anaform.BringToFront();
            }
        }
    }
}