using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.TableLayout;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.Utils.Drawing;
using System.Drawing;
using DevExpress.XtraEditors;

namespace SiparisTakipSistemi.Kullanici
{
    public partial class YetkiTanimla : DevExpress.XtraEditors.XtraForm
    {
        SiparisTakipEntities db;
        public YetkiTanimla()
        {
            InitializeComponent();
            db = new SiparisTakipEntities();
        }

        public BindingSource bindingSource = new BindingSource();
        public int secilenKullaniciID;

        private void YetkiTanimla_Load(object sender, EventArgs e)
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
        }

        public void yetkiListele()
        {
            if (txt_KullaniciAdi.Text != "" || txt_KullaniciAdi.Text != String.Empty)
            {
                var listele = from fy in db.FormYetkileri
                              where fy.KullaniciID == secilenKullaniciID
                              select fy;
                if (listele != null)
                {
                    bindingSource.DataSource = listele.ToList();
                    grCtrl_YetkiTablosu.DataSource = bindingSource;
                }
            }
        }

        private void Btn_YetkiKaydet_Click(object sender, EventArgs e)
        {
            KullaniciTanimla kullaniciTanimla = new KullaniciTanimla();
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
                if (grView_YetkiTablosu.RowCount > 0)
                {
                    var formYetkileri = (from fy in db.FormYetkileri
                                         join k in db.Kullanicilar
                                         on fy.KullaniciID equals k.KullaniciID
                                         where fy.KullaniciID == secilenKullaniciID
                                         select fy).FirstOrDefault();
                    if (formYetkileri != null)
                    {
                        formYetkileri.Ac = Convert.ToBoolean(grView_YetkiTablosu.GetRowCellValue(0, "Ac"));
                        formYetkileri.Ekle = Convert.ToBoolean(grView_YetkiTablosu.GetRowCellValue(0, "Ekle"));
                        formYetkileri.Guncelle = Convert.ToBoolean(grView_YetkiTablosu.GetRowCellValue(0, "Guncelle"));
                        formYetkileri.Sil = Convert.ToBoolean(grView_YetkiTablosu.GetRowCellValue(0, "Sil"));
                        formYetkileri.KaydedenID = KullaniciBilgileri.KaydedenID;
                        formYetkileri.KayitTarihi = DateTime.Now;
                        db.SaveChanges();
                        yetkiListele();
                        MessageBox.Show("Yetkilendirme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Yetkilendirmek istediğiniz kullanıcıyı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Yetkilendirmek istediğiniz kullanıcıyı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Txt_KullaniciAdi_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            KullaniciTanimla kullaniciTanimla = (KullaniciTanimla)Application.OpenForms["KullaniciTanimla"];
            if (Application.OpenForms["KullaniciTanimla"] == null)
            {
                KullaniciTanimla yenipencere = new KullaniciTanimla();
                yenipencere.Show();
                this.Close();
            }
            else
            {
                kullaniciTanimla.BringToFront();
                this.Close();
            }
        }
    }
}