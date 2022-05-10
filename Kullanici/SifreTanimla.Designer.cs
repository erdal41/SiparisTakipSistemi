namespace SiparisTakipSistemi.Kullanici
{
    partial class SifreTanimla
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SifreTanimla));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txt_Sifre = new DevExpress.XtraEditors.ButtonEdit();
            this.txt_KullaniciAdi = new DevExpress.XtraEditors.ButtonEdit();
            this.btn_Kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_SacAdi = new DevExpress.XtraEditors.LabelControl();
            this.txt_SifreDogrula = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.err_HataDurumu = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_KullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SifreDogrula.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_HataDurumu)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Sifre
            // 
            this.txt_Sifre.EditValue = "";
            this.txt_Sifre.Location = new System.Drawing.Point(92, 36);
            this.txt_Sifre.Name = "txt_Sifre";
            this.txt_Sifre.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_Sifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_Sifre.Properties.Appearance.Options.UseBackColor = true;
            this.txt_Sifre.Properties.Appearance.Options.UseFont = true;
            this.txt_Sifre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.txt_Sifre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txt_Sifre.Properties.PasswordChar = '✺';
            this.txt_Sifre.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Txt_Sifre_Properties_ButtonPressed);
            this.txt_Sifre.Properties.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Txt_Sifre_Properties_MouseUp);
            this.txt_Sifre.Size = new System.Drawing.Size(161, 24);
            this.txt_Sifre.TabIndex = 19;
            this.txt_Sifre.EditValueChanged += new System.EventHandler(this.Txt_Sifre_EditValueChanged);
            this.txt_Sifre.Leave += new System.EventHandler(this.Txt_Sifre_Leave);
            // 
            // txt_KullaniciAdi
            // 
            this.txt_KullaniciAdi.EditValue = "";
            this.txt_KullaniciAdi.Location = new System.Drawing.Point(92, 8);
            this.txt_KullaniciAdi.Name = "txt_KullaniciAdi";
            this.txt_KullaniciAdi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_KullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_KullaniciAdi.Properties.Appearance.Options.UseBackColor = true;
            this.txt_KullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txt_KullaniciAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_KullaniciAdi.Size = new System.Drawing.Size(161, 22);
            this.txt_KullaniciAdi.TabIndex = 18;
            this.txt_KullaniciAdi.EditValueChanged += new System.EventHandler(this.Txt_KullaniciAdi_EditValueChanged);
            // 
            // btn_Kaydet
            // 
            this.btn_Kaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Kaydet.Appearance.Options.UseFont = true;
            this.btn_Kaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Kaydet.ImageOptions.Image")));
            this.btn_Kaydet.Location = new System.Drawing.Point(176, 96);
            this.btn_Kaydet.Name = "btn_Kaydet";
            this.btn_Kaydet.Size = new System.Drawing.Size(77, 30);
            this.btn_Kaydet.TabIndex = 20;
            this.btn_Kaydet.Text = "Kaydet";
            this.btn_Kaydet.Click += new System.EventHandler(this.Btn_Kaydet_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 13);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Şifre:";
            // 
            // lbl_SacAdi
            // 
            this.lbl_SacAdi.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbl_SacAdi.Appearance.Options.UseForeColor = true;
            this.lbl_SacAdi.Location = new System.Drawing.Point(12, 12);
            this.lbl_SacAdi.Name = "lbl_SacAdi";
            this.lbl_SacAdi.Size = new System.Drawing.Size(59, 13);
            this.lbl_SacAdi.TabIndex = 21;
            this.lbl_SacAdi.Text = "Kullanıcı Adı:";
            // 
            // txt_SifreDogrula
            // 
            this.txt_SifreDogrula.EditValue = "";
            this.txt_SifreDogrula.Location = new System.Drawing.Point(92, 66);
            this.txt_SifreDogrula.Name = "txt_SifreDogrula";
            this.txt_SifreDogrula.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_SifreDogrula.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_SifreDogrula.Properties.Appearance.Options.UseBackColor = true;
            this.txt_SifreDogrula.Properties.Appearance.Options.UseFont = true;
            this.txt_SifreDogrula.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.txt_SifreDogrula.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txt_SifreDogrula.Properties.PasswordChar = '✺';
            this.txt_SifreDogrula.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Txt_SifreDogrula_Properties_ButtonPressed);
            this.txt_SifreDogrula.Properties.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Txt_Sifre_Properties_MouseUp);
            this.txt_SifreDogrula.Size = new System.Drawing.Size(161, 24);
            this.txt_SifreDogrula.TabIndex = 23;
            this.txt_SifreDogrula.EditValueChanged += new System.EventHandler(this.Txt_SifreDogrula_EditValueChanged);
            this.txt_SifreDogrula.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Txt_SifreDogrula_MouseUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 13);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "Şifreyi Doğrula:";
            // 
            // err_HataDurumu
            // 
            this.err_HataDurumu.ContainerControl = this;
            // 
            // SifreTanimla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 138);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_SifreDogrula);
            this.Controls.Add(this.txt_Sifre);
            this.Controls.Add(this.txt_KullaniciAdi);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbl_SacAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SifreTanimla";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre Değiştirme";
            this.Load += new System.EventHandler(this.SifreTanimla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_KullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SifreDogrula.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_HataDurumu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton btn_Kaydet;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbl_SacAdi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider err_HataDurumu;
        public DevExpress.XtraEditors.ButtonEdit txt_Sifre;
        public DevExpress.XtraEditors.ButtonEdit txt_KullaniciAdi;
        public DevExpress.XtraEditors.ButtonEdit txt_SifreDogrula;
    }
}