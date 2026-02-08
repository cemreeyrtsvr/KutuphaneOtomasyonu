using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Tile;
using KutuphaneOtomasyonu.Kutuphane.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    public partial class FrmAnaSayfaOgrenci : XtraForm
    {
        public int AktifOgrenciID { get; set; }

        private readonly SOgrenci _ogrenciService = new SOgrenci();
        private readonly SKitap _kitapService = new SKitap();
        private readonly SBagis _bagisService = new SBagis();
        private readonly SOdeme _odemeService = new SOdeme();

        private bool _oduncAlHazirlandi;
        private bool _favorilerHazirlandi;
        private bool _bagisHazirlandi;
        private bool _onerilerHazirlandi;

        
        private bool _onerilerIlkYuklemeYapildi;

        private GeminiAiClient _aiClient;

        
        private static readonly Dictionary<int, Image> _kapakCache = new Dictionary<int, Image>();

        public FrmAnaSayfaOgrenci()
        {
            InitializeComponent();
            Load += FrmAnaSayfaOgrenci_Load;
        }

        private string BuildPromptForRecommendations(DataTable dtGecmis, DataTable dtAday)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Sen bir kütüphane öneri asistanısın.");
            sb.AppendLine("Görev: Aşağıdaki aday kitaplar içinden öğrenciye uygun 5 adet ID seç.");
            sb.AppendLine("KURAL: SADECE JSON array döndür. Örnek: [12,45,3,9,88]");
            sb.AppendLine("KURAL: Aday listede olmayan ID yazma. Açıklama yazma. Metin yazma.");
            sb.AppendLine();

            sb.AppendLine("Öğrencinin okuduğu geçmiş (son liste):");
            if (dtGecmis != null)
            {
                int say = 0;
                foreach (DataRow r in dtGecmis.Rows)
                {
                    sb.AppendLine($"- {r["KitapAdi"]}");
                    say++;
                    if (say >= 10) break;
                }
            }

            sb.AppendLine();
            sb.AppendLine("Aday kitaplar (sadece bunlardan seç):");
            foreach (DataRow r in dtAday.Rows)
                sb.AppendLine($"ID:{r["IDKitap"]} | {r["KitapAdi"]} | {r["YazarAdi"]} | {r["TurAdi"]}");

            return sb.ToString();
        }

        private void FrmAnaSayfaOgrenci_Load(object sender, EventArgs e)
        {
            if (AktifOgrenciID <= 0)
                return;

            try
            {
                string gelenIsim = _ogrenciService.AdSoyadGetir(AktifOgrenciID);
                if (!string.IsNullOrWhiteSpace(gelenIsim) && lblAdSoyad != null)
                    lblAdSoyad.Text = "Hoşgeldin, " + gelenIsim;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Hata");
            }

            TileUzerimdekilerOzetYaz();
            TileTemplateGorunumAyarla();
            LabeliOrtala();
            FavoriBaslikOrtala();
        }

        
        private Image KapakGetirCached(int idKitap)
        {
            if (_kapakCache.TryGetValue(idKitap, out Image img) && img != null)
                return img;

            Image loaded = _kitapService.KapakGetir(idKitap);

            if (loaded == null)
            {
                
                loaded = new Bitmap(1, 1);
            }

            _kapakCache[idKitap] = loaded;
            return loaded;
        }

        private void TileTemplateGorunumAyarla()
        {
            tileView1.OptionsTiles.ItemSize = new Size(420, 170);
            tileView1.OptionsTiles.Orientation = Orientation.Vertical;

            foreach (TileViewItemElement el in tileView1.TileTemplate)
            {
                if (el.Column == null)
                {
                    el.Appearance.Normal.Font = new Font("Tahoma", 9F, FontStyle.Bold);
                    el.Appearance.Normal.ForeColor = Color.Navy;
                    el.TextAlignment = TileItemContentAlignment.TopLeft;
                    continue;
                }

                el.Appearance.Normal.ForeColor = Color.Black;

                if (el.Column.FieldName == "KitapAdi")
                {
                    el.Appearance.Normal.Font = new Font("Tahoma", 11F, FontStyle.Bold);
                    el.MaxLineCount = 2;
                    el.TextAlignment = TileItemContentAlignment.TopLeft;
                }
                else if (el.Column.FieldName == "AlisTarihi")
                {
                    el.Appearance.Normal.Font = new Font("Tahoma", 9F, FontStyle.Regular);
                    el.TextAlignment = TileItemContentAlignment.TopLeft;
                }
                else if (el.Column.FieldName == "TeslimGerekenTarih")
                {
                    el.Appearance.Normal.Font = new Font("Tahoma", 9F, FontStyle.Bold);
                    el.TextAlignment = TileItemContentAlignment.TopLeft;
                }
            }
        }

        private void YukleUzerimdekiler()
        {
            try
            {
                DataTable dt = _ogrenciService.UzerimdekileriGetir(AktifOgrenciID);

                if (tileView1.GridControl == null)
                    tileView1.GridControl = gridUzerimdekiler;

                if (gridUzerimdekiler.MainView != tileView1)
                    gridUzerimdekiler.MainView = tileView1;

                gridUzerimdekiler.DataSource = dt;
                gridUzerimdekiler.RefreshDataSource();
                tileView1.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Hata");
            }
        }

        private void TileUzerimdekilerOzetYaz()
        {
            try
            {
                DataRow ozet = _ogrenciService.UzerimdekilerOzetGetir(AktifOgrenciID);

                int kitapSayisi = 0;
                string tarihYazi = "-";

                if (ozet != null)
                {
                    if (ozet["KitapSayisi"] != DBNull.Value)
                        kitapSayisi = Convert.ToInt32(ozet["KitapSayisi"]);

                    if (ozet["EnYakinTeslim"] != DBNull.Value)
                    {
                        DateTime dt = Convert.ToDateTime(ozet["EnYakinTeslim"]);
                        tarihYazi = dt.Date == DateTime.Today
                            ? "Bugün"
                            : dt.Date == DateTime.Today.AddDays(1)
                                ? "Yarın"
                                : dt.ToString("dd.MM.yyyy");
                    }
                }

                string altYazi = $"{kitapSayisi} Kitap Okuyorsun. En Yakın Teslim : {tarihYazi}";

                TileItemElement aciklamaEl;
                if (tileUzerimdekiler.Elements.Count >= 3)
                    aciklamaEl = tileUzerimdekiler.Elements[2];
                else
                {
                    aciklamaEl = new TileItemElement();
                    tileUzerimdekiler.Elements.Add(aciklamaEl);
                }

                aciklamaEl.Text = altYazi;
                aciklamaEl.TextAlignment = TileItemContentAlignment.BottomCenter;
                aciklamaEl.Appearance.Normal.Font = new Font("Tahoma", 8.25F, FontStyle.Regular);
                aciklamaEl.Appearance.Normal.ForeColor = Color.Gray;
            }
            catch { }
        }

        
        private void OkumaGecmisiListele()
        {
            try
            {
                if (AktifOgrenciID <= 0)
                    return;

                DataTable dt = _ogrenciService.OkumaGecmisiGetir(AktifOgrenciID);
                grdGecmis.DataSource = dt;

                if (tileView2.Columns["AlisTarihi"] != null)
                {
                    tileView2.Columns["AlisTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    tileView2.Columns["AlisTarihi"].DisplayFormat.FormatString = "dd.MM.yyyy";
                }

                if (tileView2.Columns["TeslimTarihi"] != null)
                {
                    tileView2.Columns["TeslimTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    tileView2.Columns["TeslimTarihi"].DisplayFormat.FormatString = "dd.MM.yyyy";
                }

                tileView2.OptionsTiles.Orientation = Orientation.Vertical;
                tileView2.OptionsTiles.ColumnCount = 3;
                tileView2.OptionsTiles.ItemSize = new Size(320, 150);

                tileView2.OptionsTiles.IndentBetweenItems = 14;
                tileView2.OptionsTiles.Padding = new Padding(14);
                tileView2.OptionsTiles.ItemPadding = new Padding(14);

                grdGecmis.BackColor = Color.FromArgb(245, 247, 250);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Okuma geçmişi yüklenemedi: " + ex.Message);
            }
        }

        
        private void SayfaAc(DevExpress.XtraTab.XtraTabPage sayfa)
        {
            tileControl1.Visible = false;
            xtraTabControl1.Visible = true;
            xtraTabControl1.SelectedTabPage = sayfa;
        }

        private void AnaMenuyeDon()
        {
            xtraTabControl1.Visible = false;
            tileControl1.Visible = true;
            TileUzerimdekilerOzetYaz();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Çıkış Yapmak İstiyor Musunuz?", "Çıkış", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }

        
        private void tileUzerimdekiler_ItemClick(object sender, TileItemEventArgs e)
        {
            SayfaAc(pageUzerimdekiler);
            YukleUzerimdekiler();
        }

        private void tileOduncAl_ItemClick(object sender, TileItemEventArgs e)
        {
            SayfaAc(pageOduncAl);
            OduncAlSayfasiHazirla();

            
            _ = OnerileriYukleAsync(force: false);
        }

        private void tileBagis_ItemClick(object sender, TileItemEventArgs e)
        {
            SayfaAc(pageBagis);
            BagisSayfasiHazirla();
            BagislarimiYukle();
        }

        private void tileCeza_ItemClick(object sender, TileItemEventArgs e)
        {
            SayfaAc(pageCeza);
            CezaSayfasiHazirlaVeYukle();
        }

        private void tileGecmis_ItemClick(object sender, TileItemEventArgs e)
        {
            SayfaAc(pageGecmis);
            OkumaGecmisiListele();
        }

        private void tileFavoriler_ItemClick(object sender, TileItemEventArgs e)
        {
            SayfaAc(pageFavoriler);
            FavorilerSayfasiHazirla();
            FavorileriListele();
        }

        private void btnGeriDon1_Click(object sender, EventArgs e) { AnaMenuyeDon(); }
        private void btnGeriDon2_Click(object sender, EventArgs e) { AnaMenuyeDon(); }
        private void btnGeriDon3_Click(object sender, EventArgs e) { AnaMenuyeDon(); }
        private void btnGeriDon4_Click(object sender, EventArgs e) { AnaMenuyeDon(); }
        private void btnGeriDon5_Click(object sender, EventArgs e) { AnaMenuyeDon(); }
        private void btnGeriDon6_Click(object sender, EventArgs e) { AnaMenuyeDon(); }

        
        private void OduncAlSayfasiHazirla()
        {
            if (_oduncAlHazirlandi)
                return;

            _oduncAlHazirlandi = true;

            txtKitapAra.Properties.Appearance.ForeColor = Color.Black;
            txtKitapAra.Properties.Appearance.Options.UseForeColor = true;
            txtKitapAra.Properties.AppearanceFocused.ForeColor = Color.Black;
            txtKitapAra.Properties.AppearanceFocused.Options.UseForeColor = true;
            txtKitapAra.Properties.NullValuePrompt = "Kitap adı / ISBN ara";
            txtKitapAra.Properties.ShowNullValuePromptWhenFocused = true;

            LookupDoldurTur();
            LookupDoldurYazar();

            OduncAlTileViewHazirla();

            
            OnerilerTileViewHazirla();

            AraSonucGetirVeBas();
        }

        private void LookupDoldurTur()
        {
            DataTable dtTur = _kitapService.TurleriGetir();

            lueTur.Properties.DataSource = dtTur;
            lueTur.Properties.DisplayMember = "TurAdi";
            lueTur.Properties.ValueMember = "IDTur";
            lueTur.Properties.NullText = "Tür Seçiniz";
            lueTur.EditValue = null;

            lueTur.Properties.Columns.Clear();
            lueTur.Properties.Columns.Add(new LookUpColumnInfo("TurAdi", "Tür"));

            lueTur.Properties.TextEditStyle = TextEditStyles.Standard;
            lueTur.Properties.SearchMode = SearchMode.AutoFilter;
            lueTur.Properties.PopupFilterMode = PopupFilterMode.Contains;

            lueTur.EditValueChanged -= lueTur_EditValueChanged;
            lueTur.EditValueChanged += lueTur_EditValueChanged;
        }

        private void LookupDoldurYazar()
        {
            DataTable dtYazar = _kitapService.YazarlariGetir();

            lueYazar.Properties.DataSource = dtYazar;
            lueYazar.Properties.DisplayMember = "YazarAdi";
            lueYazar.Properties.ValueMember = "IDYazar";
            lueYazar.Properties.NullText = "Yazar Seçiniz";
            lueYazar.EditValue = null;

            lueYazar.Properties.Columns.Clear();
            lueYazar.Properties.Columns.Add(new LookUpColumnInfo("YazarAdi", "Yazar"));

            lueYazar.Properties.TextEditStyle = TextEditStyles.Standard;
            lueYazar.Properties.SearchMode = SearchMode.AutoFilter;
            lueYazar.Properties.PopupFilterMode = PopupFilterMode.Contains;

            lueYazar.EditValueChanged -= lueYazar_EditValueChanged;
            lueYazar.EditValueChanged += lueYazar_EditValueChanged;
        }

        private void OduncAlTileViewHazirla()
        {
            if (tileViewAraSonuc.GridControl == null)
                tileViewAraSonuc.GridControl = grdAraSonuc;

            if (grdAraSonuc.MainView != tileViewAraSonuc)
                grdAraSonuc.MainView = tileViewAraSonuc;

            tileViewAraSonuc.OptionsTiles.Orientation = Orientation.Vertical;
            tileViewAraSonuc.OptionsTiles.ColumnCount = 4;
            tileViewAraSonuc.OptionsTiles.ItemSize = new Size(320, 170);
            tileViewAraSonuc.OptionsTiles.Padding = new Padding(18);
            tileViewAraSonuc.OptionsTiles.ItemPadding = new Padding(14);
            tileViewAraSonuc.OptionsTiles.IndentBetweenItems = 16;

            grdAraSonuc.BackColor = Color.FromArgb(242, 246, 252);

            tileViewAraSonuc.ItemClick -= tileViewAraSonuc_ItemClick;
            tileViewAraSonuc.ItemClick += tileViewAraSonuc_ItemClick;

            tileViewAraSonuc.ItemCustomize -= tileViewAraSonuc_ItemCustomize;
            tileViewAraSonuc.ItemCustomize += tileViewAraSonuc_ItemCustomize;
        }

        private void tileViewAraSonuc_ItemClick(object sender, TileViewItemClickEventArgs e)
        {
            try
            {
                int rowHandle = e.Item.RowHandle;
                object idObj = tileViewAraSonuc.GetRowCellValue(rowHandle, "IDKitap");
                if (idObj == null || idObj == DBNull.Value)
                    return;

                int idKitap = Convert.ToInt32(idObj);
                KitapDetayAc(idKitap);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hata");
            }
        }

        private void KitapDetayAc(int idKitap)
        {
            FrmKitapDetay frm = new FrmKitapDetay();
            frm.AktifOgrenciID = AktifOgrenciID;
            frm.IDKitap = idKitap;
            frm.ShowDialog();

            if (xtraTabControl1.SelectedTabPage == pageFavoriler)
                FavorileriListele();
        }

        private void tileViewAraSonuc_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            try
            {
                object stokObj = tileViewAraSonuc.GetRowCellValue(e.RowHandle, "Stok");
                int stok = 0;
                if (stokObj != null && stokObj != DBNull.Value)
                    stok = Convert.ToInt32(stokObj);

                if (stok <= 0)
                {
                    e.Item.AppearanceItem.Normal.BackColor = Color.FromArgb(255, 245, 245);
                    e.Item.AppearanceItem.Normal.BorderColor = Color.FromArgb(235, 120, 120);
                }
                else
                {
                    e.Item.AppearanceItem.Normal.BackColor = Color.FromArgb(245, 250, 255);
                    e.Item.AppearanceItem.Normal.BorderColor = Color.FromArgb(140, 180, 230);
                }

                e.Item.AppearanceItem.Normal.Options.UseBackColor = true;
                e.Item.AppearanceItem.Normal.Options.UseBorderColor = true;
            }
            catch { }
        }

        private void AraSonucGetirVeBas()
        {
            int? idTur = (lueTur.EditValue == null) ? (int?)null : Convert.ToInt32(lueTur.EditValue);
            int? idYazar = (lueYazar.EditValue == null) ? (int?)null : Convert.ToInt32(lueYazar.EditValue);

            DataTable dt = _kitapService.KitapAra(
                txtKitapAra.Text.Trim(),
                idTur,
                idYazar,
                chkSadeceStok.Checked
            );

            grdAraSonuc.DataSource = dt;
            grdAraSonuc.RefreshDataSource();

            if (tileViewAraSonuc.Columns.Count == 0)
                tileViewAraSonuc.PopulateColumns();

            tileViewAraSonuc.RefreshData();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            OduncAlSayfasiHazirla();
            AraSonucGetirVeBas();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtKitapAra.Text = "";
            lueTur.EditValue = null;
            lueYazar.EditValue = null;
            chkSadeceStok.Checked = false;

            AraSonucGetirVeBas();
        }

        private void lueTur_EditValueChanged(object sender, EventArgs e)
        {
            if (_oduncAlHazirlandi)
                AraSonucGetirVeBas();
        }

        private void lueYazar_EditValueChanged(object sender, EventArgs e)
        {
            if (_oduncAlHazirlandi)
                AraSonucGetirVeBas();
        }

        
        private void FavorilerSayfasiHazirla()
        {
            if (_favorilerHazirlandi)
                return;

            _favorilerHazirlandi = true;

            if (tileViewFavoriler.GridControl == null)
                tileViewFavoriler.GridControl = grdFavoriler;

            if (grdFavoriler.MainView != tileViewFavoriler)
                grdFavoriler.MainView = tileViewFavoriler;

            grdFavoriler.Dock = DockStyle.Fill;

            tileViewFavoriler.OptionsTiles.Orientation = Orientation.Vertical;
            tileViewFavoriler.OptionsTiles.ColumnCount = 4;
            tileViewFavoriler.OptionsTiles.ItemSize = new Size(360, 170);
            tileViewFavoriler.OptionsTiles.IndentBetweenItems = 14;
            tileViewFavoriler.OptionsTiles.Padding = new Padding(16);
            tileViewFavoriler.OptionsTiles.ItemPadding = new Padding(12);

            tileViewFavoriler.ItemClick -= tileViewFavoriler_ItemClick;
            tileViewFavoriler.ItemClick += tileViewFavoriler_ItemClick;
        }

        private void FavorileriListele()
        {
            try
            {
                DataTable dt = _kitapService.FavorileriListele(AktifOgrenciID);

                grdFavoriler.DataSource = dt;
                grdFavoriler.RefreshDataSource();

                if (tileViewFavoriler.Columns.Count == 0)
                    tileViewFavoriler.PopulateColumns();

                FavorilerTileTemplateKur_NoSpan();

                tileViewFavoriler.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hata");
            }
        }

        private void FavorilerTileTemplateKur_NoSpan()
        {
            if (tileViewFavoriler.Columns["KitapAdi"] == null) return;
            if (tileViewFavoriler.Columns["YazarAdi"] == null) return;
            if (tileViewFavoriler.Columns["TurAdi"] == null) return;
            if (tileViewFavoriler.Columns["KayitTarihi"] == null) return;

            if (tileViewFavoriler.Columns["IDKitap"] != null)
                tileViewFavoriler.Columns["IDKitap"].Visible = false;

            tileViewFavoriler.Columns["KayitTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            tileViewFavoriler.Columns["KayitTarihi"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";

            tileViewFavoriler.TileTemplate.Clear();

            TileViewItemElement elKitap = new TileViewItemElement();
            elKitap.Column = tileViewFavoriler.Columns["KitapAdi"];
            elKitap.RowIndex = 0;
            elKitap.TextAlignment = TileItemContentAlignment.TopLeft;
            elKitap.Appearance.Normal.Font = new Font("Tahoma", 11F, FontStyle.Bold);

            TileViewItemElement elYazar = new TileViewItemElement();
            elYazar.Column = tileViewFavoriler.Columns["YazarAdi"];
            elYazar.RowIndex = 1;
            elYazar.TextAlignment = TileItemContentAlignment.MiddleLeft;
            elYazar.Appearance.Normal.Font = new Font("Tahoma", 9F, FontStyle.Regular);

            TileViewItemElement elTur = new TileViewItemElement();
            elTur.Column = tileViewFavoriler.Columns["TurAdi"];
            elTur.RowIndex = 2;
            elTur.TextAlignment = TileItemContentAlignment.MiddleLeft;
            elTur.Appearance.Normal.Font = new Font("Tahoma", 9F, FontStyle.Regular);

            TileViewItemElement elKayit = new TileViewItemElement();
            elKayit.Column = tileViewFavoriler.Columns["KayitTarihi"];
            elKayit.RowIndex = 3;
            elKayit.TextAlignment = TileItemContentAlignment.BottomLeft;
            elKayit.Appearance.Normal.Font = new Font("Tahoma", 8.25F, FontStyle.Regular);
            elKayit.Appearance.Normal.ForeColor = Color.DimGray;

            tileViewFavoriler.TileTemplate.Add(elKitap);
            tileViewFavoriler.TileTemplate.Add(elYazar);
            tileViewFavoriler.TileTemplate.Add(elTur);
            tileViewFavoriler.TileTemplate.Add(elKayit);
        }

        private void tileViewFavoriler_ItemClick(object sender, TileViewItemClickEventArgs e)
        {
            try
            {
                int rowHandle = e.Item.RowHandle;

                object idObj = tileViewFavoriler.GetRowCellValue(rowHandle, "IDKitap");
                if (idObj == null || idObj == DBNull.Value)
                    return;

                int idKitap = Convert.ToInt32(idObj);
                KitapDetayAc(idKitap);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hata");
            }
        }

        
        private void BagisSayfasiHazirla()
        {
            if (_bagisHazirlandi) return;
            _bagisHazirlandi = true;

            btnBagisGonder.Click -= btnBagisGonder_Click;
            btnBagisGonder.Click += btnBagisGonder_Click;

            btnBagisYenile.Click -= btnBagisYenile_Click;
            btnBagisYenile.Click += btnBagisYenile_Click;

            txtBagisKitapAdi.Properties.NullValuePrompt = "Kitap adı";
            txtBagisKitapAdi.Properties.ShowNullValuePromptWhenFocused = true;

            txtBagisYazarAdi.Properties.NullValuePrompt = "Yazar adı";
            txtBagisYazarAdi.Properties.ShowNullValuePromptWhenFocused = true;

            txtBagisISBN.Properties.NullValuePrompt = "ISBN (opsiyonel)";
            txtBagisISBN.Properties.ShowNullValuePromptWhenFocused = true;

            ModernButonAyarla(btnBagisGonder, Color.FromArgb(30, 136, 229), Color.White);
            ModernButonAyarla(btnBagisYenile, Color.FromArgb(96, 125, 139), Color.White);

            grdBagislarim.MainView = gridViewBagislarim;
            gridViewBagislarim.OptionsView.ShowGroupPanel = false;
            gridViewBagislarim.OptionsBehavior.Editable = false;
            gridViewBagislarim.OptionsView.ColumnAutoWidth = true;
            gridViewBagislarim.OptionsView.EnableAppearanceOddRow = true;

            gridViewBagislarim.CustomColumnDisplayText -= gridViewBagislarim_CustomColumnDisplayText;
            gridViewBagislarim.CustomColumnDisplayText += gridViewBagislarim_CustomColumnDisplayText;

            gridViewBagislarim.RowStyle -= gridViewBagislarim_RowStyle;
            gridViewBagislarim.RowStyle += gridViewBagislarim_RowStyle;

            ModernDurumLabelAyarla(lblBekleyenSayi, "Bekliyor: 0", Color.FromArgb(255, 249, 196), Color.FromArgb(102, 60, 0));
            ModernDurumLabelAyarla(lblOnaySayi, "Onaylandı: 0", Color.FromArgb(200, 230, 201), Color.FromArgb(0, 70, 0));
            ModernDurumLabelAyarla(lblRedSayi, "Reddedildi: 0", Color.FromArgb(255, 205, 210), Color.FromArgb(90, 0, 0));

            pageBagis.Resize -= pageBagis_Resize;
            pageBagis.Resize += pageBagis_Resize;
            pageBagis_Resize(null, EventArgs.Empty);
        }

        private void pageBagis_Resize(object sender, EventArgs e)
        {
            int margin = 18;
            int gap = 16;

            int leftW = 420;
            int pageW = pageBagis.ClientSize.Width;
            int pageH = pageBagis.ClientSize.Height;

            int gridLeft = leftW + gap;
            int gridW = Math.Max(200, pageW - gridLeft - margin);
            int gridTop = margin;
            int gridH = Math.Max(200, pageH - (margin * 2));

            grdBagislarim.Location = new Point(gridLeft, gridTop);
            grdBagislarim.Size = new Size(gridW, gridH);
            grdBagislarim.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            int xEdit = 160;
            int editW = Math.Max(200, leftW - xEdit - margin);

            int y = 70;
            int rowH = 34;
            int space = 18;

            if (txtBagisKitapAdi != null)
            {
                txtBagisKitapAdi.Location = new Point(xEdit, y);
                txtBagisKitapAdi.Size = new Size(editW, rowH);
                txtBagisKitapAdi.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }
            y += rowH + space;

            if (txtBagisYazarAdi != null)
            {
                txtBagisYazarAdi.Location = new Point(xEdit, y);
                txtBagisYazarAdi.Size = new Size(editW, rowH);
                txtBagisYazarAdi.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }
            y += rowH + space;

            if (txtBagisISBN != null)
            {
                txtBagisISBN.Location = new Point(xEdit, y);
                txtBagisISBN.Size = new Size(editW, rowH);
                txtBagisISBN.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }
            y += rowH + 26;

            int btnW = (editW - 12) / 2;
            int btnH = 54;

            if (btnBagisGonder != null)
            {
                btnBagisGonder.Location = new Point(xEdit, y);
                btnBagisGonder.Size = new Size(btnW, btnH);
                btnBagisGonder.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }

            if (btnBagisYenile != null)
            {
                btnBagisYenile.Location = new Point(xEdit + btnW + 12, y);
                btnBagisYenile.Size = new Size(btnW, btnH);
                btnBagisYenile.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }

            int cardTop = pageH - margin - 44;
            int cardH = 44;

            int cardW = Math.Max(110, (leftW - margin * 2 - 16) / 3);

            if (lblBekleyenSayi != null)
            {
                lblBekleyenSayi.Location = new Point(margin, cardTop);
                lblBekleyenSayi.Size = new Size(cardW, cardH);
                lblBekleyenSayi.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            }

            if (lblOnaySayi != null)
            {
                lblOnaySayi.Location = new Point(margin + cardW + 8, cardTop);
                lblOnaySayi.Size = new Size(cardW, cardH);
                lblOnaySayi.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            }

            if (lblRedSayi != null)
            {
                lblRedSayi.Location = new Point(margin + (cardW + 8) * 2, cardTop);
                lblRedSayi.Size = new Size(cardW, cardH);
                lblRedSayi.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            }
        }

        private void ModernButonAyarla(SimpleButton btn, Color back, Color fore)
        {
            if (btn == null) return;

            btn.Appearance.BackColor = back;
            btn.Appearance.ForeColor = fore;
            btn.Appearance.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            btn.Appearance.Options.UseBackColor = true;
            btn.Appearance.Options.UseForeColor = true;
            btn.Appearance.Options.UseFont = true;

            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btn.LookAndFeel.UseDefaultLookAndFeel = false;
        }

        private void ModernDurumLabelAyarla(LabelControl lbl, string text, Color back, Color fore)
        {
            if (lbl == null) return;

            lbl.Text = text;
            lbl.Appearance.BackColor = back;
            lbl.Appearance.ForeColor = fore;
            lbl.Appearance.Font = new Font("Tahoma", 9.25F, FontStyle.Bold);
            lbl.Appearance.Options.UseBackColor = true;
            lbl.Appearance.Options.UseForeColor = true;
            lbl.Appearance.Options.UseFont = true;

            lbl.AutoSizeMode = LabelAutoSizeMode.None;
            lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lbl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lbl.Padding = new Padding(8, 6, 8, 6);
        }

        private void BagislarimiYukle()
        {
            if (AktifOgrenciID <= 0) return;

            DataTable dt = _bagisService.OgrenciBagislariListele(AktifOgrenciID);

            grdBagislarim.DataSource = dt;
            grdBagislarim.RefreshDataSource();

            if (gridViewBagislarim.Columns.Count == 0)
                gridViewBagislarim.PopulateColumns();

            if (gridViewBagislarim.Columns["IDBagis"] != null) gridViewBagislarim.Columns["IDBagis"].Visible = false;

            if (gridViewBagislarim.Columns["KitapAdi"] != null) gridViewBagislarim.Columns["KitapAdi"].Caption = "Kitap";
            if (gridViewBagislarim.Columns["YazarAdi"] != null) gridViewBagislarim.Columns["YazarAdi"].Caption = "Yazar";
            if (gridViewBagislarim.Columns["ISBN"] != null) gridViewBagislarim.Columns["ISBN"].Caption = "ISBN";
            if (gridViewBagislarim.Columns["Durum"] != null) gridViewBagislarim.Columns["Durum"].Caption = "Durum";
            if (gridViewBagislarim.Columns["RedNedeni"] != null) gridViewBagislarim.Columns["RedNedeni"].Caption = "Red Nedeni";

            if (gridViewBagislarim.Columns["KayitTarihi"] != null)
            {
                gridViewBagislarim.Columns["KayitTarihi"].Caption = "Gönderim";
                gridViewBagislarim.Columns["KayitTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewBagislarim.Columns["KayitTarihi"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            }

            if (gridViewBagislarim.Columns["OnayTarihi"] != null)
            {
                gridViewBagislarim.Columns["OnayTarihi"].Caption = "İşlem Tarihi";
                gridViewBagislarim.Columns["OnayTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewBagislarim.Columns["OnayTarihi"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            }

            BagisOzetYaz(dt);
        }

        private void BagisOzetYaz(DataTable dt)
        {
            int bek = 0, onay = 0, red = 0;

            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (r["Durum"] == DBNull.Value) continue;
                    int d = Convert.ToInt32(r["Durum"]);
                    if (d == 0) bek++;
                    else if (d == 1) onay++;
                    else if (d == 2) red++;
                }
            }

            if (lblBekleyenSayi != null) lblBekleyenSayi.Text = $"Bekliyor: {bek}";
            if (lblOnaySayi != null) lblOnaySayi.Text = $"Onaylandı: {onay}";
            if (lblRedSayi != null) lblRedSayi.Text = $"Reddedildi: {red}";
        }

        private void gridViewBagislarim_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == null || e.Column.FieldName != "Durum") return;
            if (e.Value == null || e.Value == DBNull.Value) return;

            int durum = Convert.ToInt32(e.Value);
            if (durum == 0) e.DisplayText = "Bekliyor";
            else if (durum == 1) e.DisplayText = "Onaylandı";
            else if (durum == 2) e.DisplayText = "Reddedildi";
        }

        private void gridViewBagislarim_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            object val = gridViewBagislarim.GetRowCellValue(e.RowHandle, "Durum");
            if (val == null || val == DBNull.Value) return;

            int durum = Convert.ToInt32(val);

            if (durum == 0)
            {
                e.Appearance.BackColor = Color.FromArgb(255, 250, 230);
                e.HighPriority = true;
            }
            else if (durum == 1)
            {
                e.Appearance.BackColor = Color.FromArgb(235, 255, 235);
                e.HighPriority = true;
            }
            else if (durum == 2)
            {
                e.Appearance.BackColor = Color.FromArgb(255, 235, 235);
                e.HighPriority = true;
            }
        }

        private void btnBagisYenile_Click(object sender, EventArgs e)
        {
            BagislarimiYukle();
        }

        private void btnBagisGonder_Click(object sender, EventArgs e)
        {
            string hata = _bagisService.BagisEkle(
                AktifOgrenciID,
                txtBagisKitapAdi.Text,
                txtBagisYazarAdi.Text,
                txtBagisISBN.Text
            );

            if (hata != null)
            {
                XtraMessageBox.Show(hata, "Hata");
                return;
            }

            XtraMessageBox.Show("Bağış talebin alındı. Personel onayı bekleniyor.", "Bilgi");

            txtBagisKitapAdi.Text = "";
            txtBagisYazarAdi.Text = "";
            txtBagisISBN.Text = "";

            BagislarimiYukle();
        }

        
        private void CezaSayfasiHazirlaVeYukle()
        {
            if (AktifOgrenciID <= 0) return;

            grdCezaDetay.MainView = gridViewCezaDetay;
            gridViewCezaDetay.OptionsView.ShowGroupPanel = false;
            gridViewCezaDetay.OptionsBehavior.Editable = false;
            gridViewCezaDetay.OptionsView.ColumnAutoWidth = true;

            DataTable dt = _kitapService.CezaDetayGetir(AktifOgrenciID);
            grdCezaDetay.DataSource = dt;
            grdCezaDetay.RefreshDataSource();

            if (gridViewCezaDetay.Columns.Count == 0)
                gridViewCezaDetay.PopulateColumns();

            if (gridViewCezaDetay.Columns["IDKitap"] != null) gridViewCezaDetay.Columns["IDKitap"].Visible = false;

            if (gridViewCezaDetay.Columns["KitapAdi"] != null) gridViewCezaDetay.Columns["KitapAdi"].Caption = "Kitap";
            if (gridViewCezaDetay.Columns["AlisTarihi"] != null)
            {
                gridViewCezaDetay.Columns["AlisTarihi"].Caption = "Alış Tarihi";
                gridViewCezaDetay.Columns["AlisTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewCezaDetay.Columns["AlisTarihi"].DisplayFormat.FormatString = "dd.MM.yyyy";
            }
            if (gridViewCezaDetay.Columns["TeslimGerekenTarih"] != null)
            {
                gridViewCezaDetay.Columns["TeslimGerekenTarih"].Caption = "Teslim Günü";
                gridViewCezaDetay.Columns["TeslimGerekenTarih"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewCezaDetay.Columns["TeslimGerekenTarih"].DisplayFormat.FormatString = "dd.MM.yyyy";
            }
            if (gridViewCezaDetay.Columns["GecikmeGun"] != null) gridViewCezaDetay.Columns["GecikmeGun"].Caption = "Gecikme (Gün)";
            if (gridViewCezaDetay.Columns["SatirBorcu"] != null)
            {
                gridViewCezaDetay.Columns["SatirBorcu"].Caption = "Borç (TL)";
                gridViewCezaDetay.Columns["SatirBorcu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewCezaDetay.Columns["SatirBorcu"].DisplayFormat.FormatString = "n2";
            }

            decimal toplam = 0;
            foreach (DataRow r in dt.Rows)
                toplam += Convert.ToDecimal(r["SatirBorcu"]);

            lblToplamBorcu.Text = $"Toplam Borç: {toplam:n2} TL";

            btnOdemeYap.Enabled = toplam > 0;
            btnOdemeYap.Click -= btnOdemeYap_Click;
            btnOdemeYap.Click += btnOdemeYap_Click;
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            decimal hesaplanan = _kitapService.CezaHesaplananToplamGetir(AktifOgrenciID);
            decimal odenen = _odemeService.OdenenToplamGetir(AktifOgrenciID);
            decimal kalan = hesaplanan - odenen;
            if (kalan <= 0)
            {
                XtraMessageBox.Show("Ödenecek borç yok.", "Bilgi");
                return;
            }

            using (var frm = new FrmOdemeDemo1())
            {
                frm.OgrenciId = AktifOgrenciID;
                frm.Tutar = kalan;
                frm.Aciklama = "Gecikme cezası (DEMO)";

                var dr = frm.ShowDialog();

                if (dr != DialogResult.OK || frm.OdemeBasarili == false)
                {
                    XtraMessageBox.Show("Ödeme iptal edildi.", "Bilgi");
                    return;
                }
            }

            string hata = _odemeService.OdemeEkle(
                AktifOgrenciID,
                kalan,
                "DEMO ödeme ekranından"
            );

            if (hata != null)
            {
                XtraMessageBox.Show(hata, "Hata");
                return;
            }

            XtraMessageBox.Show("Ödeme alındı (DEMO).", "Bilgi");
            CezaSayfasiHazirlaVeYukle();
        }

        
       
        private void EnsureKapakUnboundColumn()
        {
            
            var col = tileViewOneriler.Columns["Kapak"];
            if (col == null)
            {
                col = tileViewOneriler.Columns.AddField("Kapak");
                col.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            }

            
            col.Visible = false;
        }

        private void tileViewOneriler_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (!e.IsGetData) return;
            if (e.Column == null || e.Column.FieldName != "Kapak") return;

            try
            {
                object idObj = tileViewOneriler.GetListSourceRowCellValue(e.ListSourceRowIndex, "IDKitap");
                if (idObj == null || idObj == DBNull.Value)
                {
                    e.Value = null;
                    return;
                }

                int idKitap = Convert.ToInt32(idObj);
                e.Value = KapakGetirCached(idKitap);
            }
            catch
            {
                e.Value = null;
            }
        }

        private void tileViewOneriler_ItemClick(object sender, TileViewItemClickEventArgs e)
        {
            try
            {
                int rowHandle = e.Item.RowHandle;
                object idObj = tileViewOneriler.GetRowCellValue(rowHandle, "IDKitap");
                if (idObj == null || idObj == DBNull.Value) return;

                int idKitap = Convert.ToInt32(idObj);
                KitapDetayAc(idKitap);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hata");
            }
        }

        
        private void OnerilerTileTemplateKur_Resimli_FINAL()
        {
            if (tileViewOneriler.Columns["KitapAdi"] == null) return;
            if (tileViewOneriler.Columns["YazarAdi"] == null) return;
            if (tileViewOneriler.Columns["TurAdi"] == null) return;
            if (tileViewOneriler.Columns["Kapak"] == null) return;

            if (tileViewOneriler.Columns["IDKitap"] != null)
                tileViewOneriler.Columns["IDKitap"].Visible = false;

            tileViewOneriler.TileTemplate.Clear();

           
            TileViewItemElement elKapak = new TileViewItemElement();
            elKapak.Column = tileViewOneriler.Columns["Kapak"];   
            elKapak.RowIndex = 0;
            elKapak.ColumnIndex = 0;
            elKapak.TextVisible = false;                          
            elKapak.ImageScaleMode = TileItemImageScaleMode.ZoomInside; 
            elKapak.ImageAlignment = TileItemContentAlignment.MiddleCenter;

            
            TileViewItemElement elKitap = new TileViewItemElement();
            elKitap.Column = tileViewOneriler.Columns["KitapAdi"];
            elKitap.RowIndex = 0;
            elKitap.ColumnIndex = 1;
            elKitap.TextAlignment = TileItemContentAlignment.TopLeft;
            elKitap.Appearance.Normal.Font = new Font("Tahoma", 11F, FontStyle.Bold);
            elKitap.MaxLineCount = 2;

            
            TileViewItemElement elYazar = new TileViewItemElement();
            elYazar.Column = tileViewOneriler.Columns["YazarAdi"];
            elYazar.RowIndex = 1;
            elYazar.ColumnIndex = 1;
            elYazar.TextAlignment = TileItemContentAlignment.MiddleLeft;
            elYazar.Appearance.Normal.Font = new Font("Tahoma", 9F);

            
            TileViewItemElement elTur = new TileViewItemElement();
            elTur.Column = tileViewOneriler.Columns["TurAdi"];
            elTur.RowIndex = 2;
            elTur.ColumnIndex = 1;
            elTur.TextAlignment = TileItemContentAlignment.BottomLeft;
            elTur.Appearance.Normal.Font = new Font("Tahoma", 9F);
            elTur.Appearance.Normal.ForeColor = Color.Gray;

            tileViewOneriler.TileTemplate.Add(elKapak);
            tileViewOneriler.TileTemplate.Add(elKitap);
            tileViewOneriler.TileTemplate.Add(elYazar);
            tileViewOneriler.TileTemplate.Add(elTur);

            tileViewOneriler.OptionsTiles.ItemSize = new Size(320, 190);
            tileViewOneriler.OptionsTiles.ColumnCount = 4;
            tileViewOneriler.OptionsTiles.ItemPadding = new Padding(14);
            tileViewOneriler.OptionsTiles.Padding = new Padding(18);
            tileViewOneriler.OptionsTiles.IndentBetweenItems = 16;
        }


        
        private async Task OnerileriYukleAsync(bool force)
        {
            
            if (!force && _onerilerIlkYuklemeYapildi)
                return;

            _onerilerIlkYuklemeYapildi = true;

            try
            {
                if (AktifOgrenciID <= 0) return;

                OnerilerTileViewHazirla();

                if (_aiClient == null)
                    _aiClient = new GeminiAiClient();

                DataTable dtGecmis = _ogrenciService.OkumaGecmisiGetir(AktifOgrenciID);

                
                DataTable dtAday = _kitapService.AdayKitaplariGetir(80);

                
                string favoriTur = _ogrenciService.EnCokOkunanTurGetir(AktifOgrenciID);

                if (!string.IsNullOrEmpty(favoriTur))
                {
                    DataRow[] filtreli = dtAday.Select($"TurAdi = '{favoriTur.Replace("'", "''")}'");
                    if (filtreli.Length > 0)
                        dtAday = filtreli.CopyToDataTable();

                   
                    if (lblOneriBaslik != null)
                        lblOneriBaslik.Text = $"Bu kitaplar önerildi çünkü {favoriTur} türünü seviyorsun";
                }
                else
                {
                    if (lblOneriBaslik != null)
                        lblOneriBaslik.Text = "AI Önerileri";
                }

                string prompt = BuildPromptForRecommendations(dtGecmis, dtAday);

                List<int> ids = null;
                try
                {
                    ids = await _aiClient.OneriIdleriGetirAsync(prompt);
                }
                catch
                {
                    ids = null;
                }

                
                if (ids == null || ids.Count == 0)
                {
                    ids = new List<int>();
                    var rnd = new Random();
                    var pool = new List<int>();

                    foreach (DataRow r in dtAday.Rows)
                        pool.Add(Convert.ToInt32(r["IDKitap"]));

                    while (pool.Count > 0 && ids.Count < 5)
                    {
                        int index = rnd.Next(pool.Count);
                        ids.Add(pool[index]);
                        pool.RemoveAt(index);
                    }
                }

                
                DataTable dtShow = new DataTable();
                dtShow.Columns.Add("IDKitap", typeof(int));
                dtShow.Columns.Add("KitapAdi", typeof(string));
                dtShow.Columns.Add("YazarAdi", typeof(string));
                dtShow.Columns.Add("TurAdi", typeof(string));

                foreach (int id in ids)
                {
                    DataRow[] found = dtAday.Select("IDKitap=" + id);
                    if (found.Length == 0) continue;

                    DataRow nr = dtShow.NewRow();
                    nr["IDKitap"] = id;
                    nr["KitapAdi"] = found[0]["KitapAdi"];
                    nr["YazarAdi"] = found[0]["YazarAdi"];
                    nr["TurAdi"] = found[0]["TurAdi"];
                    dtShow.Rows.Add(nr);
                }

                grdOneriler.DataSource = dtShow;
                grdOneriler.RefreshDataSource();

                
                tileViewOneriler.PopulateColumns();

                
                EnsureKapakUnboundColumn();

                
                OnerilerTileTemplateKur_Resimli_FINAL();

                tileViewOneriler.RefreshData();
                grdOneriler.Refresh();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AI Hata");
                if (lblOneriBaslik != null)
                    lblOneriBaslik.Text = "AI Önerileri";
            }
        }

        private void OnerilerTileViewHazirla()
        {
            if (_onerilerHazirlandi) return;
            _onerilerHazirlandi = true;

            if (tileViewOneriler.GridControl == null)
                tileViewOneriler.GridControl = grdOneriler;

            if (grdOneriler.MainView != tileViewOneriler)
                grdOneriler.MainView = tileViewOneriler;

            tileViewOneriler.OptionsTiles.Orientation = Orientation.Vertical;

            
            tileViewOneriler.OptionsTiles.ItemSize = new Size(320, 190);
            tileViewOneriler.OptionsTiles.ColumnCount = 4;
            tileViewOneriler.OptionsTiles.ItemPadding = new Padding(14);
            tileViewOneriler.OptionsTiles.Padding = new Padding(18);
            tileViewOneriler.OptionsTiles.IndentBetweenItems = 16;

            
            tileViewOneriler.CustomUnboundColumnData -= tileViewOneriler_CustomUnboundColumnData;
            tileViewOneriler.CustomUnboundColumnData += tileViewOneriler_CustomUnboundColumnData;

            tileViewOneriler.ItemClick -= tileViewOneriler_ItemClick;
            tileViewOneriler.ItemClick += tileViewOneriler_ItemClick;
        }
        void LabeliOrtala()
        {
            

            lblBaslik.Left = (panelBaslik.Width - lblBaslik.Width) / 2;
            
        }
        void FavoriBaslikOrtala()
        {
          
            lblFavoriBaslik.Left = (panelFavoriBaslik.Width - lblFavoriBaslik.Width) / 2;
        }

        private async void btnOneriYenile_Click(object sender, EventArgs e)
        {
            await OnerileriYukleAsync(force: true);
        }

        private void grdOneriler_Click(object sender, EventArgs e)
        {

        }
        private void panelBaslik_SizeChanged(object sender, EventArgs e)
        {
            LabeliOrtala();
        }
        private void panelFavoriBaslik_SizeChanged(object sender, EventArgs e)
        {
            FavoriBaslikOrtala();
        }
        private void FrmAnaSayfaOgrenci_Load_1(object sender, EventArgs e)
        {
            LabeliOrtala();
        }
    }
}
