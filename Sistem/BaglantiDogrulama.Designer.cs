namespace SiparisTakipSistemi.Sistem
{
    partial class BaglantiDogrulama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaglantiDogrulama));
            this.lbl_SacAdi = new DevExpress.XtraEditors.LabelControl();
            this.txt_SunucuAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_SunucuAdresi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Yenile = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Kaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SunucuAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SunucuAdresi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_SacAdi
            // 
            this.lbl_SacAdi.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbl_SacAdi.Appearance.Options.UseForeColor = true;
            this.lbl_SacAdi.Location = new System.Drawing.Point(12, 16);
            this.lbl_SacAdi.Name = "lbl_SacAdi";
            this.lbl_SacAdi.Size = new System.Drawing.Size(57, 13);
            this.lbl_SacAdi.TabIndex = 9;
            this.lbl_SacAdi.Text = "Sunucu Adı:";
            // 
            // txt_SunucuAdi
            // 
            this.txt_SunucuAdi.Location = new System.Drawing.Point(90, 12);
            this.txt_SunucuAdi.Name = "txt_SunucuAdi";
            this.txt_SunucuAdi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_SunucuAdi.Properties.Appearance.Options.UseBackColor = true;
            this.txt_SunucuAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_SunucuAdi.Size = new System.Drawing.Size(191, 22);
            this.txt_SunucuAdi.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Sunucu Adresi:";
            // 
            // txt_SunucuAdresi
            // 
            this.txt_SunucuAdresi.Location = new System.Drawing.Point(90, 40);
            this.txt_SunucuAdresi.Name = "txt_SunucuAdresi";
            this.txt_SunucuAdresi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_SunucuAdresi.Properties.Appearance.Options.UseBackColor = true;
            this.txt_SunucuAdresi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_SunucuAdresi.Size = new System.Drawing.Size(191, 22);
            this.txt_SunucuAdresi.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Sunucu Adresi:";
            // 
            // btn_Yenile
            // 
            this.btn_Yenile.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Yenile.Appearance.Options.UseFont = true;
            this.btn_Yenile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Yenile.ImageOptions.Image")));
            this.btn_Yenile.Location = new System.Drawing.Point(90, 77);
            this.btn_Yenile.Name = "btn_Yenile";
            this.btn_Yenile.Size = new System.Drawing.Size(104, 30);
            this.btn_Yenile.TabIndex = 12;
            this.btn_Yenile.Text = "Adresi Yenile";
            this.btn_Yenile.Click += new System.EventHandler(this.Btn_Yenile_Click);
            // 
            // btn_Kaydet
            // 
            this.btn_Kaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Kaydet.Appearance.Options.UseFont = true;
            this.btn_Kaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Kaydet.ImageOptions.Image")));
            this.btn_Kaydet.Location = new System.Drawing.Point(200, 77);
            this.btn_Kaydet.Name = "btn_Kaydet";
            this.btn_Kaydet.Size = new System.Drawing.Size(81, 30);
            this.btn_Kaydet.TabIndex = 13;
            this.btn_Kaydet.Text = "Kaydet";
            this.btn_Kaydet.Click += new System.EventHandler(this.Btn_Kaydet_Click);
            // 
            // BaglantiDogrulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(294, 118);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.btn_Yenile);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_SunucuAdresi);
            this.Controls.Add(this.lbl_SacAdi);
            this.Controls.Add(this.txt_SunucuAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaglantiDogrulama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sunucu Doğrulama";
            ((System.ComponentModel.ISupportInitialize)(this.txt_SunucuAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SunucuAdresi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_SacAdi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.SimpleButton btn_Yenile;
        public DevExpress.XtraEditors.SimpleButton btn_Kaydet;
        public DevExpress.XtraEditors.TextEdit txt_SunucuAdi;
        public DevExpress.XtraEditors.TextEdit txt_SunucuAdresi;
    }
}