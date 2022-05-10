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
using SiparisTakipSistemi.Kullanici;
using SiparisTakipSistemi.Sistem;

namespace SiparisTakipSistemi.Urun
{
    public partial class UrunTanimla : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public UrunTanimla()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        private void UrunTanimla_Load(object sender, EventArgs e)
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
                urunListele();
                this.MinimumSize = new Size(957, 496);
            }          
            
        }

        public void urunListele()
        {
            BindingSource bindingSourceUrun = new BindingSource();
            var urun = (from u in db.Urunler
                        select new
                        {
                            u.UrunID,
                            u.UrunAdi,
                            u.UrunBirimi,
                            u.UrunAgirlik,
                            u.UrunBirimFiyati,
                        }).ToList();
            if (urun != null)
            {
                bindingSourceUrun.DataSource = urun;
                grCtrl_UrunTablosu.DataSource = bindingSourceUrun;
                grView_UrunTablosu.ClearSelection();
            }
            else
            {
                MessageBox.Show("Ürünler listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_UrunOlustur_Click(object sender, EventArgs e)
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
                if (txt_UrunAdi.Text == "" || txt_UrunAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_UrunAdi, "Ürün adı giriniz.");
                }
                else
                {
                    var urunKontrol = (from u in db.Urunler
                                       where u.UrunAdi == txt_UrunAdi.Text
                                       select u).FirstOrDefault();
                    if (urunKontrol != null)
                    {
                        MessageBox.Show("Aynı ürün mevcut. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Urunler urunler = new Urunler()
                        {
                            UrunAdi = txt_UrunAdi.Text,
                            UrunAdet = 1,
                            UrunBirimi = txt_UrunBirimi.Text,
                            UrunBirimFiyati = 0,
                            UrunAgirlik = 0,
                            KaydedenID = KullaniciBilgileri.KaydedenID,
                            KayitTarihi = DateTime.Now,
                        };
                        db.Urunler.Add(urunler);
                        DialogResult sonuc = MessageBox.Show("'" + urunler.UrunAdi + "'" + " " + "adlı ürünü kaydetmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            txt_UrunNo.Text = urunler.UrunID.ToString();
                            pnl_Iki.Enabled = true;
                            btn_UrunOlustur.Visible = false;
                            btn_UrunuSil.Visible = true;
                            btn_UrunuSil.Location = new Point(268, 5);
                            bilesenCMBListele();
                            ekBilesenCMBListele();
                            ekIslemMaliyetiCMBListele();
                            grCtrl_UrunTablosu.Enabled = false;
                            btn_Temizle.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Ürün kaydedilmedi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        public void bilesenDTWListele()
        {
            BindingSource bindingSourceUrunBilesenleri = new BindingSource();
            int id = Convert.ToInt32(txt_UrunNo.Text);
            var urunBilesenleri = (from ub in db.UrunBilesenleri
                                   join u in db.Urunler
                                   on ub.UrunID equals u.UrunID
                                   join bl in db.Bilesenler
                                   on ub.BilesenID equals bl.BilesenID
                                   where ub.BilesenID == bl.BilesenID && ub.UrunID == id
                                   select new
                                   {
                                       ub.UrunBilesenleriID,
                                       u.UrunAdi,
                                       bl.BilesenAdi,
                                       ub.UrunBilesenleriAdet,
                                       ub.UrunBilesenleriAdetAgirlik,
                                       ub.UrunBilesenleriAdetTutari,
                                   }).ToList();
            if (urunBilesenleri != null)
            {
                bindingSourceUrunBilesenleri.DataSource = urunBilesenleri;
                grCtrl_BilesenTablosu.DataSource = bindingSourceUrunBilesenleri;
                grView_BilesenTablosu.ClearSelection();
            }
            else
            {
                MessageBox.Show("Bileşenler listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void bilesenCMBListele()
        {
            var bilesen = (from bl in db.Bilesenler
                           orderby bl.BilesenID ascending
                           select new
                           {
                               bl.BilesenID,
                               bl.BilesenAdi,
                           }).ToList();
            if (bilesen != null)
            {
                cmb_Bilesen.Properties.DataSource = bilesen;
                cmb_Bilesen.Properties.DisplayMember = "BilesenAdi";
                cmb_Bilesen.Properties.ValueMember = "BilesenID";
            }
            else
            {
                MessageBox.Show("Bileşenler listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ekBilesenDTWListele()
        {
            BindingSource bindingSourceEkBilesen = new BindingSource();
            int id = Convert.ToInt32(txt_UrunNo.Text);
            var urunEkBilesenleri = (from ueb in db.UrunEkBilesenleri
                                     join u in db.Urunler
                                     on ueb.UrunID equals u.UrunID
                                     join ebl in db.EkBilesenler
                                     on ueb.EkBilesenID equals ebl.EkBilesenID
                                     where ueb.EkBilesenID == ebl.EkBilesenID && ueb.UrunID == id
                                     select new
                                     {
                                         ueb.UrunEkBilesenleriID,
                                         u.UrunAdi,
                                         ebl.EkBilesenAdi,
                                         ueb.UrunEkBilesenleriAdet,
                                         ueb.UrunEkBilesenleriAdetAgirlik,
                                         ueb.UrunEkBilesenleriAdetTutari,
                                     }).ToList();
            if (urunEkBilesenleri != null)
            {
                bindingSourceEkBilesen.DataSource = urunEkBilesenleri;
                grCtrl_EkBilesenTablosu.DataSource = bindingSourceEkBilesen;
                grView_EkBilesenTablosu.ClearSelection();
            }
            else
            {
                MessageBox.Show("Ek Bilesenler listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ekBilesenCMBListele()
        {
            var ekBilesen = (from ebl in db.EkBilesenler
                             orderby ebl.EkBilesenID ascending
                             select new
                             {
                                 ebl.EkBilesenID,
                                 ebl.EkBilesenAdi,
                             }).ToList();
            if (ekBilesen != null)
            {
                cmb_EkBilesen.Properties.DataSource = ekBilesen;
                cmb_EkBilesen.Properties.DisplayMember = "EkBilesenAdi";
                cmb_EkBilesen.Properties.ValueMember = "EkBilesenID";
            }
            else
            {
                MessageBox.Show("Ek Bileşenler listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ekIslemMaliyetiCMBListele()
        {
            var ekIslemMaliyeti = (from eim in db.EkIslemMaliyeti
                                   orderby eim.EkIslemMaliyetiID ascending
                                   select new
                                   {
                                       eim.EkIslemMaliyetiID,
                                       eim.EkIslemMaliyetiAdi,
                                   }).ToList();
            if (ekIslemMaliyeti != null)
            {
                cmb_EkIslemMaliyeti.Properties.DataSource = ekIslemMaliyeti;
                cmb_EkIslemMaliyeti.Properties.DisplayMember = "EkIslemMaliyetiAdi";
                cmb_EkIslemMaliyeti.Properties.ValueMember = "EkIslemMaliyetiID";
            }
            else
            {
                MessageBox.Show("Ek Maliyetler listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ekIslemMaliyetiDTWListele()
        {
            BindingSource bindingSourceEIslemMaliyeti = new BindingSource();
            int id = Convert.ToInt32(txt_UrunNo.Text);
            var urunEkIslemMaliyetleri = (from uem in db.UrunEkIslemMaliyetleri
                                          join u in db.Urunler
                                          on uem.UrunID equals u.UrunID
                                          join eim in db.EkIslemMaliyeti
                                          on uem.EkIslemMaliyetiID equals eim.EkIslemMaliyetiID
                                          where uem.EkIslemMaliyetiID == eim.EkIslemMaliyetiID && uem.UrunID == id
                                          select new
                                          {
                                              uem.UrunEkIslemMaliyetleriID,
                                              u.UrunAdi,
                                              eim.EkIslemMaliyetiAdi,
                                              uem.UrunEkIslemMaliyetleriUzunluk,
                                              uem.UrunEkIslemMaliyetleriFiyati,
                                          }).ToList();
            if (urunEkIslemMaliyetleri != null)
            {
                bindingSourceEIslemMaliyeti.DataSource = urunEkIslemMaliyetleri;
                grCtrl_EkIslemMaliyetTablosu.DataSource = bindingSourceEIslemMaliyeti;
                grView_EkIslemMaliyetTablosu.ClearSelection();
            }
            else
            {
                MessageBox.Show("Ek Maliyetler listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_BilesenEkle_Click(object sender, EventArgs e)
        {
            if (cmb_Bilesen.Text == "" || cmb_Bilesen == null || Convert.ToInt32(cmb_Bilesen.EditValue) == 0)
            {
                err_HataDurumu.SetError(cmb_Bilesen, "Bileşen seçiniz.");
            }
            else if (txt_BilesenAdeti.Text == "" || txt_BilesenAdeti.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_BilesenAdeti, "Adet giriniz.");
            }
            else
            {
                int secilenUrunID = Convert.ToInt32(txt_UrunNo.Text);
                int secilenBilesenID = Convert.ToInt32(cmb_Bilesen.EditValue);
                var bilesenKontrol = (from ub in db.UrunBilesenleri
                                      join u in db.Urunler
                                      on ub.UrunID equals u.UrunID
                                      where ub.BilesenID == secilenBilesenID && ub.UrunID == secilenUrunID
                                      select ub).FirstOrDefault();
                if (bilesenKontrol != null)
                {
                    MessageBox.Show("Aynı bileşen seçilmiş. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    decimal bilesenBirimFiyati = 0;
                    decimal bilesenAgirlik = 0;
                    decimal adetAgirlik = 0;
                    decimal adetTutari = 0;
                    decimal toplamBilesenFiyat = 0;
                    decimal toplamBilesenAgirlik = 0;
                    decimal toplamEkBilesenFiyat = 0;
                    decimal toplamEkBilesenAgirlik = 0;
                    decimal toplamEkFiyat = 0;
                    decimal toplamFiyat = 0;
                    decimal toplamAgirlik = 0;
                    int adet = Convert.ToInt32(txt_BilesenAdeti.Text);
                    var bilesen = (from bl in db.Bilesenler
                                   where bl.BilesenID == secilenBilesenID
                                   select bl).FirstOrDefault();
                    if (bilesen != null)
                    {
                        bilesenBirimFiyati = Convert.ToDecimal(bilesen.BilesenBirimFiyati);
                        bilesenAgirlik = Convert.ToDecimal(bilesen.BilesenAgirlik);
                        adetAgirlik = bilesenAgirlik * adet;
                        adetTutari = bilesenBirimFiyati * adet;

                        UrunBilesenleri urunBilesenleri = new UrunBilesenleri()
                        {
                            UrunID = Convert.ToInt32(txt_UrunNo.Text),
                            BilesenID = Convert.ToInt32(cmb_Bilesen.EditValue),
                            UrunBilesenleriAdet = Convert.ToInt32(txt_BilesenAdeti.Text),
                            UrunBilesenleriAdetAgirlik = adetAgirlik,
                            UrunBilesenleriAdetTutari = adetTutari,
                        };
                        db.UrunBilesenleri.Add(urunBilesenleri);
                        db.SaveChanges();
                        bilesenDTWListele();
                        ekBilesenDTWListele();
                        ekIslemMaliyetiDTWListele();
                        grView_BilesenTablosu.MoveLast();
                        btn_UrunKaydet.Enabled = true;

                        for (int index = 0; index < grView_BilesenTablosu.RowCount; index++)
                        {
                            toplamBilesenAgirlik += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetAgirlik"));
                            toplamBilesenFiyat += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetTutari"));
                        }
                        for (int index = 0; index < grView_EkBilesenTablosu.RowCount; index++)
                        {
                            toplamEkBilesenAgirlik += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetAgirlik"));
                            toplamEkBilesenFiyat += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetTutari"));
                        }
                        for (int index = 0; index < grView_EkIslemMaliyetTablosu.RowCount; index++)
                        {
                            toplamEkFiyat += Convert.ToDecimal(grView_EkIslemMaliyetTablosu.GetRowCellValue(index, "UrunEkIslemMaliyetleriFiyati"));
                        }
                        toplamAgirlik = toplamBilesenAgirlik + toplamEkBilesenAgirlik;
                        toplamFiyat = toplamBilesenFiyat + toplamEkBilesenFiyat + toplamEkFiyat;
                        txt_UrunBirimFiyati.Text = toplamFiyat.ToString();
                        txt_UrunAgirligi.Text = toplamAgirlik.ToString();
                        btn_UrunKaydet.Enabled = true;
                        btn_UrunGuncelle.Enabled = true;
                        btn_Temizle.Enabled = true;
                    }
                }
            }
        }

        private void Btn_BilesenSil_Click(object sender, EventArgs e)
        {
            if (grView_BilesenTablosu.RowCount > 0)
            {
                decimal toplamBilesenFiyat = 0;
                decimal toplamBilesenAgirlik = 0;
                decimal toplamEkBilesenFiyat = 0;
                decimal toplamEkBilesenAgirlik = 0;
                decimal toplamEkFiyat = 0;
                decimal toplamFiyat = 0;
                decimal toplamAgirlik = 0;
                int[] secilenler = grView_BilesenTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_BilesenTablosu.GetRowCellValue(secilenler[0], "UrunBilesenleriID"));
                var bilesenSil = (from ub in db.UrunBilesenleri
                                  where ub.UrunBilesenleriID == id
                                  select ub).FirstOrDefault();
                db.UrunBilesenleri.Remove(bilesenSil);
                db.SaveChanges();
                bilesenDTWListele();
                grView_BilesenTablosu.ClearSelection();

                int bilesenID = Convert.ToInt32(cmb_Bilesen.EditValue);
                var bilesen = (from bl in db.Bilesenler
                               where bl.BilesenID == bilesenID
                               select bl).FirstOrDefault();

                if (txt_BilesenAdeti.Text != "" || txt_BilesenAdeti.Text == String.Empty)
                {
                    for (int index = 0; index < grView_BilesenTablosu.RowCount; index++)
                    {
                        toplamBilesenAgirlik += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetAgirlik"));
                        toplamBilesenFiyat += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetTutari"));
                    }
                    for (int index = 0; index < grView_EkBilesenTablosu.RowCount; index++)
                    {
                        toplamEkBilesenAgirlik += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetAgirlik"));
                        toplamEkBilesenFiyat += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetTutari"));
                    }
                    for (int index = 0; index < grView_EkIslemMaliyetTablosu.RowCount; index++)
                    {
                        toplamEkFiyat += Convert.ToDecimal(grView_EkIslemMaliyetTablosu.GetRowCellValue(index, "UrunEkIslemMaliyetleriFiyati"));
                    }
                    toplamAgirlik = toplamBilesenAgirlik + toplamEkBilesenAgirlik;
                    toplamFiyat = toplamBilesenFiyat + toplamEkBilesenFiyat + toplamEkFiyat;
                    txt_UrunBirimFiyati.Text = toplamFiyat.ToString();
                    txt_UrunAgirligi.Text = toplamAgirlik.ToString();
                }
            }
            else
            {
                grCtrl_BilesenTablosu.DataSource = null;
            }
        }

        private void Btn_EkBilesenEkle_Click(object sender, EventArgs e)
        {
            if (cmb_EkBilesen.Text == "" || cmb_EkBilesen == null || Convert.ToInt32(cmb_EkBilesen.EditValue) == 0)
            {
                err_HataDurumu.SetError(cmb_EkBilesen, "Ek Bileşen seçiniz.");
            }
            else if (txt_EkBilesenAdeti.Text == "" || txt_EkBilesenAdeti.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_EkBilesenAdeti, "Adet giriniz.");
            }
            else
            {
                int secilenUrunID = Convert.ToInt32(txt_UrunNo.Text);
                int secilenEkBilesenID = Convert.ToInt32(cmb_EkBilesen.EditValue);
                var bilesenKontrol = (from ueb in db.UrunEkBilesenleri
                                      join u in db.Urunler
                                      on ueb.UrunID equals u.UrunID
                                      where ueb.EkBilesenID == secilenEkBilesenID && ueb.UrunID == secilenUrunID
                                      select ueb).FirstOrDefault();
                if (bilesenKontrol != null)
                {
                    MessageBox.Show("Aynı ek bileşen seçilmiş. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    decimal ekBilesenAdetFiyati = 0;
                    decimal ekBilesenAgirlik = 0;
                    decimal adetAgirlik = 0;
                    decimal adetTutari = 0;
                    decimal toplamBilesenFiyat = 0;
                    decimal toplamBilesenAgirlik = 0;
                    decimal toplamEkBilesenFiyat = 0;
                    decimal toplamEkBilesenAgirlik = 0;
                    decimal toplamEkFiyat = 0;
                    decimal toplamFiyat = 0;
                    decimal toplamAgirlik = 0;
                    int adet = Convert.ToInt32(txt_EkBilesenAdeti.Text);
                    var ekBilesen = (from ebl in db.EkBilesenler
                                     where ebl.EkBilesenID == secilenEkBilesenID
                                     select ebl).FirstOrDefault();
                    if (ekBilesen != null)
                    {
                        ekBilesenAdetFiyati = Convert.ToDecimal(ekBilesen.EkBilesenAdetFiyati);
                        ekBilesenAgirlik = Convert.ToDecimal(ekBilesen.EkBilesenAgirlik);
                        adetAgirlik = ekBilesenAgirlik * adet;
                        adetTutari = ekBilesenAdetFiyati * adet;

                        UrunEkBilesenleri urunEkBilesenleri = new UrunEkBilesenleri()
                        {
                            UrunID = Convert.ToInt32(txt_UrunNo.Text),
                            EkBilesenID = Convert.ToInt32(cmb_EkBilesen.EditValue),
                            UrunEkBilesenleriAdet = Convert.ToInt32(txt_EkBilesenAdeti.Text),
                            UrunEkBilesenleriAdetAgirlik = adetAgirlik,
                            UrunEkBilesenleriAdetTutari = adetTutari,
                        };
                        db.UrunEkBilesenleri.Add(urunEkBilesenleri);
                        db.SaveChanges();
                        bilesenDTWListele();
                        ekBilesenDTWListele();
                        ekIslemMaliyetiDTWListele();
                        grView_EkBilesenTablosu.MoveLast();

                        for (int index = 0; index < grView_BilesenTablosu.RowCount; index++)
                        {
                            toplamBilesenAgirlik += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetAgirlik"));
                            toplamBilesenFiyat += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetTutari"));
                        }
                        for (int index = 0; index < grView_EkBilesenTablosu.RowCount; index++)
                        {
                            toplamEkBilesenAgirlik += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetAgirlik"));
                            toplamEkBilesenFiyat += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetTutari"));
                        }
                        for (int index = 0; index < grView_EkIslemMaliyetTablosu.RowCount; index++)
                        {
                            toplamEkFiyat += Convert.ToDecimal(grView_EkIslemMaliyetTablosu.GetRowCellValue(index, "UrunEkIslemMaliyetleriFiyati"));
                        }
                        toplamAgirlik = toplamBilesenAgirlik + toplamEkBilesenAgirlik;
                        toplamFiyat = toplamBilesenFiyat + toplamEkBilesenFiyat + toplamEkFiyat;
                        txt_UrunBirimFiyati.Text = toplamFiyat.ToString();
                        txt_UrunAgirligi.Text = toplamAgirlik.ToString();
                        btn_UrunKaydet.Enabled = true;
                        btn_UrunGuncelle.Enabled = true;
                        btn_Temizle.Enabled = true;
                    }
                }
            }
        }

        private void Btn_EkBilesenSil_Click(object sender, EventArgs e)
        {
            if (grView_EkBilesenTablosu.RowCount > 0)
            {
                decimal toplamBilesenFiyat = 0;
                decimal toplamBilesenAgirlik = 0;
                decimal toplamEkBilesenFiyat = 0;
                decimal toplamEkBilesenAgirlik = 0;
                decimal toplamEkFiyat = 0;
                decimal toplamFiyat = 0;
                decimal toplamAgirlik = 0;
                int[] secilenler = grView_EkBilesenTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_EkBilesenTablosu.GetRowCellValue(secilenler[0], "EkBilesenID"));
                var ekBilesenSil = (from ueb in db.UrunEkBilesenleri
                                    where ueb.UrunEkBilesenleriID == id
                                    select ueb).FirstOrDefault();
                db.UrunEkBilesenleri.Remove(ekBilesenSil);
                db.SaveChanges();
                bilesenDTWListele();
                ekBilesenDTWListele();
                ekIslemMaliyetiDTWListele();
                grView_EkBilesenTablosu.ClearSelection();

                int ekBilesenID = Convert.ToInt32(cmb_EkBilesen.EditValue);
                var ekBilesen = (from ebl in db.EkBilesenler
                                 where ebl.EkBilesenID == ekBilesenID
                                 select ebl).FirstOrDefault();

                if (txt_EkBilesenAdeti.Text != "" || txt_EkBilesenAdeti.Text == String.Empty)
                {
                    for (int index = 0; index < grView_BilesenTablosu.RowCount; index++)
                    {
                        toplamBilesenAgirlik += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetAgirlik"));
                        toplamBilesenFiyat += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetTutari"));
                    }
                    for (int index = 0; index < grView_EkBilesenTablosu.RowCount; index++)
                    {
                        toplamEkBilesenAgirlik += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetAgirlik"));
                        toplamEkBilesenFiyat += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetTutari"));
                    }
                    for (int index = 0; index < grView_EkIslemMaliyetTablosu.RowCount; index++)
                    {
                        toplamEkFiyat += Convert.ToDecimal(grView_EkIslemMaliyetTablosu.GetRowCellValue(index, "UrunEkIslemMaliyetleriFiyati"));
                    }
                    toplamAgirlik = toplamBilesenAgirlik + toplamEkBilesenAgirlik;
                    toplamFiyat = toplamBilesenFiyat + toplamEkBilesenFiyat + toplamEkFiyat;
                    txt_UrunBirimFiyati.Text = toplamFiyat.ToString();
                    txt_UrunAgirligi.Text = toplamAgirlik.ToString();
                }
            }
            else
            {
                grCtrl_EkBilesenTablosu.DataSource = null;
            }
        }

        private void Btn_EkIslemMaliyetiEkle_Click(object sender, EventArgs e)
        {
            if (cmb_EkIslemMaliyeti.Text == "" || cmb_EkIslemMaliyeti == null || Convert.ToInt32(cmb_EkIslemMaliyeti.EditValue) == 0)
            {
                err_HataDurumu.SetError(cmb_EkIslemMaliyeti, "Ek Bileşen seçiniz.");
            }
            else if (txt_EkIslemMaliyetiUzunluk.Text == "" || txt_EkIslemMaliyetiUzunluk.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_EkIslemMaliyetiUzunluk, "Adet giriniz.");
            }
            else
            {
                int secilenUrunID = Convert.ToInt32(txt_UrunNo.Text);
                int secilenEkFiyatID = Convert.ToInt32(cmb_EkIslemMaliyeti.EditValue);
                var ekFiyatKontrol = (from uem in db.UrunEkIslemMaliyetleri
                                      join u in db.Urunler
                                      on uem.UrunID equals u.UrunID
                                      where uem.EkIslemMaliyetiID == secilenEkFiyatID && uem.UrunID == secilenUrunID
                                      select uem).FirstOrDefault();
                if (ekFiyatKontrol != null)
                {
                    MessageBox.Show("Aynı ek fiyat seçilmiş. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    decimal ekFiyat = 0;
                    decimal uzunlukTutari = 0;
                    decimal toplamBilesenFiyat = 0;
                    decimal toplamBilesenAgirlik = 0;
                    decimal toplamEkBilesenFiyat = 0;
                    decimal toplamEkBilesenAgirlik = 0;
                    decimal toplamEkFiyat = 0;
                    decimal toplamFiyat = 0;
                    decimal toplamAgirlik = 0;
                    decimal uzunluk = Convert.ToDecimal(txt_EkIslemMaliyetiUzunluk.Text);
                    var ekIslemMaliyeti = (from eim in db.EkIslemMaliyeti
                                           where eim.EkIslemMaliyetiID == secilenEkFiyatID
                                           select eim).FirstOrDefault();
                    if (ekIslemMaliyeti != null)
                    {
                        ekFiyat = Convert.ToDecimal(ekIslemMaliyeti.EkIslemMaliyetiFiyati);
                        uzunlukTutari = ekFiyat * uzunluk;

                        UrunEkIslemMaliyetleri urunEkFiyatlari = new UrunEkIslemMaliyetleri()
                        {
                            UrunID = Convert.ToInt32(txt_UrunNo.Text),
                            EkIslemMaliyetiID = Convert.ToInt32(cmb_EkIslemMaliyeti.EditValue),
                            UrunEkIslemMaliyetleriUzunluk = Convert.ToDecimal(txt_EkIslemMaliyetiUzunluk.Text),
                            UrunEkIslemMaliyetleriFiyati = uzunlukTutari,
                        };
                        db.UrunEkIslemMaliyetleri.Add(urunEkFiyatlari);
                        db.SaveChanges();
                        bilesenDTWListele();
                        ekBilesenDTWListele();
                        ekIslemMaliyetiDTWListele();
                        grView_EkIslemMaliyetTablosu.MoveLast();

                        for (int index = 0; index < grView_BilesenTablosu.RowCount; index++)
                        {
                            toplamBilesenAgirlik += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetAgirlik"));
                            toplamBilesenFiyat += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetTutari"));
                        }
                        for (int index = 0; index < grView_EkBilesenTablosu.RowCount; index++)
                        {
                            toplamEkBilesenAgirlik += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetAgirlik"));
                            toplamEkBilesenFiyat += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetTutari"));
                        }
                        for (int index = 0; index < grView_EkIslemMaliyetTablosu.RowCount; index++)
                        {
                            toplamEkFiyat += Convert.ToDecimal(grView_EkIslemMaliyetTablosu.GetRowCellValue(index, "UrunEkIslemMaliyetleriFiyati"));
                        }
                        toplamAgirlik = toplamBilesenAgirlik + toplamEkBilesenAgirlik;
                        toplamFiyat = toplamBilesenFiyat + toplamEkBilesenFiyat + toplamEkFiyat;
                        txt_UrunBirimFiyati.Text = toplamFiyat.ToString();
                        txt_UrunAgirligi.Text = toplamAgirlik.ToString();
                        btn_UrunKaydet.Enabled = true;
                        btn_UrunGuncelle.Enabled = true;
                        btn_Temizle.Enabled = true;
                    }
                }
            }
        }

        private void Btn_EkIslemMaliyetiSil_Click(object sender, EventArgs e)
        {
            if (grView_EkBilesenTablosu.RowCount > 0)
            {
                decimal toplamBilesenFiyat = 0;
                decimal toplamBilesenAgirlik = 0;
                decimal toplamEkBilesenFiyat = 0;
                decimal toplamEkBilesenAgirlik = 0;
                decimal toplamEkFiyat = 0;
                decimal toplamFiyat = 0;
                decimal toplamAgirlik = 0;
                int[] secilenler = grView_EkBilesenTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_EkBilesenTablosu.GetRowCellValue(secilenler[0], "UrunEkIslemMaliyetleriID"));
                var ekIslemMaliyetiSil = (from uem in db.UrunEkIslemMaliyetleri
                                          where uem.UrunEkIslemMaliyetleriID == id
                                          select uem).FirstOrDefault();
                db.UrunEkIslemMaliyetleri.Remove(ekIslemMaliyetiSil);
                db.SaveChanges();
                bilesenDTWListele();
                ekBilesenDTWListele();
                ekIslemMaliyetiDTWListele();
                grView_EkIslemMaliyetTablosu.ClearSelection();

                int ekFiyatID = Convert.ToInt32(cmb_EkIslemMaliyeti.EditValue);
                var ekFiyat = (from eim in db.EkIslemMaliyeti
                               where eim.EkIslemMaliyetiID == ekFiyatID
                               select eim).FirstOrDefault();

                if (txt_EkIslemMaliyetiUzunluk.Text != "" || txt_EkIslemMaliyetiUzunluk.Text == String.Empty)
                {
                    for (int index = 0; index < grView_BilesenTablosu.RowCount; index++)
                    {
                        toplamBilesenAgirlik += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetAgirlik"));
                        toplamBilesenFiyat += Convert.ToDecimal(grView_BilesenTablosu.GetRowCellValue(index, "UrunBilesenleriAdetTutari"));
                    }
                    for (int index = 0; index < grView_EkBilesenTablosu.RowCount; index++)
                    {
                        toplamEkBilesenAgirlik += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetAgirlik"));
                        toplamEkBilesenFiyat += Convert.ToDecimal(grView_EkBilesenTablosu.GetRowCellValue(index, "UrunEkBilesenleriAdetTutari"));
                    }
                    for (int index = 0; index < grView_EkIslemMaliyetTablosu.RowCount; index++)
                    {
                        toplamEkFiyat += Convert.ToDecimal(grView_EkIslemMaliyetTablosu.GetRowCellValue(index, "UrunEkIslemMaliyetleriFiyati"));
                    }
                    toplamAgirlik = toplamBilesenAgirlik + toplamEkBilesenAgirlik;
                    toplamFiyat = toplamBilesenFiyat + toplamEkBilesenFiyat + toplamEkFiyat;
                    txt_UrunBirimFiyati.Text = toplamFiyat.ToString();
                    txt_UrunAgirligi.Text = toplamAgirlik.ToString();
                }
            }
            else
            {
                grCtrl_EkIslemMaliyetTablosu.DataSource = null;
            }
        }

        private void Btn_UrunKaydet_Click(object sender, EventArgs e)
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
                if (txt_UrunAdi.Text == "" || txt_UrunAdi.Text == String.Empty || txt_UrunAdi.Text == " ")
                {
                    err_HataDurumu.SetError(txt_UrunAdi, "Ürün adı giriniz. Lütfen Kontrol ediniz.");
                }
                else if (txt_UrunBirimFiyati.Text == "0,00" || txt_UrunBirimFiyati.Text == "0" || txt_UrunBirimFiyati.Text == String.Empty || txt_UrunAgirligi.Text == "0,00" || txt_UrunAgirligi.Text == "0" || txt_UrunAgirligi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_UrunBirimFiyati, "Seçilen bileşen ve eklerin fiyatını veya miktarını kontrol ediniz.");
                    err_HataDurumu.SetError(txt_UrunAgirligi, "Seçilen bileşen ve eklerin fiyatını veya miktarını kontrol ediniz.");
                }
                else
                {
                    int id = Convert.ToInt32(txt_UrunNo.Text);
                    var urunKontrol = (from u in db.Urunler
                                       where u.UrunID != id && u.UrunAdi == txt_UrunAdi.Text
                                       select u).FirstOrDefault();
                    if (urunKontrol != null)
                    {
                        MessageBox.Show("Aynı ürün mevcut. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var urun = (from bl in db.Urunler
                                    where bl.UrunID == id
                                    select bl).FirstOrDefault();
                        urun.UrunAdi = txt_UrunAdi.Text;
                        urun.UrunAdet = 1;
                        urun.UrunBirimi = txt_UrunBirimi.Text;
                        urun.UrunBirimFiyati = Convert.ToDecimal(txt_UrunBirimFiyati.Text);
                        urun.UrunAgirlik = Convert.ToDecimal(txt_UrunAgirligi.Text);
                        urun.KaydedenID = KullaniciBilgileri.KaydedenID;
                        urun.KayitTarihi = DateTime.Now;

                        DialogResult sonuc = MessageBox.Show("'" + urun.UrunAdi + "'" + " " + "adlı ürünü kaydetmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            urunListele();
                            grView_UrunTablosu.MoveLast();
                            MessageBox.Show("Ürün kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            temizle();
                            grCtrl_UrunTablosu.Enabled = true;
                            btn_Temizle.Enabled = true;
                            UrunListesi urunListesi = (UrunListesi)Application.OpenForms["UrunListesi"];
                            if (Application.OpenForms["UrunListesi"] != null)
                            {
                                urunListesi.urunListele();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ürün kaydedilmedi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void Btn_UrunGuncelle_Click(object sender, EventArgs e)
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
                if (txt_UrunAdi.Text == "" || txt_UrunAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_UrunAdi, "Ürün oluşturulmamış. Lütfen Kontrol ediniz.");
                }
                else if (txt_UrunBirimFiyati.Text == "0,00" || txt_UrunBirimFiyati.Text == "0" || txt_UrunBirimFiyati.Text == String.Empty || txt_UrunAgirligi.Text == "0,00" || txt_UrunAgirligi.Text == "0" || txt_UrunAgirligi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_UrunBirimFiyati, "Seçilen sacın fiyatını veya miktarını kontrol ediniz.");
                    err_HataDurumu.SetError(txt_UrunAgirligi, "Seçilen sacın fiyatını veya miktarını kontrol ediniz.");
                }
                else
                {
                    int id = Convert.ToInt32(txt_UrunNo.Text);
                    var urunKontrol = (from u in db.Urunler
                                       where u.UrunID != id && u.UrunAdi == txt_UrunAdi.Text
                                       select u).FirstOrDefault();
                    if (urunKontrol == null)
                    {
                        var urun = (from bl in db.Urunler
                                    where bl.UrunID == id
                                    select bl).FirstOrDefault();
                        urun.UrunAdi = txt_UrunAdi.Text;
                        urun.UrunAdet = 1;
                        urun.UrunBirimi = txt_UrunBirimi.Text;
                        urun.UrunBirimFiyati = Convert.ToDecimal(txt_UrunBirimFiyati.Text);
                        urun.UrunAgirlik = Convert.ToDecimal(txt_UrunAgirligi.Text);
                        urun.KaydedenID = KullaniciBilgileri.KaydedenID;
                        urun.KayitTarihi = DateTime.Now;

                        DialogResult sonuc = MessageBox.Show("'" + urun.UrunAdi + "'" + " " + "adlı ürünü güncellemek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            int focuedRowHandle = grView_UrunTablosu.FocusedRowHandle;
                            urunListele();
                            grView_UrunTablosu.FocusedRowHandle = focuedRowHandle;
                            MessageBox.Show("Ürün güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ürün güncellendi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            UrunListesi urunListesi = (UrunListesi)Application.OpenForms["UrunListesi"];
                            if (Application.OpenForms["UrunListesi"] != null)
                            {
                                urunListesi.urunListele();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aynı ürün zaten mevcut. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void Btn_UrunuSil_Click(object sender, EventArgs e)
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
                if (txt_UrunNo.Text != "" || txt_UrunNo.Text != String.Empty)
                {
                    int id = Convert.ToInt32(txt_UrunNo.Text);
                    var urunKontrol = (from md in db.MaliyetDetayi
                                       join u in db.Urunler
                                       on md.UrunID equals u.UrunID
                                       where md.UrunID == id
                                       select md).FirstOrDefault();
                    if (urunKontrol != null)
                    {
                        MessageBox.Show("Silmek istediğiniz ürün maliyet hesaplarken kullanılmış. Bu yüzden ürünü silemezsiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var urunSil = (from bl in db.Urunler
                                       where bl.UrunID == id
                                       select bl).FirstOrDefault();

                        db.UrunBilesenleri.RemoveRange(db.UrunBilesenleri.Where(x => x.UrunID == id));
                        db.UrunEkBilesenleri.RemoveRange(db.UrunEkBilesenleri.Where(x => x.UrunID == id));
                        db.UrunEkIslemMaliyetleri.RemoveRange(db.UrunEkIslemMaliyetleri.Where(x => x.UrunID == id));

                        DialogResult sonuc = MessageBox.Show("'" + urunSil.UrunAdi + "'" + " " + "adlı ürünü siliyorsunuz." + "\n" + "DİKKAT! Ürünü silerseniz, ürüne ait tüm bilgiler silinecektir. Yine de silmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.Urunler.Remove(urunSil);
                            db.SaveChanges();
                            urunListele();
                            MessageBox.Show("Ürün silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            temizle();
                            btn_Temizle.Enabled = true;
                            grCtrl_UrunTablosu.Enabled = true;
                            pnl_Iki.Enabled = false;
                            UrunListesi urunListesi = (UrunListesi)Application.OpenForms["UrunListesi"];
                            if (Application.OpenForms["UrunListesi"] != null)
                            {
                                urunListesi.urunListele();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bilesen silinmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek ürünü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void temizle()
        {
            btn_UrunOlustur.Visible = true;
            btn_UrunuSil.Visible = false;
            btn_UrunGuncelle.Visible = false;
            txt_UrunNo.Text = string.Empty;
            txt_UrunAdi.Text = string.Empty;
            grCtrl_BilesenTablosu.DataSource = null;
            grCtrl_EkBilesenTablosu.DataSource = null;
            grCtrl_EkIslemMaliyetTablosu.DataSource = null;
            txt_UrunBirimFiyati.Text = string.Empty;
            txt_UrunAgirligi.Text = string.Empty;
            grView_UrunTablosu.ClearSelection();
            bilesenCMBListele();
            ekBilesenCMBListele();
            ekIslemMaliyetiCMBListele();
            txt_BilesenAdeti.Text = string.Empty;
            txt_EkBilesenAdeti.Text = string.Empty;
            txt_EkIslemMaliyetiUzunluk.Text = string.Empty;
            pnl_Iki.Enabled = false;
            btn_UrunKaydet.Enabled = false;
        }

        private void Btn_Temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void GrView_UrunTablosu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (grView_UrunTablosu.RowCount > 0)
            {
                int[] secilenler = grView_UrunTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_UrunTablosu.GetRowCellValue(secilenler[0], "UrunID"));
                var urunGetir = (from u in db.Urunler.AsNoTracking()
                                 where u.UrunID == id
                                 select new
                                 {
                                     u.UrunID,
                                     u.UrunAdi,
                                     u.UrunBirimi,
                                     u.UrunAgirlik,
                                     u.UrunBirimFiyati,
                                 }).FirstOrDefault();
                if (urunGetir != null)
                {
                    txt_UrunNo.Text = urunGetir.UrunID.ToString();
                    txt_UrunAdi.Text = urunGetir.UrunAdi.ToString();
                    txt_UrunBirimi.Text = urunGetir.UrunBirimi.ToString();
                    txt_UrunAgirligi.Text = urunGetir.UrunBirimFiyati.ToString();
                    txt_UrunBirimFiyati.Text = urunGetir.UrunAgirlik.ToString();

                }
                else
                {
                    MessageBox.Show("Hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btn_UrunKaydet.Enabled = false;
                btn_UrunGuncelle.Enabled = true;
                btn_Temizle.Enabled = true;
                pnl_Iki.Enabled = true;
                btn_UrunOlustur.Visible = false;
                btn_UrunuSil.Visible = true;
                btn_UrunuSil.Location = new Point(268, 5);
                btn_UrunGuncelle.Visible = true;
                btn_UrunGuncelle.Location = new Point(92, 101);
                bilesenCMBListele();
                ekBilesenCMBListele();
                ekIslemMaliyetiCMBListele();

                BindingSource bindingSourceUBilesenleri = new BindingSource();
                var urunBilesenleri = (from ub in db.UrunBilesenleri
                                       join u in db.Urunler
                                       on ub.UrunID equals u.UrunID
                                       join bl in db.Bilesenler
                                       on ub.BilesenID equals bl.BilesenID
                                       where ub.UrunID == id
                                       select new
                                       {
                                           ub.UrunBilesenleriID,
                                           u.UrunAdi,
                                           bl.BilesenAdi,
                                           ub.UrunBilesenleriAdet,
                                           ub.UrunBilesenleriAdetAgirlik,
                                           ub.UrunBilesenleriAdetTutari,
                                       }).ToList();
                if (urunBilesenleri != null)
                {
                    bindingSourceUBilesenleri.DataSource = urunBilesenleri;
                    grCtrl_BilesenTablosu.DataSource = bindingSourceUBilesenleri;
                    grView_BilesenTablosu.ClearSelection();
                }

                BindingSource bindingSourceUEkBilesenleri = new BindingSource();
                var urunEkBilesenleri = (from ueb in db.UrunEkBilesenleri
                                         join u in db.Urunler
                                         on ueb.UrunID equals u.UrunID
                                         join ebl in db.EkBilesenler
                                         on ueb.EkBilesenID equals ebl.EkBilesenID
                                         where ueb.UrunID == id
                                         select new
                                         {
                                             ueb.UrunEkBilesenleriID,
                                             u.UrunAdi,
                                             ebl.EkBilesenAdi,
                                             ueb.UrunEkBilesenleriAdet,
                                             ueb.UrunEkBilesenleriAdetAgirlik,
                                             ueb.UrunEkBilesenleriAdetTutari,
                                         }).ToList();
                if (urunEkBilesenleri != null)
                {
                    bindingSourceUEkBilesenleri.DataSource = urunEkBilesenleri;
                    grCtrl_EkBilesenTablosu.DataSource = bindingSourceUEkBilesenleri;
                    grView_EkBilesenTablosu.ClearSelection();
                }

                BindingSource bindingSourceUEkIslemMaliyetleri = new BindingSource();
                var urunEkMaliyet = (from uem in db.UrunEkIslemMaliyetleri
                                     join u in db.Urunler
                                     on uem.UrunID equals u.UrunID
                                     join eim in db.EkIslemMaliyeti
                                     on uem.EkIslemMaliyetiID equals eim.EkIslemMaliyetiID
                                     where uem.UrunID == id
                                     select new
                                     {
                                         uem.EkIslemMaliyetiID,
                                         u.UrunAdi,
                                         eim.EkIslemMaliyetiAdi,
                                         uem.UrunEkIslemMaliyetleriUzunluk,
                                         uem.UrunEkIslemMaliyetleriFiyati,
                                     }).ToList();
                if (urunEkMaliyet != null)
                {
                    bindingSourceUEkIslemMaliyetleri.DataSource = urunEkMaliyet;
                    grCtrl_EkIslemMaliyetTablosu.DataSource = bindingSourceUEkIslemMaliyetleri;
                    grView_EkIslemMaliyetTablosu.ClearSelection();
                }

                var urun = (from u in db.Urunler
                            where u.UrunID == id
                            select u).FirstOrDefault();
                if (urun != null)
                {
                    txt_UrunBirimFiyati.Text = urun.UrunBirimFiyati.ToString();
                    txt_UrunAgirligi.Text = urun.UrunAgirlik.ToString();
                }
            }
        }

        private void UrunTanimla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txt_UrunNo.Text != "" || txt_UrunNo.Text != String.Empty)
            {
                int id = Convert.ToInt32(txt_UrunNo.Text);
                var urunKontrol = (from u in db.Urunler
                                   where u.UrunID == id && u.UrunBirimFiyati == 0m
                                   select u).FirstOrDefault();
                if (urunKontrol != null)
                {
                    DialogResult result = MessageBox.Show("Ürün oluşturma işlemi yarım bırakıldı. Yarım bırakılan ürün oluşturma işlemini iptal etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        var urunSil = (from u in db.Urunler
                                       where u.UrunID == id
                                       select u).FirstOrDefault();

                        db.UrunBilesenleri.RemoveRange(db.UrunBilesenleri.Where(x => x.UrunID == id));
                        db.UrunEkBilesenleri.RemoveRange(db.UrunEkBilesenleri.Where(x => x.UrunID == id));
                        db.UrunEkIslemMaliyetleri.RemoveRange(db.UrunEkIslemMaliyetleri.Where(x => x.UrunID == id));

                        db.Urunler.Remove(urunSil);
                        db.SaveChanges();
                        temizle();
                        MessageBox.Show("Ürün oluşturma işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void Txt_UrunAdi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
            txt_UrunAdi.Text = txt_UrunAdi.Text.ToUpper();
        }

        private void Cmb_Bilesen_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_BilesenAdeti_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Cmb_EkBilesen_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_EkBilesenAdeti_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Cmb_EkIslemMaliyeti_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_EkIslemMaliyetiUzunluk_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_UrunAgirligi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_UrunBirimFiyati_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_BilesenAdeti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Txt_EkBilesenAdeti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Txt_EkIslemMaliyetiUzunluk_KeyPress(object sender, KeyPressEventArgs e)
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

        private void GrView_UrunTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_UrunTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
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

        private void GrView_EkIslemMaliyetTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_EkIslemMaliyetTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void UrunTanimla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Anaform anaform = (Anaform)Application.OpenForms["Anaform"];
            if (Application.OpenForms["Anaform"] != null)
            {
                anaform.BringToFront();
            }
        }
    }
}