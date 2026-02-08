namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    partial class FrmKitapDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKitapDetay));
            this.picKapak = new DevExpress.XtraEditors.PictureEdit();
            this.lblKitapAdi = new DevExpress.XtraEditors.LabelControl();
            this.lblYazar = new DevExpress.XtraEditors.LabelControl();
            this.lblTur = new DevExpress.XtraEditors.LabelControl();
            this.lblISBN = new DevExpress.XtraEditors.LabelControl();
            this.lblStok = new DevExpress.XtraEditors.LabelControl();
            this.lblDurum = new DevExpress.XtraEditors.LabelControl();
            this.btnOduncAl = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnFavori = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.picKapak.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picKapak
            // 
            this.picKapak.Location = new System.Drawing.Point(3, 3);
            this.picKapak.Name = "picKapak";
            this.picKapak.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.tableLayoutPanel1.SetRowSpan(this.picKapak, 7);
            this.picKapak.Size = new System.Drawing.Size(296, 654);
            this.picKapak.TabIndex = 0;
            this.picKapak.EditValueChanged += new System.EventHandler(this.picKapak_EditValueChanged);
            // 
            // lblKitapAdi
            // 
            this.lblKitapAdi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKitapAdi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKitapAdi.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblKitapAdi.Appearance.Options.UseFont = true;
            this.lblKitapAdi.Appearance.Options.UseForeColor = true;
            this.lblKitapAdi.Location = new System.Drawing.Point(537, 3);
            this.lblKitapAdi.Name = "lblKitapAdi";
            this.lblKitapAdi.Size = new System.Drawing.Size(81, 18);
            this.lblKitapAdi.TabIndex = 1;
            this.lblKitapAdi.Text = "labelControl1";
            // 
            // lblYazar
            // 
            this.lblYazar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYazar.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblYazar.Appearance.Options.UseFont = true;
            this.lblYazar.Appearance.Options.UseForeColor = true;
            this.lblYazar.Location = new System.Drawing.Point(537, 96);
            this.lblYazar.Name = "lblYazar";
            this.lblYazar.Size = new System.Drawing.Size(81, 18);
            this.lblYazar.TabIndex = 2;
            this.lblYazar.Text = "labelControl2";
            // 
            // lblTur
            // 
            this.lblTur.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTur.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTur.Appearance.Options.UseFont = true;
            this.lblTur.Appearance.Options.UseForeColor = true;
            this.lblTur.Location = new System.Drawing.Point(537, 189);
            this.lblTur.Name = "lblTur";
            this.lblTur.Size = new System.Drawing.Size(81, 18);
            this.lblTur.TabIndex = 3;
            this.lblTur.Text = "labelControl3";
            // 
            // lblISBN
            // 
            this.lblISBN.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblISBN.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblISBN.Appearance.Options.UseFont = true;
            this.lblISBN.Appearance.Options.UseForeColor = true;
            this.lblISBN.Location = new System.Drawing.Point(537, 283);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(81, 18);
            this.lblISBN.TabIndex = 4;
            this.lblISBN.Text = "labelControl4";
            // 
            // lblStok
            // 
            this.lblStok.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStok.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblStok.Appearance.Options.UseFont = true;
            this.lblStok.Appearance.Options.UseForeColor = true;
            this.lblStok.Location = new System.Drawing.Point(537, 377);
            this.lblStok.Name = "lblStok";
            this.lblStok.Size = new System.Drawing.Size(81, 18);
            this.lblStok.TabIndex = 5;
            this.lblStok.Text = "labelControl5";
            // 
            // lblDurum
            // 
            this.lblDurum.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblDurum.Appearance.Options.UseFont = true;
            this.lblDurum.Appearance.Options.UseForeColor = true;
            this.lblDurum.Location = new System.Drawing.Point(537, 471);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(81, 18);
            this.lblDurum.TabIndex = 6;
            this.lblDurum.Text = "labelControl6";
            // 
            // btnOduncAl
            // 
            this.btnOduncAl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOduncAl.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOduncAl.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOduncAl.Appearance.Options.UseFont = true;
            this.btnOduncAl.Appearance.Options.UseForeColor = true;
            this.btnOduncAl.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOduncAl.ImageOptions.Image")));
            this.btnOduncAl.Location = new System.Drawing.Point(305, 565);
            this.btnOduncAl.Name = "btnOduncAl";
            this.btnOduncAl.Size = new System.Drawing.Size(226, 92);
            this.btnOduncAl.TabIndex = 7;
            this.btnOduncAl.Text = "Ödünç Al";
            this.btnOduncAl.Click += new System.EventHandler(this.btnOduncAl_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.33393F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.33303F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.33303F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl6, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.picKapak, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOduncAl, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblYazar, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTur, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblISBN, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblStok, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDurum, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblKitapAdi, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFavori, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.22846F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.22846F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.30862F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.30862F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.30862F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.30862F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.30862F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(768, 660);
            this.tableLayoutPanel1.TabIndex = 8;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(305, 471);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(213, 18);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Mevcut Olarak Alınabilir mi?";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(305, 377);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(96, 18);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Stok Durumu";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(305, 283);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 18);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "ISBN :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(305, 189);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(62, 18);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Tür Adı :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(305, 96);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 18);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Yazar Adı :";
            // 
            // btnFavori
            // 
            this.btnFavori.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFavori.Appearance.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.btnFavori.Appearance.Options.UseFont = true;
            this.btnFavori.Appearance.Options.UseForeColor = true;
            this.btnFavori.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFavori.ImageOptions.Image")));
            this.btnFavori.Location = new System.Drawing.Point(537, 565);
            this.btnFavori.Name = "btnFavori";
            this.btnFavori.Size = new System.Drawing.Size(228, 92);
            this.btnFavori.TabIndex = 14;
            this.btnFavori.Text = "Favorilere Ekle";
            this.btnFavori.Click += new System.EventHandler(this.btnFavori_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(305, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 18);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Kitap Adı :";
            // 
            // FrmKitapDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 660);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmKitapDetay";
            this.Text = "FrmKitapDetay";
            ((System.ComponentModel.ISupportInitialize)(this.picKapak.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picKapak;
        private DevExpress.XtraEditors.LabelControl lblKitapAdi;
        private DevExpress.XtraEditors.LabelControl lblYazar;
        private DevExpress.XtraEditors.LabelControl lblTur;
        private DevExpress.XtraEditors.LabelControl lblISBN;
        private DevExpress.XtraEditors.LabelControl lblStok;
        private DevExpress.XtraEditors.LabelControl lblDurum;
        private DevExpress.XtraEditors.SimpleButton btnOduncAl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnFavori;
    }
}