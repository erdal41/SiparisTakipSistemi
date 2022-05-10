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
using SiparisTakipSistemi.Kullanici;
using SiparisTakipSistemi.Sistem;

namespace SiparisTakipSistemi.Bilesen
{
    public partial class BilesenTanimla : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;       

        public BilesenTanimla()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        private void BilesenTanimla_Load(object sender, EventArgs e)
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
                this.MinimumSize = new Size(957, 496);
                bilesenListele();
            }
        }

        public void bilesenListele()
        {
            BindingSource bilesenBS = new BindingSource();
            var bilesen = (from bl in db.Bilesenler
                           select new
                           {
                               bl.BilesenID,
                               bl.BilesenAdi,
                               bl.BilesenBirimi,
                               bl.BilesenAgirlik,
                               bl.BilesenBirimFiyati,
                           }).ToList(); 
            if (bilesen != null)
            {
                bilesenBS.DataSource = bilesen;
                grCtrl_BilesenTablosu.DataSource = bilesenBS;
            }
            else
            {
                MessageBox.Show("Bileşenler listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }              

        private void Btn_BilesenOlustur_Click(object sender, EventArgs e)
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
                if (txt_BilesenAdi.Text == "" || txt_BilesenAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_BilesenAdi, "Bileşen adını boş geçemezsiniz.");
                }
                else
                {
                    var bilesenKontrol = (from bl in db.Bilesenler
                                          where bl.BilesenAdi == txt_BilesenAdi.Text
                                          select bl).FirstOrDefault();
                    if (bilesenKontrol != null)
                    {
                        MessageBox.Show("Aynı bileşen mevcut. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Bilesenler bilesenler = new Bilesenler()
                        {
                            BilesenAdi = txt_BilesenAdi.Text,
                            BilesenAdet = 1,
                            BilesenBirimi = txt_BilesenBirimi.Text,
                            BilesenBirimFiyati = 0,
                            BilesenAgirlik = 0,
                            KaydedenID = KullaniciBilgileri.KaydedenID,
                            KayitTarihi = DateTime.Now,
                        };
                        db.Bilesenler.Add(bilesenler);
                        DialogResult sonuc = MessageBox.Show("'" + bilesenler.BilesenAdi + "'" + " " + "adlı bileşeni kaydetmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            txt_BilesenNo.Text = bilesenler.BilesenID.ToString();
                            pnl_Iki.Enabled = true;
                            sacCMBListele();
                            kutuProfilCMBListele();
                            btn_BileseniSil.Visible = true;
                            btn_BileseniSil.Location = new Point(268, 5);
                            btn_BilesenOlustur.Visible = false;
                            grCtrl_BilesenTablosu.Enabled = false;
                            btn_Temizle.Enabled = false;
                            tab_Menu.TabPages[0].PageEnabled = true;
                            tab_Menu.TabPages[1].PageEnabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Bileşen kaydedilmedi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        public void sacDTWListele()
        {
            if (txt_BilesenNo.Text != "" || txt_BilesenNo.Text != String.Empty)
            {
                BindingSource sacBS = new BindingSource();
                int bilesenNo = Convert.ToInt32(txt_BilesenNo.Text);
                var bilesenSaclari = (from bs in db.BilesenSaclari
                                      join bl in db.Bilesenler
                                      on bs.BilesenID equals bl.BilesenID
                                      join s in db.Saclar
                                      on bs.SacID equals s.SacID
                                      where bs.SacID == s.SacID && bs.BilesenID == bilesenNo
                                      select new
                                      {
                                          bs.BilesenSaclariID,
                                          bl.BilesenAdi,
                                          s.SacAdi,
                                          bs.SacAgirlik,
                                          bs.AgirlikTutari,
                                      });
                if (bilesenSaclari != null)
                {
                    sacBS.DataSource = bilesenSaclari.ToList();
                    grCtrl_SacTablosu.DataSource = sacBS;
                }
                else
                {
                    MessageBox.Show("Saclar listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sacCMBListele()
        {
            var sac = (from s in db.Saclar
                       orderby s.SacID ascending
                       select new
                       {
                           s.SacID,
                           s.SacAdi,
                       }).ToList();
            if (sac != null)
            {               
                cmb_Sac.Properties.DataSource = sac;
                cmb_Sac.Properties.DisplayMember = "SacAdi";
                cmb_Sac.Properties.ValueMember = "SacID";
            }
            else
            {
                MessageBox.Show("Saclar listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_SacEkle_Click(object sender, EventArgs e)
        {
            if (cmb_Sac.Text == "" || cmb_Sac == null || Convert.ToInt32(cmb_Sac.EditValue) == 0)
            {
                err_HataDurumu.SetError(cmb_Sac, "Sac seçiniz.");
            }
            else if (txt_SacAgirligi.Text == "" || txt_SacAgirligi.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_SacAgirligi, "Ağırlık giriniz.");
            }
            else
            {
                int secilenBilesenID = Convert.ToInt32(txt_BilesenNo.Text);
                int secilenSacID = Convert.ToInt32(cmb_Sac.EditValue);
                var sacKontrol = (from bs in db.BilesenSaclari
                                  join bl in db.Bilesenler
                                  on bs.BilesenID equals bl.BilesenID
                                  where bs.SacID == secilenSacID && bs.BilesenID == secilenBilesenID
                                  select bs).FirstOrDefault();
                if (sacKontrol != null)
                {
                    MessageBox.Show("Aynı sac seçilmiş. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    decimal agirlikTutari = 0;
                    decimal toplamTutar = 0;
                    decimal toplamAgirlik = 0;
                    decimal birimFiyati = 0;
                    decimal sacAgirlik = Convert.ToDecimal(txt_SacAgirligi.Text);
                    int sacID = Convert.ToInt32(cmb_Sac.EditValue);
                    var sac = (from s in db.Saclar
                               where s.SacID == sacID
                               select s).FirstOrDefault();
                    if (sac != null)
                    {
                        birimFiyati = Convert.ToDecimal(sac.SacBirimFiyati);
                        agirlikTutari = birimFiyati * sacAgirlik;

                        BilesenSaclari bilesenSaclari = new BilesenSaclari()
                        {
                            BilesenID = Convert.ToInt32(txt_BilesenNo.Text),
                            SacID = Convert.ToInt32(cmb_Sac.EditValue),
                            SacAgirlik = sacAgirlik,
                            AgirlikTutari = agirlikTutari,
                        };
                        db.BilesenSaclari.Add(bilesenSaclari);
                        db.SaveChanges();
                        sacDTWListele();
                        grView_SacTablosu.MoveLast();

                        for (int i = 0; i < grView_SacTablosu.RowCount; i++)
                        {
                            toplamAgirlik += Convert.ToDecimal(grView_SacTablosu.GetRowCellValue(i, "SacAgirlik"));
                            toplamTutar += Convert.ToDecimal(grView_SacTablosu.GetRowCellValue(i, "AgirlikTutari"));
                        }
                        txt_BilesenBirimFiyati.Text = toplamTutar.ToString();
                        txt_BilesenAgirligi.Text = toplamAgirlik.ToString();
                        btn_BilesenKaydet.Enabled = true;
                        btn_BilesenGuncelle.Enabled = true;
                        btn_Temizle.Enabled = true;
                        tab_Menu.TabPages[1].PageEnabled = false;
                    }
                }
            }
        }

        private void Btn_SacSil_Click(object sender, EventArgs e)
        {
            if (grView_SacTablosu.RowCount > 0)
            {
                decimal toplamTutar = 0;
                decimal toplamAgirlik = 0;
                int[] secilenler = grView_SacTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_SacTablosu.GetRowCellValue(secilenler[0], "BilesenSaclariID"));
                var sacSil = (from bs in db.BilesenSaclari
                              where bs.BilesenSaclariID == id
                              select bs).FirstOrDefault();
                db.BilesenSaclari.Remove(sacSil);
                db.SaveChanges();
                sacDTWListele();
                grView_SacTablosu.ClearSelection();

                if (txt_SacAgirligi.Text != "" || txt_SacAgirligi.Text == String.Empty)
                {
                    for (int i = 0; i < grView_SacTablosu.RowCount; i++)
                    {
                        toplamAgirlik += Convert.ToDecimal(grView_SacTablosu.GetRowCellValue(i, "SacAgirlik"));
                        toplamTutar += Convert.ToDecimal(grView_SacTablosu.GetRowCellValue(i, "AgirlikTutari"));
                    }
                    txt_BilesenBirimFiyati.Text = toplamTutar.ToString();
                    txt_BilesenAgirligi.Text = toplamAgirlik.ToString();
                }
            }
            else if (grView_SacTablosu.RowCount == 0)
            {
                grCtrl_SacTablosu.DataSource = null;
                tab_Menu.TabPages[1].Enabled = true;
            }
            else
            {
                grCtrl_SacTablosu.DataSource = null;
            }
        }

        private void Btn_BilesenKaydet_Click(object sender, EventArgs e)
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
                int id = Convert.ToInt32(txt_BilesenNo.Text);
                if (txt_BilesenAdi.Text == "" || txt_BilesenAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_BilesenAdi, "Bileşen oluşturulmamış. Lütfen Kontrol ediniz.");
                }
                else if (txt_BilesenBirimFiyati.Text == "0,00" || txt_BilesenBirimFiyati.Text == "0" || txt_BilesenBirimFiyati.Text == String.Empty || txt_BilesenAgirligi.Text == "0,00" || txt_BilesenAgirligi.Text == "0" || txt_BilesenAgirligi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_BilesenBirimFiyati, "Seçilen sacın fiyatını veya miktarını kontrol ediniz.");
                    err_HataDurumu.SetError(txt_BilesenAgirligi, "Seçilen sacın fiyatını veya miktarını kontrol ediniz.");
                }
                else
                {
                    var bilesenKontrol = (from bl in db.Bilesenler
                                          where bl.BilesenID != id && bl.BilesenAdi == txt_BilesenAdi.Text
                                          select bl).FirstOrDefault();
                    if (bilesenKontrol != null)
                    {
                        MessageBox.Show("Aynı bileşen mevcut. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var bilesen = (from bl in db.Bilesenler
                                       where bl.BilesenID == id
                                       select bl).FirstOrDefault();
                        bilesen.BilesenAdi = txt_BilesenAdi.Text;
                        bilesen.BilesenAdet = 1;
                        bilesen.BilesenBirimi = txt_BilesenBirimi.Text;
                        bilesen.BilesenBirimFiyati = Convert.ToDecimal(txt_BilesenBirimFiyati.Text);
                        bilesen.BilesenAgirlik = Convert.ToDecimal(txt_BilesenAgirligi.Text);
                        bilesen.KaydedenID = KullaniciBilgileri.KaydedenID;
                        bilesen.KayitTarihi = DateTime.Now;

                        DialogResult sonuc = MessageBox.Show("'" + bilesen.BilesenAdi + "'" + " " + "adlı bileşeni kaydetmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            bilesenListele();
                            kutuProfilCMBListele();
                            txt_KProfilUzunluk.Text = string.Empty;
                            MessageBox.Show("Bileşen kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            temizle();
                            grView_BilesenTablosu.MoveLast();
                            btn_Temizle.Enabled = true;
                            grCtrl_BilesenTablosu.Enabled = true;
                            pnl_Iki.Enabled = false;
                            UrunTanimla urunTanimla = (UrunTanimla)Application.OpenForms["UrunTanimla"];
                            if (Application.OpenForms["UrunTanimla"] != null)
                            {
                                urunTanimla.bilesenCMBListele();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bileşen kaydedilmedi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void Btn_BilesenGuncelle_Click(object sender, EventArgs e)
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
                int id = Convert.ToInt32(txt_BilesenNo.Text);             
                if (txt_BilesenAdi.Text == "" || txt_BilesenAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_BilesenAdi, "Bileşen oluşturulmamış. Lütfen Kontrol ediniz.");
                }
                else if (txt_BilesenBirimFiyati.Text == "0,00" || txt_BilesenBirimFiyati.Text == "0" || txt_BilesenBirimFiyati.Text == String.Empty || txt_BilesenAgirligi.Text == "0,00" || txt_BilesenAgirligi.Text == "0" || txt_BilesenAgirligi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_BilesenBirimFiyati, "Seçilen sacın fiyatını veya miktarını kontrol ediniz.");
                    err_HataDurumu.SetError(txt_BilesenAgirligi, "Seçilen sacın fiyatını veya miktarını kontrol ediniz.");
                }
                else
                {
                    var bilesenKontrol = (from bl in db.Bilesenler
                                          where bl.BilesenID != id && bl.BilesenAdi == txt_BilesenAdi.Text
                                          select bl).FirstOrDefault();
                    if (bilesenKontrol == null)
                    {
                        var bilesen = (from bl in db.Bilesenler
                                       where bl.BilesenID == id
                                       select bl).FirstOrDefault();
                        bilesen.BilesenAdi = txt_BilesenAdi.Text;
                        bilesen.BilesenAdet = 1;
                        bilesen.BilesenBirimi = txt_BilesenBirimi.Text;
                        bilesen.BilesenBirimFiyati = Convert.ToDecimal(txt_BilesenBirimFiyati.Text);
                        bilesen.BilesenAgirlik = Convert.ToDecimal(txt_BilesenAgirligi.Text);
                        bilesen.KaydedenID = KullaniciBilgileri.KaydedenID;
                        bilesen.KayitTarihi = DateTime.Now;

                        DialogResult sonuc = MessageBox.Show("'" + bilesen.BilesenAdi + "'" + " " + "adlı bileşeni güncellemek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            int focuedRowHandle = grView_BilesenTablosu.FocusedRowHandle;
                            bilesenListele();
                            grView_BilesenTablosu.FocusedRowHandle = focuedRowHandle;
                            MessageBox.Show("Bileşen güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            decimal urunBilesenleriAgirlik = 0;
                            decimal urunBilesenleriFiyat = 0;
                            decimal urunEkBilesenleriAgirlik = 0;
                            decimal urunEkBilesenleriFiyat = 0;
                            decimal urunEkMaliyetFiyat = 0;
                            SiparisTakipEntities db1 = new SiparisTakipEntities();
                            var urunGuncelle1 = (from ueb in db1.UrunEkBilesenleri
                                                 join u in db1.Urunler
                                                 on ueb.UrunID equals u.UrunID
                                                 join ebl in db1.EkBilesenler
                                                 on ueb.EkBilesenID equals ebl.EkBilesenID
                                                 where ueb.UrunID == u.UrunID
                                                 select ueb).ToList();
                            if (urunGuncelle1 != null)
                            {
                                foreach (var item in urunGuncelle1)
                                {
                                    var urunAgirlik = db1.UrunEkBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunEkBilesenleriAdetAgirlik);
                                    var urunBirimFiyati = db1.UrunEkBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunEkBilesenleriAdetTutari);
                                    urunEkBilesenleriFiyat = Convert.ToDecimal(urunBirimFiyati);
                                    urunEkBilesenleriAgirlik = Convert.ToDecimal(urunAgirlik);
                                }
                            }

                            SiparisTakipEntities db2 = new SiparisTakipEntities();
                            var urunGuncelle2 = (from uim in db2.UrunEkIslemMaliyetleri
                                                 join u in db2.Urunler
                                                 on uim.UrunID equals u.UrunID
                                                 join eim in db2.EkIslemMaliyeti
                                                 on uim.EkIslemMaliyetiID equals eim.EkIslemMaliyetiID
                                                 where uim.UrunID == u.UrunID
                                                 select uim).ToList();
                            if (urunGuncelle2 != null)
                            {
                                foreach (var item in urunGuncelle2)
                                {
                                    var urunBirimFiyati = db2.UrunEkIslemMaliyetleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunEkIslemMaliyetleriFiyati);
                                    urunEkMaliyetFiyat = Convert.ToDecimal(urunBirimFiyati);
                                }
                            }

                            decimal adet = 0;
                            decimal adetAgirlik = 0;
                            decimal adetTutari = 0;
                            decimal bilesenBirimFiyati = 0;
                            decimal bilesenAgirlik = 0;
                            SiparisTakipEntities db3 = new SiparisTakipEntities();
                            var urunBilesenleriGuncelle = (from ub in db3.UrunBilesenleri
                                                           join u in db3.Urunler
                                                           on ub.UrunID equals u.UrunID
                                                           join bl in db3.Bilesenler
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
                            db3.SaveChanges();

                            SiparisTakipEntities db4 = new SiparisTakipEntities();
                            var urunGuncelle3 = (from ub in db4.UrunBilesenleri
                                                 join u in db4.Urunler
                                                 on ub.UrunID equals u.UrunID
                                                 join bl in db4.Bilesenler
                                                 on ub.BilesenID equals bl.BilesenID
                                                 where ub.UrunID == u.UrunID
                                                 select ub).ToList();
                            if (urunGuncelle3 != null)
                            {
                                foreach (var item in urunGuncelle3)
                                {
                                    var urunBirimFiyati = db4.UrunBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunBilesenleriAdetTutari);
                                    var urunAgirlik = db4.UrunBilesenleri.Where(x => x.UrunID == item.Urunler.UrunID).Sum(x => x.UrunBilesenleriAdetAgirlik);
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
                            db4.SaveChanges();

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
                            MessageBox.Show("Bileşen güncellendi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aynı bileşen zaten mevcut. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void Btn_BileseniSil_Click(object sender, EventArgs e)
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
                if (txt_BilesenNo.Text != "" || txt_BilesenNo.Text != String.Empty)
                {
                    int id = Convert.ToInt32(txt_BilesenNo.Text);
                    var urunKontrol = (from ub in db.UrunBilesenleri
                                       join bl in db.Bilesenler
                                       on ub.BilesenID equals bl.BilesenID
                                       where ub.BilesenID == id
                                       select ub).FirstOrDefault();
                    if (urunKontrol != null)
                    {
                        MessageBox.Show("Silmek istediğiniz bileşen ürün için kullanılmış. Bu yüzden bileşeni silemezsiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var bilesenSil = (from bl in db.Bilesenler
                                          where bl.BilesenID == id
                                          select bl).FirstOrDefault();

                        db.BilesenSaclari.RemoveRange(db.BilesenSaclari.Where(x => x.BilesenID == id));
                        db.BilesenKProfilleri.RemoveRange(db.BilesenKProfilleri.Where(x => x.BilesenID == id));

                        DialogResult sonuc = MessageBox.Show("'" + bilesenSil.BilesenAdi + "'" + " " + "adlı bileşeni siliyorsunuz." + "\n" + "DİKKAT! Sacı silerseniz, saca ait tüm bilgiler silinecektir. Yine de silmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.Bilesenler.Remove(bilesenSil);
                            db.SaveChanges();
                            bilesenListele();
                            kutuProfilCMBListele();
                            sacCMBListele();
                            txt_SacAgirligi.Text = string.Empty;
                            txt_KProfilUzunluk.Text = string.Empty;
                            grCtrl_SacTablosu.DataSource = null;
                            grCtrl_KProfilTablosu.DataSource = null;
                            MessageBox.Show("Bileşen silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pnl_Iki.Enabled = false;
                            btn_BilesenKaydet.Enabled = false;
                            btn_BilesenGuncelle.Enabled = false;
                            btn_Temizle.Enabled = true;
                            grCtrl_BilesenTablosu.Enabled = true;
                            temizle();
                        }
                        else
                        {
                            MessageBox.Show("Sac silinmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek bileşeni seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void temizle()
        {
            btn_BilesenOlustur.Visible = true;
            btn_BileseniSil.Visible = false;
            btn_BilesenKaydet.Visible = true;
            btn_BilesenGuncelle.Visible = false;
            txt_BilesenNo.Text = string.Empty;
            txt_BilesenAdi.Text = string.Empty;
            sacCMBListele();
            kutuProfilCMBListele();
            txt_SacAgirligi.Text = string.Empty;
            grCtrl_SacTablosu.DataSource = null;
            txt_BilesenBirimFiyati.Text = string.Empty;
            txt_BilesenAgirligi.Text = string.Empty;
            grView_BilesenTablosu.ClearSelection();
            btn_BilesenKaydet.Enabled = false;
            pnl_Iki.Enabled = false;
        }

        private void Btn_Temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void GrView_BilesenTablosu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (grView_BilesenTablosu.RowCount > 0)
            {
                int[] secilenler = grView_BilesenTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_BilesenTablosu.GetRowCellValue(secilenler[0], "BilesenID"));
                var bilesenGetir = (from bl in db.Bilesenler.AsNoTracking()
                                    where bl.BilesenID == id
                                    select new
                                    {
                                        bl.BilesenID,
                                        bl.BilesenAdi,
                                        bl.BilesenBirimi,
                                        bl.BilesenAgirlik,
                                        bl.BilesenBirimFiyati,
                                    }).FirstOrDefault();
                if (bilesenGetir != null)
                {
                    txt_BilesenNo.Text = bilesenGetir.BilesenID.ToString();
                    txt_BilesenAdi.Text = bilesenGetir.BilesenAdi.ToString();
                    txt_BilesenBirimi.Text = bilesenGetir.BilesenBirimi.ToString();
                    txt_BilesenAgirligi.Text = bilesenGetir.BilesenAgirlik.ToString();
                    txt_BilesenBirimFiyati.Text = bilesenGetir.BilesenBirimFiyati.ToString();

                }

                btn_BilesenGuncelle.Enabled = true;
                btn_Temizle.Enabled = true;
                pnl_Iki.Enabled = true;
                btn_BilesenOlustur.Visible = false;
                btn_BileseniSil.Visible = true;
                btn_BileseniSil.Location = new Point(268, 5);
                btn_BilesenKaydet.Visible = false;
                btn_BilesenGuncelle.Visible = true;
                btn_BilesenGuncelle.Location = new Point(85, 102);
                sacCMBListele();
                kutuProfilCMBListele();

                var sacKontrol = (from bs in db.BilesenSaclari
                                  join bl in db.Bilesenler
                                  on bs.BilesenID equals bl.BilesenID
                                  where bs.BilesenID == id
                                  select bs).FirstOrDefault();
                var kutuProfilKontrol = (from bk in db.BilesenKProfilleri
                                         join bl in db.Bilesenler
                                         on bk.BilesenID equals bl.BilesenID
                                         where bk.BilesenID == id
                                         select bk).FirstOrDefault();
                if (sacKontrol != null)
                {
                    BindingSource bilesenSaclariBS = new BindingSource();
                    var bilesenSaclari = (from bs in db.BilesenSaclari
                                          join bl in db.Bilesenler
                                          on bs.BilesenID equals bl.BilesenID
                                          join s in db.Saclar
                                          on bs.SacID equals s.SacID
                                          where bs.BilesenID == id
                                          select new
                                          {
                                              bs.BilesenSaclariID,
                                              bl.BilesenAdi,
                                              s.SacAdi,
                                              bs.SacAgirlik,
                                              bs.AgirlikTutari,
                                          });
                    if (bilesenSaclari != null)
                    {
                        bilesenSaclariBS.DataSource = bilesenSaclari.ToList();
                        grCtrl_SacTablosu.DataSource = bilesenSaclariBS;
                        tab_Menu.SelectedTabPage = tab_Sac;
                        tab_Menu.TabPages[0].PageEnabled = true;
                        tab_Menu.TabPages[1].PageEnabled = false;
                    }
                }
                else if (kutuProfilKontrol != null)
                {
                    BindingSource bilesenKProfilleriBS = new BindingSource();
                    var bilesenKutuProfilleri = (from bk in db.BilesenKProfilleri
                                                 join bl in db.Bilesenler
                                                 on bk.BilesenID equals bl.BilesenID
                                                 join kp in db.KutuProfiller
                                                 on bk.KProfilID equals kp.KProfilID
                                                 where bk.BilesenID == id
                                                 select new
                                                 {
                                                     bk.BilesenKProfilID,
                                                     bl.BilesenAdi,
                                                     kp.KProfilAdi,
                                                     bk.KProfilAgirlik,
                                                     bk.KProfiUzunluk,
                                                     bk.UzunlukTutari,
                                                 });
                    if (bilesenKutuProfilleri != null)
                    {
                        bilesenKProfilleriBS.DataSource = bilesenKutuProfilleri.ToList();
                        grCtrl_KProfilTablosu.DataSource = bilesenKProfilleriBS;
                        tab_Menu.SelectedTabPage = tab_KutuProfil;
                        tab_Menu.TabPages[0].PageEnabled = false;
                        tab_Menu.TabPages[1].PageEnabled = true;
                    }
                }

                var bilesen = (from bl in db.Bilesenler
                               where bl.BilesenID == id
                               select bl).FirstOrDefault();
                if (bilesen != null)
                {
                    txt_BilesenBirimFiyati.Text = bilesen.BilesenBirimFiyati.ToString();
                    txt_BilesenAgirligi.Text = bilesen.BilesenAgirlik.ToString();
                }
            }
        }

        private void Txt_BilesenBirimFiyati_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_BilesenAgirligi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_SacAgirligi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Cmb_Sac_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_SacAgirligi_KeyPress(object sender, KeyPressEventArgs e)
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
      
        public void kutuProfilDTWListele()
        {
            BindingSource kutuProfilBS = new BindingSource();
            int bilesenNo = Convert.ToInt32(txt_BilesenNo.Text);
            var bilesenKutuProfilleri = (from bk in db.BilesenKProfilleri
                                         join bl in db.Bilesenler
                                         on bk.BilesenID equals bl.BilesenID
                                         join kp in db.KutuProfiller
                                         on bk.KProfilID equals kp.KProfilID
                                         where bk.KProfilID == kp.KProfilID && bk.BilesenID == bilesenNo
                                         select new
                                         {
                                             bk.BilesenKProfilID,
                                             bl.BilesenAdi,
                                             kp.KProfilAdi,
                                             bk.KProfilAgirlik,
                                             bk.KProfiUzunluk,
                                             bk.UzunlukTutari,
                                         });
            if (bilesenKutuProfilleri != null)
            {
                kutuProfilBS.DataSource = bilesenKutuProfilleri.ToList();
                grCtrl_KProfilTablosu.DataSource = kutuProfilBS;
            }
            else
            {
                MessageBox.Show("Kutu Profiller listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kutuProfilCMBListele()
        {
            var kutuProfil = (from kp in db.KutuProfiller
                              orderby kp.KProfilID ascending
                              select new
                              {
                                  kp.KProfilID,
                                  kp.KProfilAdi,
                              }).ToList();
            if (kutuProfil != null)
            {                
                cmb_KProfil.Properties.DataSource = kutuProfil;
                cmb_KProfil.Properties.DisplayMember = "KProfilAdi";
                cmb_KProfil.Properties.ValueMember = "KProfilID";
            }
            else
            {
                MessageBox.Show("Saclar listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_KProfilEkle_Click(object sender, EventArgs e)
        {
            int secilenKutuProfilID = Convert.ToInt32(cmb_KProfil.EditValue);
            int secilenBilesenID = Convert.ToInt32(txt_BilesenNo.Text);
            if (cmb_KProfil.Text == "" || cmb_KProfil.EditValue == null || secilenKutuProfilID == 0)
            {
                err_HataDurumu.SetError(cmb_KProfil, "Kutu Profil seçiniz.");
            }
            else if (txt_KProfilUzunluk.Text == "" || txt_KProfilUzunluk.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_SacAgirligi, "Uzunluk giriniz.");
            }
            else
            {
                var sacKontrol = (from bk in db.BilesenKProfilleri
                                  join bl in db.Bilesenler
                                  on bk.BilesenID equals bl.BilesenID
                                  where bk.KProfilID == secilenKutuProfilID && bk.BilesenID == secilenBilesenID
                                  select bk).FirstOrDefault();
                if (sacKontrol != null)
                {
                    MessageBox.Show("Aynı kutu profil seçilmiş. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    decimal agirlik = 0;
                    decimal uzunlukTutari = 0;
                    decimal toplamTutar = 0;
                    decimal toplamAgirlik = 0;
                    decimal kProfilAgirlik = 0;
                    decimal birimFiyati = 0;
                    decimal kutuProfilUzunluk = Convert.ToDecimal(txt_KProfilUzunluk.Text);
                    int kutuProfilID = Convert.ToInt32(cmb_KProfil.EditValue);
                    var kutuProfil = (from kp in db.KutuProfiller
                                      where kp.KProfilID == kutuProfilID
                                      select kp).FirstOrDefault();
                    if (kutuProfil != null)
                    {
                        birimFiyati = Convert.ToDecimal(kutuProfil.KProfilBirimFiyati);
                        kProfilAgirlik = Convert.ToDecimal(kutuProfil.KProfilAgirlik);
                        agirlik = kProfilAgirlik * kutuProfilUzunluk;
                        uzunlukTutari = birimFiyati * kutuProfilUzunluk;

                        BilesenKProfilleri BilesenKProfilleri = new BilesenKProfilleri()
                        {
                            BilesenID = Convert.ToInt32(txt_BilesenNo.Text),
                            KProfilID = Convert.ToInt32(cmb_KProfil.EditValue),
                            KProfilAgirlik = agirlik,
                            KProfiUzunluk = kutuProfilUzunluk,
                            UzunlukTutari = uzunlukTutari,
                        };
                        db.BilesenKProfilleri.Add(BilesenKProfilleri);
                        db.SaveChanges();
                        kutuProfilDTWListele();
                        grView_KProfilTablosu.MoveLast();

                        for (int i = 0; i < grView_KProfilTablosu.RowCount; i++)
                        {
                            toplamAgirlik += Convert.ToDecimal(grView_KProfilTablosu.GetRowCellValue(i, "KProfilAgirlik"));
                            toplamTutar += Convert.ToDecimal(grView_KProfilTablosu.GetRowCellValue(i, "UzunlukTutari"));
                        }
                        txt_BilesenBirimFiyati.Text = toplamTutar.ToString();
                        txt_BilesenAgirligi.Text = toplamAgirlik.ToString();
                        txt_BilesenBirimi.Enabled = true;
                        btn_BilesenKaydet.Enabled = true;
                        btn_BilesenGuncelle.Enabled = true;
                        btn_Temizle.Enabled = true;
                        tab_Menu.TabPages[0].PageEnabled = false;
                    }
                }
            }
        }

        private void Btn_KProfilSil_Click(object sender, EventArgs e)
        {
            if (grView_KProfilTablosu.RowCount > 0)
            {
                decimal toplamTutar = 0;
                decimal toplamAgirlik = 0;
                int[] secilenler = grView_KProfilTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_KProfilTablosu.GetRowCellValue(secilenler[0], "BilesenKProfilID"));
                var kutuProfilSil = (from bk in db.BilesenKProfilleri
                                     where bk.BilesenKProfilID == id
                                     select bk).FirstOrDefault();
                db.BilesenKProfilleri.Remove(kutuProfilSil);
                db.SaveChanges();
                kutuProfilDTWListele();
                grView_KProfilTablosu.ClearSelection();
                if (txt_KProfilUzunluk.Text != "" || txt_KProfilUzunluk.Text == String.Empty)
                {
                    for (int i = 0; i < grView_KProfilTablosu.RowCount; i++)
                    {
                        toplamAgirlik += Convert.ToDecimal(grView_KProfilTablosu.GetRowCellValue(i, "KProfilAgirlik"));
                        toplamTutar += Convert.ToDecimal(grView_KProfilTablosu.GetRowCellValue(i, "UzunlukTutari"));
                    }
                    txt_BilesenBirimFiyati.Text = toplamTutar.ToString();
                    txt_BilesenAgirligi.Text = toplamAgirlik.ToString();
                }
            }
            else if (grView_KProfilTablosu.RowCount == 0)
            {
                grCtrl_KProfilTablosu.DataSource = null;
                tab_Menu.TabPages[0].Enabled = true;
            }
            else
            {
                grCtrl_KProfilTablosu.DataSource = null;
            }
        }

        private void Txt_BilesenAdi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
            txt_BilesenAdi.Text = txt_BilesenAdi.Text.ToUpper();
        }

        private void Txt_KProfilUzunluk_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Cmb_KProfil_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_KProfilUzunluk_KeyPress(object sender, KeyPressEventArgs e)
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

        private void GrView_BilesenTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_BilesenTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }

        }

        private void GrView_SacTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_SacTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void GrView_KProfilTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_KProfilTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }

        }

        private void BilesenTanimla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txt_BilesenNo.Text != "" || txt_BilesenNo.Text != String.Empty)
            {
                int id = Convert.ToInt32(txt_BilesenNo.Text);
                var bilesenKontrol = (from bl in db.Bilesenler
                                   where bl.BilesenID == id && bl.BilesenBirimFiyati == 0m
                                   select bl).FirstOrDefault();
                if (bilesenKontrol != null)
                {
                    DialogResult result = MessageBox.Show("Bileşen oluşturma işlemi yarım bırakıldı. Yarım bırakılan bileşen oluşturma işlemini iptal etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        var bilesenSil = (from bl in db.Bilesenler
                                       where bl.BilesenID == id
                                       select bl).FirstOrDefault();

                        db.BilesenSaclari.RemoveRange(db.BilesenSaclari.Where(x => x.BilesenID == id));
                        db.BilesenKProfilleri.RemoveRange(db.BilesenKProfilleri .Where(x => x.BilesenID == id));

                        db.Bilesenler.Remove(bilesenSil);
                        db.SaveChanges();
                        temizle();
                        MessageBox.Show("Bileşen oluşturma işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        e.Cancel = true;                     
                            
                    }
                }
            }            
        }

        private void BilesenTanimla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Anaform anaform = (Anaform)Application.OpenForms["Anaform"];
            if (Application.OpenForms["Anaform"] != null)
            {
                anaform.BringToFront();
            }
        }
    }
}