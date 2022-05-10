namespace SiparisTakipSistemi.Kullanici
{
    partial class SifreDogrula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SifreDogrula));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txt_Sifre = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Onayla = new DevExpress.XtraEditors.SimpleButton();
            this.err_HataDurumu = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_HataDurumu)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Sifre
            // 
            this.txt_Sifre.EditValue = "";
            this.txt_Sifre.Location = new System.Drawing.Point(95, 7);
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
            this.txt_Sifre.TabIndex = 23;
            this.txt_Sifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Sifre_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 13);
            this.labelControl2.TabIndex = 24;
            this.labelControl2.Text = "Mevcut Şifreniz:";
            // 
            // btn_Onayla
            // 
            this.btn_Onayla.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Onayla.Appearance.Options.UseFont = true;
            this.btn_Onayla.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Onayla.ImageOptions.Image")));
            this.btn_Onayla.Location = new System.Drawing.Point(179, 37);
            this.btn_Onayla.Name = "btn_Onayla";
            this.btn_Onayla.Size = new System.Drawing.Size(77, 30);
            this.btn_Onayla.TabIndex = 25;
            this.btn_Onayla.Text = "Onayla";
            this.btn_Onayla.Click += new System.EventHandler(this.Btn_Onayla_Click);
            // 
            // err_HataDurumu
            // 
            this.err_HataDurumu.ContainerControl = this;
            // 
            // SifreDogrula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 74);
            this.Controls.Add(this.btn_Onayla);
            this.Controls.Add(this.txt_Sifre);
            this.Controls.Add(this.labelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SifreDogrula";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre Doğrula";
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_HataDurumu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit txt_Sifre;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.SimpleButton btn_Onayla;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider err_HataDurumu;
    }
}