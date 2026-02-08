namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    partial class FrmPersonelGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPersonelGiris));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.grpGiris = new DevExpress.XtraEditors.GroupControl();
            this.lblHata = new DevExpress.XtraEditors.LabelControl();
            this.lnkKayitOl = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.btnGiris = new DevExpress.XtraEditors.SimpleButton();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.peKutuphane = new DevExpress.XtraEditors.PictureEdit();
            this.txtSifre = new DevExpress.XtraEditors.ButtonEdit();
            this.btnGeriDon = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGiris)).BeginInit();
            this.grpGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peKutuphane.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureEdit1.BackgroundImage")));
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(768, 660);
            this.pictureEdit1.TabIndex = 0;
            // 
            // grpGiris
            // 
            this.grpGiris.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpGiris.Controls.Add(this.lblHata);
            this.grpGiris.Controls.Add(this.lnkKayitOl);
            this.grpGiris.Controls.Add(this.btnGiris);
            this.grpGiris.Controls.Add(this.txtKullaniciAdi);
            this.grpGiris.Controls.Add(this.labelControl1);
            this.grpGiris.Controls.Add(this.peKutuphane);
            this.grpGiris.Controls.Add(this.txtSifre);
            this.grpGiris.Location = new System.Drawing.Point(174, 0);
            this.grpGiris.Margin = new System.Windows.Forms.Padding(4);
            this.grpGiris.Name = "grpGiris";
            this.grpGiris.ShowCaption = false;
            this.grpGiris.Size = new System.Drawing.Size(472, 660);
            this.grpGiris.TabIndex = 1;
            this.grpGiris.Text = "groupControl1";
            // 
            // lblHata
            // 
            this.lblHata.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHata.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblHata.Appearance.Options.UseFont = true;
            this.lblHata.Appearance.Options.UseForeColor = true;
            this.lblHata.Location = new System.Drawing.Point(159, 367);
            this.lblHata.Name = "lblHata";
            this.lblHata.Size = new System.Drawing.Size(0, 17);
            this.lblHata.TabIndex = 6;
            // 
            // lnkKayitOl
            // 
            this.lnkKayitOl.Location = new System.Drawing.Point(176, 514);
            this.lnkKayitOl.Name = "lnkKayitOl";
            this.lnkKayitOl.Size = new System.Drawing.Size(168, 16);
            this.lnkKayitOl.TabIndex = 5;
            this.lnkKayitOl.Text = "<href>Hesabınız Yok Mu? Kayıt olun.<href>";
            this.lnkKayitOl.Click += new System.EventHandler(this.lnkKayitOl_Click);
            // 
            // btnGiris
            // 
            this.btnGiris.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGiris.Appearance.BackColor = System.Drawing.Color.Teal;
            this.btnGiris.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGiris.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnGiris.Appearance.Options.UseBackColor = true;
            this.btnGiris.Appearance.Options.UseBorderColor = true;
            this.btnGiris.Appearance.Options.UseFont = true;
            this.btnGiris.Appearance.Options.UseForeColor = true;
            this.btnGiris.Location = new System.Drawing.Point(194, 412);
            this.btnGiris.Margin = new System.Windows.Forms.Padding(4);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(128, 41);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(138, 266);
            this.txtKullaniciAdi.Margin = new System.Windows.Forms.Padding(4);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.AutoHeight = false;
            this.txtKullaniciAdi.Properties.NullValuePrompt = "Kullanıcı Adı";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(240, 31);
            this.txtKullaniciAdi.TabIndex = 2;
            
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(159, 193);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(198, 31);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "  PERSONEL GİRİŞİ";
            // 
            // peKutuphane
            // 
            this.peKutuphane.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.peKutuphane.EditValue = ((object)(resources.GetObject("peKutuphane.EditValue")));
            this.peKutuphane.Location = new System.Drawing.Point(194, 52);
            this.peKutuphane.Margin = new System.Windows.Forms.Padding(4);
            this.peKutuphane.Name = "peKutuphane";
            this.peKutuphane.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peKutuphane.Properties.Appearance.Options.UseBackColor = true;
            this.peKutuphane.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peKutuphane.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.peKutuphane.Size = new System.Drawing.Size(128, 99);
            this.peKutuphane.TabIndex = 0;
            // 
            // txtSifre
            // 
            this.txtSifre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSifre.Location = new System.Drawing.Point(138, 339);
            this.txtSifre.Margin = new System.Windows.Forms.Padding(5);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = global::KutuphaneOtomasyonu.Properties.Resources.RedEye2;
            editorButtonImageOptions1.SvgImageSize = new System.Drawing.Size(20, 20);
            serializableAppearanceObject1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            serializableAppearanceObject1.Options.UseForeColor = true;
            this.txtSifre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 30, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtSifre.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSifre.Properties.ContextImageOptions.SvgImage = global::KutuphaneOtomasyonu.Properties.Resources.RedEye;
            this.txtSifre.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(1, 1);
            this.txtSifre.Properties.NullValuePrompt = "Şifre";
            this.txtSifre.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorFocused)));
            this.txtSifre.Properties.UseSystemPasswordChar = true;
            this.txtSifre.Size = new System.Drawing.Size(240, 31);
            this.txtSifre.TabIndex = 3;
            this.txtSifre.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSifre_ButtonClick);
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.ImageOptions.SvgImage = global::KutuphaneOtomasyonu.Properties.Resources.undo;
            this.btnGeriDon.Location = new System.Drawing.Point(12, 12);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnGeriDon.Size = new System.Drawing.Size(40, 40);
            this.btnGeriDon.TabIndex = 10;
            this.btnGeriDon.ToolTip = "Giriş Ekranına Dön";
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // FrmPersonelGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 660);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.grpGiris);
            this.Controls.Add(this.pictureEdit1);
            this.Name = "FrmPersonelGiris";
            this.Text = "Personel Girişi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPersonelGiris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGiris)).EndInit();
            this.grpGiris.ResumeLayout(false);
            this.grpGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peKutuphane.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.GroupControl grpGiris;
        private DevExpress.XtraEditors.PictureEdit peKutuphane;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGiris;
        private DevExpress.XtraEditors.ButtonEdit txtSifre;
        private DevExpress.XtraEditors.HyperlinkLabelControl lnkKayitOl;
        private DevExpress.XtraEditors.LabelControl lblHata;
        private DevExpress.XtraEditors.SimpleButton btnGeriDon;
    }
}