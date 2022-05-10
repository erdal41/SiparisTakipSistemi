namespace SiparisTakipSistemi.Urun
{
    partial class UrunListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrunListesi));
            this.pnl_Bir = new DevExpress.XtraEditors.PanelControl();
            this.btn_UrunOlustur = new DevExpress.XtraEditors.SimpleButton();
            this.pnl_İki = new DevExpress.XtraEditors.PanelControl();
            this.grCtrl_UrunTablosu = new DevExpress.XtraGrid.GridControl();
            this.grView_UrunTablosu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_UrunID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UrunAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Bir)).BeginInit();
            this.pnl_Bir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_İki)).BeginInit();
            this.pnl_İki.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrl_UrunTablosu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grView_UrunTablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Bir
            // 
            this.pnl_Bir.Controls.Add(this.btn_UrunOlustur);
            this.pnl_Bir.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Bir.Location = new System.Drawing.Point(0, 0);
            this.pnl_Bir.Name = "pnl_Bir";
            this.pnl_Bir.Size = new System.Drawing.Size(391, 43);
            this.pnl_Bir.TabIndex = 0;
            // 
            // btn_UrunOlustur
            // 
            this.btn_UrunOlustur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_UrunOlustur.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_UrunOlustur.Appearance.Options.UseFont = true;
            this.btn_UrunOlustur.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_UrunOlustur.ImageOptions.Image")));
            this.btn_UrunOlustur.Location = new System.Drawing.Point(317, 4);
            this.btn_UrunOlustur.Name = "btn_UrunOlustur";
            this.btn_UrunOlustur.Size = new System.Drawing.Size(70, 36);
            this.btn_UrunOlustur.TabIndex = 3;
            this.btn_UrunOlustur.Text = "Ürün\nOluştur";
            this.btn_UrunOlustur.Click += new System.EventHandler(this.Btn_UrunOlustur_Click);
            // 
            // pnl_İki
            // 
            this.pnl_İki.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_İki.Controls.Add(this.grCtrl_UrunTablosu);
            this.pnl_İki.Location = new System.Drawing.Point(0, 43);
            this.pnl_İki.Name = "pnl_İki";
            this.pnl_İki.Size = new System.Drawing.Size(391, 321);
            this.pnl_İki.TabIndex = 1;
            // 
            // grCtrl_UrunTablosu
            // 
            this.grCtrl_UrunTablosu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCtrl_UrunTablosu.Location = new System.Drawing.Point(2, 2);
            this.grCtrl_UrunTablosu.MainView = this.grView_UrunTablosu;
            this.grCtrl_UrunTablosu.Name = "grCtrl_UrunTablosu";
            this.grCtrl_UrunTablosu.Size = new System.Drawing.Size(387, 317);
            this.grCtrl_UrunTablosu.TabIndex = 22;
            this.grCtrl_UrunTablosu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grView_UrunTablosu});
            this.grCtrl_UrunTablosu.DoubleClick += new System.EventHandler(this.GrCtrl_UrunTablosu_DoubleClick);
            // 
            // grView_UrunTablosu
            // 
            this.grView_UrunTablosu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_UrunID,
            this.col_UrunAdi});
            this.grView_UrunTablosu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grView_UrunTablosu.GridControl = this.grCtrl_UrunTablosu;
            this.grView_UrunTablosu.Name = "grView_UrunTablosu";
            this.grView_UrunTablosu.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grView_UrunTablosu.OptionsBehavior.Editable = false;
            this.grView_UrunTablosu.OptionsBehavior.ReadOnly = true;
            this.grView_UrunTablosu.OptionsCustomization.AllowFilter = false;
            this.grView_UrunTablosu.OptionsCustomization.CustomizationFormSnapMode = DevExpress.Utils.Controls.SnapMode.None;
            this.grView_UrunTablosu.OptionsNavigation.AutoFocusNewRow = true;
            this.grView_UrunTablosu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grView_UrunTablosu.OptionsView.ShowAutoFilterRow = true;
            this.grView_UrunTablosu.OptionsView.ShowGroupPanel = false;
            this.grView_UrunTablosu.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GrView_UrunTablosu_RowCellStyle);
            // 
            // col_UrunID
            // 
            this.col_UrunID.Caption = "Ürün No";
            this.col_UrunID.FieldName = "UrunID";
            this.col_UrunID.Name = "col_UrunID";
            this.col_UrunID.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.col_UrunID.Visible = true;
            this.col_UrunID.VisibleIndex = 0;
            // 
            // col_UrunAdi
            // 
            this.col_UrunAdi.Caption = "Ürün Adı";
            this.col_UrunAdi.FieldName = "UrunAdi";
            this.col_UrunAdi.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.col_UrunAdi.Name = "col_UrunAdi";
            this.col_UrunAdi.Visible = true;
            this.col_UrunAdi.VisibleIndex = 1;
            // 
            // UrunListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 364);
            this.Controls.Add(this.pnl_İki);
            this.Controls.Add(this.pnl_Bir);
            this.Name = "UrunListesi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Listesi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UrunListesi_FormClosed);
            this.Load += new System.EventHandler(this.UrunListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Bir)).EndInit();
            this.pnl_Bir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_İki)).EndInit();
            this.pnl_İki.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grCtrl_UrunTablosu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grView_UrunTablosu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnl_Bir;
        private DevExpress.XtraEditors.PanelControl pnl_İki;
        private DevExpress.XtraGrid.GridControl grCtrl_UrunTablosu;
        private DevExpress.XtraGrid.Views.Grid.GridView grView_UrunTablosu;
        private DevExpress.XtraGrid.Columns.GridColumn col_UrunID;
        private DevExpress.XtraGrid.Columns.GridColumn col_UrunAdi;
        private DevExpress.XtraEditors.SimpleButton btn_UrunOlustur;
    }
}