namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    partial class FrmGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiris));
            this.btnOgrenciGirisi = new DevExpress.XtraEditors.SimpleButton();
            this.btnPersonelGirisi = new DevExpress.XtraEditors.SimpleButton();
            this.peArkaPlan = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.peArkaPlan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOgrenciGirisi
            // 
            this.btnOgrenciGirisi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOgrenciGirisi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOgrenciGirisi.ImageOptions.Image")));
            this.btnOgrenciGirisi.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnOgrenciGirisi.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            this.btnOgrenciGirisi.Location = new System.Drawing.Point(256, 349);
            this.btnOgrenciGirisi.Margin = new System.Windows.Forms.Padding(3360);
            this.btnOgrenciGirisi.Name = "btnOgrenciGirisi";
            this.btnOgrenciGirisi.Size = new System.Drawing.Size(218, 76);
            this.btnOgrenciGirisi.TabIndex = 0;
            this.btnOgrenciGirisi.Text = "ÖĞRENCİ GİRİŞİ";
            this.btnOgrenciGirisi.Click += new System.EventHandler(this.btnOgrenciGirisi_Click);
            // 
            // btnPersonelGirisi
            // 
            this.btnPersonelGirisi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPersonelGirisi.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnPersonelGirisi.ImageOptions.SvgImage = global::KutuphaneOtomasyonu.Properties.Resources.bo_employee1;
            this.btnPersonelGirisi.Location = new System.Drawing.Point(256, 217);
            this.btnPersonelGirisi.Margin = new System.Windows.Forms.Padding(3360);
            this.btnPersonelGirisi.Name = "btnPersonelGirisi";
            this.btnPersonelGirisi.Size = new System.Drawing.Size(218, 76);
            this.btnPersonelGirisi.TabIndex = 1;
            this.btnPersonelGirisi.Text = "PERSONEL GİRİŞİ";
            this.btnPersonelGirisi.Click += new System.EventHandler(this.btnPersonelGirisi_Click);
            // 
            // peArkaPlan
            // 
            this.peArkaPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peArkaPlan.EditValue = ((object)(resources.GetObject("peArkaPlan.EditValue")));
            this.peArkaPlan.Location = new System.Drawing.Point(0, 0);
            this.peArkaPlan.Name = "peArkaPlan";
            this.peArkaPlan.Properties.ReadOnly = true;
            this.peArkaPlan.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.peArkaPlan.Properties.ShowMenu = false;
            this.peArkaPlan.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.peArkaPlan.Size = new System.Drawing.Size(752, 667);
            this.peArkaPlan.TabIndex = 3;
            // 
            // FrmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(752, 667);
            this.Controls.Add(this.btnPersonelGirisi);
            this.Controls.Add(this.btnOgrenciGirisi);
            this.Controls.Add(this.peArkaPlan);
            this.Name = "FrmGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kütüphane Giriş";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmGiris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.peArkaPlan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOgrenciGirisi;
        private DevExpress.XtraEditors.SimpleButton btnPersonelGirisi;
        
        private DevExpress.XtraEditors.PictureEdit peArkaPlan;
    }
}