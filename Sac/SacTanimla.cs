using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using SiparisTakipSistemi.Bilesen;
using SiparisTakipSistemi.Urun;
using System.Collections.Generic;
using System.ComponentModel;
using SiparisTakipSistemi.Kullanici;
using SiparisTakipSistemi.Sistem;

namespace SiparisTakipSistemi.Sac
{
    public partial class SacTanimla : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        
        public SacTanimla()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }
        private void SacTanimla_Load(object sender, EventArgs e)
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
                this.MinimumSize = new Size(1002, 327);
                sacListele();
            }
            
        }

        public void sacListele()
        {
            BindingSource sacBS = new BindingSource();
            var sac = (from s in db.Saclar
                       select new
                       {
                           s.SacID,
                           s.SacAdi,
                           s.SacBirimi,
                           s.SacBirimFiyati,
                       });
            if (sac != null)
            {
                sacBS.DataSource = sac.ToList();
                grCtrl_SacTablosu.DataSource = sacBS;
            }
            else
            {
                MessageBox.Show("Saclar listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrView_SacTablosu_RowClick(object sender, RowClickEventArgs e)
        {
            if (grView_SacTablosu.RowCount > 0)
            {
                int[] secilenler = grView_SacTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_SacTablosu.GetRowCellValue(secilenler[0], "SacID"));
                var sacGetir = (from s in db.Saclar.AsNoTracking()
                                       where s.SacID == id
                                       select new
                                       {
                                           s.SacID,
                                           s.SacAdi,
                                           s.SacBirimi,
                                           s.SacBirimFiyati,
                                       }).FirstOrDefault();
                if (sacGetir != null)
                {
                    txt_SacNo.Text = sacGetir.SacID.ToString();
                    txt_SacAdi.Text = sacGetir.SacAdi.ToString();
                    txt_SacBirimi.Text = sacGetir.SacBirimi.ToString();
                    txt_SacBirimFiyati.Text = sacGetir.SacBirimFiyati.ToString();

                }

                btn_SacKaydet.Visible = false;
                btn_SacGuncelle.Visible = true;
                btn_SacSil.Visible = true;
                btn_SacSil.Location = new Point(103, 106);
            }
        }

        private void Btn_SacKaydet_Click(object sender, EventArgs e)
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
                if (txt_SacAdi.Text == "" || txt_SacAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_SacAdi, "Sac adı giriniz.");
                }
                else if (txt_SacBirimFiyati.Text == "" || txt_SacBirimFiyati.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_SacBirimFiyati, "Sacın birim fiyatını giriniz.");
                }
                else
                {
                    var sacKontrol = (from s in db.Saclar
                                      where s.SacAdi == txt_SacAdi.Text
                                      select s).FirstOrDefault();
                    if (sacKontrol != null)
                    {
                        MessageBox.Show("Girdiğiniz sac adı zaten kayıtlı. Lütfen başka isim giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Saclar sac = new Saclar()
                        {
                            SacAdi = txt_SacAdi.Text,
                            SacBirimi = txt_SacBirimi.Text,
                            SacBirimFiyati = Convert.ToDecimal(txt_SacBirimFiyati.Text),
                            SacAgirlik = 1,
                            KaydedenID = KullaniciBilgileri.KaydedenID,
                            KayitTarihi = DateTime.Now,
                        };
                        db.Saclar.Add(sac);
                        db.SaveChanges();
                        sacListele();
                        grView_SacTablosu.MoveLast();
                        txt_SacNo.Text = sac.SacID.ToString();
                        MessageBox.Show("Sac kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        temizle();
                    }
                }
            }
        }

        private void Btn_SacGuncelle_Click(object sender, EventArgs e)
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
                if (txt_SacAdi.Text == "" || txt_SacAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_SacAdi, "Sac adı giriniz.");
                }
                else if (txt_SacBirimFiyati.Text == "" || txt_SacBirimFiyati.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_SacBirimFiyati, "Sac birim fiyatını giriniz.");
                }
                else
                {
                    int id = Convert.ToInt32(txt_SacNo.Text);
                    var sacKontrol = (from s in db.Saclar
                                      where s.SacID != id && s.SacAdi == txt_SacAdi.Text
                                      select s).FirstOrDefault();
                    if (sacKontrol == null)
                    {
                        var sacGuncelle = (from s in db.Saclar
                                           where s.SacID == id
                                           select s).FirstOrDefault();
                        sacGuncelle.SacAdi = txt_SacAdi.Text;
                        sacGuncelle.SacBirimi = txt_SacBirimi.Text;
                        sacGuncelle.SacBirimFiyati = Convert.ToDecimal(txt_SacBirimFiyati.Text);
                        sacGuncelle.SacAgirlik = 1;
                        sacGuncelle.KaydedenID = KullaniciBilgileri.KaydedenID;
                        sacGuncelle.KayitTarihi = DateTime.Now;

                        DialogResult sonuc = MessageBox.Show("'" + sacGuncelle.SacAdi + "'" + " " + "adlı sacı güncellemek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            int focuedRowHandle = grView_SacTablosu.FocusedRowHandle;
                            sacListele();
                            grView_SacTablosu.FocusedRowHandle = focuedRowHandle;
                            MessageBox.Show("Sac güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            decimal agirlik = 0;
                            decimal agirlikTutari = 0;
                            decimal sacBirimFiyati = Convert.ToDecimal(sacGuncelle.SacBirimFiyati);
                            SiparisTakipEntities db2 = new SiparisTakipEntities();
                            var bilesenSaclariGuncelle = (from bs in db2.BilesenSaclari
                                                          join bl in db2.Bilesenler
                                                          on bs.BilesenID equals bl.BilesenID
                                                          join s in db2.Saclar
                                                          on bs.SacID equals s.SacID
                                                          where bs.SacID == id
                                                          select bs).ToList();

                            if (bilesenSaclariGuncelle != null)
                            {
                                foreach (var item in bilesenSaclariGuncelle)
                                {
                                    agirlik = Convert.ToDecimal(item.SacAgirlik);
                                    agirlikTutari = sacBirimFiyati * agirlik;
                                    item.AgirlikTutari = agirlikTutari;
                                }
                            }
                            db2.SaveChanges();


                            SiparisTakipEntities db3 = new SiparisTakipEntities();
                            var bilesenGuncelle = (from bs in db3.BilesenSaclari
                                                   join bl in db3.Bilesenler
                                                   on bs.BilesenID equals bl.BilesenID
                                                   join s in db3.Saclar
                                                   on bs.SacID equals s.SacID
                                                   where bs.BilesenID == bl.BilesenID
                                                   select bs).ToList();
                            if (bilesenGuncelle != null)
                            {
                                foreach (var item in bilesenGuncelle)
                                {
                                    var toplamTutar = db3.BilesenSaclari.Where(x => x.BilesenID == item.Bilesenler.BilesenID).Sum(x => x.AgirlikTutari);
                                    var toplamAgirlik = db3.BilesenSaclari.Where(x => x.BilesenID == item.Bilesenler.BilesenID).Sum(x => x.SacAgirlik);
                                    item.Bilesenler.BilesenBirimFiyati = toplamTutar;
                                    item.Bilesenler.BilesenAgirlik = toplamAgirlik;
                                }
                            }
                            db3.SaveChanges();

                            BilesenTanimla bilesenTanimla = (BilesenTanimla)Application.OpenForms["BilesenTanimla"];
                            if (Application.OpenForms["BilesenTanimla"] != null)
                            {
                                bilesenTanimla.bilesenListele();
                                bilesenTanimla.sacDTWListele();
                            }


                            decimal urunBilesenleriAgirlik = 0;
                            decimal urunBilesenleriFiyat = 0;
                            decimal urunEkBilesenleriAgirlik = 0;
                            decimal urunEkBilesenleriFiyat = 0;
                            decimal urunEkMaliyetFiyat = 0;
                            SiparisTakipEntities db6 = new SiparisTakipEntities();
                            var urunGuncelle2 = (from ueb in db6.UrunEkBilesenleri
                                                 join u in db6.Urunler
                                                 on ueb.UrunID equals u.UrunID
                                                 join ebl in db6.EkBilesenler
                                                 on ueb.EkBilesenID equals ebl.EkBilesenID
                                                 where ueb.UrunID == u.UrunID
                                                 select ueb).ToList();
                            if (urunGuncelle2 != null)
                            {
                                foreach (var item in urunGuncelle2)
                                {
                                    var urunAgirlik = db6.UrunEkBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunEkBilesenleriAdetAgirlik);
                                    var urunBirimFiyati = db6.UrunEkBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunEkBilesenleriAdetTutari);
                                    urunEkBilesenleriFiyat = Convert.ToDecimal(urunBirimFiyati);
                                    urunEkBilesenleriAgirlik = Convert.ToDecimal(urunAgirlik);
                                }
                            }

                            SiparisTakipEntities db7 = new SiparisTakipEntities();
                            var urunGuncelle3 = (from uem in db7.UrunEkIslemMaliyetleri
                                                 join u in db7.Urunler
                                                 on uem.UrunID equals u.UrunID
                                                 join eim in db7.EkIslemMaliyeti
                                                 on uem.EkIslemMaliyetiID equals eim.EkIslemMaliyetiID
                                                 where uem.UrunID == u.UrunID
                                                 select uem).ToList();
                            if (urunGuncelle3 != null)
                            {
                                foreach (var item in urunGuncelle3)
                                {
                                    var urunBirimFiyati = db7.UrunEkIslemMaliyetleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunEkIslemMaliyetleriFiyati);
                                    urunEkMaliyetFiyat = Convert.ToDecimal(urunBirimFiyati);
                                }
                            }
                            db7.SaveChanges();

                            decimal adet = 0;
                            decimal adetAgirlik = 0;
                            decimal adetTutari = 0;
                            decimal bilesenBirimFiyati = 0;
                            decimal bilesenAgirlik = 0;
                            SiparisTakipEntities db4 = new SiparisTakipEntities();
                            var urunBilesenleriGuncelle = (from ub in db4.UrunBilesenleri
                                                           join u in db4.Urunler
                                                           on ub.UrunID equals u.UrunID
                                                           join bl in db4.Bilesenler
                                                           on ub.BilesenID equals bl.BilesenID
                                                           where ub.BilesenID == bl.BilesenID
                                                           select ub).ToList();
                            if (urunBilesenleriGuncelle != null)
                            {
                                foreach (var item in urunBilesenleriGuncelle)
                                {
                                    adet = Convert.ToDecimal(item.UrunBilesenleriAdet);
                                    bilesenBirimFiyati = Convert.ToDecimal(item.Bilesenler.BilesenBirimFiyati);
                                    bilesenAgirlik = Convert.ToDecimal(item.Bilesenler.BilesenAgirlik);
                                    adetAgirlik = adet * bilesenAgirlik;
                                    adetTutari = adet * bilesenBirimFiyati;
                                    item.UrunBilesenleriAdetAgirlik = adetAgirlik;
                                    item.UrunBilesenleriAdetTutari = adetTutari;
                                }
                            }
                            db4.SaveChanges();

                            SiparisTakipEntities db5 = new SiparisTakipEntities();
                            var urunGuncelle = (from ub in db5.UrunBilesenleri
                                                join u in db5.Urunler
                                                on ub.UrunID equals u.UrunID
                                                join bl in db5.Bilesenler
                                                on ub.BilesenID equals bl.BilesenID
                                                where ub.UrunID == u.UrunID
                                                select ub).ToList();
                            if (urunGuncelle != null)
                            {
                                foreach (var item in urunGuncelle)
                                {
                                    var urunBirimFiyati = db5.UrunBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunBilesenleriAdetTutari);
                                    var urunAgirlik = db5.UrunBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunBilesenleriAdetAgirlik);
                                    urunBilesenleriFiyat = Convert.ToDecimal(urunBirimFiyati);
                                    urunBilesenleriAgirlik = Convert.ToDecimal(urunAgirlik);
                                    item.Urunler.UrunBirimFiyati = urunBilesenleriFiyat + urunEkBilesenleriFiyat + urunEkMaliyetFiyat;
                                    item.Urunler.UrunAgirlik = urunBilesenleriAgirlik + urunEkBilesenleriAgirlik;
                                }
                            }
                            db5.SaveChanges();


                            UrunTanimla urunTanimla = (UrunTanimla)Application.OpenForms["UrunTanimla"];
                            if (Application.OpenForms["UrunTanimla"] != null)
                            {
                                urunTanimla.urunListele();
                                urunTanimla.bilesenDTWListele();
                            }
                            UrunListesi urunListesi = (UrunListesi)Application.OpenForms["UrunListesi"];
                            if (Application.OpenForms["UrunListesi"] != null)
                            {
                                urunListesi.urunListele();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sac güncellenmedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aynı sac zaten mevcut. Lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void Btn_SacSil_Click(object sender, EventArgs e)
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
                int id = Convert.ToInt32(txt_SacNo.Text);
                var sacKontrol = (from bs in db.BilesenSaclari
                                  join s in db.Saclar
                                  on bs.SacID equals s.SacID
                                  where bs.SacID == id
                                  select bs).FirstOrDefault();
                if (sacKontrol != null)
                {
                    MessageBox.Show("Silmek istediğiniz sac kullanılıyor. Lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var sacSil = (from s in db.Saclar
                                  where s.SacID == id
                                  select s).FirstOrDefault();


                    int kayitId = Convert.ToInt32(txt_SacNo.Text);
                    SiparisTakipEntities entity = new SiparisTakipEntities();
                    if (int.TryParse(grView_SacTablosu.GetFocusedRowCellValue("SacID").ToString(), out kayitId))
                    {
                        var silinecek = entity.Saclar.Where(kayit => kayit.SacID == kayitId).Single();
                        DialogResult sonuc = MessageBox.Show("'" + txt_SacAdi.Text + "'" + " " + "adlı sacı siliyorsunuz." + "\n" + "DİKKAT! Sacı silerseniz, saca ait tüm bilgiler silinecektir. Yine de silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            entity.Saclar.Remove(silinecek);
                            entity.SaveChanges();
                            sacListele();
                            MessageBox.Show("Sac silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            temizle();
                        }
                        else
                        {
                            MessageBox.Show("Sac silinmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void temizle()
        {
            btn_SacKaydet.Visible = true;
            btn_SacGuncelle.Visible = false;
            btn_SacSil.Visible = false;
            txt_SacNo.Text = string.Empty;
            txt_SacAdi.Text = string.Empty;
            txt_SacBirimFiyati.Text = string.Empty;
            grCtrl_SacTablosu.RefreshDataSource();
            grView_SacTablosu.ClearSelection();
        }

        private void Btn_Temizle_Click(object sender, EventArgs e)
        {
            temizle();
            grView_SacTablosu.FocusedRowHandle = 3;
        }

        private void Txt_SacAdi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
            txt_SacAdi.Text = txt_SacAdi.Text.ToUpper();
        }

        private void Txt_SacBirimFiyati_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_SacBirimFiyati_KeyPress(object sender, KeyPressEventArgs e)
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

        private void GrView_SacTablosu_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_SacTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void SacTanimla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Anaform anaform = (Anaform)Application.OpenForms["Anaform"];
            if (Application.OpenForms["Anaform"] != null)
            {
                anaform.BringToFront();
            }
        }
    }
}