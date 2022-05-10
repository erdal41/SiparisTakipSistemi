namespace SiparisTakipSistemi.Maliyet
{
    partial class EkMaliyetTanimla
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EkMaliyetTanimla));
            this.err_HataDurumu = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.pnl_Bir = new DevExpress.XtraEditors.PanelControl();
            this.btn_EkMaliyetSil = new DevExpress.XtraEditors.SimpleButton();
            this.btn_EkMaliyetGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Temizle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_EkMaliyetKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_EkMaliyetAdi = new DevExpress.XtraEditors.TextEdit();
            this.txt_EkMaliyetNo = new DevExpress.XtraEditors.TextEdit();
            this.pnl_Iki = new DevExpress.XtraEditors.PanelControl();
            this.grCtrl_EkMaliyetTablosu = new DevExpress.XtraGrid.GridControl();
            this.grView_EkMaliyetTablosu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_EkMaliyetID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EkMaliyetAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.err_HataDurumu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Bir)).BeginInit();
            this.pnl_Bir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EkMaliyetAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EkMaliyetNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Iki)).BeginInit();
            this.pnl_Iki.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrl_EkMaliyetTablosu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grView_EkMaliyetTablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // err_HataDurumu
            // 
            this.err_HataDurumu.ContainerControl = this;
            // 
            // pnl_Bir
            // 
            this.pnl_Bir.Controls.Add(this.btn_EkMaliyetSil);
            this.pnl_Bir.Controls.Add(this.btn_EkMaliyetGuncelle);
            this.pnl_Bir.Controls.Add(this.btn_Temizle);
            this.pnl_Bir.Controls.Add(this.btn_EkMaliyetKaydet);
            this.pnl_Bir.Controls.Add(this.labelControl1);
            this.pnl_Bir.Controls.Add(this.labelControl2);
            this.pnl_Bir.Controls.Add(this.txt_EkMaliyetAdi);
            this.pnl_Bir.Controls.Add(this.txt_EkMaliyetNo);
            this.pnl_Bir.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Bir.Location = new System.Drawing.Point(0, 0);
            this.pnl_Bir.Name = "pnl_Bir";
            this.pnl_Bir.Size = new System.Drawing.Size(246, 244);
            this.pnl_Bir.TabIndex = 0;
            // 
            // btn_EkMaliyetSil
            // 
            this.btn_EkMaliyetSil.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_EkMaliyetSil.Appearance.Options.UseFont = true;
            this.btn_EkMaliyetSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_EkMaliyetSil.ImageOptions.Image")));
            this.btn_EkMaliyetSil.Location = new System.Drawing.Point(6, 125);
            this.btn_EkMaliyetSil.Name = "btn_EkMaliyetSil";
            this.btn_EkMaliyetSil.Size = new System.Drawing.Size(74, 34);
            this.btn_EkMaliyetSil.TabIndex = 37;
            this.btn_EkMaliyetSil.Text = "Sil";
            this.btn_EkMaliyetSil.Visible = false;
            this.btn_EkMaliyetSil.Click += new System.EventHandler(this.Btn_EkMaliyetSil_Click);
            // 
            // btn_EkMaliyetGuncelle
            // 
            this.btn_EkMaliyetGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_EkMaliyetGuncelle.Appearance.Options.UseFont = true;
            this.btn_EkMaliyetGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_EkMaliyetGuncelle.ImageOptions.Image")));
            this.btn_EkMaliyetGuncelle.Location = new System.Drawing.Point(6, 85);
            this.btn_EkMaliyetGuncelle.Name = "btn_EkMaliyetGuncelle";
            this.btn_EkMaliyetGuncelle.Size = new System.Drawing.Size(74, 34);
            this.btn_EkMaliyetGuncelle.TabIndex = 35;
            this.btn_EkMaliyetGuncelle.Text = "Güncelle";
            this.btn_EkMaliyetGuncelle.Visible = false;
            this.btn_EkMaliyetGuncelle.Click += new System.EventHandler(this.Btn_EkMaliyetGuncelle_Click);
            // 
            // btn_Temizle
            // 
            this.btn_Temizle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Temizle.Appearance.Options.UseFont = true;
            this.btn_Temizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Temizle.ImageOptions.Image")));
            this.btn_Temizle.Location = new System.Drawing.Point(166, 85);
            this.btn_Temizle.Name = "btn_Temizle";
            this.btn_Temizle.Size = new System.Drawing.Size(74, 34);
            this.btn_Temizle.TabIndex = 38;
            this.btn_Temizle.Text = "Temizle";
            this.btn_Temizle.Click += new System.EventHandler(this.Btn_Temizle_Click);
            // 
            // btn_EkMaliyetKaydet
            // 
            this.btn_EkMaliyetKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_EkMaliyetKaydet.Appearance.Options.UseFont = true;
            this.btn_EkMaliyetKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_EkMaliyetKaydet.ImageOptions.Image")));
            this.btn_EkMaliyetKaydet.Location = new System.Drawing.Point(86, 85);
            this.btn_EkMaliyetKaydet.Name = "btn_EkMaliyetKaydet";
            this.btn_EkMaliyetKaydet.Size = new System.Drawing.Size(74, 34);
            this.btn_EkMaliyetKaydet.TabIndex = 36;
            this.btn_EkMaliyetKaydet.Text = "Kaydet";
            this.btn_EkMaliyetKaydet.Click += new System.EventHandler(this.Btn_EkMaliyetKaydet_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Ek Maliyet No:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 31;
            this.labelControl2.Text = "Ek Maliyet Adı:";
            // 
            // txt_EkMaliyetAdi
            // 
            this.txt_EkMaliyetAdi.EditValue = "";
            this.txt_EkMaliyetAdi.Location = new System.Drawing.Point(81, 36);
            this.txt_EkMaliyetAdi.Name = "txt_EkMaliyetAdi";
            this.txt_EkMaliyetAdi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_EkMaliyetAdi.Properties.Appearance.Options.UseBackColor = true;
            this.txt_EkMaliyetAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_EkMaliyetAdi.Size = new System.Drawing.Size(159, 22);
            this.txt_EkMaliyetAdi.TabIndex = 32;
            this.txt_EkMaliyetAdi.EditValueChanged += new System.EventHandler(this.Txt_EkMaliyetAdi_EditValueChanged);
            // 
            // txt_EkMaliyetNo
            // 
            this.txt_EkMaliyetNo.Enabled = false;
            this.txt_EkMaliyetNo.Location = new System.Drawing.Point(81, 8);
            this.txt_EkMaliyetNo.Name = "txt_EkMaliyetNo";
            this.txt_EkMaliyetNo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_EkMaliyetNo.Properties.Appearance.Options.UseBackColor = true;
            this.txt_EkMaliyetNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_EkMaliyetNo.Size = new System.Drawing.Size(159, 22);
            this.txt_EkMaliyetNo.TabIndex = 33;
            // 
            // pnl_Iki
            // 
            this.pnl_Iki.Controls.Add(this.grCtrl_EkMaliyetTablosu);
            this.pnl_Iki.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Iki.Location = new System.Drawing.Point(246, 0);
            this.pnl_Iki.Name = "pnl_Iki";
            this.pnl_Iki.Size = new System.Drawing.Size(304, 244);
            this.pnl_Iki.TabIndex = 1;
            // 
            // grCtrl_EkMaliyetTablosu
            // 
            this.grCtrl_EkMaliyetTablosu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCtrl_EkMaliyetTablosu.Location = new System.Drawing.Point(2, 2);
            this.grCtrl_EkMaliyetTablosu.MainView = this.grView_EkMaliyetTablosu;
            this.grCtrl_EkMaliyetTablosu.Name = "grCtrl_EkMaliyetTablosu";
            this.grCtrl_EkMaliyetTablosu.Size = new System.Drawing.Size(300, 240);
            this.grCtrl_EkMaliyetTablosu.TabIndex = 9;
            this.grCtrl_EkMaliyetTablosu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grView_EkMaliyetTablosu});
            // 
            // grView_EkMaliyetTablosu
            // 
            this.grView_EkMaliyetTablosu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_EkMaliyetID,
            this.col_EkMaliyetAdi});
            this.grView_EkMaliyetTablosu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grView_EkMaliyetTablosu.GridControl = this.grCtrl_EkMaliyetTablosu;
            this.grView_EkMaliyetTablosu.Name = "grView_EkMaliyetTablosu";
            this.grView_EkMaliyetTablosu.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grView_EkMaliyetTablosu.OptionsBehavior.Editable = false;
            this.grView_EkMaliyetTablosu.OptionsBehavior.ReadOnly = true;
            this.grView_EkMaliyetTablosu.OptionsCustomization.AllowFilter = false;
            this.grView_EkMaliyetTablosu.OptionsCustomization.CustomizationFormSnapMode = DevExpress.Utils.Controls.SnapMode.None;
            this.grView_EkMaliyetTablosu.OptionsNavigation.AutoFocusNewRow = true;
            this.grView_EkMaliyetTablosu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grView_EkMaliyetTablosu.OptionsView.ShowAutoFilterRow = true;
            this.grView_EkMaliyetTablosu.OptionsView.ShowGroupPanel = false;
            this.grView_EkMaliyetTablosu.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GrView_EkMaliyetTablosu_RowClick);
            this.grView_EkMaliyetTablosu.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GrView_EkMaliyetTablosu_RowCellStyle);
            // 
            // col_EkMaliyetID
            // 
            this.col_EkMaliyetID.Caption = "No";
            this.col_EkMaliyetID.FieldName = "EkMaliyetID";
            this.col_EkMaliyetID.Name = "col_EkMaliyetID";
            this.col_EkMaliyetID.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.col_EkMaliyetID.Visible = true;
            this.col_EkMaliyetID.VisibleIndex = 0;
            // 
            // col_EkMaliyetAdi
            // 
            this.col_EkMaliyetAdi.Caption = "Ek Maliyet Adı";
            this.col_EkMaliyetAdi.FieldName = "EkMaliyetAdi";
            this.col_EkMaliyetAdi.Name = "col_EkMaliyetAdi";
            this.col_EkMaliyetAdi.Visible = true;
            this.col_EkMaliyetAdi.VisibleIndex = 1;
            // 
            // EkMaliyetTanimla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 244);
            this.Controls.Add(this.pnl_Iki);
            this.Controls.Add(this.pnl_Bir);
            this.IconOptions.ShowIcon = false;
            this.Name = "EkMaliyetTanimla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ek Maliyet İşlemleri";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EkMaliyetTanimla_FormClosed);
            this.Load += new System.EventHandler(this.EkMaliyetTanimla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err_HataDurumu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Bir)).EndInit();
            this.pnl_Bir.ResumeLayout(false);
            this.pnl_Bir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EkMaliyetAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EkMaliyetNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Iki)).EndInit();
            this.pnl_Iki.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grCtrl_EkMaliyetTablosu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grView_EkMaliyetTablosu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider err_HataDurumu;
        private DevExpress.XtraEditors.PanelControl pnl_Iki;
        private DevExpress.XtraEditors.PanelControl pnl_Bir;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_EkMaliyetAdi;
        private DevExpress.XtraEditors.TextEdit txt_EkMaliyetNo;
        private DevExpress.XtraEditors.SimpleButton btn_EkMaliyetSil;
        private DevExpress.XtraEditors.SimpleButton btn_EkMaliyetGuncelle;
        private DevExpress.XtraEditors.SimpleButton btn_Temizle;
        private DevExpress.XtraEditors.SimpleButton btn_EkMaliyetKaydet;
        private DevExpress.XtraGrid.GridControl grCtrl_EkMaliyetTablosu;
        private DevExpress.XtraGrid.Views.Grid.GridView grView_EkMaliyetTablosu;
        private DevExpress.XtraGrid.Columns.GridColumn col_EkMaliyetID;
        private DevExpress.XtraGrid.Columns.GridColumn col_EkMaliyetAdi;
    }
}