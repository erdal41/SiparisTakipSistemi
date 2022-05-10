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

namespace SiparisTakipSistemi.Maliyet
{
    public partial class MaliyetListesi : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public MaliyetListesi()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        private void MaliyetListesi_Load(object sender, EventArgs e)
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
                maliyetListele();
            }
        }

        public void maliyetListele()
        {
            BindingSource bindingSourceMDetayi = new BindingSource();
            var maliyet = (from ml in db.Maliyetler
                          select new
                          {
                              ml.MaliyetID,
                              ml.GenelToplamAgirlik,
                              ml.GenelToplamTutar,
                          }).ToList();
            if (maliyet != null)
            {
                bindingSourceMDetayi.DataSource = maliyet;
                grCtrl_MaliyetTablosu.DataSource = bindingSourceMDetayi;
                grView_MaliyetTablosu.ClearSelection();
            }
        }

        private void GrView_MaliyetTablosu_DoubleClick(object sender, EventArgs e)
        {
            if (grView_MaliyetTablosu.RowCount > 0)
            {
                int[] secilenler = grView_MaliyetTablosu.GetSelectedRows();
                int id = Convert.ToInt32(grView_MaliyetTablosu.GetRowCellValue(secilenler[0], "MaliyetID"));
                if (Application.OpenForms["MaliyetTanimla"] != null)
                {
                    MaliyetTanimla maliyetTanimla = (MaliyetTanimla)Application.OpenForms["MaliyetTanimla"];
                    var maliyet = (from ml in db.Maliyetler.AsNoTracking()
                                   where ml.MaliyetID == id
                                   select ml).FirstOrDefault();
                    if (maliyet != null)
                    {
                        maliyetTanimla.seciliMaliyet = maliyet;
                        maliyetTanimla.txt_MaliyetNo.Text = maliyet.MaliyetID.ToString();
                        maliyetTanimla.txt_GenelToplam.Text = maliyet.GenelToplamTutar.ToString();
                        maliyetTanimla.txt_Miktar.Text = "0";
                        maliyetTanimla.pnl_Bir.Enabled = true;
                        maliyetTanimla.pnl_Iki.Enabled = true;
                        maliyetTanimla.tablePnl_Bir.Enabled = true;
                        maliyetTanimla.btn_MaliyetOlustur.Visible = false;
                        maliyetTanimla.btn_MaliyetYazdir.Enabled = true;
                        maliyetTanimla.btn_MaliyetiSil.Enabled = true;

                        BindingSource bindingSourceMDetayi = new BindingSource();
                        var maliyetDetayi = (from md in db.MaliyetDetayi
                                             join mh in db.Maliyetler
                                             on md.MaliyetID equals mh.MaliyetID
                                             join u in db.Urunler
                                             on md.UrunID equals u.UrunID
                                             where md.MaliyetID == id
                                             select new
                                             {
                                                 md.MaliyetDetayiID,
                                                 u.UrunAdi,
                                                 md.MaliyetBirimi,
                                                 md.BirimAgirlik,
                                                 md.BirimFiyati,
                                                 md.UrunMiktari,
                                                 md.ToplamAgirlik,
                                                 md.ToplamTutar,
                                             }).ToList();
                        if (maliyetDetayi != null)
                        {
                            bindingSourceMDetayi.DataSource = maliyetDetayi;
                            maliyetTanimla.grCtrl_MaliyetTablosu.DataSource = bindingSourceMDetayi;
                            maliyetTanimla.grView_MaliyetTablosu.ClearSelection();
                        }
                        else
                        {
                            MessageBox.Show("hata 1");
                        }

                        BindingSource bindingSourceMEkleri = new BindingSource();
                        var ekMaliyet = (from me in db.MaliyetEkleri
                                         join ml in db.Maliyetler
                                         on me.MaliyetID equals ml.MaliyetID
                                         join em in db.EkMaliyetler
                                         on me.EkMaliyetID equals em.EkMaliyetID
                                         where me.MaliyetID == id
                                         select new
                                         {
                                             me.MaliyetEkleriID,
                                             em.EkMaliyetAdi,
                                             me.MaliyetFiyati,
                                         }).ToList();
                        if (ekMaliyet != null)
                        {
                            bindingSourceMEkleri.DataSource = ekMaliyet;
                            maliyetTanimla.grCtrl_EkMaliyetTablosu.DataSource = bindingSourceMEkleri;
                            maliyetTanimla.grView_EkMaliyetTablosu.ClearSelection();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Maliyet seçiminde hata oluştu. Sistem yöneticisi ile iletişime geçiniz.");
                    }
                }
                else
                {
                    MaliyetTanimla maliyetTanimla = new MaliyetTanimla();
                    var maliyet = (from ml in db.Maliyetler.AsNoTracking()
                                   where ml.MaliyetID == id
                                   select ml).FirstOrDefault();
                    if (maliyet != null)
                    {

                        maliyetTanimla.seciliMaliyet = maliyet;
                        maliyetTanimla.txt_MaliyetNo.Text = maliyet.MaliyetID.ToString();
                        maliyetTanimla.txt_GenelToplam.Text = maliyet.GenelToplamTutar.ToString();
                        maliyetTanimla.txt_Miktar.Text = "0";
                        maliyetTanimla.pnl_Bir.Enabled = true;
                        maliyetTanimla.pnl_Iki.Enabled = true;
                        maliyetTanimla.tablePnl_Bir.Enabled = true;
                        maliyetTanimla.btn_MaliyetOlustur.Visible = false;
                        maliyetTanimla.btn_MaliyetYazdir.Enabled = true;
                        maliyetTanimla.btn_MaliyetiSil.Enabled = true;

                        BindingSource bindingSourceMDetayi = new BindingSource();
                        var maliyetDetayi = (from md in db.MaliyetDetayi
                                             join mh in db.Maliyetler
                                             on md.MaliyetID equals mh.MaliyetID
                                             join u in db.Urunler
                                             on md.UrunID equals u.UrunID
                                             where md.MaliyetID == id
                                             select new
                                             {
                                                 md.MaliyetDetayiID,
                                                 u.UrunAdi,
                                                 md.MaliyetBirimi,
                                                 md.BirimAgirlik,
                                                 md.BirimFiyati,
                                                 md.UrunMiktari,
                                                 md.ToplamAgirlik,
                                                 md.ToplamTutar,
                                             }).ToList();
                        if (maliyetDetayi != null)
                        {
                            maliyetTanimla.Show();
                            bindingSourceMDetayi.DataSource = maliyetDetayi;
                            maliyetTanimla.grCtrl_MaliyetTablosu.DataSource = bindingSourceMDetayi;
                            maliyetTanimla.grView_MaliyetTablosu.ClearSelection();
                        }

                        BindingSource bindingSourceMEkleri = new BindingSource();
                        var ekMaliyet = (from me in db.MaliyetEkleri
                                         join ml in db.Maliyetler
                                         on me.MaliyetID equals ml.MaliyetID
                                         join em in db.EkMaliyetler
                                         on me.EkMaliyetID equals em.EkMaliyetID
                                         where me.MaliyetID == id
                                         select new
                                         {
                                             me.MaliyetEkleriID,
                                             em.EkMaliyetAdi,
                                             me.MaliyetFiyati,
                                         }).ToList();
                        if (ekMaliyet != null)
                        {
                            bindingSourceMEkleri.DataSource = ekMaliyet;
                            maliyetTanimla.grCtrl_EkMaliyetTablosu.DataSource = bindingSourceMEkleri;
                            maliyetTanimla.grView_EkMaliyetTablosu.ClearSelection();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Maliyet seçiminde hata oluştu. Sistem yöneticisi ile iletişime geçiniz.");
                    }
                }
            }
        }

        private void Btn_MaliyetOlustur_Click(object sender, EventArgs e)
        {
            var yetkiKontrol = (from fy in db.FormYetkileri
                                join k in db.Kullanicilar
                                on fy.KullaniciID equals k.KullaniciID
                                where fy.KullaniciID == KullaniciBilgileri.KaydedenID && fy.Ac == false && fy.FormAdi == "Maliyet İşlemleri"
                                select fy).FirstOrDefault();
            if (yetkiKontrol != null)
            {
                MessageBox.Show("Bu işlem için yetkiniz yoktur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MaliyetTanimla maliyetTanimla = (MaliyetTanimla)Application.OpenForms["MaliyetTanimla"];
                if (Application.OpenForms["MaliyetTanimla"] == null)
                {
                    MaliyetTanimla yenipencere = new MaliyetTanimla();
                    yenipencere.Show();
                }
                else
                {
                    maliyetTanimla.BringToFront();
                }
            }
        }

        private void GrView_MaliyetTablosu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grView_MaliyetTablosu.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.ForeColor = Color.DarkSlateGray;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }

        }

        private void MaliyetListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Anaform anaform = (Anaform)Application.OpenForms["Anaform"];
            if (Application.OpenForms["Anaform"] != null)
            {
                anaform.BringToFront();
            }
        }
    }
}