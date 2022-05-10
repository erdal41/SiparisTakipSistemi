using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SiparisTakipSistemi.Kullanici;
using SiparisTakipSistemi.Maliyet;
using SiparisTakipSistemi.Sistem;

namespace SiparisTakipSistemi.Urun
{
    public partial class UrunListesi : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public UrunListesi()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        private void UrunListesi_Load(object sender, EventArgs e)
        {
            var yetkiKontrol = (from fy in db.FormYetkileri
                                join k in db.Kullanicilar
                                on fy.KullaniciID equals k.KullaniciID
                                where fy.KullaniciID == KullaniciBilgileri.KaydedenID && fy.Ac == false && fy.FormAdi == this.Text
                                select fy).FirstOrDefault();
            if (yetkiKontrol != null)
            {
                MessageBox.Show("Bu işlem için yetkiniz yoktur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                urunListele();
                this.MinimumSize = new Size(393, 396);
            }
        }

        public void urunListele()
        {
            BindingSource bindingSourceUrunler = new BindingSource();
            var urun = (from u in db.Urunler
                        select new
                        {
                            u.UrunID,
                            u.UrunAdi,
                        }).ToList();
            if (urun != null)
            {
                bindingSourceUrunler.DataSource = urun;
                grCtrl_UrunTablosu.DataSource = bindingSourceUrunler;
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
                                where fy.KullaniciID == KullaniciBilgileri.KaydedenID && fy.Ac == false && fy.FormAdi == "Ürün İşlemleri"
                                select fy).FirstOrDefault();
            if (yetkiKontrol != null)
            {
                MessageBox.Show("Bu işlem için yetkiniz yoktur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                UrunTanimla urunTanimla = new UrunTanimla();
                urunTanimla.ShowDialog();
            }
        }

        private void GrCtrl_UrunTablosu_DoubleClick(object sender, EventArgs e)
        {
            if (grView_UrunTablosu.RowCount > 0)
            {
                if (Application.OpenForms["MaliyetTanimla"] != null)
                {
                    int[] secilenler = grView_UrunTablosu.GetSelectedRows();
                    int id = Convert.ToInt32(grView_UrunTablosu.GetRowCellValue(secilenler[0], "UrunID"));
                    var urun = (from u in db.Urunler
                                where u.UrunID == id
                                select new
                                {
                                    u.UrunID,
                                    u.UrunAdi,
                                    u.UrunBirimi,
                                    u.UrunBirimFiyati,
                                    u.UrunAgirlik,
                                }).FirstOrDefault();
                    if (urun != null)
                    {
                        MaliyetTanimla maliyetTanimla = (MaliyetTanimla)Application.OpenForms["MaliyetTanimla"];
                        maliyetTanimla.secilenUrunID = urun.UrunID;
                        maliyetTanimla.txt_UrunAdi.Text = urun.UrunAdi;
                        maliyetTanimla.txt_UrunBirimi.Text = urun.UrunBirimi;
                        maliyetTanimla.txt_UrunBirimFiyati.Text = urun.UrunBirimFiyati.ToString();
                        maliyetTanimla.txt_BirimAgirligi.Text = urun.UrunAgirlik.ToString();
                        maliyetTanimla.txt_Miktar.Text = "0";
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ürün seçiminde hata oluştu. Sistem yöneticisi ile iletişime geçiniz.");
                    }
                }
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

        private void UrunListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Anaform anaform = (Anaform)Application.OpenForms["Anaform"];
            if (Application.OpenForms["Anaform"] != null)
            {
                anaform.BringToFront();
            }
        }
    }
}