namespace SiparisTakipSistemi.Kullanici
{
    partial class KullaniciGirisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciGirisi));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.chk_BeniHatirla = new DevExpress.XtraEditors.CheckEdit();
            this.txt_Sifre = new DevExpress.XtraEditors.ButtonEdit();
            this.txt_KullaniciAdi = new DevExpress.XtraEditors.ButtonEdit();
            this.btn_Cikis = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Giris = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.err_HataDurumu = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_BeniHatirla.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_KullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_HataDurumu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.chk_BeniHatirla);
            this.panel.Controls.Add(this.txt_Sifre);
            this.panel.Controls.Add(this.txt_KullaniciAdi);
            this.panel.Controls.Add(this.btn_Cikis);
            this.panel.Controls.Add(this.btn_Giris);
            this.panel.Controls.Add(this.labelControl2);
            this.panel.Controls.Add(this.labelControl1);
            this.panel.Location = new System.Drawing.Point(48, 42);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(312, 157);
            this.panel.TabIndex = 111;
            // 
            // chk_BeniHatirla
            // 
            this.chk_BeniHatirla.Location = new System.Drawing.Point(196, 80);
            this.chk_BeniHatirla.Name = "chk_BeniHatirla";
            this.chk_BeniHatirla.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chk_BeniHatirla.Properties.Appearance.Options.UseFont = true;
            this.chk_BeniHatirla.Properties.Caption = "Beni Hatırla";
            this.chk_BeniHatirla.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.chk_BeniHatirla.Properties.CheckBoxOptions.SvgColorChecked = System.Drawing.Color.WhiteSmoke;
            this.chk_BeniHatirla.Size = new System.Drawing.Size(93, 22);
            this.chk_BeniHatirla.TabIndex = 18;
            // 
            // txt_Sifre
            // 
            this.txt_Sifre.EditValue = "";
            this.txt_Sifre.Location = new System.Drawing.Point(98, 50);
            this.txt_Sifre.Name = "txt_Sifre";
            this.txt_Sifre.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_Sifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_Sifre.Properties.Appearance.Options.UseBackColor = true;
            this.txt_Sifre.Properties.Appearance.Options.UseFont = true;
            this.txt_Sifre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.txt_Sifre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txt_Sifre.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txt_Sifre.Properties.ContextImageOptions.Image")));
            this.txt_Sifre.Properties.PasswordChar = '✺';
            this.txt_Sifre.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Txt_Sifre_Properties_ButtonPressed);
            this.txt_Sifre.Properties.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Txt_Sifre_Properties_MouseUp);
            this.txt_Sifre.Size = new System.Drawing.Size(191, 24);
            this.txt_Sifre.TabIndex = 2;
            this.txt_Sifre.EditValueChanged += new System.EventHandler(this.Txt_Sifre_EditValueChanged);
            this.txt_Sifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Sifre_KeyDown);
            // 
            // txt_KullaniciAdi
            // 
            this.txt_KullaniciAdi.EditValue = "";
            this.txt_KullaniciAdi.Location = new System.Drawing.Point(98, 22);
            this.txt_KullaniciAdi.Name = "txt_KullaniciAdi";
            this.txt_KullaniciAdi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_KullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_KullaniciAdi.Properties.Appearance.Options.UseBackColor = true;
            this.txt_KullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txt_KullaniciAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_KullaniciAdi.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txt_KullaniciAdi.Properties.ContextImageOptions.Image")));
            this.txt_KullaniciAdi.Size = new System.Drawing.Size(191, 22);
            this.txt_KullaniciAdi.TabIndex = 1;
            this.txt_KullaniciAdi.EditValueChanged += new System.EventHandler(this.Txt_KullaniciAdi_EditValueChanged);
            this.txt_KullaniciAdi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_KullaniciAdi_KeyDown);
            this.txt_KullaniciAdi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KullaniciAdi_KeyPress);
            // 
            // btn_Cikis
            // 
            this.btn_Cikis.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Cikis.Appearance.Options.UseFont = true;
            this.btn_Cikis.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cikis.ImageOptions.Image")));
            this.btn_Cikis.Location = new System.Drawing.Point(212, 108);
            this.btn_Cikis.Name = "btn_Cikis";
            this.btn_Cikis.Size = new System.Drawing.Size(77, 30);
            this.btn_Cikis.TabIndex = 4;
            this.btn_Cikis.Text = "Çıkış";
            this.btn_Cikis.Click += new System.EventHandler(this.Btn_Cikis_Click);
            // 
            // btn_Giris
            // 
            this.btn_Giris.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Giris.Appearance.Options.UseFont = true;
            this.btn_Giris.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Giris.ImageOptions.Image")));
            this.btn_Giris.Location = new System.Drawing.Point(98, 108);
            this.btn_Giris.Name = "btn_Giris";
            this.btn_Giris.Size = new System.Drawing.Size(77, 30);
            this.btn_Giris.TabIndex = 3;
            this.btn_Giris.Text = "Giriş";
            this.btn_Giris.Click += new System.EventHandler(this.Btn_Giris_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(20, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 13);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "Şifre:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(20, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Kullanıcı Adı:";
            // 
            // err_HataDurumu
            // 
            this.err_HataDurumu.ContainerControl = this;
            // 
            // KullaniciGirisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 242);
            this.Controls.Add(this.panel);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KullaniciGirisi";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.KullaniciGirisi_Load);
            this.Shown += new System.EventHandler(this.KullaniciGirisi_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KullaniciGirisi_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_BeniHatirla.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_KullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_HataDurumu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.ButtonEdit txt_Sifre;
        private DevExpress.XtraEditors.ButtonEdit txt_KullaniciAdi;
        public DevExpress.XtraEditors.SimpleButton btn_Cikis;
        public DevExpress.XtraEditors.SimpleButton btn_Giris;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider err_HataDurumu;
        private DevExpress.XtraEditors.CheckEdit chk_BeniHatirla;
    }
}