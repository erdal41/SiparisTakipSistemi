namespace SiparisTakipSistemi.Sac
{
    partial class SacTanimla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SacTanimla));
            this.pnl_Bir = new DevExpress.XtraEditors.PanelControl();
            this.btn_SacSil = new DevExpress.XtraEditors.SimpleButton();
            this.btn_SacGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Temizle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_SacKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_BirimFiyati = new DevExpress.XtraEditors.LabelControl();
            this.txt_SacBirimFiyati = new DevExpress.XtraEditors.TextEdit();
            this.lbl_SacAdi = new DevExpress.XtraEditors.LabelControl();
            this.txt_SacAdi = new DevExpress.XtraEditors.TextEdit();
            this.lbl_Birim = new DevExpress.XtraEditors.LabelControl();
            this.lbl_SacNo = new DevExpress.XtraEditors.LabelControl();
            this.txt_SacBirimi = new DevExpress.XtraEditors.TextEdit();
            this.txt_SacNo = new DevExpress.XtraEditors.TextEdit();
            this.err_HataDurumu = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.pnl_Iki = new DevExpress.XtraEditors.PanelControl();
            this.grCtrl_SacTablosu = new DevExpress.XtraGrid.GridControl();
            this.grView_SacTablosu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_SacID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SacAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SacBirimi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SacBirimFiyati = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Bir)).BeginInit();
            this.pnl_Bir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SacBirimFiyati.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SacAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SacBirimi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SacNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_HataDurumu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Iki)).BeginInit();
            this.pnl_Iki.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrl_SacTablosu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grView_SacTablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Bir
            // 
            this.pnl_Bir.Controls.Add(this.btn_SacSil);
            this.pnl_Bir.Controls.Add(this.btn_SacGuncelle);
            this.pnl_Bir.Controls.Add(this.btn_Temizle);
            this.pnl_Bir.Controls.Add(this.btn_SacKaydet);
            this.pnl_Bir.Controls.Add(this.lbl_BirimFiyati);
            this.pnl_Bir.Controls.Add(this.txt_SacBirimFiyati);
            this.pnl_Bir.Controls.Add(this.lbl_SacAdi);
            this.pnl_Bir.Controls.Add(this.txt_SacAdi);
            this.pnl_Bir.Controls.Add(this.lbl_Birim);
            this.pnl_Bir.Controls.Add(this.lbl_SacNo);
            this.pnl_Bir.Controls.Add(this.txt_SacBirimi);
            this.pnl_Bir.Controls.Add(this.txt_SacNo);
            this.pnl_Bir.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Bir.Location = new System.Drawing.Point(0, 0);
            this.pnl_Bir.Name = "pnl_Bir";
            this.pnl_Bir.Size = new System.Drawing.Size(274, 295);
            this.pnl_Bir.TabIndex = 0;
            // 
            // btn_SacSil
            // 
            this.btn_SacSil.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_SacSil.Appearance.Options.UseFont = true;
            this.btn_SacSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SacSil.ImageOptions.Image")));
            this.btn_SacSil.Location = new System.Drawing.Point(23, 146);
            this.btn_SacSil.Name = "btn_SacSil";
            this.btn_SacSil.Size = new System.Drawing.Size(74, 34);
            this.btn_SacSil.TabIndex = 6;
            this.btn_SacSil.Text = "Sil";
            this.btn_SacSil.Visible = false;
            this.btn_SacSil.Click += new System.EventHandler(this.Btn_SacSil_Click);
            // 
            // btn_SacGuncelle
            // 
            this.btn_SacGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_SacGuncelle.Appearance.Options.UseFont = true;
            this.btn_SacGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SacGuncelle.ImageOptions.Image")));
            this.btn_SacGuncelle.Location = new System.Drawing.Point(23, 106);
            this.btn_SacGuncelle.Name = "btn_SacGuncelle";
            this.btn_SacGuncelle.Size = new System.Drawing.Size(74, 34);
            this.btn_SacGuncelle.TabIndex = 4;
            this.btn_SacGuncelle.Text = "Güncelle";
            this.btn_SacGuncelle.Visible = false;
            this.btn_SacGuncelle.Click += new System.EventHandler(this.Btn_SacGuncelle_Click);
            // 
            // btn_Temizle
            // 
            this.btn_Temizle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Temizle.Appearance.Options.UseFont = true;
            this.btn_Temizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Temizle.ImageOptions.Image")));
            this.btn_Temizle.Location = new System.Drawing.Point(183, 106);
            this.btn_Temizle.Name = "btn_Temizle";
            this.btn_Temizle.Size = new System.Drawing.Size(74, 34);
            this.btn_Temizle.TabIndex = 6;
            this.btn_Temizle.Text = "Temizle";
            this.btn_Temizle.Click += new System.EventHandler(this.Btn_Temizle_Click);
            // 
            // btn_SacKaydet
            // 
            this.btn_SacKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_SacKaydet.Appearance.Options.UseFont = true;
            this.btn_SacKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SacKaydet.ImageOptions.Image")));
            this.btn_SacKaydet.Location = new System.Drawing.Point(103, 106);
            this.btn_SacKaydet.Name = "btn_SacKaydet";
            this.btn_SacKaydet.Size = new System.Drawing.Size(74, 34);
            this.btn_SacKaydet.TabIndex = 3;
            this.btn_SacKaydet.Text = "Kaydet";
            this.btn_SacKaydet.Click += new System.EventHandler(this.Btn_SacKaydet_Click);
            // 
            // lbl_BirimFiyati
            // 
            this.lbl_BirimFiyati.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbl_BirimFiyati.Appearance.Options.UseForeColor = true;
            this.lbl_BirimFiyati.Location = new System.Drawing.Point(5, 69);
            this.lbl_BirimFiyati.Name = "lbl_BirimFiyati";
            this.lbl_BirimFiyati.Size = new System.Drawing.Size(55, 13);
            this.lbl_BirimFiyati.TabIndex = 9;
            this.lbl_BirimFiyati.Text = "Birim Fiyatı:";
            // 
            // txt_SacBirimFiyati
            // 
            this.txt_SacBirimFiyati.Location = new System.Drawing.Point(66, 65);
            this.txt_SacBirimFiyati.Name = "txt_SacBirimFiyati";
            this.txt_SacBirimFiyati.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_SacBirimFiyati.Properties.Appearance.Options.UseBackColor = true;
            this.txt_SacBirimFiyati.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_SacBirimFiyati.Size = new System.Drawing.Size(70, 22);
            this.txt_SacBirimFiyati.TabIndex = 2;
            this.txt_SacBirimFiyati.EditValueChanged += new System.EventHandler(this.Txt_SacBirimFiyati_EditValueChanged);
            this.txt_SacBirimFiyati.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_SacBirimFiyati_KeyPress);
            // 
            // lbl_SacAdi
            // 
            this.lbl_SacAdi.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbl_SacAdi.Appearance.Options.UseForeColor = true;
            this.lbl_SacAdi.Location = new System.Drawing.Point(5, 41);
            this.lbl_SacAdi.Name = "lbl_SacAdi";
            this.lbl_SacAdi.Size = new System.Drawing.Size(39, 13);
            this.lbl_SacAdi.TabIndex = 7;
            this.lbl_SacAdi.Text = "Sac Adı:";
            // 
            // txt_SacAdi
            // 
            this.txt_SacAdi.Location = new System.Drawing.Point(66, 37);
            this.txt_SacAdi.Name = "txt_SacAdi";
            this.txt_SacAdi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_SacAdi.Properties.Appearance.Options.UseBackColor = true;
            this.txt_SacAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_SacAdi.Size = new System.Drawing.Size(191, 22);
            this.txt_SacAdi.TabIndex = 1;
            this.txt_SacAdi.EditValueChanged += new System.EventHandler(this.Txt_SacAdi_EditValueChanged);
            // 
            // lbl_Birim
            // 
            this.lbl_Birim.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbl_Birim.Appearance.Options.UseForeColor = true;
            this.lbl_Birim.Location = new System.Drawing.Point(153, 12);
            this.lbl_Birim.Name = "lbl_Birim";
            this.lbl_Birim.Size = new System.Drawing.Size(28, 13);
            this.lbl_Birim.TabIndex = 5;
            this.lbl_Birim.Text = "Birimi:";
            // 
            // lbl_SacNo
            // 
            this.lbl_SacNo.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbl_SacNo.Appearance.Options.UseForeColor = true;
            this.lbl_SacNo.Location = new System.Drawing.Point(5, 13);
            this.lbl_SacNo.Name = "lbl_SacNo";
            this.lbl_SacNo.Size = new System.Drawing.Size(37, 13);
            this.lbl_SacNo.TabIndex = 4;
            this.lbl_SacNo.Text = "Sac No:";
            // 
            // txt_SacBirimi
            // 
            this.txt_SacBirimi.EditValue = "Kilogram";
            this.txt_SacBirimi.Enabled = false;
            this.txt_SacBirimi.Location = new System.Drawing.Point(187, 9);
            this.txt_SacBirimi.Name = "txt_SacBirimi";
            this.txt_SacBirimi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_SacBirimi.Properties.Appearance.Options.UseBackColor = true;
            this.txt_SacBirimi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_SacBirimi.Size = new System.Drawing.Size(70, 22);
            this.txt_SacBirimi.TabIndex = 8;
            // 
            // txt_SacNo
            // 
            this.txt_SacNo.Enabled = false;
            this.txt_SacNo.Location = new System.Drawing.Point(66, 9);
            this.txt_SacNo.Name = "txt_SacNo";
            this.txt_SacNo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_SacNo.Properties.Appearance.Options.UseBackColor = true;
            this.txt_SacNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_SacNo.Size = new System.Drawing.Size(70, 22);
            this.txt_SacNo.TabIndex = 9;
            // 
            // err_HataDurumu
            // 
            this.err_HataDurumu.ContainerControl = this;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = -1;
            // 
            // pnl_Iki
            // 
            this.pnl_Iki.Controls.Add(this.grCtrl_SacTablosu);
            this.pnl_Iki.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Iki.Location = new System.Drawing.Point(274, 0);
            this.pnl_Iki.Name = "pnl_Iki";
            this.pnl_Iki.Size = new System.Drawing.Size(726, 295);
            this.pnl_Iki.TabIndex = 1;
            // 
            // grCtrl_SacTablosu
            // 
            this.grCtrl_SacTablosu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCtrl_SacTablosu.Location = new System.Drawing.Point(2, 2);
            this.grCtrl_SacTablosu.MainView = this.grView_SacTablosu;
            this.grCtrl_SacTablosu.Name = "grCtrl_SacTablosu";
            this.grCtrl_SacTablosu.Size = new System.Drawing.Size(722, 291);
            this.grCtrl_SacTablosu.TabIndex = 3;
            this.grCtrl_SacTablosu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grView_SacTablosu});
            // 
            // grView_SacTablosu
            // 
            this.grView_SacTablosu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_SacID,
            this.col_SacAdi,
            this.col_SacBirimi,
            this.col_SacBirimFiyati});
            this.grView_SacTablosu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grView_SacTablosu.GridControl = this.grCtrl_SacTablosu;
            this.grView_SacTablosu.Name = "grView_SacTablosu";
            this.grView_SacTablosu.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grView_SacTablosu.OptionsBehavior.Editable = false;
            this.grView_SacTablosu.OptionsBehavior.ReadOnly = true;
            this.grView_SacTablosu.OptionsCustomization.AllowFilter = false;
            this.grView_SacTablosu.OptionsCustomization.CustomizationFormSnapMode = DevExpress.Utils.Controls.SnapMode.None;
            this.grView_SacTablosu.OptionsNavigation.AutoFocusNewRow = true;
            this.grView_SacTablosu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grView_SacTablosu.OptionsView.ShowAutoFilterRow = true;
            this.grView_SacTablosu.OptionsView.ShowGroupPanel = false;
            this.grView_SacTablosu.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GrView_SacTablosu_RowClick);
            this.grView_SacTablosu.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GrView_SacTablosu_RowCellStyle);
            // 
            // col_SacID
            // 
            this.col_SacID.Caption = "Sac No";
            this.col_SacID.FieldName = "SacID";
            this.col_SacID.Name = "col_SacID";
            this.col_SacID.Visible = true;
            this.col_SacID.VisibleIndex = 0;
            // 
            // col_SacAdi
            // 
            this.col_SacAdi.Caption = "Sac Adı";
            this.col_SacAdi.FieldName = "SacAdi";
            this.col_SacAdi.Name = "col_SacAdi";
            this.col_SacAdi.Visible = true;
            this.col_SacAdi.VisibleIndex = 1;
            // 
            // col_SacBirimi
            // 
            this.col_SacBirimi.Caption = "Birim";
            this.col_SacBirimi.FieldName = "SacBirimi";
            this.col_SacBirimi.Name = "col_SacBirimi";
            this.col_SacBirimi.Visible = true;
            this.col_SacBirimi.VisibleIndex = 2;
            // 
            // col_SacBirimFiyati
            // 
            this.col_SacBirimFiyati.AppearanceCell.BackColor = System.Drawing.Color.NavajoWhite;
            this.col_SacBirimFiyati.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_SacBirimFiyati.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.col_SacBirimFiyati.AppearanceCell.Options.UseBackColor = true;
            this.col_SacBirimFiyati.AppearanceCell.Options.UseFont = true;
            this.col_SacBirimFiyati.Caption = "Birim Fiyatı";
            this.col_SacBirimFiyati.DisplayFormat.FormatString = "c2";
            this.col_SacBirimFiyati.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.col_SacBirimFiyati.FieldName = "SacBirimFiyati";
            this.col_SacBirimFiyati.Name = "col_SacBirimFiyati";
            this.col_SacBirimFiyati.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.col_SacBirimFiyati.Visible = true;
            this.col_SacBirimFiyati.VisibleIndex = 3;
            // 
            // SacTanimla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 295);
            this.Controls.Add(this.pnl_Iki);
            this.Controls.Add(this.pnl_Bir);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Name = "SacTanimla";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sac İşlemleri";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SacTanimla_FormClosed);
            this.Load += new System.EventHandler(this.SacTanimla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Bir)).EndInit();
            this.pnl_Bir.ResumeLayout(false);
            this.pnl_Bir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SacBirimFiyati.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SacAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SacBirimi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SacNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_HataDurumu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Iki)).EndInit();
            this.pnl_Iki.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grCtrl_SacTablosu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grView_SacTablosu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnl_Bir;
        private DevExpress.XtraEditors.TextEdit txt_SacNo;
        private DevExpress.XtraEditors.LabelControl lbl_SacNo;
        private DevExpress.XtraEditors.TextEdit txt_SacBirimi;
        private DevExpress.XtraEditors.LabelControl lbl_Birim;
        private DevExpress.XtraEditors.LabelControl lbl_SacAdi;
        private DevExpress.XtraEditors.TextEdit txt_SacAdi;
        private DevExpress.XtraEditors.LabelControl lbl_BirimFiyati;
        private DevExpress.XtraEditors.TextEdit txt_SacBirimFiyati;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider err_HataDurumu;
        private DevExpress.XtraEditors.SimpleButton btn_SacKaydet;
        private DevExpress.XtraEditors.SimpleButton btn_Temizle;
        private DevExpress.XtraEditors.SimpleButton btn_SacGuncelle;
        private DevExpress.XtraEditors.SimpleButton btn_SacSil;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraEditors.PanelControl pnl_Iki;
        private DevExpress.XtraGrid.GridControl grCtrl_SacTablosu;
        private DevExpress.XtraGrid.Views.Grid.GridView grView_SacTablosu;
        private DevExpress.XtraGrid.Columns.GridColumn col_SacID;
        private DevExpress.XtraGrid.Columns.GridColumn col_SacAdi;
        private DevExpress.XtraGrid.Columns.GridColumn col_SacBirimi;
        private DevExpress.XtraGrid.Columns.GridColumn col_SacBirimFiyati;
    }
}