using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using KutuphaneOtomasyonu.Kutuphane.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    public partial class FrmAnaSayfaPersonel : XtraForm
    {
        private SKitap _kitapService = new SKitap();
        private SOgrenci _ogrenciService = new SOgrenci();
        private readonly SBagis _bagisService = new SBagis();
        private bool _bagisUIHazir = false;

        public FrmAnaSayfaPersonel()
        {
            InitializeComponent();

            // Form kapandığında Giriş formuna dönmek için olayı bağlıyoruz
            this.FormClosed += FrmAnaSayfaPersonel_FormClosed;

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            Shown -= FrmAnaSayfaPersonel_Shown;
            Shown += FrmAnaSayfaPersonel_Shown;

            if (tabcntrl != null)
            {
                tabcntrl.SelectedPageChanged -= tabcntrl_SelectedPageChanged;
                tabcntrl.SelectedPageChanged += tabcntrl_SelectedPageChanged;

                if (tabcntrl.TabPages.Count > 0)
                    tabcntrl.SelectedTabPage = xtraTabPage1;
            }

            try
            {
                btnOnayla.Click -= btnOnayla_Click;
                btnOnayla.Click += btnOnayla_Click;

                btnReddet.Click -= btnReddet_Click;
                btnReddet.Click += btnReddet_Click;
            }
            catch { }
        }

        // --- YENİ EKLENEN KAPATMA OLAYI ---
        private void FrmAnaSayfaPersonel_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Bu form kapandığında FrmGiris formunu bul ve göster, yoksa yeni oluştur.
            Form frm = Application.OpenForms["FrmGiris"];
            if (frm != null)
            {
                frm.Show();
            }
            else
            {
                FrmGiris yeniGiris = new FrmGiris();
                yeniGiris.Show();
            }
        }

        private void BagisSayfasiHazirla()
        {
            if (_bagisUIHazir) return;
            _bagisUIHazir = true;

            try { grdBagisOnay.Dock = DockStyle.Fill; } catch { }

            try
            {
                gridViewBagisOnay.OptionsView.ShowGroupPanel = false;
                gridViewBagisOnay.OptionsView.ColumnAutoWidth = false;
                gridViewBagisOnay.RowHeight = 28;

                gridViewBagisOnay.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                gridViewBagisOnay.Appearance.Row.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            }
            catch { }

            try
            {
                btnOnayla.Text = "BAĞIŞI ONAYLA";
                btnOnayla.Height = 60;
                btnOnayla.Appearance.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
                btnOnayla.Appearance.ForeColor = Color.White;
                btnOnayla.Appearance.BackColor = Color.FromArgb(46, 204, 113);
                btnOnayla.Appearance.BackColor2 = Color.FromArgb(39, 174, 96);
                btnOnayla.Appearance.Options.UseBackColor = true;
                btnOnayla.Appearance.Options.UseForeColor = true;
                btnOnayla.Appearance.Options.UseFont = true;
                btnOnayla.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

                btnReddet.Text = "BAĞIŞI REDDET";
                btnReddet.Height = 60;
                btnReddet.Appearance.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
                btnReddet.Appearance.ForeColor = Color.White;
                btnReddet.Appearance.BackColor = Color.FromArgb(231, 76, 60);
                btnReddet.Appearance.BackColor2 = Color.FromArgb(192, 57, 43);
                btnReddet.Appearance.Options.UseBackColor = true;
                btnReddet.Appearance.Options.UseForeColor = true;
                btnReddet.Appearance.Options.UseFont = true;
                btnReddet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
            catch { }

            try
            {
                txtRedNedeni.Properties.NullValuePrompt = "Red sebebi (opsiyonel)";
                txtRedNedeni.Properties.ShowNullValuePromptWhenFocused = true;
                txtRedNedeni.Properties.Appearance.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                txtRedNedeni.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            }
            catch { }
        }

        private void BagislariYukle()
        {
            try
            {
                DataTable dt = _bagisService.BekleyenBagislariListele();
                grdBagisOnay.DataSource = dt;
                gridViewBagisOnay.PopulateColumns();

                if (gridViewBagisOnay.Columns["IDBagis"] != null) gridViewBagisOnay.Columns["IDBagis"].Visible = false;
                if (gridViewBagisOnay.Columns["IDOgrenci"] != null) gridViewBagisOnay.Columns["IDOgrenci"].Visible = false;

                if (gridViewBagisOnay.Columns["KullaniciAdi"] != null)
                {
                    gridViewBagisOnay.Columns["KullaniciAdi"].Caption = "Öğrenci";
                    gridViewBagisOnay.Columns["KullaniciAdi"].Width = 160;
                }

                if (gridViewBagisOnay.Columns["KitapAdi"] != null)
                {
                    gridViewBagisOnay.Columns["KitapAdi"].Caption = "Kitap Adı";
                    gridViewBagisOnay.Columns["KitapAdi"].Width = 260;
                }

                if (gridViewBagisOnay.Columns["YazarAdi"] != null)
                {
                    gridViewBagisOnay.Columns["YazarAdi"].Caption = "Yazar";
                    gridViewBagisOnay.Columns["YazarAdi"].Width = 180;
                }

                if (gridViewBagisOnay.Columns["ISBN"] != null)
                {
                    gridViewBagisOnay.Columns["ISBN"].Caption = "ISBN";
                    gridViewBagisOnay.Columns["ISBN"].Width = 150;
                }

                if (gridViewBagisOnay.Columns["KayitTarihi"] != null)
                {
                    gridViewBagisOnay.Columns["KayitTarihi"].Caption = "Talep Tarihi";
                    gridViewBagisOnay.Columns["KayitTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    gridViewBagisOnay.Columns["KayitTarihi"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
                    gridViewBagisOnay.Columns["KayitTarihi"].Width = 160;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Bağışlar yüklenemedi: " + ex.Message, "Hata");
            }
        }

        void Temizle()
        {
            try { txtKitapAdi.Text = ""; } catch { }
            try { txtISBN.Text = ""; } catch { }
            try { seSayfaSayisi.Text = ""; } catch { }
            try { seStokKontrol.Text = ""; } catch { }
            try { cmbYazarAdi.Text = ""; } catch { }
            try { cmbTur.Text = ""; } catch { }
            this.Tag = null;
        }

        void Listele()
        {
            DataTable _dt = _kitapService.KitaplariListele();
            if (_dt != null) gcKitaplar.DataSource = _dt;

            // Grid ayarları (Horizontal Alignment Center)
            foreach (GridColumn col in gvKitaplar.Columns)
            {
                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        void KutulariDoldur()
        {
            try
            {
                DataTable _dtYazar = _kitapService.YazarlariGetir();
                cmbYazarAdi.Properties.Items.Clear();
                if (_dtYazar != null) foreach (DataRow row in _dtYazar.Rows) cmbYazarAdi.Properties.Items.Add(row["YazarAdi"]);

                DataTable _dtTur = _kitapService.TurleriGetir();
                cmbTur.Properties.Items.Clear();
                if (_dtTur != null) foreach (DataRow row in _dtTur.Rows) cmbTur.Properties.Items.Add(row["TurAdi"]);
            }
            catch { }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (tabcntrl.SelectedTabPage != xtraTabPage1) return;

            DataRow dr = gvKitaplar.GetDataRow(gvKitaplar.FocusedRowHandle);
            if (dr == null) return;

            this.Tag = dr["IDKitap"].ToString();
            txtKitapAdi.Text = dr["KitapAdi"].ToString();
            txtISBN.Text = dr["ISBN"].ToString();
            seSayfaSayisi.Text = dr["SayfaSayisi"].ToString();
            seStokKontrol.Text = dr["Stok"].ToString();
            cmbYazarAdi.Text = dr["YazarAdi"].ToString();
            cmbTur.Text = dr["TurAdi"].ToString();
        }

        private void simpleButtonEkle_Click(object sender, EventArgs e)
        {
            string sonuc = _kitapService.KitapEkle(txtKitapAdi.Text, txtISBN.Text, seSayfaSayisi.Text, seStokKontrol.Text, cmbYazarAdi.Text, cmbTur.Text);
            if (sonuc == null) { XtraMessageBox.Show("Kitap Eklendi"); Listele(); Temizle(); }
            else XtraMessageBox.Show(sonuc);
        }

        private void simpleButtonSil_Click(object sender, EventArgs e)
        {
            if (Tag != null && MessageBox.Show("Silinsin mi?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _kitapService.KitapSil(Convert.ToInt32(Tag)); Listele(); Temizle();
            }
        }

        private void simpleButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (Tag != null)
            {
                _kitapService.KitapGuncelle(Convert.ToInt32(Tag), txtKitapAdi.Text, txtISBN.Text, seSayfaSayisi.Text, seStokKontrol.Text, cmbYazarAdi.Text, cmbTur.Text);
                Listele(); Temizle();
            }
        }

        void EmanetListele()
        {
            DataTable _dt = _kitapService.EmanetleriListele();
            if (_dt == null || _dt.Rows.Count == 0)
            {
                gcEmanetler.DataSource = null;
                return;
            }

            gcEmanetler.DataSource = _dt;
            gvEmanetler.PopulateColumns();
            gvEmanetler.OptionsView.ColumnAutoWidth = true;

            if (gvEmanetler.Columns["IDEmanet"] != null) gvEmanetler.Columns["IDEmanet"].Visible = false;
            if (gvEmanetler.Columns["IDKitap"] != null) gvEmanetler.Columns["IDKitap"].Visible = false;
            if (gvEmanetler.Columns["IDOgrenci"] != null) gvEmanetler.Columns["IDOgrenci"].Visible = false;
        }

        void EmanetKutulariDoldur()
        {
            DataTable _dtOgrenci = _kitapService.OgrencileriGetir();
            lueOduncOgrenci.Properties.DataSource = _dtOgrenci;
            lueOduncOgrenci.Properties.ValueMember = "IDOgrenci";
            lueOduncOgrenci.Properties.DisplayMember = "KullaniciAdi";
            lueOduncOgrenci.Properties.NullText = "Öğrenci Seçiniz";

            DataTable _dtKitap = _kitapService.MusaitKitaplariGetir();
            lueOduncKitap.Properties.DataSource = _dtKitap;
            lueOduncKitap.Properties.ValueMember = "IDKitap";
            lueOduncKitap.Properties.DisplayMember = "KitapAdi";
            lueOduncKitap.Properties.NullText = "Kitap Seçiniz";
        }

        private void gvEmanetler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gvEmanetler.GetDataRow(gvEmanetler.FocusedRowHandle);
            if (dr != null)
            {
                if (dr.Table.Columns.Contains("IDEmanet"))
                {
                    this.Tag = dr["IDEmanet"].ToString();
                    dateIadeTarihi.DateTime = DateTime.Now;
                }
                if (dr.Table.Columns.Contains("IDOgrenci") && dr["IDOgrenci"] != DBNull.Value) lueOduncOgrenci.EditValue = dr["IDOgrenci"];
                if (dr.Table.Columns.Contains("IDKitap") && dr["IDKitap"] != DBNull.Value) lueOduncKitap.EditValue = dr["IDKitap"];
            }
        }

        private void btnOduncVer_Click(object sender, EventArgs e)
        {
            if (lueOduncOgrenci.EditValue == null || lueOduncKitap.EditValue == null)
            {
                XtraMessageBox.Show("Lütfen seçim yapınız.", "Uyarı");
                return;
            }

            int oId = Convert.ToInt32(lueOduncOgrenci.EditValue);
            int kId = Convert.ToInt32(lueOduncKitap.EditValue);

            string engel = _kitapService.EmanetVerilebilirMi(oId);
            if (engel != null) { XtraMessageBox.Show(engel, "Uyarı"); return; }

            string sonuc = _kitapService.OduncVer(kId, oId, dateAlisTarihi.DateTime);
            if (sonuc == null) { XtraMessageBox.Show("Ödünç Verildi"); EmanetListele(); EmanetKutulariDoldur(); }
            else XtraMessageBox.Show(sonuc);
        }

        private void btnIadeEt_Click(object sender, EventArgs e)
        {
            if (Tag == null) return;
            DataRow dr = gvEmanetler.GetDataRow(gvEmanetler.FocusedRowHandle);
            int kId = Convert.ToInt32(dr["IDKitap"]);
            string sonuc = _kitapService.IadeAl(Convert.ToInt32(Tag), kId, dateIadeTarihi.DateTime, calcGecikmeBedeli.Text);
            if (sonuc == null) { XtraMessageBox.Show("İade Alındı"); EmanetListele(); EmanetKutulariDoldur(); Tag = null; }
            else XtraMessageBox.Show(sonuc);
        }

        private void FrmAnaSayfaPersonel_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Listele();
                KutulariDoldur();
                GrafikleriYukle();
                KartlariDoldur();
                BagisSayfasiHazirla();
                BagislariYukle();
            }
            catch { }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void tabcntrl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            string yazi = tabcntrl.SelectedTabPage.Text.Trim();
            if (yazi == "Kitap Yönetimi") Listele();
            else if (yazi == "Durum Yönetimi") { EmanetListele(); EmanetKutulariDoldur(); }
            else if (yazi == "Bağış İşlemleri") { BagisSayfasiHazirla(); BagislariYukle(); }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (gridViewBagisOnay.FocusedRowHandle < 0) return;
            object idObj = gridViewBagisOnay.GetFocusedRowCellValue("IDBagis");
            if (idObj == null || idObj == DBNull.Value) return;
            string hata = _bagisService.BagisOnayla(Convert.ToInt32(idObj), null);
            if (hata != null) XtraMessageBox.Show(hata);
            else { XtraMessageBox.Show("Onaylandı"); BagislariYukle(); }
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
            if (gridViewBagisOnay.FocusedRowHandle < 0) return;
            object idObj = gridViewBagisOnay.GetFocusedRowCellValue("IDBagis");
            if (idObj == null || idObj == DBNull.Value) return;
            string hata = _bagisService.BagisReddet(Convert.ToInt32(idObj), null, txtRedNedeni.Text);
            if (hata != null) XtraMessageBox.Show(hata);
            else { XtraMessageBox.Show("Reddedildi"); BagislariYukle(); }
        }

        void GrafikleriYukle()
        {
            try
            {
                // --- PASTA GRAFİĞİ DÜZENLEMESİ ---
                chartTur.Series.Clear();
                DevExpress.XtraCharts.Series s1 = new DevExpress.XtraCharts.Series("Turler", DevExpress.XtraCharts.ViewType.Pie);
                DataTable dt1 = _kitapService.GrafikTurGetir();

                if (dt1 != null)
                {
                    foreach (DataRow dr in dt1.Rows)
                        s1.Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr["TurAdi"], dr["Sayi"]));
                }

                // Dilimlerin üzerinde "Tür Adı: %Yüzde" formatında gösterim sağlar
                s1.Label.TextPattern = "{A}: {VP:P2}";
                // Legend (sağ liste) kısmında tür adını gösterir
                s1.LegendTextPattern = "{A}";

                // Etiketlerin çakışmaması için iki sütunlu yerleşim
                ((DevExpress.XtraCharts.PieSeriesLabel)s1.Label).Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
                s1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                chartTur.Series.Add(s1);

                chartYazar.Series.Clear();
                DevExpress.XtraCharts.Series s2 = new DevExpress.XtraCharts.Series("Yazarlar", DevExpress.XtraCharts.ViewType.Bar);
                DataTable dt2 = _kitapService.GrafikYazarGetir();
                if (dt2 != null) foreach (DataRow dr in dt2.Rows) s2.Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr["YazarAdi"], dr["Sayi"]));
                chartYazar.Series.Add(s2);

                chartKitap.Series.Clear();
                DevExpress.XtraCharts.Series s3 = new DevExpress.XtraCharts.Series("Populer", DevExpress.XtraCharts.ViewType.Bar);
                DataTable dt3 = _kitapService.GrafikEnCokOkunanGetir();
                if (dt3 != null) foreach (DataRow dr in dt3.Rows) s3.Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr["KitapAdi"], dr["OkunmaSayisi"]));
                chartKitap.Series.Add(s3);
            }
            catch { }
        }

        void KartlariDoldur()
        {
            Dictionary<string, string> stats = _kitapService.KartIstatistikleriniGetir();
            if (stats != null)
            {
                lblToplamKitap.Text = stats["ToplamKitap"];
                lblToplamUye.Text = stats["ToplamUye"];
                lblToplamPersonel.Text = stats["ToplamPersonel"];
                lblBugunVerilen.Text = stats["BugunVerilen"];
            }
        }

        private void gvEmanetler_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                object val = gvEmanetler.GetRowCellValue(e.RowHandle, "AlisTarihi");
                if (val != null && val != DBNull.Value)
                {
                    if (Convert.ToDateTime(val).AddDays(15) < DateTime.Now.Date)
                    {
                        e.Appearance.BackColor = Color.Salmon;
                        e.Appearance.ForeColor = Color.White;
                        e.HighPriority = true;
                    }
                }
            }
        }

        private void btnExcelAl_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog { Filter = "Excel Dosyası (*.xlsx)|*.xlsx", FileName = "Kitap_Listesi" };
            if (dialog.ShowDialog() == DialogResult.OK) gcKitaplar.ExportToXlsx(dialog.FileName);
        }

        private void btnPdfAl_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog { Filter = "PDF Dosyası (*.pdf)|*.pdf", FileName = "Kitap_Listesi" };
            if (dialog.ShowDialog() == DialogResult.OK) gcKitaplar.ExportToPdf(dialog.FileName);
        }

        private void gvEmanetler_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow) popupMenuEmanet.ShowPopup(Control.MousePosition);
        }
    }
}