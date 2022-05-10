using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SiparisTakipSistemi.Kullanici;
using SiparisTakipSistemi.Sistem;

namespace SiparisTakipSistemi.Maliyet
{
    public partial class EkMaliyetTanimla : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public EkMaliyetTanimla()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        private void EkMaliyetTanimla_Load(object sender, EventArgs e)
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
                ekMaliyetListele();
            }
        }

        public void ekMaliyetListele()
        {
            BindingSource bindingSourceEM = new BindingSource();
            var ekMaliyet = (from em in db.EkMaliyetler
                             select em).ToList();
            bindingSourceEM.DataSource = ekMaliyet;
            grCtrl_EkMaliyetTablosu.DataSource = bindingSourceEM;
        }        

        private void Btn_EkMaliyetKaydet_Click(object sender, EventArgs e)
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
                if (txt_EkMaliyetAdi.Text == "" || txt_EkMaliyetAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkMaliyetAdi, "Ek maliyet adı giriniz.");
                }
                else
                {
                    var ekMaliyetKontrol = (from em in db.EkMaliyetler
                                            where em.EkMaliyetAdi == txt_EkMaliyetAdi.Text
                                            select em).FirstOrDefault();
                    if (ekMaliyetKontrol != null)
                    {
                        MessageBox.Show("Ek Maliyet adı daha önce kullanılmış, lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        EkMaliyetler ekMaliyetler = new EkMaliyetler()
                        {
                            EkMaliyetAdi = txt_EkMaliyetAdi.Text,
                            KaydedenID = KullaniciBilgileri.KaydedenID,
                            KayitTarihi = DateTime.Now,
                        };
                        DialogResult sonuc = MessageBox.Show("'" + txt_EkMaliyetAdi.Text + "'" + " " + " " + "adlı ek maliyeti kaydetmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.EkMaliyetler.Add(ekMaliyetler);
                            db.SaveChanges();
                            ekMaliyetListele();
                            grView_EkMaliyetTablosu.MoveLast();
                            temizle();
                            MessageBox.Show("Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Kaydedilmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void Btn_EkMaliyetGuncelle_Click(object sender, EventArgs e)
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
                if (txt_EkMaliyetAdi.Text == "" || txt_EkMaliyetAdi.Text == String.Empty)
                {
                    err_HataDurumu.SetError(txt_EkMaliyetAdi, "Ek maliyet adı giriniz.");
                }
                else
                {
                    if (txt_EkMaliyetNo.Text != "" || txt_EkMaliyetNo.Text != String.Empty)
                    {
                        int id = Convert.ToInt32(txt_EkMaliyetNo.Text);
                        var ekMaliyetKontrol = (from em in db.EkMaliyetler
                                                where em.EkMaliyetID != id && em.EkMaliyetAdi == txt_EkMaliyetAdi.Text
                                                select em).FirstOrDefault();
                        if (ekMaliyetKontrol == null)
                        {
                            var ekMaliyet = (from em in db.EkMaliyetler
                                             where em.EkMaliyetID == id
                                             select em).FirstOrDefault();
                            ekMaliyet.EkMaliyetAdi = txt_EkMaliyetAdi.Text;
                            ekMaliyet.KaydedenID = KullaniciBilgileri.KaydedenID;
                            ekMaliyet.KayitTarihi = DateTime.Now;
                            DialogResult sonuc = MessageBox.Show("'" + ekMaliyet.EkMaliyetAdi + "'" + " " + "adlı ek maliyeti güncellemek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (sonuc == DialogResult.Yes)
                            {
                                db.SaveChanges();
                                int focuedRowHandle = grView_EkMaliyetTablosu.FocusedRowHandle;
                                ekMaliyetListele();
                                grView_EkMaliyetTablosu.FocusedRowHandle = focuedRowHandle;

                                MessageBox.Show("Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Güncellenmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ek Maliyet adı daha önce kullanılmış, lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void Btn_EkMaliyetSil_Click(object sender, EventArgs e)
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
                if (txt_EkMaliyetNo.Text != "" || txt_EkMaliyetNo.Text != String.Empty)
                {
                    int id = Convert.ToInt32(txt_EkMaliyetNo.Text);
                    var urunKontrol = (from me in db.MaliyetEkleri
                                       join em in db.EkMaliyetler
                                       on me.EkMaliyetID equals em.EkMaliyetID
                                       where me.EkMaliyetID == id
                                       select me).FirstOrDefault();
                    if (urunKontrol != null)
                    {
                        MessageBox.Show("Silmek istediğiniz ek maliyet, maliyet hesaplarken kullanılmış. Bu yüzden silemezsiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var ekMaliyetSil = (from em in db.EkMaliyetler
                                            where em.EkMaliyetID == id
                                            select em).FirstOrDefault();
                        DialogResult sonuc = MessageBox.Show("'" + ekMaliyetSil.EkMaliyetAdi + "'" + " " + "adlı ek maliyeti siliyorsunuz." + "\n" + "DİKKAT! Ek Maliyeti silerseniz, ek maliyete ait tüm bilgiler silinecektir. Yine de silmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sonuc == DialogResult.Yes)
                        {
                            db.EkMaliyetler.Remove(ekMaliyetSil);
                            db.SaveChanges();
                            ekMaliyetListele();
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
                    MessageBox.Show("Silinecek ek maliyeti seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        void temizle()
        {
            txt_EkMaliyetNo.Text = string.Empty;
            txt_EkMaliyetAdi.Text = string.Empty;
            btn_EkMaliyetKaydet.Visible = true;
            btn_EkMaliyetGuncelle.Visible = false;
            btn_EkMaliyetSil.Visible = false;
        }

        private void Btn_Temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void GrView_EkMaliyetTablosu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (grView_EkMaliyetTablosu.RowCount > 0)
            {
                int[] secilenler = grView_EkMaliyetTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_EkMaliyetTablosu.GetRowCellValue(secilenler[0], "EkMaliyetID"));
                var ekMaliyetGetir = (from em in db.EkMaliyetler
                                      where em.EkMaliyetID == id
                                      select em).FirstOrDefault();
                if (ekMaliyetGetir != null)
                {
                    txt_EkMaliyetNo.Text = ekMaliyetGetir.EkMaliyetID.ToString();
                    txt_EkMaliyetAdi.Text = ekMaliyetGetir.EkMaliyetAdi;
                    btn_EkMaliyetKaydet.Visible = false;
                    btn_EkMaliyetGuncelle.Visible = true;
                    btn_EkMaliyetSil.Visible = true;
                    btn_EkMaliyetSil.Location = new Point(86, 85);
                }
                else
                {
                    MessageBox.Show("Hata oluştu. Lütfen sistem yöneticisi ile iletişime geçiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GrView_EkMaliyetTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_EkMaliyetTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void Txt_EkMaliyetAdi_EditValueChanged(object sender, EventArgs e)
        {
            err_HataDurumu.ClearErrors();
            txt_EkMaliyetAdi.Text = txt_EkMaliyetAdi.Text.ToUpper();
        }

        private void EkMaliyetTanimla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Anaform anaform = (Anaform)Application.OpenForms["Anaform"];
            if (Application.OpenForms["Anaform"] != null)
            {
                anaform.BringToFront();
            }
        }
    }
}