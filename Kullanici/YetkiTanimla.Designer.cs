namespace SiparisTakipSistemi.Kullanici
{
    partial class YetkiTanimla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YetkiTanimla));
            this.pnl_Bir = new DevExpress.XtraEditors.PanelControl();
            this.btn_YetkiKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_KullaniciAdi = new DevExpress.XtraEditors.ButtonEdit();
            this.pnl_Iki = new DevExpress.XtraEditors.PanelControl();
            this.grCtrl_YetkiTablosu = new DevExpress.XtraGrid.GridControl();
            this.grView_YetkiTablosu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_FormYetkileriID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_FormAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ekle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Guncelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sil = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Bir)).BeginInit();
            this.pnl_Bir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_KullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Iki)).BeginInit();
            this.pnl_Iki.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrl_YetkiTablosu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grView_YetkiTablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Bir
            // 
            this.pnl_Bir.Controls.Add(this.btn_YetkiKaydet);
            this.pnl_Bir.Controls.Add(this.label1);
            this.pnl_Bir.Controls.Add(this.txt_KullaniciAdi);
            this.pnl_Bir.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Bir.Location = new System.Drawing.Point(0, 0);
            this.pnl_Bir.Name = "pnl_Bir";
            this.pnl_Bir.Size = new System.Drawing.Size(696, 48);
            this.pnl_Bir.TabIndex = 0;
            // 
            // btn_YetkiKaydet
            // 
            this.btn_YetkiKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_YetkiKaydet.Appearance.Options.UseFont = true;
            this.btn_YetkiKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_YetkiKaydet.ImageOptions.Image")));
            this.btn_YetkiKaydet.Location = new System.Drawing.Point(336, 5);
            this.btn_YetkiKaydet.Name = "btn_YetkiKaydet";
            this.btn_YetkiKaydet.Size = new System.Drawing.Size(74, 37);
            this.btn_YetkiKaydet.TabIndex = 7;
            this.btn_YetkiKaydet.Text = "Kaydet";
            this.btn_YetkiKaydet.Click += new System.EventHandler(this.Btn_YetkiKaydet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // txt_KullaniciAdi
            // 
            this.txt_KullaniciAdi.Location = new System.Drawing.Point(77, 12);
            this.txt_KullaniciAdi.Name = "txt_KullaniciAdi";
            this.txt_KullaniciAdi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_KullaniciAdi.Properties.Appearance.Options.UseBackColor = true;
            this.txt_KullaniciAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_KullaniciAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.txt_KullaniciAdi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txt_KullaniciAdi.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Txt_KullaniciAdi_Properties_ButtonClick);
            this.txt_KullaniciAdi.Size = new System.Drawing.Size(234, 22);
            this.txt_KullaniciAdi.TabIndex = 5;
            // 
            // pnl_Iki
            // 
            this.pnl_Iki.Controls.Add(this.grCtrl_YetkiTablosu);
            this.pnl_Iki.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Iki.Location = new System.Drawing.Point(0, 48);
            this.pnl_Iki.Name = "pnl_Iki";
            this.pnl_Iki.Size = new System.Drawing.Size(696, 301);
            this.pnl_Iki.TabIndex = 1;
            // 
            // grCtrl_YetkiTablosu
            // 
            this.grCtrl_YetkiTablosu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCtrl_YetkiTablosu.Location = new System.Drawing.Point(2, 2);
            this.grCtrl_YetkiTablosu.MainView = this.grView_YetkiTablosu;
            this.grCtrl_YetkiTablosu.Name = "grCtrl_YetkiTablosu";
            this.grCtrl_YetkiTablosu.Size = new System.Drawing.Size(692, 297);
            this.grCtrl_YetkiTablosu.TabIndex = 8;
            this.grCtrl_YetkiTablosu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grView_YetkiTablosu});
            // 
            // grView_YetkiTablosu
            // 
            this.grView_YetkiTablosu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_FormYetkileriID,
            this.col_FormAdi,
            this.col_Ac,
            this.col_Ekle,
            this.col_Guncelle,
            this.col_Sil});
            this.grView_YetkiTablosu.GridControl = this.grCtrl_YetkiTablosu;
            this.grView_YetkiTablosu.Name = "grView_YetkiTablosu";
            this.grView_YetkiTablosu.OptionsCustomization.CustomizationFormSnapMode = DevExpress.Utils.Controls.SnapMode.None;
            this.grView_YetkiTablosu.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grView_YetkiTablosu.OptionsView.ShowGroupPanel = false;
            // 
            // col_FormYetkileriID
            // 
            this.col_FormYetkileriID.Caption = "No";
            this.col_FormYetkileriID.FieldName = "FormYetkileriID";
            this.col_FormYetkileriID.Name = "col_FormYetkileriID";
            this.col_FormYetkileriID.OptionsColumn.ReadOnly = true;
            this.col_FormYetkileriID.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.col_FormYetkileriID.Visible = true;
            this.col_FormYetkileriID.VisibleIndex = 0;
            // 
            // col_FormAdi
            // 
            this.col_FormAdi.Caption = "İşlem Adı";
            this.col_FormAdi.FieldName = "FormAdi";
            this.col_FormAdi.Name = "col_FormAdi";
            this.col_FormAdi.OptionsColumn.ReadOnly = true;
            this.col_FormAdi.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.col_FormAdi.Visible = true;
            this.col_FormAdi.VisibleIndex = 1;
            // 
            // col_Ac
            // 
            this.col_Ac.Caption = "Aç";
            this.col_Ac.FieldName = "Ac";
            this.col_Ac.Name = "col_Ac";
            this.col_Ac.Visible = true;
            this.col_Ac.VisibleIndex = 2;
            // 
            // col_Ekle
            // 
            this.col_Ekle.Caption = "Ekle";
            this.col_Ekle.FieldName = "Ekle";
            this.col_Ekle.Name = "col_Ekle";
            this.col_Ekle.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.col_Ekle.Visible = true;
            this.col_Ekle.VisibleIndex = 3;
            // 
            // col_Guncelle
            // 
            this.col_Guncelle.Caption = "Güncelle";
            this.col_Guncelle.FieldName = "Guncelle";
            this.col_Guncelle.Name = "col_Guncelle";
            this.col_Guncelle.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.col_Guncelle.Visible = true;
            this.col_Guncelle.VisibleIndex = 4;
            // 
            // col_Sil
            // 
            this.col_Sil.Caption = "Sil";
            this.col_Sil.FieldName = "Sil";
            this.col_Sil.Name = "col_Sil";
            this.col_Sil.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.col_Sil.Visible = true;
            this.col_Sil.VisibleIndex = 5;
            // 
            // YetkiTanimla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 349);
            this.Controls.Add(this.pnl_Iki);
            this.Controls.Add(this.pnl_Bir);
            this.Name = "YetkiTanimla";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Yetki İşlemleri";
            this.Load += new System.EventHandler(this.YetkiTanimla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Bir)).EndInit();
            this.pnl_Bir.ResumeLayout(false);
            this.pnl_Bir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_KullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Iki)).EndInit();
            this.pnl_Iki.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grCtrl_YetkiTablosu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grView_YetkiTablosu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnl_Bir;
        private DevExpress.XtraEditors.PanelControl pnl_Iki;
        public DevExpress.XtraEditors.ButtonEdit txt_KullaniciAdi;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Views.Grid.GridView grView_YetkiTablosu;
        private DevExpress.XtraGrid.Columns.GridColumn col_FormYetkileriID;
        private DevExpress.XtraGrid.Columns.GridColumn col_FormAdi;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ac;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ekle;
        private DevExpress.XtraGrid.Columns.GridColumn col_Guncelle;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sil;
        public DevExpress.XtraGrid.GridControl grCtrl_YetkiTablosu;
        private DevExpress.XtraEditors.SimpleButton btn_YetkiKaydet;
    }
}