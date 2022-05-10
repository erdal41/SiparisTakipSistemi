namespace SiparisTakipSistemi.Sistem
{
    partial class Anaform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anaform));
            this.bar_MainMenu = new DevExpress.XtraBars.BarManager(this.components);
            this.bar_UstMenu = new DevExpress.XtraBars.Bar();
            this.bar_Maliyet = new DevExpress.XtraBars.BarSubItem();
            this.bar_MaliyetIslemleri = new DevExpress.XtraBars.BarButtonItem();
            this.bar_MaliyetListesi = new DevExpress.XtraBars.BarButtonItem();
            this.bar_EkMaliyetIslemleri = new DevExpress.XtraBars.BarButtonItem();
            this.bar_Urunler = new DevExpress.XtraBars.BarSubItem();
            this.bar_UrunIslemleri = new DevExpress.XtraBars.BarButtonItem();
            this.bar_UrunListesi = new DevExpress.XtraBars.BarButtonItem();
            this.bar_Bilesenler = new DevExpress.XtraBars.BarSubItem();
            this.bar_BilesenIslemleri = new DevExpress.XtraBars.BarButtonItem();
            this.bar_EkBilesenIslemleri = new DevExpress.XtraBars.BarButtonItem();
            this.bar_EkIslemMaliyetleri = new DevExpress.XtraBars.BarButtonItem();
            this.bar_Saclar = new DevExpress.XtraBars.BarSubItem();
            this.bar_SacIslemleri = new DevExpress.XtraBars.BarButtonItem();
            this.bar_KutuProfiller = new DevExpress.XtraBars.BarSubItem();
            this.bar_KutuProfilIslemleri = new DevExpress.XtraBars.BarButtonItem();
            this.bar_Kullanicilar = new DevExpress.XtraBars.BarSubItem();
            this.bar_KullaniciIslemleri = new DevExpress.XtraBars.BarButtonItem();
            this.bar_YetkiTanimla = new DevExpress.XtraBars.BarButtonItem();
            this.bar_SifreDegistirme = new DevExpress.XtraBars.BarButtonItem();
            this.bar_Sistem = new DevExpress.XtraBars.BarSubItem();
            this.bar_SunucuDogrula = new DevExpress.XtraBars.BarButtonItem();
            this.bar_Cikis = new DevExpress.XtraBars.BarButtonItem();
            this.bar_AltMenu = new DevExpress.XtraBars.Bar();
            this.bar_KullaniciAdSoyad = new DevExpress.XtraBars.BarStaticItem();
            this.bar_SonGirilenTarih = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.bar_MainMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // bar_MainMenu
            // 
            this.bar_MainMenu.AllowCustomization = false;
            this.bar_MainMenu.AllowQuickCustomization = false;
            this.bar_MainMenu.AllowShowToolbarsPopup = false;
            this.bar_MainMenu.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar_UstMenu,
            this.bar_AltMenu});
            this.bar_MainMenu.DockControls.Add(this.barDockControlTop);
            this.bar_MainMenu.DockControls.Add(this.barDockControlBottom);
            this.bar_MainMenu.DockControls.Add(this.barDockControlLeft);
            this.bar_MainMenu.DockControls.Add(this.barDockControlRight);
            this.bar_MainMenu.Form = this;
            this.bar_MainMenu.HideBarsWhenMerging = false;
            this.bar_MainMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bar_Maliyet,
            this.bar_MaliyetIslemleri,
            this.bar_MaliyetListesi,
            this.bar_Urunler,
            this.bar_UrunIslemleri,
            this.bar_UrunListesi,
            this.bar_Bilesenler,
            this.bar_BilesenIslemleri,
            this.bar_EkBilesenIslemleri,
            this.bar_EkIslemMaliyetleri,
            this.bar_Saclar,
            this.bar_SacIslemleri,
            this.bar_KutuProfiller,
            this.bar_KutuProfilIslemleri,
            this.bar_Sistem,
            this.bar_Cikis,
            this.bar_SunucuDogrula,
            this.bar_KullaniciAdSoyad,
            this.bar_Kullanicilar,
            this.bar_KullaniciIslemleri,
            this.bar_YetkiTanimla,
            this.bar_SifreDegistirme,
            this.bar_EkMaliyetIslemleri,
            this.bar_SonGirilenTarih});
            this.bar_MainMenu.MainMenu = this.bar_UstMenu;
            this.bar_MainMenu.MaxItemId = 28;
            this.bar_MainMenu.StatusBar = this.bar_AltMenu;
            // 
            // bar_UstMenu
            // 
            this.bar_UstMenu.BarName = "Main Menu";
            this.bar_UstMenu.DockCol = 0;
            this.bar_UstMenu.DockRow = 0;
            this.bar_UstMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar_UstMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_Maliyet, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_Urunler, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_Bilesenler, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_Saclar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_KutuProfiller, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_Kullanicilar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_Sistem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar_UstMenu.OptionsBar.DisableClose = true;
            this.bar_UstMenu.OptionsBar.DisableCustomization = true;
            this.bar_UstMenu.OptionsBar.DrawBorder = false;
            this.bar_UstMenu.OptionsBar.DrawDragBorder = false;
            this.bar_UstMenu.OptionsBar.DrawSizeGrip = true;
            this.bar_UstMenu.OptionsBar.MultiLine = true;
            this.bar_UstMenu.OptionsBar.UseWholeRow = true;
            this.bar_UstMenu.Text = "Main Menü";
            // 
            // bar_Maliyet
            // 
            this.bar_Maliyet.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.bar_Maliyet.Caption = "Maliyet";
            this.bar_Maliyet.Id = 0;
            this.bar_Maliyet.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_Maliyet.ImageOptions.SvgImage")));
            this.bar_Maliyet.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bar_Maliyet.ItemAppearance.Normal.Options.UseFont = true;
            this.bar_Maliyet.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_MaliyetIslemleri, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_MaliyetListesi, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_EkMaliyetIslemleri, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar_Maliyet.Name = "bar_Maliyet";
            this.bar_Maliyet.Size = new System.Drawing.Size(0, 50);
            // 
            // bar_MaliyetIslemleri
            // 
            this.bar_MaliyetIslemleri.Caption = "Maliyet İşlemleri";
            this.bar_MaliyetIslemleri.Id = 1;
            this.bar_MaliyetIslemleri.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_MaliyetIslemleri.ImageOptions.SvgImage")));
            this.bar_MaliyetIslemleri.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.bar_MaliyetIslemleri.Name = "bar_MaliyetIslemleri";
            this.bar_MaliyetIslemleri.ShortcutKeyDisplayString = "F1";
            this.bar_MaliyetIslemleri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_MaliyetIslemleri_ItemClick);
            // 
            // bar_MaliyetListesi
            // 
            this.bar_MaliyetListesi.Caption = "Maliyet Listesi";
            this.bar_MaliyetListesi.Id = 2;
            this.bar_MaliyetListesi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_MaliyetListesi.ImageOptions.SvgImage")));
            this.bar_MaliyetListesi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M));
            this.bar_MaliyetListesi.Name = "bar_MaliyetListesi";
            this.bar_MaliyetListesi.ShortcutKeyDisplayString = "Ctrl+M";
            this.bar_MaliyetListesi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_MaliyetListesi_ItemClick);
            // 
            // bar_EkMaliyetIslemleri
            // 
            this.bar_EkMaliyetIslemleri.Caption = "Ek Maliyet İşlemleri";
            this.bar_EkMaliyetIslemleri.Id = 22;
            this.bar_EkMaliyetIslemleri.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_EkMaliyetIslemleri.ImageOptions.SvgImage")));
            this.bar_EkMaliyetIslemleri.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.M));
            this.bar_EkMaliyetIslemleri.Name = "bar_EkMaliyetIslemleri";
            this.bar_EkMaliyetIslemleri.ShortcutKeyDisplayString = "Ctrl+Shift+M";
            this.bar_EkMaliyetIslemleri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_EkMaliyetIslemleri_ItemClick);
            // 
            // bar_Urunler
            // 
            this.bar_Urunler.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.bar_Urunler.Caption = "Ürünler";
            this.bar_Urunler.Id = 3;
            this.bar_Urunler.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_Urunler.ImageOptions.SvgImage")));
            this.bar_Urunler.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bar_Urunler.ItemAppearance.Normal.Options.UseFont = true;
            this.bar_Urunler.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_UrunIslemleri, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_UrunListesi, true)});
            this.bar_Urunler.Name = "bar_Urunler";
            this.bar_Urunler.Size = new System.Drawing.Size(0, 50);
            // 
            // bar_UrunIslemleri
            // 
            this.bar_UrunIslemleri.Caption = "Ürün İşlemleri";
            this.bar_UrunIslemleri.Id = 4;
            this.bar_UrunIslemleri.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_UrunIslemleri.ImageOptions.SvgImage")));
            this.bar_UrunIslemleri.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.bar_UrunIslemleri.Name = "bar_UrunIslemleri";
            this.bar_UrunIslemleri.ShortcutKeyDisplayString = "F2";
            this.bar_UrunIslemleri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_UrunIslemleri_ItemClick);
            // 
            // bar_UrunListesi
            // 
            this.bar_UrunListesi.Caption = "Ürün Listesi";
            this.bar_UrunListesi.Id = 5;
            this.bar_UrunListesi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_UrunListesi.ImageOptions.SvgImage")));
            this.bar_UrunListesi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U));
            this.bar_UrunListesi.Name = "bar_UrunListesi";
            this.bar_UrunListesi.ShortcutKeyDisplayString = "Ctrl+U";
            this.bar_UrunListesi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_UrunListesi_ItemClick);
            // 
            // bar_Bilesenler
            // 
            this.bar_Bilesenler.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.bar_Bilesenler.Caption = "Bileşenler";
            this.bar_Bilesenler.Id = 6;
            this.bar_Bilesenler.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_Bilesenler.ImageOptions.SvgImage")));
            this.bar_Bilesenler.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bar_Bilesenler.ItemAppearance.Normal.Options.UseFont = true;
            this.bar_Bilesenler.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_BilesenIslemleri, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_EkBilesenIslemleri, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_EkIslemMaliyetleri, true)});
            this.bar_Bilesenler.Name = "bar_Bilesenler";
            this.bar_Bilesenler.Size = new System.Drawing.Size(0, 50);
            // 
            // bar_BilesenIslemleri
            // 
            this.bar_BilesenIslemleri.Caption = "Bileşen İşlemleri";
            this.bar_BilesenIslemleri.Id = 7;
            this.bar_BilesenIslemleri.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_BilesenIslemleri.ImageOptions.SvgImage")));
            this.bar_BilesenIslemleri.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.bar_BilesenIslemleri.Name = "bar_BilesenIslemleri";
            this.bar_BilesenIslemleri.ShortcutKeyDisplayString = "F3";
            this.bar_BilesenIslemleri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_BilesenIslemleri_ItemClick);
            // 
            // bar_EkBilesenIslemleri
            // 
            this.bar_EkBilesenIslemleri.Caption = "Ek Bileşen İşlemleri";
            this.bar_EkBilesenIslemleri.Id = 8;
            this.bar_EkBilesenIslemleri.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_EkBilesenIslemleri.ImageOptions.SvgImage")));
            this.bar_EkBilesenIslemleri.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.bar_EkBilesenIslemleri.Name = "bar_EkBilesenIslemleri";
            this.bar_EkBilesenIslemleri.ShortcutKeyDisplayString = "F4";
            this.bar_EkBilesenIslemleri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_EkBilesenIslemleri_ItemClick);
            // 
            // bar_EkIslemMaliyetleri
            // 
            this.bar_EkIslemMaliyetleri.Caption = "Ek İşlem Maliyetleri";
            this.bar_EkIslemMaliyetleri.Id = 9;
            this.bar_EkIslemMaliyetleri.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_EkIslemMaliyetleri.ImageOptions.SvgImage")));
            this.bar_EkIslemMaliyetleri.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.bar_EkIslemMaliyetleri.Name = "bar_EkIslemMaliyetleri";
            this.bar_EkIslemMaliyetleri.ShortcutKeyDisplayString = "F5";
            this.bar_EkIslemMaliyetleri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_EkIslemMaliyetleri_ItemClick);
            // 
            // bar_Saclar
            // 
            this.bar_Saclar.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.bar_Saclar.Caption = "Saclar";
            this.bar_Saclar.Id = 10;
            this.bar_Saclar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_Saclar.ImageOptions.SvgImage")));
            this.bar_Saclar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bar_Saclar.ItemAppearance.Normal.Options.UseFont = true;
            this.bar_Saclar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_SacIslemleri, true)});
            this.bar_Saclar.Name = "bar_Saclar";
            this.bar_Saclar.Size = new System.Drawing.Size(0, 50);
            // 
            // bar_SacIslemleri
            // 
            this.bar_SacIslemleri.Caption = "Sac İşlemleri";
            this.bar_SacIslemleri.Id = 11;
            this.bar_SacIslemleri.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_SacIslemleri.ImageOptions.SvgImage")));
            this.bar_SacIslemleri.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.bar_SacIslemleri.Name = "bar_SacIslemleri";
            this.bar_SacIslemleri.ShortcutKeyDisplayString = "F6";
            this.bar_SacIslemleri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_SacIslemleri_ItemClick);
            // 
            // bar_KutuProfiller
            // 
            this.bar_KutuProfiller.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.bar_KutuProfiller.Caption = "Kutu Profiller";
            this.bar_KutuProfiller.Id = 12;
            this.bar_KutuProfiller.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_KutuProfiller.ImageOptions.SvgImage")));
            this.bar_KutuProfiller.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bar_KutuProfiller.ItemAppearance.Normal.Options.UseFont = true;
            this.bar_KutuProfiller.ItemInMenuAppearance.Normal.BackColor = System.Drawing.Color.Red;
            this.bar_KutuProfiller.ItemInMenuAppearance.Normal.Options.UseBackColor = true;
            this.bar_KutuProfiller.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_KutuProfilIslemleri, true)});
            this.bar_KutuProfiller.Name = "bar_KutuProfiller";
            this.bar_KutuProfiller.Size = new System.Drawing.Size(0, 50);
            // 
            // bar_KutuProfilIslemleri
            // 
            this.bar_KutuProfilIslemleri.Caption = "Kutu Profil İşlemleri";
            this.bar_KutuProfilIslemleri.Id = 13;
            this.bar_KutuProfilIslemleri.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_KutuProfilIslemleri.ImageOptions.SvgImage")));
            this.bar_KutuProfilIslemleri.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F7);
            this.bar_KutuProfilIslemleri.Name = "bar_KutuProfilIslemleri";
            this.bar_KutuProfilIslemleri.ShortcutKeyDisplayString = "F7";
            this.bar_KutuProfilIslemleri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_KutuProfilIslemleri_ItemClick);
            // 
            // bar_Kullanicilar
            // 
            this.bar_Kullanicilar.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.bar_Kullanicilar.Caption = "Kullanıcılar";
            this.bar_Kullanicilar.Id = 18;
            this.bar_Kullanicilar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_Kullanicilar.ImageOptions.Image")));
            this.bar_Kullanicilar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_Kullanicilar.ImageOptions.LargeImage")));
            this.bar_Kullanicilar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bar_Kullanicilar.ItemAppearance.Normal.Options.UseFont = true;
            this.bar_Kullanicilar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_KullaniciIslemleri),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_YetkiTanimla, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_SifreDegistirme, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar_Kullanicilar.Name = "bar_Kullanicilar";
            // 
            // bar_KullaniciIslemleri
            // 
            this.bar_KullaniciIslemleri.Caption = "Kullanıcı İşlemleri";
            this.bar_KullaniciIslemleri.Id = 19;
            this.bar_KullaniciIslemleri.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_KullaniciIslemleri.ImageOptions.Image")));
            this.bar_KullaniciIslemleri.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_KullaniciIslemleri.ImageOptions.LargeImage")));
            this.bar_KullaniciIslemleri.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K));
            this.bar_KullaniciIslemleri.Name = "bar_KullaniciIslemleri";
            this.bar_KullaniciIslemleri.ShortcutKeyDisplayString = "Ctrl+K";
            this.bar_KullaniciIslemleri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_KullaniciIslemleri_ItemClick);
            // 
            // bar_YetkiTanimla
            // 
            this.bar_YetkiTanimla.Caption = "Yetki İşlemleri";
            this.bar_YetkiTanimla.Id = 20;
            this.bar_YetkiTanimla.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_YetkiTanimla.ImageOptions.Image")));
            this.bar_YetkiTanimla.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_YetkiTanimla.ImageOptions.LargeImage")));
            this.bar_YetkiTanimla.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y));
            this.bar_YetkiTanimla.Name = "bar_YetkiTanimla";
            this.bar_YetkiTanimla.ShortcutKeyDisplayString = "Ctrl+Y";
            this.bar_YetkiTanimla.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_YetkiTanimla_ItemClick);
            // 
            // bar_SifreDegistirme
            // 
            this.bar_SifreDegistirme.Caption = "Şifre Değiştirme";
            this.bar_SifreDegistirme.Id = 21;
            this.bar_SifreDegistirme.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_SifreDegistirme.ImageOptions.SvgImage")));
            this.bar_SifreDegistirme.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.bar_SifreDegistirme.Name = "bar_SifreDegistirme";
            this.bar_SifreDegistirme.ShortcutKeyDisplayString = "Ctrl+P";
            this.bar_SifreDegistirme.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_SifreDegistirme_ItemClick);
            // 
            // bar_Sistem
            // 
            this.bar_Sistem.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.bar_Sistem.Caption = "Sistem";
            this.bar_Sistem.Id = 14;
            this.bar_Sistem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_Sistem.ImageOptions.SvgImage")));
            this.bar_Sistem.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bar_Sistem.ItemAppearance.Normal.Options.UseFont = true;
            this.bar_Sistem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_SunucuDogrula, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_Cikis, true)});
            this.bar_Sistem.Name = "bar_Sistem";
            // 
            // bar_SunucuDogrula
            // 
            this.bar_SunucuDogrula.Caption = "Sunucu Doğrula";
            this.bar_SunucuDogrula.Id = 16;
            this.bar_SunucuDogrula.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_SunucuDogrula.ImageOptions.SvgImage")));
            this.bar_SunucuDogrula.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1));
            this.bar_SunucuDogrula.Name = "bar_SunucuDogrula";
            this.bar_SunucuDogrula.ShortcutKeyDisplayString = "Ctrl+F1";
            this.bar_SunucuDogrula.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_SunucuDogrula_ItemClick);
            // 
            // bar_Cikis
            // 
            this.bar_Cikis.Caption = "Çıkış";
            this.bar_Cikis.Id = 15;
            this.bar_Cikis.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_Cikis.ImageOptions.SvgImage")));
            this.bar_Cikis.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.bar_Cikis.Name = "bar_Cikis";
            this.bar_Cikis.ShortcutKeyDisplayString = "Ctrl + Q";
            this.bar_Cikis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_Cikis_ItemClick);
            // 
            // bar_AltMenu
            // 
            this.bar_AltMenu.BarName = "Status bar";
            this.bar_AltMenu.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar_AltMenu.DockCol = 0;
            this.bar_AltMenu.DockRow = 0;
            this.bar_AltMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar_AltMenu.HideWhenMerging = DevExpress.Utils.DefaultBoolean.False;
            this.bar_AltMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_KullaniciAdSoyad, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_SonGirilenTarih, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar_AltMenu.OptionsBar.AllowQuickCustomization = false;
            this.bar_AltMenu.OptionsBar.DrawDragBorder = false;
            this.bar_AltMenu.OptionsBar.UseWholeRow = true;
            this.bar_AltMenu.Text = "Status bar";
            // 
            // bar_KullaniciAdSoyad
            // 
            this.bar_KullaniciAdSoyad.AccessibleDescription = "Giriş yapan personelin adı ve soyadı";
            this.bar_KullaniciAdSoyad.Hint = "Giriş yapan personelin adı ve soyadı";
            this.bar_KullaniciAdSoyad.Id = 17;
            this.bar_KullaniciAdSoyad.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_KullaniciAdSoyad.ImageOptions.Image")));
            this.bar_KullaniciAdSoyad.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_KullaniciAdSoyad.ImageOptions.LargeImage")));
            this.bar_KullaniciAdSoyad.Name = "bar_KullaniciAdSoyad";
            this.bar_KullaniciAdSoyad.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bar_SonGirilenTarih
            // 
            this.bar_SonGirilenTarih.Hint = "Giriş yapan personelin, son giriş tarihi";
            this.bar_SonGirilenTarih.Id = 27;
            this.bar_SonGirilenTarih.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_SonGirilenTarih.ImageOptions.Image")));
            this.bar_SonGirilenTarih.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_SonGirilenTarih.ImageOptions.LargeImage")));
            this.bar_SonGirilenTarih.Name = "bar_SonGirilenTarih";
            this.bar_SonGirilenTarih.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bar_MainMenu;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlTop.Size = new System.Drawing.Size(819, 52);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 412);
            this.barDockControlBottom.Manager = this.bar_MainMenu;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlBottom.Size = new System.Drawing.Size(819, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 52);
            this.barDockControlLeft.Manager = this.bar_MainMenu;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 360);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(819, 52);
            this.barDockControlRight.Manager = this.bar_MainMenu;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 360);
            // 
            // Anaform
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 436);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Anaform";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maliyet Hesaplama Sistemi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Anaform_FormClosing);
            this.Load += new System.EventHandler(this.Anaform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar_MainMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Bar bar_AltMenu;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem bar_Maliyet;
        private DevExpress.XtraBars.BarButtonItem bar_MaliyetIslemleri;
        private DevExpress.XtraBars.BarButtonItem bar_MaliyetListesi;
        private DevExpress.XtraBars.BarSubItem bar_Urunler;
        private DevExpress.XtraBars.BarButtonItem bar_UrunIslemleri;
        private DevExpress.XtraBars.BarButtonItem bar_UrunListesi;
        private DevExpress.XtraBars.BarSubItem bar_Bilesenler;
        private DevExpress.XtraBars.BarButtonItem bar_BilesenIslemleri;
        private DevExpress.XtraBars.BarButtonItem bar_EkBilesenIslemleri;
        private DevExpress.XtraBars.BarButtonItem bar_EkIslemMaliyetleri;
        private DevExpress.XtraBars.BarSubItem bar_Saclar;
        private DevExpress.XtraBars.BarButtonItem bar_SacIslemleri;
        private DevExpress.XtraBars.BarSubItem bar_KutuProfiller;
        private DevExpress.XtraBars.BarButtonItem bar_KutuProfilIslemleri;
        private DevExpress.XtraBars.BarSubItem bar_Sistem;
        private DevExpress.XtraBars.BarButtonItem bar_Cikis;
        private DevExpress.XtraBars.BarButtonItem bar_SunucuDogrula;
        public DevExpress.XtraBars.BarStaticItem bar_KullaniciAdSoyad;
        private DevExpress.XtraBars.BarSubItem bar_Kullanicilar;
        private DevExpress.XtraBars.BarButtonItem bar_KullaniciIslemleri;
        private DevExpress.XtraBars.BarButtonItem bar_YetkiTanimla;
        public DevExpress.XtraBars.Bar bar_UstMenu;
        public DevExpress.XtraBars.BarManager bar_MainMenu;
        private DevExpress.XtraBars.BarButtonItem bar_SifreDegistirme;
        private DevExpress.XtraBars.BarButtonItem bar_EkMaliyetIslemleri;
        public DevExpress.XtraBars.BarStaticItem bar_SonGirilenTarih;
    }
}