namespace SiparisTakipSistemi.Sistem
{
    partial class SifreDogrulama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SifreDogrulama));
            this.btn_SifreDogrula = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Sifre = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sifre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_SifreDogrula
            // 
            this.btn_SifreDogrula.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_SifreDogrula.Appearance.Options.UseFont = true;
            this.btn_SifreDogrula.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SifreDogrula.ImageOptions.Image")));
            this.btn_SifreDogrula.Location = new System.Drawing.Point(111, 40);
            this.btn_SifreDogrula.Name = "btn_SifreDogrula";
            this.btn_SifreDogrula.Size = new System.Drawing.Size(109, 30);
            this.btn_SifreDogrula.TabIndex = 16;
            this.btn_SifreDogrula.Text = "Şifreyi Doğrula";
            this.btn_SifreDogrula.Click += new System.EventHandler(this.Btn_SifreDogrula_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Şifre:";
            // 
            // txt_Sifre
            // 
            this.txt_Sifre.Location = new System.Drawing.Point(44, 12);
            this.txt_Sifre.Name = "txt_Sifre";
            this.txt_Sifre.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_Sifre.Properties.Appearance.Options.UseBackColor = true;
            this.txt_Sifre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt_Sifre.Properties.PasswordChar = '✺';
            this.txt_Sifre.Size = new System.Drawing.Size(176, 22);
            this.txt_Sifre.TabIndex = 13;
            // 
            // SifreDogrulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 84);
            this.Controls.Add(this.btn_SifreDogrula);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_Sifre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SifreDogrulama";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre";
            this.Load += new System.EventHandler(this.SifreDogrulama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sifre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btn_SifreDogrula;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_Sifre;
    }
}