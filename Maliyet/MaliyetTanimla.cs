using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SiparisTakipSistemi.Urun;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using System.Diagnostics;
using SiparisTakipSistemi.Kullanici;
using SiparisTakipSistemi.Sistem;

namespace SiparisTakipSistemi.Maliyet
{
    public partial class MaliyetTanimla : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public Maliyetler seciliMaliyet;
        public MaliyetTanimla()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
            seciliMaliyet = null;
        }

        
        public int secilenTeklifID;
        public int secilenMusteriID;
        public int secilenUrunID;
        public int secilenUrunBirimiID;
        public int secilenBoyaID;
        decimal toplamAgirlik;

        private void MaliyetTanimla_Load(object sender, EventArgs e)
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
                cmb_EkMaliyetListele();
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
                Maliyetler maliyetler = new Maliyetler()
                {
                    IlkTutar = 0,
                    GenelToplamAgirlik = 0,
                    GenelToplamTutar = Convert.ToDecimal(txt_GenelToplam.Text),
                    KaydedenID = KullaniciBilgileri.KaydedenID,
                    KayitTarihi = DateTime.Now,
                };
                db.Maliyetler.Add(maliyetler);

                DialogResult sonuc = MessageBox.Show("Maliyeti oluşturmak istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sonuc == DialogResult.Yes)
                {
                    db.SaveChanges();
                    MessageBox.Show("Maliyet Oluşturuldu. Alt kısımdan maliyet için ürün ekleyiniz. ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    seciliMaliyet = maliyetler;
                    txt_MaliyetNo.Text = maliyetler.MaliyetID.ToString();

                    pnl_Iki.Enabled = true;
                    btn_MaliyetOlustur.Visible = false;
                    btn_MaliyetiSil.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Maliyet Oluşturulamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void temizle()
        {
            txt_MaliyetNo.Text = string.Empty;
            txt_UrunAdi.Text = string.Empty;
            txt_UrunBirimi.Text = string.Empty;
            txt_BirimAgirligi.Text = string.Empty;
            txt_UrunBirimFiyati.Text = string.Empty;
            txt_Miktar.Text = string.Empty;
            txt_ToplamAdetAgirligi.Text = string.Empty;
            txt_ToplamAdetTutari.Text = string.Empty;
            cmb_EkMaliyetListele();
            txt_EkMaliyetTutari.Text = string.Empty;
            txt_GenelToplam.Text = "0";
            pnl_Iki.Enabled = false;
            tablePnl_Bir.Enabled = false;
            grCtrl_MaliyetTablosu.DataSource = null;
            grCtrl_EkMaliyetTablosu.DataSource = null;
            btn_MaliyetOlustur.Visible = true;
        }

        private void Btn_Temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void maliyetListele()
        {
            BindingSource bindingSourceMDetayi = new BindingSource();
            if (seciliMaliyet != null)
            {
                var maliyetDetayi = (from md in db.MaliyetDetayi
                                     join mh in db.Maliyetler
                                     on md.MaliyetID equals mh.MaliyetID
                                     join u in db.Urunler
                                     on md.UrunID equals u.UrunID
                                     where md.MaliyetID == seciliMaliyet.MaliyetID
                                     select new
                                     {
                                         md.MaliyetDetayiID,
                                         u.UrunAdi,
                                         md.MaliyetBirimi,
                                         md.BirimAgirlik,
                                         md.BirimFiyati,
                                         md.UrunMiktari,
                                         md.ToplamTutar,
                                         md.ToplamAgirlik,
                                     }).ToList();
                if (maliyetDetayi != null)
                {
                    bindingSourceMDetayi.DataSource = maliyetDetayi;
                    grCtrl_MaliyetTablosu.DataSource = bindingSourceMDetayi;
                    grView_MaliyetTablosu.ClearSelection();
                }
            }
        }

        private void dtw_EkMaliyetListele()
        {
            BindingSource bindingSourceEkMaliyet = new BindingSource();
            var maliyet = (from me in db.MaliyetEkleri
                          join m in db.EkMaliyetler
                          on me.EkMaliyetID equals m.EkMaliyetID
                          where me.MaliyetID == seciliMaliyet.MaliyetID
                          select new
                          {
                              me.MaliyetEkleriID,
                              m.EkMaliyetAdi,
                              me.MaliyetFiyati
                          }).ToList();
            if (maliyet != null)
            {
                bindingSourceEkMaliyet.DataSource = maliyet;
                grCtrl_EkMaliyetTablosu.DataSource = bindingSourceEkMaliyet;
            }
        }

        private void cmb_EkMaliyetListele()
        {
            var maliyet = (from ml in db.EkMaliyetler
                           orderby ml.EkMaliyetID descending
                           select new
                           {
                               ml.EkMaliyetID,
                               ml.EkMaliyetAdi,
                           }).ToList();
            if (maliyet != null)
            {              
                cmb_EkMaliyet.Properties.DataSource = maliyet;
                cmb_EkMaliyet.Properties.ValueMember = "EkMaliyetID";
                cmb_EkMaliyet.Properties.DisplayMember = "EkMaliyetAdi";
            }
            else
            {
                MessageBox.Show("Hata, Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txt_UrunAdi_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            UrunListesi urunListesi = (UrunListesi)Application.OpenForms["UrunListesi"];
            if (Application.OpenForms["UrunListesi"] == null)
            {
                UrunListesi yenipencere = new UrunListesi();
                yenipencere.ShowDialog();
            }
            else
            {
                urunListesi.BringToFront();
            }
        }

        private void Txt_Miktar_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_UrunBirimFiyati.Text == "" || txt_UrunBirimFiyati.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_UrunBirimFiyati, "Birim fiyatı boş, önce ürün seçiniz.");
            }
            else if (txt_Miktar.Text == "" || txt_Miktar.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_Miktar, "Adet giriniz.");
            }
            else
            {
                err_HataDurumu.ClearErrors();
                decimal miktar = Convert.ToDecimal(txt_Miktar.Text);
                decimal birimFiyati = Convert.ToDecimal(txt_UrunBirimFiyati.Text);
                decimal birimAgirlik = Convert.ToDecimal(txt_BirimAgirligi.Text);
                decimal toplamTutar = birimFiyati * miktar;
                decimal toplamAgirlik = birimAgirlik * miktar;
                txt_ToplamAdetTutari.Text = toplamTutar.ToString();
                txt_ToplamAdetAgirligi.Text = toplamAgirlik.ToString();
            }
        }

        private void Txt_Miktar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Btn_UrunEkle_Click(object sender, EventArgs e)
        {
            if (txt_UrunAdi.Text == "" || txt_Miktar.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_UrunAdi, "Ürün seçiniz.");
            }
            else if (txt_Miktar.Text == "" || txt_Miktar.Text == "0" || txt_Miktar.Text == "0,00" || txt_Miktar.Text == String.Empty)
            {
                err_HataDurumu.SetError(txt_Miktar, "Ürün adeti giriniz.");
            }
            else
            {
                MaliyetDetayi maliyetDetayi = new MaliyetDetayi()
                {
                    MaliyetID = seciliMaliyet.MaliyetID,
                    UrunID = secilenUrunID,
                    MaliyetBirimi = txt_UrunBirimi.Text,
                    BirimAgirlik = Convert.ToDecimal(txt_BirimAgirligi.Text),
                    BirimFiyati = Convert.ToDecimal(txt_UrunBirimFiyati.Text),
                    UrunMiktari = Convert.ToInt32(txt_Miktar.Text),
                    ToplamTutar = Convert.ToDecimal(txt_ToplamAdetTutari.Text),
                    ToplamAgirlik = Convert.ToDecimal(txt_ToplamAdetAgirligi.Text),
                };
                db.MaliyetDetayi.Add(maliyetDetayi);
                db.SaveChanges();
                maliyetListele();
                tablePnl_Bir.Enabled = true;

                if (txt_Miktar.Text == "")
                {
                    err_HataDurumu.SetError(txt_Miktar, "Ürün adeti alanını boş geçemezsiniz.");
                }
                else
                {
                    decimal miktar = Convert.ToDecimal(txt_Miktar.Text);
                    decimal birimFiyati = Convert.ToDecimal(txt_UrunBirimFiyati.Text);
                    decimal birimAgirlik = Convert.ToDecimal(txt_BirimAgirligi.Text);
                    decimal toplamTutar = birimFiyati * miktar;
                    decimal toplamAgirlik = birimAgirlik * miktar;
                    txt_ToplamAdetTutari.Text = toplamTutar.ToString();
                    txt_ToplamAdetAgirligi.Text = toplamAgirlik.ToString();
                }                
            }
        }

        private void Btn_UrunSil_Click(object sender, EventArgs e)
        {
            if (grView_MaliyetTablosu.RowCount > 0)
            {
                int[] secilenler = grView_MaliyetTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_MaliyetTablosu.GetRowCellValue(secilenler[0], "MaliyetDetayiID"));
                var sil = (from md in db.MaliyetDetayi
                           where md.MaliyetDetayiID == id
                           select md).FirstOrDefault();
                db.MaliyetDetayi.Remove(sil);
                db.SaveChanges();
                maliyetListele();
            }
            else
            {
                grCtrl_MaliyetTablosu.DataSource = null;
            }
        }

        private void Btn_UrunGuncelle_Click(object sender, EventArgs e)
        {
            if (txt_UrunAdi.Text == "")
            {
                err_HataDurumu.SetError(txt_UrunAdi, "Ürün seçiniz.");
            }
            else if (txt_Miktar.Text == "")
            {
                err_HataDurumu.SetError(txt_Miktar, "Ürün adeti giriniz.");
            }
            else
            {
                if (txt_Miktar.Text == "")
                {
                    err_HataDurumu.SetError(txt_Miktar, "Ürün adeti alanını boş geçemezsiniz.");
                }
                else
                {
                    decimal miktar = Convert.ToDecimal(txt_Miktar.Text);
                    decimal birimFiyati = Convert.ToDecimal(txt_UrunBirimFiyati.Text);
                    decimal birimAgirlik = Convert.ToDecimal(txt_BirimAgirligi.Text);
                    decimal toplamTutar = birimFiyati * miktar;
                    decimal toplamAgirlik = birimAgirlik * miktar;
                    txt_ToplamAdetTutari.Text = toplamTutar.ToString();
                    txt_ToplamAdetAgirligi.Text = toplamAgirlik.ToString();
                }


                int[] secilenler = grView_MaliyetTablosu.GetSelectedRows();
                int seciliUrun = Convert.ToInt32(grView_MaliyetTablosu.GetRowCellValue(secilenler[0], "MaliyetDetayiID"));
                var guncelle = (from mh in db.MaliyetDetayi
                                where mh.MaliyetDetayiID == seciliUrun
                                select mh).FirstOrDefault();
                guncelle.UrunID = secilenUrunID;
                guncelle.MaliyetBirimi = txt_UrunBirimi.Text;
                guncelle.BirimAgirlik = Convert.ToDecimal(txt_BirimAgirligi.Text);
                guncelle.BirimFiyati = Convert.ToDecimal(txt_UrunBirimFiyati.Text);
                guncelle.UrunMiktari = Convert.ToInt32(txt_Miktar.Text);
                guncelle.ToplamTutar = Convert.ToDecimal(txt_ToplamAdetTutari.Text);
                guncelle.ToplamAgirlik = Convert.ToDecimal(txt_ToplamAdetAgirligi.Text);

                db.SaveChanges();
                int focuedRowHandle = grView_MaliyetTablosu.FocusedRowHandle;
                maliyetListele();
                grView_MaliyetTablosu.FocusedRowHandle = focuedRowHandle;
            }
        }

        private void MaliyetTanimla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txt_MaliyetNo.Text != "" || txt_MaliyetNo.Text != String.Empty)
            {
                if (txt_GenelToplam.Text == "0" || txt_GenelToplam.Text == "0,00" || txt_GenelToplam.Text == "" || txt_GenelToplam.Text == String.Empty)
                {
                    DialogResult result = MessageBox.Show("Maliyet oluşturma işlemi yarım bırakıldı. Maliyeti iptal etmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {

                        int id = Convert.ToInt32(txt_MaliyetNo.Text);
                        var maliyetSil = (from mh in db.Maliyetler
                                          where mh.MaliyetID == id
                                          select mh).FirstOrDefault();

                        db.MaliyetDetayi.RemoveRange(db.MaliyetDetayi.Where(x => x.MaliyetID == id));
                        db.MaliyetEkleri.RemoveRange(db.MaliyetEkleri.Where(x => x.MaliyetID == id));

                        db.Maliyetler.Remove(maliyetSil);
                        db.SaveChanges();

                        temizle();

                        MessageBox.Show("Maliyet iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void Btn_MaliyetiSil_Click(object sender, EventArgs e)
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
                int id = Convert.ToInt32(txt_MaliyetNo.Text);
                var maliyetSil = (from mh in db.Maliyetler
                                  where mh.MaliyetID == id
                                  select mh).FirstOrDefault();

                db.MaliyetDetayi.RemoveRange(db.MaliyetDetayi.Where(x => x.MaliyetID == id));
                db.MaliyetEkleri.RemoveRange(db.MaliyetEkleri.Where(x => x.MaliyetID == id));

                DialogResult sonuc = MessageBox.Show("Maliyeti siliyorsunuz." + "\n" + "DİKKAT! Maliyeti silerseniz, bu maliyete ait tüm ürünler ve bilgiler silinecektir. Yine de silmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sonuc == DialogResult.Yes)
                {
                    db.Maliyetler.Remove(maliyetSil);
                    db.SaveChanges();
                    temizle();

                    MessageBox.Show("Maliyet silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MaliyetListesi maliyetListesi = (MaliyetListesi)Application.OpenForms["MaliyetListesi"];
                    if (Application.OpenForms["MaliyetListesi"] != null)
                    {
                        maliyetListesi.maliyetListele();
                    }
                }
                else
                {
                    MessageBox.Show("Maliyet silinmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Btn_EkMaliyetEkle_Click(object sender, EventArgs e)
        {
            if (txt_EkMaliyetTutari.Text == "")
            {
                err_HataDurumu.SetError(txt_EkMaliyetTutari, "Tutar giriniz.");
            }
            else if (cmb_EkMaliyet.ItemIndex == 0)
            {
                err_HataDurumu.SetError(cmb_EkMaliyet, "Ek maliyet seçiniz.");
            }
            else
            {
                MaliyetEkleri maliyetEkleri = new MaliyetEkleri()
                {
                    MaliyetID = seciliMaliyet.MaliyetID,
                    EkMaliyetID = Convert.ToInt32(cmb_EkMaliyet.EditValue),
                    MaliyetFiyati = Convert.ToDecimal(txt_EkMaliyetTutari.Text),
                };
                db.MaliyetEkleri.Add(maliyetEkleri);
                db.SaveChanges();
                dtw_EkMaliyetListele();
            }
        }

        private void Bar_EkMaliyetYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cmb_EkMaliyetListele();
            dtw_EkMaliyetListele();
        }

        private void Bar_EkMaliyetSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grView_EkMaliyetTablosu.RowCount > 0)
            {
                int[] secilenler = grView_EkMaliyetTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_EkMaliyetTablosu.GetRowCellValue(secilenler[0], "MaliyetEkleriID"));
                var sil = (from me in db.MaliyetEkleri
                           where me.MaliyetEkleriID == id
                           select me).FirstOrDefault();
                db.MaliyetEkleri.Remove(sil);
                db.SaveChanges();
                dtw_EkMaliyetListele();
            }
            else
            {
                grCtrl_EkMaliyetTablosu.DataSource = null;
            }
        }

        private void Btn_MaliyetiKaydet_Click(object sender, EventArgs e)
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
                grView_MaliyetTablosu.UpdateSummary();
                decimal ilkTutar = 0;
                decimal genelToplam = 0;
                if (grView_EkMaliyetTablosu.RowCount > 0)
                {
                    ilkTutar = Convert.ToDecimal(grView_MaliyetTablosu.Columns["ToplamTutar"].SummaryItem.SummaryValue);
                    toplamAgirlik = Convert.ToDecimal(grView_MaliyetTablosu.Columns["ToplamAgirlik"].SummaryItem.SummaryValue);
                    decimal tutar = 0;
                    for (int index = 0; index <= grView_EkMaliyetTablosu.RowCount - 1; index++)
                    {
                        tutar += Convert.ToDecimal(grView_EkMaliyetTablosu.GetRowCellValue(index, "MaliyetFiyati"));
                    }
                    genelToplam = ilkTutar + tutar;
                    txt_GenelToplam.Text = genelToplam.ToString();
                }
                else
                {
                    ilkTutar = Convert.ToDecimal(grView_MaliyetTablosu.Columns["ToplamTutar"].SummaryItem.SummaryValue);
                    toplamAgirlik = Convert.ToDecimal(grView_MaliyetTablosu.Columns["ToplamAgirlik"].SummaryItem.SummaryValue);
                    txt_GenelToplam.Text = ilkTutar.ToString();
                }
                int id = Convert.ToInt32(txt_MaliyetNo.Text);
                var guncelle = (from mh in db.Maliyetler
                                where mh.MaliyetID == id
                                select mh).FirstOrDefault();
                guncelle.IlkTutar = Convert.ToDecimal(ilkTutar);
                guncelle.GenelToplamAgirlik = toplamAgirlik;
                guncelle.GenelToplamTutar = Convert.ToDecimal(txt_GenelToplam.Text);
                guncelle.KaydedenID = KullaniciBilgileri.KaydedenID;
                guncelle.KayitTarihi = DateTime.Now;
                db.SaveChanges();
                dtw_EkMaliyetListele();
                btn_MaliyetYazdir.Enabled = true;
                MessageBox.Show("İşlem başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MaliyetListesi maliyetListesi = (MaliyetListesi)Application.OpenForms["MaliyetListesi"];
                if (Application.OpenForms["MaliyetListesi"] != null)
                {
                    maliyetListesi.maliyetListele();
                }
            }
        }

        private void GrView_MaliyetTablosu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (grView_MaliyetTablosu.RowCount > 0)
            {
                int[] secilenler = grView_MaliyetTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_MaliyetTablosu.GetRowCellValue(secilenler[0], "MaliyetDetayiID"));
                var maliyetDetayiGetir = (from md in db.MaliyetDetayi.AsNoTracking()
                                          join u in db.Urunler
                                          on md.UrunID equals u.UrunID
                                          where md.MaliyetDetayiID == id
                                          select new
                                          {
                                              u.UrunAdi,
                                              md.MaliyetBirimi,
                                              md.BirimAgirlik,
                                              md.BirimFiyati,
                                              md.UrunMiktari,
                                              md.ToplamAgirlik,
                                              md.ToplamTutar,
                                          }).FirstOrDefault();
                if (maliyetDetayiGetir != null)
                {
                    txt_UrunAdi.Text = maliyetDetayiGetir.UrunAdi;
                    txt_UrunBirimi.Text = maliyetDetayiGetir.MaliyetBirimi.ToString();
                    txt_BirimAgirligi.Text = maliyetDetayiGetir.BirimAgirlik.ToString();
                    txt_UrunBirimFiyati.Text = maliyetDetayiGetir.BirimFiyati.ToString();
                    txt_Miktar.Text = maliyetDetayiGetir.UrunMiktari.ToString();
                    txt_ToplamAdetAgirligi.Text = maliyetDetayiGetir.ToplamAgirlik.ToString();
                    txt_ToplamAdetTutari.Text = maliyetDetayiGetir.ToplamTutar.ToString();
                }

                var urunSorgu = (from md in db.MaliyetDetayi
                                 where md.MaliyetDetayiID == id
                                 select md).FirstOrDefault();
                if (urunSorgu != null)
                {
                    secilenUrunID = Convert.ToInt32(urunSorgu.UrunID);
                }
            }
        }

        private static void pdf_YaziEkle(PdfPTable tablo, string yazi, int satırBirlestir, int sutunBirlestir, int hucreYasla, int hucreBorder, iTextSharp.text.Font yaziTipi, int padding)
        {
            PdfPCell hucre_Yazi = new PdfPCell(new Phrase(yazi, yaziTipi));
            hucre_Yazi.Rowspan = satırBirlestir;
            hucre_Yazi.Colspan = sutunBirlestir;
            hucre_Yazi.Border = hucreBorder;
            hucre_Yazi.HorizontalAlignment = hucreYasla;
            hucre_Yazi.Padding = padding;
            hucre_Yazi.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            tablo.AddCell(hucre_Yazi);
        }

        public void pdf_Yazdır()
        {
            //Phrase p;
            decimal gtt = 0m;
            var sorgu = (from md in db.MaliyetDetayi
                         join mh in db.Maliyetler
                         on md.MaliyetID equals mh.MaliyetID
                         where md.MaliyetID == seciliMaliyet.MaliyetID || seciliMaliyet.GenelToplamTutar != gtt
                         select md).FirstOrDefault();
            if (sorgu != null)
            {
                iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document();
                Document doc = new Document();

                BaseFont font = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\tahoma.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font_SekizKalin = new iTextSharp.text.Font(font, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font font_SekizNormal = new iTextSharp.text.Font(font, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font font_DokuzNormal = new iTextSharp.text.Font(font, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font font_BuyukBaslik = new iTextSharp.text.Font(font, 18, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE);

                try
                {

                    PdfWriter.GetInstance(pdfDosya, new FileStream(@".\Maliyet.pdf", FileMode.Create));


                pdfDosya.AddCreator("Rafgrup"); //Oluşturan kişinin isminin eklenmesi
                pdfDosya.AddCreationDate();//Oluşturulma tarihinin eklenmesi
                pdfDosya.AddAuthor("Maliyet Raporu v.1.0"); //Yazarın isiminin eklenmesi
                pdfDosya.AddHeader("Başlık", "PDF UYGULAMASI OLUSTUR");
                pdfDosya.AddTitle("ITrack Aylık Fatura"); //Başlık ve title eklenmesi

                int id = Convert.ToInt32(txt_MaliyetNo.Text);
                var kontrol = (from md in db.MaliyetDetayi
                               join mh in db.Maliyetler
                               on md.MaliyetID equals mh.MaliyetID
                               join u in db.Urunler
                               on md.UrunID equals u.UrunID
                               where md.MaliyetID == id
                               select new
                               {
                                   md.MaliyetID,
                                   u.UrunAdi,
                                   md.MaliyetBirimi,
                                   md.BirimAgirlik,
                                   md.BirimFiyati,
                                   md.UrunMiktari,
                                   md.ToplamTutar,
                                   md.ToplamAgirlik,
                                   mh.IlkTutar,
                                   mh.GenelToplamAgirlik,
                                   mh.GenelToplamTutar,
                               }).ToList();
                if (kontrol != null)
                {
                    PdfPTable tablo_Baslik = new PdfPTable(2);
                    tablo_Baslik.TotalWidth = 550f;
                    tablo_Baslik.LockedWidth = true;

                    float[] genislik_Baslik = new float[] { 500f, 50f };
                    tablo_Baslik.SetWidths(genislik_Baslik);

                    if (kontrol.FirstOrDefault().MaliyetID != null)
                    {
                        pdf_YaziEkle(tablo_Baslik, "ÜRÜN FORMU", 2, 1, 1, 15, font_BuyukBaslik, 3);
                        pdf_YaziEkle(tablo_Baslik, "No:", 1, 1, 0, 9, font_SekizKalin, 3);
                        pdf_YaziEkle(tablo_Baslik, kontrol.FirstOrDefault().MaliyetID.ToString(), 1, 1, 0, 9, font_SekizNormal, 3);
                    }
                    else
                    {
                        MessageBox.Show("hata");
                    }

                    //p = new Phrase("\n");

                    PdfPTable tablo_Icerik = new PdfPTable(7);
                    tablo_Icerik.TotalWidth = 550f;
                    tablo_Icerik.LockedWidth = true;

                    float[] genislik_Icerik = new float[] { 80f, 30f, 30f, 30f, 30f, 30f, 30f, };
                    tablo_Icerik.SetWidths(genislik_Icerik);

                    pdf_YaziEkle(tablo_Icerik, "Malzeme Adı", 1, 1, 0, 15, font_SekizKalin, 3);
                    pdf_YaziEkle(tablo_Icerik, "Ağırlık", 1, 1, 1, 15, font_SekizKalin, 3);
                    pdf_YaziEkle(tablo_Icerik, "Miktar", 1, 2, 1, 15, font_SekizKalin, 3);
                    pdf_YaziEkle(tablo_Icerik, "Birim Fiyatı", 1, 1, 1, 15, font_SekizKalin, 3);
                    pdf_YaziEkle(tablo_Icerik, "Toplam Tutar", 1, 1, 1, 15, font_SekizKalin, 3);
                    pdf_YaziEkle(tablo_Icerik, "Toplam Ağırlık", 1, 1, 1, 15, font_SekizKalin, 3);

                    foreach (var item in kontrol)
                    {
                        pdf_YaziEkle(tablo_Icerik, item.UrunAdi, 1, 1, 0, 15, font_SekizNormal, 3);
                        pdf_YaziEkle(tablo_Icerik, item.BirimAgirlik.ToString(), 1, 1, 1, 15, font_SekizNormal, 3);
                        pdf_YaziEkle(tablo_Icerik, item.UrunMiktari.ToString(), 1, 1, 1, 15, font_SekizNormal, 3);
                        pdf_YaziEkle(tablo_Icerik, item.MaliyetBirimi, 1, 1, 1, 15, font_SekizNormal, 3);
                        pdf_YaziEkle(tablo_Icerik, item.BirimFiyati.ToString(), 1, 1, 1, 15, font_SekizNormal, 3);
                        pdf_YaziEkle(tablo_Icerik, item.ToplamTutar.ToString(), 1, 1, 1, 15, font_SekizNormal, 3);
                        pdf_YaziEkle(tablo_Icerik, item.ToplamAgirlik.ToString(), 1, 1, 1, 15, font_SekizNormal, 3);
                    }



                    pdf_YaziEkle(tablo_Icerik, "", 1, 3, 1, 0, font_SekizKalin, 3);
                    pdf_YaziEkle(tablo_Icerik, "TOPLAM", 1, 2, 0, 15, font_SekizKalin, 3);
                    pdf_YaziEkle(tablo_Icerik, kontrol.FirstOrDefault().IlkTutar.ToString(), 1, 2, 1, 15, font_SekizNormal, 3);

                    var ekMaliyetKontrol = (from me in db.MaliyetEkleri
                                            join mh in db.Maliyetler
                                            on me.MaliyetID equals mh.MaliyetID
                                            join em in db.EkMaliyetler
                                            on me.EkMaliyetID equals em.EkMaliyetID
                                            where me.MaliyetID == seciliMaliyet.MaliyetID
                                            select new
                                            {
                                                em.EkMaliyetAdi,
                                                me.MaliyetFiyati,
                                            }).ToList();

                    if (ekMaliyetKontrol != null)
                    {
                        foreach (var item in ekMaliyetKontrol)
                        {
                            pdf_YaziEkle(tablo_Icerik, "", 1, 3, 1, 0, font_SekizKalin, 3);
                            pdf_YaziEkle(tablo_Icerik, item.EkMaliyetAdi, 1, 2, 0, 15, font_SekizKalin, 3);
                            pdf_YaziEkle(tablo_Icerik, item.MaliyetFiyati.ToString(), 1, 2, 1, 15, font_SekizNormal, 3);
                        }
                    }

                    pdf_YaziEkle(tablo_Icerik, "", 1, 3, 1, 0, font_SekizKalin, 3);
                    pdf_YaziEkle(tablo_Icerik, "G.TOPLAM AĞIRLIK", 1, 2, 0, 15, font_SekizKalin, 3);
                    pdf_YaziEkle(tablo_Icerik, kontrol.FirstOrDefault().GenelToplamAgirlik.ToString(), 1, 2, 1, 15, font_SekizNormal, 3);

                    pdf_YaziEkle(tablo_Icerik, "", 1, 3, 1, 0, font_SekizKalin, 3);
                    pdf_YaziEkle(tablo_Icerik, "G.TOPLAM TUTAR", 1, 2, 0, 15, font_SekizKalin, 3);
                    pdf_YaziEkle(tablo_Icerik, kontrol.FirstOrDefault().GenelToplamTutar.ToString(), 1, 2, 1, 15, font_SekizNormal, 3);

                    //p = new Phrase("\n");

                    pdfDosya.Open();
                    pdfDosya.Add(tablo_Baslik);
                    pdfDosya.Add(tablo_Icerik);
                    Process.Start(@".\Maliyet.pdf");
                    pdfDosya.Close();
                }
            }
                catch
            {
                MessageBox.Show("Önce açık pdf dosyasını kapatınız.");
            }
        }
            else
            {
                MessageBox.Show("Yazdırmadan önce teklif bilgilerini eksiksiz giriniz..!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_MaliyetYazdir_Click(object sender, EventArgs e)
        {
            if (txt_GenelToplam.Text != "0" || txt_GenelToplam.Text != "0,00" || txt_GenelToplam.Text != "" || txt_GenelToplam.Text != null)
            {
                pdf_Yazdır();
            }
        }

        private void Txt_EkMaliyetTutari_KeyPress(object sender, KeyPressEventArgs e)
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

        private void GrView_EkMaliyetTablosu_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                pp_EkMaliyetMenu.ShowPopup(p2);
            }
        }

        private void GrView_MaliyetTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_MaliyetTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new System.Drawing.Font(e.Appearance.Font, FontStyle.Bold);
            }

        }

        private void GrView_EkMaliyetTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_EkMaliyetTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new System.Drawing.Font(e.Appearance.Font, FontStyle.Bold);
            }

        }

        private void MaliyetTanimla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Anaform anaform = (Anaform)Application.OpenForms["Anaform"];
            if (Application.OpenForms["Anaform"] != null)
            {
                anaform.BringToFront();
            }
        }
    }
}