using System;
using System.ComponentModel;
using System.Drawing; // Color, Point, Font için şart
using System.Windows.Forms; // Label, Form, Button için şart
using DevExpress.XtraEditors; // DevExpress araçları için
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;

namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    partial class FrmAnaSayfaPersonel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaSayfaPersonel));
            this.İstatistikler = new DevExpress.XtraTab.XtraTabPage();
            this.tbl_pnlGrafik = new System.Windows.Forms.TableLayoutPanel();
            this.chartKitap = new DevExpress.XtraCharts.ChartControl();
            this.chartTur = new DevExpress.XtraCharts.ChartControl();
            this.chartYazar = new DevExpress.XtraCharts.ChartControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tbl_pnlIstatistik = new System.Windows.Forms.TableLayoutPanel();
            this.grpUye = new DevExpress.XtraEditors.GroupControl();
            this.lblToplamUye = new DevExpress.XtraEditors.LabelControl();
            this.lblUyeTxt = new DevExpress.XtraEditors.LabelControl();
            this.grpPersonel = new DevExpress.XtraEditors.GroupControl();
            this.lblToplamPersonel = new DevExpress.XtraEditors.LabelControl();
            this.lblPersonelTxt = new DevExpress.XtraEditors.LabelControl();
            this.grpKitap = new DevExpress.XtraEditors.GroupControl();
            this.lblToplamKitap = new DevExpress.XtraEditors.LabelControl();
            this.lblKitapTxt = new DevExpress.XtraEditors.LabelControl();
            this.grpBugun = new DevExpress.XtraEditors.GroupControl();
            this.lblBugunVerilen = new DevExpress.XtraEditors.LabelControl();
            this.lblBugunTxt = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcEmanetler = new DevExpress.XtraGrid.GridControl();
            this.gvEmanetler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnl_cntrlIslemler = new DevExpress.XtraEditors.PanelControl();
            this.tbl_lytIslemler = new System.Windows.Forms.TableLayoutPanel();
            this.grp_cntrlOduncVer = new DevExpress.XtraEditors.GroupControl();
            this.tbl_lytOdunc = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOduncVer = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateAlisTarihi = new DevExpress.XtraEditors.DateEdit();
            this.lueOduncOgrenci = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lueOduncKitap = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit3View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpcntrlIadeAl = new DevExpress.XtraEditors.GroupControl();
            this.cmbKitapDurumu = new DevExpress.XtraEditors.ComboBoxEdit();
            this.calcGecikmeBedeli = new DevExpress.XtraEditors.CalcEdit();
            this.dateIadeTarihi = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnIadeEt = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.btnPdfAl = new DevExpress.XtraEditors.SimpleButton();
            this.gcKitaplar = new DevExpress.XtraGrid.GridControl();
            this.gvKitaplar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExcelAl = new DevExpress.XtraEditors.SimpleButton();
            this.grpKitaplar = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textEditbarkod = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.seSayfaSayisi = new DevExpress.XtraEditors.SpinEdit();
            this.seStokKontrol = new DevExpress.XtraEditors.SpinEdit();
            this.txtISBN = new DevExpress.XtraEditors.TextEdit();
            this.cmbTur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbYazarAdi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtKitapAdi = new DevExpress.XtraEditors.TextEdit();
            this.lblStokKontrolu = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.lblKitapAdi = new System.Windows.Forms.Label();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.lblYazarAdi = new System.Windows.Forms.Label();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.lblSayfaSayisi = new System.Windows.Forms.Label();
            this.lblTur = new System.Windows.Forms.Label();
            this.tabcntrl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.tlpBagis = new System.Windows.Forms.TableLayoutPanel();
            this.btnOnayla = new DevExpress.XtraEditors.SimpleButton();
            this.grdBagisOnay = new DevExpress.XtraGrid.GridControl();
            this.gridViewBagisOnay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnOgrenciDetayinaGit = new DevExpress.XtraBars.BarButtonItem();
            this.btnKitapHareketleri = new DevExpress.XtraBars.BarButtonItem();
            this.btn = new DevExpress.XtraBars.BarButtonItem();
            this.btnMailGonder = new DevExpress.XtraBars.BarButtonItem();
            this.txtRedNedeni = new DevExpress.XtraEditors.TextEdit();
            this.btnReddet = new DevExpress.XtraEditors.SimpleButton();
            this.popupMenuEmanet = new DevExpress.XtraBars.PopupMenu(this.components);
            this.İstatistikler.SuspendLayout();
            this.tbl_pnlGrafik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartKitap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartYazar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tbl_pnlIstatistik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpUye)).BeginInit();
            this.grpUye.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonel)).BeginInit();
            this.grpPersonel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpKitap)).BeginInit();
            this.grpKitap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpBugun)).BeginInit();
            this.grpBugun.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmanetler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmanetler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_cntrlIslemler)).BeginInit();
            this.pnl_cntrlIslemler.SuspendLayout();
            this.tbl_lytIslemler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grp_cntrlOduncVer)).BeginInit();
            this.grp_cntrlOduncVer.SuspendLayout();
            this.tbl_lytOdunc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateAlisTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAlisTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOduncOgrenci.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOduncKitap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit3View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpcntrlIadeAl)).BeginInit();
            this.grpcntrlIadeAl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKitapDurumu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcGecikmeBedeli.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIadeTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIadeTarihi.Properties.CalendarTimeProperties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcKitaplar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKitaplar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpKitaplar)).BeginInit();
            this.grpKitaplar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditbarkod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seSayfaSayisi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStokKontrol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtISBN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYazarAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKitapAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabcntrl)).BeginInit();
            this.tabcntrl.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.tlpBagis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBagisOnay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBagisOnay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRedNedeni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuEmanet)).BeginInit();
            this.SuspendLayout();
            // 
            // İstatistikler
            // 
            this.İstatistikler.Controls.Add(this.tbl_pnlGrafik);
            this.İstatistikler.Controls.Add(this.panelControl2);
            this.İstatistikler.Name = "İstatistikler";
            this.İstatistikler.Size = new System.Drawing.Size(1274, 630);
            this.İstatistikler.Text = "İstatistikler";
            // 
            // tbl_pnlGrafik
            // 
            this.tbl_pnlGrafik.ColumnCount = 3;
            this.tbl_pnlGrafik.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbl_pnlGrafik.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbl_pnlGrafik.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbl_pnlGrafik.Controls.Add(this.chartKitap, 2, 0);
            this.tbl_pnlGrafik.Controls.Add(this.chartTur, 0, 0);
            this.tbl_pnlGrafik.Controls.Add(this.chartYazar, 1, 0);
            this.tbl_pnlGrafik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_pnlGrafik.Location = new System.Drawing.Point(0, 135);
            this.tbl_pnlGrafik.Name = "tbl_pnlGrafik";
            this.tbl_pnlGrafik.RowCount = 1;
            this.tbl_pnlGrafik.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_pnlGrafik.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 495F));
            this.tbl_pnlGrafik.Size = new System.Drawing.Size(1274, 495);
            this.tbl_pnlGrafik.TabIndex = 4;
            // 
            // chartKitap
            // 
            this.chartKitap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartKitap.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartKitap.Location = new System.Drawing.Point(851, 3);
            this.chartKitap.Name = "chartKitap";
            this.chartKitap.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartKitap.Size = new System.Drawing.Size(420, 489);
            this.chartKitap.TabIndex = 3;
            // 
            // chartTur
            // 
            this.chartTur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTur.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.chartTur.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartTur.Location = new System.Drawing.Point(3, 3);
            this.chartTur.Name = "chartTur";
            this.chartTur.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartTur.Size = new System.Drawing.Size(418, 489);
            this.chartTur.TabIndex = 0;
            // 
            // chartYazar
            // 
            this.chartYazar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartYazar.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartYazar.Location = new System.Drawing.Point(427, 3);
            this.chartYazar.Name = "chartYazar";
            this.chartYazar.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartYazar.Size = new System.Drawing.Size(418, 489);
            this.chartYazar.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tbl_pnlIstatistik);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1274, 135);
            this.panelControl2.TabIndex = 2;
            // 
            // tbl_pnlIstatistik
            // 
            this.tbl_pnlIstatistik.ColumnCount = 4;
            this.tbl_pnlIstatistik.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_pnlIstatistik.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_pnlIstatistik.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_pnlIstatistik.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_pnlIstatistik.Controls.Add(this.grpUye, 1, 0);
            this.tbl_pnlIstatistik.Controls.Add(this.grpPersonel, 3, 0);
            this.tbl_pnlIstatistik.Controls.Add(this.grpKitap, 0, 0);
            this.tbl_pnlIstatistik.Controls.Add(this.grpBugun, 2, 0);
            this.tbl_pnlIstatistik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_pnlIstatistik.Location = new System.Drawing.Point(2, 2);
            this.tbl_pnlIstatistik.Name = "tbl_pnlIstatistik";
            this.tbl_pnlIstatistik.RowCount = 1;
            this.tbl_pnlIstatistik.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_pnlIstatistik.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tbl_pnlIstatistik.Size = new System.Drawing.Size(1270, 131);
            this.tbl_pnlIstatistik.TabIndex = 0;
            // 
            // grpUye
            // 
            this.grpUye.Appearance.BackColor = System.Drawing.Color.Tomato;
            this.grpUye.Appearance.Options.UseBackColor = true;
            this.grpUye.AppearanceCaption.Options.UseBackColor = true;
            this.grpUye.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grpUye.Controls.Add(this.lblToplamUye);
            this.grpUye.Controls.Add(this.lblUyeTxt);
            this.grpUye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUye.Location = new System.Drawing.Point(320, 3);
            this.grpUye.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpUye.Name = "grpUye";
            this.grpUye.ShowCaption = false;
            this.grpUye.Size = new System.Drawing.Size(311, 125);
            this.grpUye.TabIndex = 1;
            this.grpUye.Text = "groupControl7";
            // 
            // lblToplamUye
            // 
            this.lblToplamUye.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblToplamUye.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamUye.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblToplamUye.Appearance.Options.UseFont = true;
            this.lblToplamUye.Appearance.Options.UseForeColor = true;
            this.lblToplamUye.Location = new System.Drawing.Point(151, 64);
            this.lblToplamUye.Name = "lblToplamUye";
            this.lblToplamUye.Size = new System.Drawing.Size(23, 54);
            this.lblToplamUye.TabIndex = 2;
            this.lblToplamUye.Text = "0";
            // 
            // lblUyeTxt
            // 
            this.lblUyeTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUyeTxt.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUyeTxt.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblUyeTxt.Appearance.Options.UseFont = true;
            this.lblUyeTxt.Appearance.Options.UseForeColor = true;
            this.lblUyeTxt.Location = new System.Drawing.Point(109, 23);
            this.lblUyeTxt.Name = "lblUyeTxt";
            this.lblUyeTxt.Size = new System.Drawing.Size(106, 23);
            this.lblUyeTxt.TabIndex = 1;
            this.lblUyeTxt.Text = "TOPLAM ÜYE";
            // 
            // grpPersonel
            // 
            this.grpPersonel.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.grpPersonel.Appearance.Options.UseBackColor = true;
            this.grpPersonel.AppearanceCaption.Options.UseBackColor = true;
            this.grpPersonel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grpPersonel.Controls.Add(this.lblToplamPersonel);
            this.grpPersonel.Controls.Add(this.lblPersonelTxt);
            this.grpPersonel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPersonel.Location = new System.Drawing.Point(954, 3);
            this.grpPersonel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpPersonel.Name = "grpPersonel";
            this.grpPersonel.ShowCaption = false;
            this.grpPersonel.Size = new System.Drawing.Size(313, 125);
            this.grpPersonel.TabIndex = 1;
            this.grpPersonel.Text = "groupControl9";
            // 
            // lblToplamPersonel
            // 
            this.lblToplamPersonel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblToplamPersonel.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamPersonel.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblToplamPersonel.Appearance.Options.UseFont = true;
            this.lblToplamPersonel.Appearance.Options.UseForeColor = true;
            this.lblToplamPersonel.Location = new System.Drawing.Point(148, 64);
            this.lblToplamPersonel.Name = "lblToplamPersonel";
            this.lblToplamPersonel.Size = new System.Drawing.Size(23, 54);
            this.lblToplamPersonel.TabIndex = 4;
            this.lblToplamPersonel.Text = "0";
            // 
            // lblPersonelTxt
            // 
            this.lblPersonelTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPersonelTxt.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPersonelTxt.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblPersonelTxt.Appearance.Options.UseFont = true;
            this.lblPersonelTxt.Appearance.Options.UseForeColor = true;
            this.lblPersonelTxt.Location = new System.Drawing.Point(84, 23);
            this.lblPersonelTxt.Name = "lblPersonelTxt";
            this.lblPersonelTxt.Size = new System.Drawing.Size(159, 23);
            this.lblPersonelTxt.TabIndex = 3;
            this.lblPersonelTxt.Text = "TOPLAM PERSONEL";
            // 
            // grpKitap
            // 
            this.grpKitap.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.grpKitap.Appearance.Options.UseBackColor = true;
            this.grpKitap.AppearanceCaption.Options.UseBackColor = true;
            this.grpKitap.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grpKitap.Controls.Add(this.lblToplamKitap);
            this.grpKitap.Controls.Add(this.lblKitapTxt);
            this.grpKitap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKitap.Location = new System.Drawing.Point(3, 3);
            this.grpKitap.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpKitap.Name = "grpKitap";
            this.grpKitap.ShowCaption = false;
            this.grpKitap.Size = new System.Drawing.Size(311, 125);
            this.grpKitap.TabIndex = 0;
            this.grpKitap.Text = "groupControl5";
            // 
            // lblToplamKitap
            // 
            this.lblToplamKitap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblToplamKitap.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamKitap.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblToplamKitap.Appearance.Options.UseFont = true;
            this.lblToplamKitap.Appearance.Options.UseForeColor = true;
            this.lblToplamKitap.Location = new System.Drawing.Point(144, 64);
            this.lblToplamKitap.Name = "lblToplamKitap";
            this.lblToplamKitap.Size = new System.Drawing.Size(23, 54);
            this.lblToplamKitap.TabIndex = 1;
            this.lblToplamKitap.Text = "0";
            // 
            // lblKitapTxt
            // 
            this.lblKitapTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKitapTxt.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKitapTxt.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblKitapTxt.Appearance.Options.UseFont = true;
            this.lblKitapTxt.Appearance.Options.UseForeColor = true;
            this.lblKitapTxt.Location = new System.Drawing.Point(97, 23);
            this.lblKitapTxt.Name = "lblKitapTxt";
            this.lblKitapTxt.Size = new System.Drawing.Size(123, 23);
            this.lblKitapTxt.TabIndex = 0;
            this.lblKitapTxt.Text = "TOPLAM KİTAP";
            // 
            // grpBugun
            // 
            this.grpBugun.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.grpBugun.Appearance.Options.UseBackColor = true;
            this.grpBugun.AppearanceCaption.Options.UseBackColor = true;
            this.grpBugun.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grpBugun.Controls.Add(this.lblBugunVerilen);
            this.grpBugun.Controls.Add(this.lblBugunTxt);
            this.grpBugun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBugun.Location = new System.Drawing.Point(637, 3);
            this.grpBugun.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpBugun.Name = "grpBugun";
            this.grpBugun.ShowCaption = false;
            this.grpBugun.Size = new System.Drawing.Size(311, 125);
            this.grpBugun.TabIndex = 1;
            this.grpBugun.Text = "groupControl8";
            // 
            // lblBugunVerilen
            // 
            this.lblBugunVerilen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBugunVerilen.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBugunVerilen.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBugunVerilen.Appearance.Options.UseFont = true;
            this.lblBugunVerilen.Appearance.Options.UseForeColor = true;
            this.lblBugunVerilen.Location = new System.Drawing.Point(150, 64);
            this.lblBugunVerilen.Name = "lblBugunVerilen";
            this.lblBugunVerilen.Size = new System.Drawing.Size(23, 54);
            this.lblBugunVerilen.TabIndex = 3;
            this.lblBugunVerilen.Text = "0";
            // 
            // lblBugunTxt
            // 
            this.lblBugunTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBugunTxt.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBugunTxt.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBugunTxt.Appearance.Options.UseFont = true;
            this.lblBugunTxt.Appearance.Options.UseForeColor = true;
            this.lblBugunTxt.Location = new System.Drawing.Point(94, 23);
            this.lblBugunTxt.Name = "lblBugunTxt";
            this.lblBugunTxt.Size = new System.Drawing.Size(132, 23);
            this.lblBugunTxt.TabIndex = 2;
            this.lblBugunTxt.Text = "BUGÜN VERİLEN";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcEmanetler);
            this.xtraTabPage2.Controls.Add(this.pnl_cntrlIslemler);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1274, 630);
            this.xtraTabPage2.Text = "Durum Yönetimi";
            // 
            // gcEmanetler
            // 
            this.gcEmanetler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEmanetler.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Teal;
            this.gcEmanetler.EmbeddedNavigator.Appearance.BorderColor = System.Drawing.Color.Teal;
            this.gcEmanetler.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.gcEmanetler.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gcEmanetler.EmbeddedNavigator.Appearance.Options.UseBorderColor = true;
            this.gcEmanetler.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gcEmanetler.Location = new System.Drawing.Point(0, 350);
            this.gcEmanetler.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcEmanetler.MainView = this.gvEmanetler;
            this.gcEmanetler.Name = "gcEmanetler";
            this.gcEmanetler.Size = new System.Drawing.Size(1274, 280);
            this.gcEmanetler.TabIndex = 8;
            this.gcEmanetler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEmanetler,
            this.gridView1});
            // 
            // gvEmanetler
            // 
            this.gvEmanetler.GridControl = this.gcEmanetler;
            this.gvEmanetler.Name = "gvEmanetler";
            this.gvEmanetler.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvEmanetler_RowStyle);
            this.gvEmanetler.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gvEmanetler_PopupMenuShowing);
            this.gvEmanetler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvEmanetler_FocusedRowChanged);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcEmanetler;
            this.gridView1.Name = "gridView1";
            // 
            // pnl_cntrlIslemler
            // 
            this.pnl_cntrlIslemler.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnl_cntrlIslemler.Controls.Add(this.tbl_lytIslemler);
            this.pnl_cntrlIslemler.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_cntrlIslemler.Location = new System.Drawing.Point(0, 0);
            this.pnl_cntrlIslemler.Name = "pnl_cntrlIslemler";
            this.pnl_cntrlIslemler.Size = new System.Drawing.Size(1274, 350);
            this.pnl_cntrlIslemler.TabIndex = 7;
            // 
            // tbl_lytIslemler
            // 
            this.tbl_lytIslemler.ColumnCount = 2;
            this.tbl_lytIslemler.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_lytIslemler.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_lytIslemler.Controls.Add(this.grp_cntrlOduncVer, 0, 0);
            this.tbl_lytIslemler.Controls.Add(this.grpcntrlIadeAl, 1, 0);
            this.tbl_lytIslemler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_lytIslemler.Location = new System.Drawing.Point(0, 0);
            this.tbl_lytIslemler.Name = "tbl_lytIslemler";
            this.tbl_lytIslemler.RowCount = 1;
            this.tbl_lytIslemler.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_lytIslemler.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tbl_lytIslemler.Size = new System.Drawing.Size(1274, 350);
            this.tbl_lytIslemler.TabIndex = 0;
            // 
            // grp_cntrlOduncVer
            // 
            this.grp_cntrlOduncVer.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grp_cntrlOduncVer.Appearance.Options.UseBackColor = true;
            this.grp_cntrlOduncVer.Appearance.Options.UseBorderColor = true;
            this.grp_cntrlOduncVer.Appearance.Options.UseForeColor = true;
            this.grp_cntrlOduncVer.AppearanceCaption.BackColor = System.Drawing.Color.Teal;
            this.grp_cntrlOduncVer.AppearanceCaption.BorderColor = System.Drawing.Color.Teal;
            this.grp_cntrlOduncVer.AppearanceCaption.ForeColor = System.Drawing.Color.Teal;
            this.grp_cntrlOduncVer.AppearanceCaption.Options.UseBackColor = true;
            this.grp_cntrlOduncVer.AppearanceCaption.Options.UseBorderColor = true;
            this.grp_cntrlOduncVer.AppearanceCaption.Options.UseForeColor = true;
            this.grp_cntrlOduncVer.Controls.Add(this.tbl_lytOdunc);
            this.grp_cntrlOduncVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_cntrlOduncVer.Location = new System.Drawing.Point(3, 3);
            this.grp_cntrlOduncVer.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grp_cntrlOduncVer.Name = "grp_cntrlOduncVer";
            this.grp_cntrlOduncVer.Size = new System.Drawing.Size(631, 344);
            this.grp_cntrlOduncVer.TabIndex = 4;
            this.grp_cntrlOduncVer.Text = "Ödünç Verme ";
            // 
            // tbl_lytOdunc
            // 
            this.tbl_lytOdunc.ColumnCount = 2;
            this.tbl_lytOdunc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tbl_lytOdunc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tbl_lytOdunc.Controls.Add(this.label7, 0, 2);
            this.tbl_lytOdunc.Controls.Add(this.btnOduncVer, 1, 3);
            this.tbl_lytOdunc.Controls.Add(this.label5, 0, 0);
            this.tbl_lytOdunc.Controls.Add(this.label6, 0, 1);
            this.tbl_lytOdunc.Controls.Add(this.dateAlisTarihi, 1, 2);
            this.tbl_lytOdunc.Controls.Add(this.lueOduncOgrenci, 1, 0);
            this.tbl_lytOdunc.Controls.Add(this.lueOduncKitap, 1, 1);
            this.tbl_lytOdunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_lytOdunc.Location = new System.Drawing.Point(2, 28);
            this.tbl_lytOdunc.Name = "tbl_lytOdunc";
            this.tbl_lytOdunc.RowCount = 4;
            this.tbl_lytOdunc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_lytOdunc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_lytOdunc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_lytOdunc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_lytOdunc.Size = new System.Drawing.Size(627, 314);
            this.tbl_lytOdunc.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Alınan Tarih";
            // 
            // btnOduncVer
            // 
            this.btnOduncVer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOduncVer.Location = new System.Drawing.Point(364, 256);
            this.btnOduncVer.Name = "btnOduncVer";
            this.btnOduncVer.Size = new System.Drawing.Size(118, 36);
            this.btnOduncVer.TabIndex = 8;
            this.btnOduncVer.Text = "Ödünç Ver";
            this.btnOduncVer.Click += new System.EventHandler(this.btnOduncVer_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ödünç Alan Öğrenci";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ödünç Alınan Kitap";
            // 
            // dateAlisTarihi
            // 
            this.dateAlisTarihi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateAlisTarihi.EditValue = null;
            this.dateAlisTarihi.Location = new System.Drawing.Point(335, 184);
            this.dateAlisTarihi.Name = "dateAlisTarihi";
            this.dateAlisTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAlisTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAlisTarihi.Size = new System.Drawing.Size(175, 22);
            this.dateAlisTarihi.TabIndex = 9;
            // 
            // lueOduncOgrenci
            // 
            this.lueOduncOgrenci.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lueOduncOgrenci.Location = new System.Drawing.Point(335, 28);
            this.lueOduncOgrenci.Name = "lueOduncOgrenci";
            this.lueOduncOgrenci.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOduncOgrenci.Properties.NullText = "";
            this.lueOduncOgrenci.Properties.PopupView = this.gridLookUpEdit2View;
            this.lueOduncOgrenci.Size = new System.Drawing.Size(175, 22);
            this.lueOduncOgrenci.TabIndex = 6;
            // 
            // gridLookUpEdit2View
            // 
            this.gridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit2View.Name = "gridLookUpEdit2View";
            this.gridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // lueOduncKitap
            // 
            this.lueOduncKitap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lueOduncKitap.Location = new System.Drawing.Point(335, 106);
            this.lueOduncKitap.Name = "lueOduncKitap";
            this.lueOduncKitap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOduncKitap.Properties.NullText = "";
            this.lueOduncKitap.Properties.PopupView = this.gridLookUpEdit3View;
            this.lueOduncKitap.Size = new System.Drawing.Size(175, 22);
            this.lueOduncKitap.TabIndex = 7;
            // 
            // gridLookUpEdit3View
            // 
            this.gridLookUpEdit3View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit3View.Name = "gridLookUpEdit3View";
            this.gridLookUpEdit3View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit3View.OptionsView.ShowGroupPanel = false;
            // 
            // grpcntrlIadeAl
            // 
            this.grpcntrlIadeAl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpcntrlIadeAl.Appearance.Options.UseBackColor = true;
            this.grpcntrlIadeAl.AppearanceCaption.BorderColor = System.Drawing.Color.Teal;
            this.grpcntrlIadeAl.AppearanceCaption.ForeColor = System.Drawing.Color.Teal;
            this.grpcntrlIadeAl.AppearanceCaption.Options.UseBorderColor = true;
            this.grpcntrlIadeAl.AppearanceCaption.Options.UseForeColor = true;
            this.grpcntrlIadeAl.Controls.Add(this.cmbKitapDurumu);
            this.grpcntrlIadeAl.Controls.Add(this.calcGecikmeBedeli);
            this.grpcntrlIadeAl.Controls.Add(this.dateIadeTarihi);
            this.grpcntrlIadeAl.Controls.Add(this.label1);
            this.grpcntrlIadeAl.Controls.Add(this.label11);
            this.grpcntrlIadeAl.Controls.Add(this.label8);
            this.grpcntrlIadeAl.Controls.Add(this.btnIadeEt);
            this.grpcntrlIadeAl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpcntrlIadeAl.Location = new System.Drawing.Point(640, 3);
            this.grpcntrlIadeAl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpcntrlIadeAl.Name = "grpcntrlIadeAl";
            this.grpcntrlIadeAl.Size = new System.Drawing.Size(631, 344);
            this.grpcntrlIadeAl.TabIndex = 4;
            this.grpcntrlIadeAl.Text = "İade Alma";
            // 
            // cmbKitapDurumu
            // 
            this.cmbKitapDurumu.EditValue = "Sağlam";
            this.cmbKitapDurumu.Location = new System.Drawing.Point(197, 100);
            this.cmbKitapDurumu.Name = "cmbKitapDurumu";
            this.cmbKitapDurumu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKitapDurumu.Properties.Items.AddRange(new object[] {
            "Sağlam",
            "Hafif Yıpranmış",
            "Ağır Hasarlı",
            "Sayfa Eksik",
            "Kayıp / Pert"});
            this.cmbKitapDurumu.Size = new System.Drawing.Size(156, 22);
            this.cmbKitapDurumu.TabIndex = 14;
            // 
            // calcGecikmeBedeli
            // 
            this.calcGecikmeBedeli.Location = new System.Drawing.Point(197, 150);
            this.calcGecikmeBedeli.Name = "calcGecikmeBedeli";
            this.calcGecikmeBedeli.Properties.Appearance.Options.UseTextOptions = true;
            this.calcGecikmeBedeli.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.calcGecikmeBedeli.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcGecikmeBedeli.Properties.MaskSettings.Set("mask", "c");
            this.calcGecikmeBedeli.Properties.UseMaskAsDisplayFormat = true;
            this.calcGecikmeBedeli.Size = new System.Drawing.Size(156, 22);
            this.calcGecikmeBedeli.TabIndex = 13;
            // 
            // dateIadeTarihi
            // 
            this.dateIadeTarihi.EditValue = null;
            this.dateIadeTarihi.Location = new System.Drawing.Point(197, 52);
            this.dateIadeTarihi.Name = "dateIadeTarihi";
            this.dateIadeTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIadeTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIadeTarihi.Size = new System.Drawing.Size(156, 22);
            this.dateIadeTarihi.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kitap Durumu";
            
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "İade Tarihi";
           
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Gecikme Bedeliniz :";
            // 
            // btnIadeEt
            // 
            this.btnIadeEt.Location = new System.Drawing.Point(214, 205);
            this.btnIadeEt.Name = "btnIadeEt";
            this.btnIadeEt.Size = new System.Drawing.Size(118, 36);
            this.btnIadeEt.TabIndex = 10;
            this.btnIadeEt.Text = "İade Et";
            this.btnIadeEt.Click += new System.EventHandler(this.btnIadeEt_Click);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl4);
            this.xtraTabPage1.Controls.Add(this.grpKitaplar);
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1274, 630);
            this.xtraTabPage1.Text = "Kitap Yönetimi";
            // 
            // groupControl4
            // 
            this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl4.Appearance.Options.UseBackColor = true;
            this.groupControl4.Appearance.Options.UseBorderColor = true;
            this.groupControl4.Appearance.Options.UseFont = true;
            this.groupControl4.AppearanceCaption.BorderColor = System.Drawing.Color.Teal;
            this.groupControl4.AppearanceCaption.Options.UseBorderColor = true;
            this.groupControl4.Controls.Add(this.btnPdfAl);
            this.groupControl4.Controls.Add(this.gcKitaplar);
            this.groupControl4.Controls.Add(this.btnExcelAl);
            this.groupControl4.Location = new System.Drawing.Point(467, 120);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(807, 477);
            this.groupControl4.TabIndex = 18;
            this.groupControl4.Text = "Kitap Listesi";
            // 
            // btnPdfAl
            // 
            this.btnPdfAl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPdfAl.ImageOptions.SvgImage = global::KutuphaneOtomasyonu.Properties.Resources.documentpdf;
            this.btnPdfAl.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnPdfAl.Location = new System.Drawing.Point(723, 0);
            this.btnPdfAl.Name = "btnPdfAl";
            this.btnPdfAl.Size = new System.Drawing.Size(85, 25);
            this.btnPdfAl.TabIndex = 2;
            this.btnPdfAl.Text = "Pdf";
            this.btnPdfAl.Click += new System.EventHandler(this.btnPdfAl_Click);
            // 
            // gcKitaplar
            // 
            this.gcKitaplar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcKitaplar.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.CadetBlue;
            this.gcKitaplar.EmbeddedNavigator.Appearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.gcKitaplar.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.CadetBlue;
            this.gcKitaplar.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gcKitaplar.EmbeddedNavigator.Appearance.Options.UseBorderColor = true;
            this.gcKitaplar.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gcKitaplar.Location = new System.Drawing.Point(2, 28);
            this.gcKitaplar.MainView = this.gvKitaplar;
            this.gcKitaplar.Name = "gcKitaplar";
            this.gcKitaplar.Size = new System.Drawing.Size(803, 447);
            this.gcKitaplar.TabIndex = 0;
            this.gcKitaplar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvKitaplar,
            this.gridView2});
            // 
            // gvKitaplar
            // 
            this.gvKitaplar.GridControl = this.gcKitaplar;
            this.gvKitaplar.Name = "gvKitaplar";
            this.gvKitaplar.OptionsBehavior.Editable = false;
            this.gvKitaplar.OptionsFind.AlwaysVisible = true;
            this.gvKitaplar.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gvKitaplar.OptionsFind.FindNullPrompt = "Aramak için bir şeyler yazın..";
            this.gvKitaplar.OptionsFind.ShowFindButton = false;
            this.gvKitaplar.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gvKitaplar.OptionsView.ShowGroupPanel = false;
            this.gvKitaplar.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gcKitaplar;
            this.gridView2.Name = "gridView2";
            // 
            // btnExcelAl
            // 
            this.btnExcelAl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelAl.ImageOptions.SvgImage = global::KutuphaneOtomasyonu.Properties.Resources.exporttoxlsx;
            this.btnExcelAl.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnExcelAl.Location = new System.Drawing.Point(584, 0);
            this.btnExcelAl.Name = "btnExcelAl";
            this.btnExcelAl.Size = new System.Drawing.Size(85, 25);
            this.btnExcelAl.TabIndex = 2;
            this.btnExcelAl.Text = "Excel";
            this.btnExcelAl.Click += new System.EventHandler(this.btnExcelAl_Click);
            // 
            // grpKitaplar
            // 
            this.grpKitaplar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKitaplar.AppearanceCaption.BorderColor = System.Drawing.Color.Teal;
            this.grpKitaplar.AppearanceCaption.Options.UseBorderColor = true;
            this.grpKitaplar.Controls.Add(this.panelControl1);
            this.grpKitaplar.Location = new System.Drawing.Point(467, 0);
            this.grpKitaplar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpKitaplar.Name = "grpKitaplar";
            this.grpKitaplar.Size = new System.Drawing.Size(807, 87);
            this.grpKitaplar.TabIndex = 1;
            this.grpKitaplar.Text = "Barkod Sorgula";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Teal;
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.Teal;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.Appearance.Options.UseForeColor = true;
            this.panelControl1.Controls.Add(this.textEditbarkod);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 28);
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(803, 57);
            this.panelControl1.TabIndex = 1;
            // 
            // textEditbarkod
            // 
            this.textEditbarkod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditbarkod.Location = new System.Drawing.Point(171, 22);
            this.textEditbarkod.Name = "textEditbarkod";
            this.textEditbarkod.Properties.AutoHeight = false;
            this.textEditbarkod.Size = new System.Drawing.Size(607, 27);
            this.textEditbarkod.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(40, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(125, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Barkod Numarası : ";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.Appearance.Options.UseForeColor = true;
            this.groupControl1.AppearanceCaption.BorderColor = System.Drawing.Color.Teal;
            this.groupControl1.AppearanceCaption.Options.UseBorderColor = true;
            this.groupControl1.Controls.Add(this.seSayfaSayisi);
            this.groupControl1.Controls.Add(this.seStokKontrol);
            this.groupControl1.Controls.Add(this.txtISBN);
            this.groupControl1.Controls.Add(this.cmbTur);
            this.groupControl1.Controls.Add(this.cmbYazarAdi);
            this.groupControl1.Controls.Add(this.txtKitapAdi);
            this.groupControl1.Controls.Add(this.lblStokKontrolu);
            this.groupControl1.Controls.Add(this.lblISBN);
            this.groupControl1.Controls.Add(this.btnGuncelle);
            this.groupControl1.Controls.Add(this.lblKitapAdi);
            this.groupControl1.Controls.Add(this.btnEkle);
            this.groupControl1.Controls.Add(this.lblYazarAdi);
            this.groupControl1.Controls.Add(this.btnSil);
            this.groupControl1.Controls.Add(this.lblSayfaSayisi);
            this.groupControl1.Controls.Add(this.lblTur);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(467, 630);
            this.groupControl1.TabIndex = 17;
            this.groupControl1.Text = "Kitap İşlemleri";
            // 
            // seSayfaSayisi
            // 
            this.seSayfaSayisi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seSayfaSayisi.Location = new System.Drawing.Point(176, 260);
            this.seSayfaSayisi.Name = "seSayfaSayisi";
            this.seSayfaSayisi.Properties.Appearance.Options.UseTextOptions = true;
            this.seSayfaSayisi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.seSayfaSayisi.Properties.AutoHeight = false;
            this.seSayfaSayisi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seSayfaSayisi.Properties.IsFloatValue = false;
            this.seSayfaSayisi.Properties.MaskSettings.Set("mask", "N00");
            this.seSayfaSayisi.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.seSayfaSayisi.Size = new System.Drawing.Size(192, 25);
            this.seSayfaSayisi.TabIndex = 26;
            // 
            // seStokKontrol
            // 
            this.seStokKontrol.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seStokKontrol.Location = new System.Drawing.Point(176, 449);
            this.seStokKontrol.Name = "seStokKontrol";
            this.seStokKontrol.Properties.Appearance.Options.UseTextOptions = true;
            this.seStokKontrol.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.seStokKontrol.Properties.AutoHeight = false;
            this.seStokKontrol.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seStokKontrol.Properties.IsFloatValue = false;
            this.seStokKontrol.Properties.MaskSettings.Set("mask", "N00");
            this.seStokKontrol.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.seStokKontrol.Size = new System.Drawing.Size(192, 25);
            this.seStokKontrol.TabIndex = 25;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(176, 386);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Properties.AutoHeight = false;
            this.txtISBN.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtISBN.Properties.MaskSettings.Set("mask", "000-000-00-0000-0");
            this.txtISBN.Properties.UseMaskAsDisplayFormat = true;
            this.txtISBN.Size = new System.Drawing.Size(192, 25);
            this.txtISBN.TabIndex = 24;
            // 
            // cmbTur
            // 
            this.cmbTur.Location = new System.Drawing.Point(176, 323);
            this.cmbTur.Name = "cmbTur";
            this.cmbTur.Properties.AutoHeight = false;
            this.cmbTur.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTur.Size = new System.Drawing.Size(192, 25);
            this.cmbTur.TabIndex = 23;
            // 
            // cmbYazarAdi
            // 
            this.cmbYazarAdi.Location = new System.Drawing.Point(176, 197);
            this.cmbYazarAdi.Name = "cmbYazarAdi";
            this.cmbYazarAdi.Properties.AutoHeight = false;
            this.cmbYazarAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbYazarAdi.Size = new System.Drawing.Size(192, 25);
            this.cmbYazarAdi.TabIndex = 22;
            // 
            // txtKitapAdi
            // 
            this.txtKitapAdi.Location = new System.Drawing.Point(176, 133);
            this.txtKitapAdi.Name = "txtKitapAdi";
            this.txtKitapAdi.Properties.AutoHeight = false;
            this.txtKitapAdi.Size = new System.Drawing.Size(192, 26);
            this.txtKitapAdi.TabIndex = 21;
            // 
            // lblStokKontrolu
            // 
            this.lblStokKontrolu.AutoSize = true;
            this.lblStokKontrolu.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblStokKontrolu.Location = new System.Drawing.Point(34, 452);
            this.lblStokKontrolu.Name = "lblStokKontrolu";
            this.lblStokKontrolu.Size = new System.Drawing.Size(114, 22);
            this.lblStokKontrolu.TabIndex = 20;
            this.lblStokKontrolu.Text = "Stok Kontrolü";
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblISBN.Location = new System.Drawing.Point(34, 384);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(46, 22);
            this.lblISBN.TabIndex = 19;
            this.lblISBN.Text = "ISBN";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuncelle.ImageOptions.Image")));
            this.btnGuncelle.Location = new System.Drawing.Point(338, 528);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(98, 42);
            this.btnGuncelle.TabIndex = 16;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.simpleButtonGuncelle_Click);
            // 
            // lblKitapAdi
            // 
            this.lblKitapAdi.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblKitapAdi.Location = new System.Drawing.Point(34, 133);
            this.lblKitapAdi.Name = "lblKitapAdi";
            this.lblKitapAdi.Size = new System.Drawing.Size(78, 26);
            this.lblKitapAdi.TabIndex = 1;
            this.lblKitapAdi.Text = "Kitap Adı";
            // 
            // btnEkle
            // 
            this.btnEkle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEkle.ImageOptions.Image")));
            this.btnEkle.Location = new System.Drawing.Point(36, 528);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(98, 42);
            this.btnEkle.TabIndex = 15;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.simpleButtonEkle_Click);
            // 
            // lblYazarAdi
            // 
            this.lblYazarAdi.AutoSize = true;
            this.lblYazarAdi.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblYazarAdi.Location = new System.Drawing.Point(34, 202);
            this.lblYazarAdi.Name = "lblYazarAdi";
            this.lblYazarAdi.Size = new System.Drawing.Size(78, 22);
            this.lblYazarAdi.TabIndex = 2;
            this.lblYazarAdi.Text = "Yazar Adı";
            // 
            // btnSil
            // 
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.Image")));
            this.btnSil.Location = new System.Drawing.Point(187, 528);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(98, 42);
            this.btnSil.TabIndex = 14;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.simpleButtonSil_Click);
            // 
            // lblSayfaSayisi
            // 
            this.lblSayfaSayisi.AutoSize = true;
            this.lblSayfaSayisi.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblSayfaSayisi.Location = new System.Drawing.Point(34, 266);
            this.lblSayfaSayisi.Name = "lblSayfaSayisi";
            this.lblSayfaSayisi.Size = new System.Drawing.Size(98, 22);
            this.lblSayfaSayisi.TabIndex = 3;
            this.lblSayfaSayisi.Text = "Sayfa Sayısı";
            // 
            // lblTur
            // 
            this.lblTur.AutoSize = true;
            this.lblTur.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblTur.Location = new System.Drawing.Point(34, 331);
            this.lblTur.Name = "lblTur";
            this.lblTur.Size = new System.Drawing.Size(34, 22);
            this.lblTur.TabIndex = 4;
            this.lblTur.Text = "Tür";
            // 
            // tabcntrl
            // 
            this.tabcntrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcntrl.Location = new System.Drawing.Point(0, 0);
            this.tabcntrl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabcntrl.Name = "tabcntrl";
            this.tabcntrl.SelectedTabPage = this.xtraTabPage2;
            this.tabcntrl.Size = new System.Drawing.Size(1276, 660);
            this.tabcntrl.TabIndex = 1;
            this.tabcntrl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.İstatistikler,
            this.xtraTabPage3});
            this.tabcntrl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabcntrl_SelectedPageChanged);
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.tlpBagis);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(1274, 630);
            this.xtraTabPage3.Text = "Bağış İşlemleri";
            // 
            // tlpBagis
            // 
            this.tlpBagis.ColumnCount = 2;
            this.tlpBagis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tlpBagis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBagis.Controls.Add(this.btnOnayla, 0, 0);
            this.tlpBagis.Controls.Add(this.grdBagisOnay, 1, 0);
            this.tlpBagis.Controls.Add(this.txtRedNedeni, 0, 2);
            this.tlpBagis.Controls.Add(this.btnReddet, 0, 1);
            this.tlpBagis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBagis.Location = new System.Drawing.Point(0, 0);
            this.tlpBagis.Name = "tlpBagis";
            this.tlpBagis.RowCount = 3;
            this.tlpBagis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBagis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBagis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpBagis.Size = new System.Drawing.Size(1274, 630);
            this.tlpBagis.TabIndex = 3;
            // 
            // btnOnayla
            // 
            this.btnOnayla.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOnayla.Appearance.Options.UseFont = true;
            this.btnOnayla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOnayla.Location = new System.Drawing.Point(3, 3);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(374, 264);
            this.btnOnayla.TabIndex = 1;
            this.btnOnayla.Text = "BAĞIŞI ONAYLA";
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // 
            // grdBagisOnay
            // 
            this.grdBagisOnay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBagisOnay.Location = new System.Drawing.Point(383, 3);
            this.grdBagisOnay.MainView = this.gridViewBagisOnay;
            this.grdBagisOnay.MenuManager = this.barManager1;
            this.grdBagisOnay.Name = "grdBagisOnay";
            this.tlpBagis.SetRowSpan(this.grdBagisOnay, 3);
            this.grdBagisOnay.Size = new System.Drawing.Size(888, 624);
            this.grdBagisOnay.TabIndex = 0;
            this.grdBagisOnay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBagisOnay});
            // 
            // gridViewBagisOnay
            // 
            this.gridViewBagisOnay.GridControl = this.grdBagisOnay;
            this.gridViewBagisOnay.Name = "gridViewBagisOnay";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnOgrenciDetayinaGit,
            this.btnKitapHareketleri,
            this.btn,
            this.btnMailGonder});
            this.barManager1.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1276, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 660);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1276, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 660);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1276, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 660);
            // 
            // btnOgrenciDetayinaGit
            // 
            this.btnOgrenciDetayinaGit.Caption = "Öğrenci Detayına Git";
            this.btnOgrenciDetayinaGit.Id = 0;
            this.btnOgrenciDetayinaGit.ImageOptions.SvgImage = global::KutuphaneOtomasyonu.Properties.Resources.mr;
            this.btnOgrenciDetayinaGit.Name = "btnOgrenciDetayinaGit";
            
            // 
            // btnKitapHareketleri
            // 
            this.btnKitapHareketleri.Caption = "Kitap Hareketleri";
            this.btnKitapHareketleri.Id = 1;
            this.btnKitapHareketleri.ImageOptions.Image = global::KutuphaneOtomasyonu.Properties.Resources.logical_16x16;
            this.btnKitapHareketleri.ImageOptions.LargeImage = global::KutuphaneOtomasyonu.Properties.Resources.logical_32x32;
            this.btnKitapHareketleri.Name = "btnKitapHareketleri";
            // 
            // btn
            // 
            this.btn.Caption = "barButtonItem1";
            this.btn.Id = 2;
            this.btn.Name = "btn";
            // 
            // btnMailGonder
            // 
            this.btnMailGonder.Caption = "Mail Gönder";
            this.btnMailGonder.Id = 3;
            this.btnMailGonder.ImageOptions.SvgImage = global::KutuphaneOtomasyonu.Properties.Resources.outlookexport;
            this.btnMailGonder.Name = "btnMailGonder";
            // 
            // txtRedNedeni
            // 
            this.txtRedNedeni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRedNedeni.Location = new System.Drawing.Point(3, 543);
            this.txtRedNedeni.MenuManager = this.barManager1;
            this.txtRedNedeni.Name = "txtRedNedeni";
            this.txtRedNedeni.Properties.AutoHeight = false;
            this.txtRedNedeni.Properties.NullText = "Red Sebebi";
            this.txtRedNedeni.Size = new System.Drawing.Size(374, 84);
            this.txtRedNedeni.TabIndex = 2;
            // 
            // btnReddet
            // 
            this.btnReddet.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReddet.Appearance.Options.UseFont = true;
            this.btnReddet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReddet.Location = new System.Drawing.Point(3, 273);
            this.btnReddet.Name = "btnReddet";
            this.btnReddet.Size = new System.Drawing.Size(374, 264);
            this.btnReddet.TabIndex = 1;
            this.btnReddet.Text = "BAĞIŞI REDDET";
            this.btnReddet.Click += new System.EventHandler(this.btnReddet_Click);
            // 
            // popupMenuEmanet
            // 
            this.popupMenuEmanet.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOgrenciDetayinaGit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnKitapHareketleri),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMailGonder)});
            this.popupMenuEmanet.Manager = this.barManager1;
            this.popupMenuEmanet.Name = "popupMenuEmanet";
            // 
            // FrmAnaSayfaPersonel
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1276, 660);
            this.Controls.Add(this.tabcntrl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmAnaSayfaPersonel";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FrmAnaSayfaPersonel_Shown);
            this.İstatistikler.ResumeLayout(false);
            this.tbl_pnlGrafik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartKitap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartYazar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tbl_pnlIstatistik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpUye)).EndInit();
            this.grpUye.ResumeLayout(false);
            this.grpUye.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonel)).EndInit();
            this.grpPersonel.ResumeLayout(false);
            this.grpPersonel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpKitap)).EndInit();
            this.grpKitap.ResumeLayout(false);
            this.grpKitap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpBugun)).EndInit();
            this.grpBugun.ResumeLayout(false);
            this.grpBugun.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEmanetler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmanetler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_cntrlIslemler)).EndInit();
            this.pnl_cntrlIslemler.ResumeLayout(false);
            this.tbl_lytIslemler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grp_cntrlOduncVer)).EndInit();
            this.grp_cntrlOduncVer.ResumeLayout(false);
            this.tbl_lytOdunc.ResumeLayout(false);
            this.tbl_lytOdunc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateAlisTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAlisTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOduncOgrenci.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOduncKitap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit3View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpcntrlIadeAl)).EndInit();
            this.grpcntrlIadeAl.ResumeLayout(false);
            this.grpcntrlIadeAl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKitapDurumu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcGecikmeBedeli.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIadeTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIadeTarihi.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcKitaplar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKitaplar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpKitaplar)).EndInit();
            this.grpKitaplar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditbarkod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seSayfaSayisi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStokKontrol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtISBN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYazarAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKitapAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabcntrl)).EndInit();
            this.tabcntrl.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.tlpBagis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBagisOnay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBagisOnay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRedNedeni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuEmanet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private XtraTabControl tabcntrl;
        private XtraTabPage xtraTabPage2;
        private GridControl gcEmanetler;
        private GridView gvEmanetler;
        private PanelControl pnl_cntrlIslemler;
        private TableLayoutPanel tbl_lytIslemler;
        private GroupControl grp_cntrlOduncVer;
        private TableLayoutPanel tbl_lytOdunc;
        private Label label7;
        private SimpleButton btnOduncVer;
        private Label label5;
        private Label label6;
        private DateEdit dateAlisTarihi;
        private GridLookUpEdit lueOduncOgrenci;
        private GridView gridLookUpEdit2View;
        private GridLookUpEdit lueOduncKitap;
        private GridView gridLookUpEdit3View;
        private GroupControl grpcntrlIadeAl;
        private ComboBoxEdit cmbKitapDurumu;
        private CalcEdit calcGecikmeBedeli;
        private DateEdit dateIadeTarihi;
        private Label label1;
        private Label label11;
        private Label label8;
        private SimpleButton btnIadeEt;
        private XtraTabPage xtraTabPage1;
        private GroupControl groupControl4;
        private SimpleButton btnPdfAl;
        private GridControl gcKitaplar;
        private GridView gvKitaplar;
        private SimpleButton btnExcelAl;
        private GroupControl grpKitaplar;
        private PanelControl panelControl1;
        private TextEdit textEditbarkod;
        private LabelControl labelControl1;
        private GroupControl groupControl1;
        private SpinEdit seSayfaSayisi;
        private SpinEdit seStokKontrol;
        private TextEdit txtISBN;
        private ComboBoxEdit cmbTur;
        private ComboBoxEdit cmbYazarAdi;
        private TextEdit txtKitapAdi;
        private Label lblStokKontrolu;
        private Label lblISBN;
        private SimpleButton btnGuncelle;
        private Label lblKitapAdi;
        private SimpleButton btnEkle;
        private Label lblYazarAdi;
        private SimpleButton btnSil;
        private Label lblSayfaSayisi;
        private Label lblTur;
        private XtraTabPage İstatistikler;
        private TableLayoutPanel tbl_pnlGrafik;
        private DevExpress.XtraCharts.ChartControl chartKitap;
        private DevExpress.XtraCharts.ChartControl chartTur;
        private DevExpress.XtraCharts.ChartControl chartYazar;
        private PanelControl panelControl2;
        private TableLayoutPanel tbl_pnlIstatistik;
        private GroupControl grpUye;
        private LabelControl lblToplamUye;
        private LabelControl lblUyeTxt;
        private GroupControl grpPersonel;
        private LabelControl lblToplamPersonel;
        private LabelControl lblPersonelTxt;
        private GroupControl grpKitap;
        private LabelControl lblToplamKitap;
        private LabelControl lblKitapTxt;
        private GroupControl grpBugun;
        private LabelControl lblBugunVerilen;
        private LabelControl lblBugunTxt;
        private GridView gridView1;
        private GridView gridView2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu popupMenuEmanet;
        private DevExpress.XtraBars.BarButtonItem btnOgrenciDetayinaGit;
        private DevExpress.XtraBars.BarButtonItem btnKitapHareketleri;
        private DevExpress.XtraBars.BarButtonItem btn;
        private DevExpress.XtraBars.BarButtonItem btnMailGonder;
        private XtraTabPage xtraTabPage3;
        private TextEdit txtRedNedeni;
        private SimpleButton btnReddet;
        private SimpleButton btnOnayla;
        private GridControl grdBagisOnay;
        private GridView gridViewBagisOnay;
        private TableLayoutPanel tlpBagis;
    }
}