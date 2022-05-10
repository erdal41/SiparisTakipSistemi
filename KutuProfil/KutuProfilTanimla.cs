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
using SiparisTakipSistemi.Bilesen;
using SiparisTakipSistemi.Urun;
using SiparisTakipSistemi.Kullanici;
using SiparisTakipSistemi.Sistem;

namespace SiparisTakipSistemi.KutuProfil
{
    public partial class KutuProfilTanimla : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public KutuProfilTanimla()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        private void KutuProfilTanimla_Load(object sender, EventArgs e)
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
                kutuProfilListele();
                this.MinimumSize = new Size(1002, 327);
            }
        }

        private void kutuProfilListele()
        {
            BindingSource kutuProfilBS = new BindingSource();
            var kutuProfil = (from kp in db.KutuProfiller
                              select new
                              {
                                  kp.KProfilID,
                                  kp.KProfilAdi,
                                  kp.KProfilBirimi,
                                  kp.KProfilBirimFiyati,
                                  kp.KProfilAgirlik,
                              });
            if (kutuProfil != null)
            {
                kutuProfilBS.DataSource = kutuProfil.ToList();
                grCtrl_KProfilTablosu.DataSource = kutuProfilBS;
            }
            else
            {
                MessageBox.Show("Kutu Profiller listelenirken hata oluştu.Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrView_KProfilTablosu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (grView_KProfilTablosu.RowCount > 0)
            {
                int[] secilenler = grView_KProfilTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_KProfilTablosu.GetRowCellValue(secilenler[0], "KProfilID"));
                var kutuProfilGetir = (from kp in db.KutuProfiller.AsNoTracking()
                                    where kp.KProfilID == id
                                    select new
                                    {
                                        kp.KProfilID,
                                        kp.KProfilAdi,
                                        kp.KProfilBirimi,
                                        kp.KProfilAgirlik,
                                        kp.KProfilBirimFiyati,
                                    }).FirstOrDefault();
                if (kutuProfilGetir != null)
                {
                    txt_KProfilNo.Text = kutuProfilGetir.KProfilID.ToString();
                    txt_KProfilAdi.Text = kutuProfilGetir.KProfilAdi.ToString();
                    txt_KProfilBirimi.Text = kutuProfilGetir.KProfilBirimi.ToString();
                    txt_KProfilAgirlik.Text = kutuProfilGetir.KProfilAgirlik.ToString();
                    txt_KProfilBirimFiyati.Text = kutuProfilGetir.KProfilBirimFiyati.ToString();

                }

                btn_KProfilKaydet.Visible = false;
                btn_KProfilGuncelle.Visible = true;
                btn_KProfilSil.Visible = true;
                btn_KProfilSil.Location = new Point(103, 106);
            }
        }

        private void Btn_KProfilKaydet_Click(object sender, EventArgs e)
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
                if (txt_KProfilAdi.Text == "" || txt_KProfilAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_KProfilAdi, "Kutu Profilin adını giriniz.");
                }
                else if (txt_KProfilBirimFiyati.Text == "" || txt_KProfilBirimFiyati.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_KProfilBirimFiyati, "Kutu Profilin birim fiyatını giriniz.");
                }
                else if (txt_KProfilAgirlik.Text == "" || txt_KProfilAgirlik.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_KProfilAgirlik, "Kutu Profilin ağırlığını giriniz.");
                }
                else
                {
                    var kutuProfilKontrol = (from kp in db.KutuProfiller
                                             where kp.KProfilAdi == txt_KProfilAdi.Text
                                             select kp).FirstOrDefault();
                    if (kutuProfilKontrol != null)
                    {
                        MessageBox.Show("Girdiğiniz kutu profil ismi zaten kayıtlı. Lütfen başka isim giriniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        KutuProfiller kutuProfiller = new KutuProfiller()
                        {
                            KProfilAdi = txt_KProfilAdi.Text,
                            KProfilBirimi = txt_KProfilBirimi.Text,
                            KProfilBirimFiyati = Convert.ToDecimal(txt_KProfilBirimFiyati.Text),
                            KProfilAgirlik = Convert.ToDecimal(txt_KProfilAgirlik.Text),
                            KProfilUzunluk = 1,
                            KaydedenID = KullaniciBilgileri.KaydedenID,
                            KayitTarihi = DateTime.Now,
                        };
                        db.KutuProfiller.Add(kutuProfiller);
                        db.SaveChanges();
                        txt_KProfilNo.Text = kutuProfiller.KProfilID.ToString();
                        kutuProfilListele();
                        grView_KProfilTablosu.MoveLast();
                        MessageBox.Show("Kutu Profil kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        temizle();
                    }
                }
            }
        }

        private void Btn_KProfilGuncelle_Click(object sender, EventArgs e)
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
                if (txt_KProfilAdi.Text == "" || txt_KProfilAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_KProfilAdi, "Kutu Profilin adını giriniz.");
                }
                else if (txt_KProfilBirimFiyati.Text == "" || txt_KProfilBirimFiyati.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_KProfilBirimFiyati, "Kutu Profilin birim fiyatını giriniz.");
                }
                else if (txt_KProfilAgirlik.Text == "" || txt_KProfilAgirlik.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_KProfilAgirlik, "Kutu Profilin ağırlığını giriniz.");
                }
                else
                {
                    int id = Convert.ToInt32(txt_KProfilNo.Text);
                    var kutuProfilKontrol = (from kp in db.KutuProfiller
                                             where kp.KProfilID != id && kp.KProfilAdi == txt_KProfilAdi.Text
                                             select kp).FirstOrDefault();
                    if (kutuProfilKontrol == null)
                    {
                        var kutuProfilGuncelle = (from kp in db.KutuProfiller
                                                  where kp.KProfilID == id
                                                  select kp).FirstOrDefault();
                        kutuProfilGuncelle.KProfilAdi = txt_KProfilAdi.Text;
                        kutuProfilGuncelle.KProfilBirimi = txt_KProfilBirimi.Text;
                        kutuProfilGuncelle.KProfilBirimFiyati = Convert.ToDecimal(txt_KProfilBirimFiyati.Text);
                        kutuProfilGuncelle.KProfilAgirlik = Convert.ToDecimal(txt_KProfilAgirlik.Text);
                        kutuProfilGuncelle.KProfilUzunluk = 1;
                        kutuProfilGuncelle.KaydedenID = KullaniciBilgileri.KaydedenID;
                        kutuProfilGuncelle.KayitTarihi = DateTime.Now;

                        DialogResult sonuc = MessageBox.Show("'" + kutuProfilGuncelle.KProfilAdi + "'" + " " + "adlı kutu profili güncellemek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            int focuedRowHandle = grView_KProfilTablosu.FocusedRowHandle;
                            kutuProfilListele();
                            grView_KProfilTablosu.FocusedRowHandle = focuedRowHandle;
                            MessageBox.Show("Kutu Profil güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            decimal uzunluk = 0;
                            decimal uzunlukTutari = 0;
                            decimal agirlik = 0;
                            decimal kutuProfilBirimFiyati = Convert.ToDecimal(kutuProfilGuncelle.KProfilBirimFiyati);
                            decimal kutuProfilAgirlik = Convert.ToDecimal(kutuProfilGuncelle.KProfilAgirlik);
                            SiparisTakipEntities db2 = new SiparisTakipEntities();
                            var bilesenKutuProfilleriGuncelle = (from bk in db2.BilesenKProfilleri
                                                                 join bl in db2.Bilesenler
                                                                 on bk.BilesenID equals bl.BilesenID
                                                                 join kp in db2.KutuProfiller
                                                                 on bk.KProfilID equals kp.KProfilID
                                                                 where bk.KProfilID == id
                                                                 select bk).ToList();

                            if (bilesenKutuProfilleriGuncelle != null)
                            {
                                foreach (var item in bilesenKutuProfilleriGuncelle)
                                {
                                    uzunluk = Convert.ToDecimal(item.KProfiUzunluk);
                                    uzunlukTutari = kutuProfilBirimFiyati * uzunluk;
                                    agirlik = kutuProfilAgirlik * uzunluk;
                                    item.KProfilAgirlik = agirlik;
                                    item.UzunlukTutari = uzunlukTutari;
                                }
                            }
                            db2.SaveChanges();


                            SiparisTakipEntities db3 = new SiparisTakipEntities();
                            var bilesenGuncelle = (from bk in db3.BilesenKProfilleri
                                                   join bl in db3.Bilesenler
                                                   on bk.BilesenID equals bl.BilesenID
                                                   join kp in db3.KutuProfiller
                                                   on bk.KProfilID equals kp.KProfilID
                                                   where bk.BilesenID == bl.BilesenID
                                                   select bk).ToList();
                            if (bilesenGuncelle != null)
                            {
                                foreach (var item in bilesenGuncelle)
                                {
                                    var toplamTutar = db3.BilesenKProfilleri.Where(x => x.BilesenID == item.Bilesenler.BilesenID).Sum(x => x.UzunlukTutari);
                                    var toplamAgirlik = db3.BilesenKProfilleri.Where(x => x.BilesenID == item.Bilesenler.BilesenID).Sum(x => x.KProfilAgirlik);
                                    item.Bilesenler.BilesenBirimFiyati = toplamTutar;
                                    item.Bilesenler.BilesenAgirlik = toplamAgirlik;
                                }
                            }
                            else
                            {
                                MessageBox.Show("hata");
                            }
                            db3.SaveChanges();

                            BilesenTanimla bilesenTanimla = (BilesenTanimla)Application.OpenForms["BilesenTanimla"];
                            if (Application.OpenForms["BilesenTanimla"] != null)
                            {
                                bilesenTanimla.bilesenListele();
                                bilesenTanimla.kutuProfilDTWListele();
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
                            else
                            {
                                MessageBox.Show("Sistem hatası. Lütfen sistem yöneticisi ile iletişime geçiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            MessageBox.Show("Kutu Profil güncellenmedi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aynı kutu profil zaten mevcut. Lütfen kontrol ediniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void Btn_KProfilSil_Click(object sender, EventArgs e)
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
                int id = Convert.ToInt32(txt_KProfilNo.Text);
                var kutuProfilKontrol = (from bk in db.BilesenKProfilleri
                                         join kp in db.KutuProfiller
                                         on bk.KProfilID equals kp.KProfilID
                                         where bk.KProfilID == id
                                         select bk).FirstOrDefault();
                if (kutuProfilKontrol != null)
                {
                    MessageBox.Show("Silmek istediğiniz kutu profil kullanılıyor. Lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var kutuProfilSil = (from kp in db.KutuProfiller
                                         where kp.KProfilID == id
                                         select kp).FirstOrDefault();

                    DialogResult sonuc = MessageBox.Show("'" + kutuProfilSil.KProfilAdi + "'" + " " + "adlı kutu profili siliyorsunuz." + "\n" + "DİKKAT! Kutu Profili silerseniz, kutu profile ait tüm bilgiler silinecektir. Yine de silmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (sonuc == DialogResult.Yes)
                    {
                        db.KutuProfiller.Remove(kutuProfilSil);
                        db.SaveChanges();
                        kutuProfilListele();
                        MessageBox.Show("Kutu Profil silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("Kutu Profil silinmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void temizle()
        {
            btn_KProfilKaydet.Visible = true;
            btn_KProfilGuncelle.Visible = false;
            btn_KProfilSil.Visible = false;
            txt_KProfilNo.Text = string.Empty;
            txt_KProfilAdi.Text = string.Empty;
            txt_KProfilBirimFiyati.Text = string.Empty;
            txt_KProfilAgirlik.Text = string.Empty;
            grView_KProfilTablosu.ClearSelection();
        }

        private void Btn_Temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void Txt_KProfilAdi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
            txt_KProfilAdi.Text = txt_KProfilAdi.Text.ToUpper();
        }

        private void Txt_KProfilBirimFiyati_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_KProfilAgirlik_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
        }

        private void Txt_KProfilBirimFiyati_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Txt_KProfilAgirlik_KeyPress(object sender, KeyPressEventArgs e)
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

        private void KutuProfilTanimla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Anaform anaform = (Anaform)Application.OpenForms["Anaform"];
            if (Application.OpenForms["Anaform"] != null)
            {
                anaform.BringToFront();
            }
        }
    }
}