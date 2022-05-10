namespace SiparisTakipSistemi.Maliyet
{
    partial class MaliyetListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaliyetListesi));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_MaliyetOlustur = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.grCtrl_MaliyetTablosu = new DevExpress.XtraGrid.GridControl();
            this.grView_MaliyetTablosu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_MaliyetID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GenelToplamTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GenelToplamAgirlik = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrl_MaliyetTablosu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grView_MaliyetTablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_MaliyetOlustur);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(540, 57);
            this.panelControl1.TabIndex = 0;
            // 
            // btn_MaliyetOlustur
            // 
            this.btn_MaliyetOlustur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_MaliyetOlustur.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_MaliyetOlustur.Appearance.Options.UseFont = true;
            this.btn_MaliyetOlustur.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_MaliyetOlustur.ImageOptions.Image")));
            this.btn_MaliyetOlustur.Location = new System.Drawing.Point(415, 5);
            this.btn_MaliyetOlustur.Name = "btn_MaliyetOlustur";
            this.btn_MaliyetOlustur.Size = new System.Drawing.Size(120, 46);
            this.btn_MaliyetOlustur.TabIndex = 3;
            this.btn_MaliyetOlustur.Text = "Maliyet Oluştur";
            this.btn_MaliyetOlustur.Click += new System.EventHandler(this.Btn_MaliyetOlustur_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.grCtrl_MaliyetTablosu);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 57);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(540, 358);
            this.panelControl2.TabIndex = 1;
            // 
            // grCtrl_MaliyetTablosu
            // 
            this.grCtrl_MaliyetTablosu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCtrl_MaliyetTablosu.Location = new System.Drawing.Point(2, 2);
            this.grCtrl_MaliyetTablosu.MainView = this.grView_MaliyetTablosu;
            this.grCtrl_MaliyetTablosu.Name = "grCtrl_MaliyetTablosu";
            this.grCtrl_MaliyetTablosu.Size = new System.Drawing.Size(536, 354);
            this.grCtrl_MaliyetTablosu.TabIndex = 24;
            this.grCtrl_MaliyetTablosu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grView_MaliyetTablosu});
            // 
            // grView_MaliyetTablosu
            // 
            this.grView_MaliyetTablosu.Appearance.SelectedRow.BackColor = System.Drawing.Color.RoyalBlue;
            this.grView_MaliyetTablosu.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grView_MaliyetTablosu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaliyetID,
            this.col_GenelToplamTutar,
            this.col_GenelToplamAgirlik});
            this.grView_MaliyetTablosu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grView_MaliyetTablosu.GridControl = this.grCtrl_MaliyetTablosu;
            this.grView_MaliyetTablosu.Name = "grView_MaliyetTablosu";
            this.grView_MaliyetTablosu.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grView_MaliyetTablosu.OptionsBehavior.Editable = false;
            this.grView_MaliyetTablosu.OptionsBehavior.ReadOnly = true;
            this.grView_MaliyetTablosu.OptionsCustomization.AllowFilter = false;
            this.grView_MaliyetTablosu.OptionsCustomization.CustomizationFormSnapMode = DevExpress.Utils.Controls.SnapMode.None;
            this.grView_MaliyetTablosu.OptionsNavigation.AutoFocusNewRow = true;
            this.grView_MaliyetTablosu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grView_MaliyetTablosu.OptionsView.ShowAutoFilterRow = true;
            this.grView_MaliyetTablosu.OptionsView.ShowFooter = true;
            this.grView_MaliyetTablosu.OptionsView.ShowGroupPanel = false;
            this.grView_MaliyetTablosu.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GrView_MaliyetTablosu_RowCellStyle);
            this.grView_MaliyetTablosu.DoubleClick += new System.EventHandler(this.GrView_MaliyetTablosu_DoubleClick);
            // 
            // col_MaliyetID
            // 
            this.col_MaliyetID.Caption = "Maliyet No";
            this.col_MaliyetID.FieldName = "MaliyetID";
            this.col_MaliyetID.Name = "col_MaliyetID";
            this.col_MaliyetID.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.col_MaliyetID.Visible = true;
            this.col_MaliyetID.VisibleIndex = 0;
            // 
            // col_GenelToplamTutar
            // 
            this.col_GenelToplamTutar.AppearanceCell.BackColor = System.Drawing.Color.NavajoWhite;
            this.col_GenelToplamTutar.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_GenelToplamTutar.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.col_GenelToplamTutar.AppearanceCell.Options.UseBackColor = true;
            this.col_GenelToplamTutar.AppearanceCell.Options.UseFont = true;
            this.col_GenelToplamTutar.Caption = "Toplam Tutar";
            this.col_GenelToplamTutar.DisplayFormat.FormatString = "c2";
            this.col_GenelToplamTutar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.col_GenelToplamTutar.FieldName = "GenelToplamTutar";
            this.col_GenelToplamTutar.Name = "col_GenelToplamTutar";
            this.col_GenelToplamTutar.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.col_GenelToplamTutar.Visible = true;
            this.col_GenelToplamTutar.VisibleIndex = 2;
            // 
            // col_GenelToplamAgirlik
            // 
            this.col_GenelToplamAgirlik.Caption = "Toplam Ağırlık";
            this.col_GenelToplamAgirlik.FieldName = "GenelToplamAgirlik";
            this.col_GenelToplamAgirlik.Name = "col_GenelToplamAgirlik";
            this.col_GenelToplamAgirlik.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.col_GenelToplamAgirlik.Visible = true;
            this.col_GenelToplamAgirlik.VisibleIndex = 1;
            // 
            // MaliyetListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 415);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "MaliyetListesi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maliyet Listesi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaliyetListesi_FormClosed);
            this.Load += new System.EventHandler(this.MaliyetListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grCtrl_MaliyetTablosu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grView_MaliyetTablosu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_MaliyetOlustur;
        private DevExpress.XtraGrid.GridControl grCtrl_MaliyetTablosu;
        private DevExpress.XtraGrid.Views.Grid.GridView grView_MaliyetTablosu;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaliyetID;
        private DevExpress.XtraGrid.Columns.GridColumn col_GenelToplamTutar;
        private DevExpress.XtraGrid.Columns.GridColumn col_GenelToplamAgirlik;
    }
}