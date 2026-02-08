using DevExpress.XtraEditors;
using KutuphaneOtomasyonu.Kutuphane.Service;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    public partial class FrmKitapDetay : XtraForm
    {
        public int AktifOgrenciID { get; set; }
        public int IDKitap { get; set; }

        private readonly SKitap _kitapService = new SKitap();
        private static readonly HttpClient _http = new HttpClient();

        private static readonly System.Collections.Generic.Dictionary<string, Image> _memoryCache
            = new System.Collections.Generic.Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);

        private bool _isFavori;

        public FrmKitapDetay()
        {
            InitializeComponent();
            Load += FrmKitapDetay_Load;
        }

        private async void FrmKitapDetay_Load(object sender, EventArgs e)
        {
            try
            {
                if (IDKitap <= 0)
                {
                    XtraMessageBox.Show("Kitap bilgisi bulunamadı (IDKitap geçersiz).", "Uyarı");
                    Close();
                    return;
                }

                KitapDetayYukle();

                // Favori butonu (öğrenci yoksa disable)
                if (AktifOgrenciID <= 0)
                {
                    btnFavori.Enabled = false;
                }
                else
                {
                    _isFavori = _kitapService.FavoriMi(AktifOgrenciID, IDKitap);
                    FavoriButonGorunumUygula();
                }

                await KapakYukleISBN();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hata");
            }
        }

        private void KitapDetayYukle()
        {
            DataRow row = _kitapService.KitapDetayGetir(IDKitap);
            if (row == null)
            {
                XtraMessageBox.Show("Kitap detayı bulunamadı.", "Uyarı");
                Close();
                return;
            }

            lblKitapAdi.Text = row["KitapAdi"]?.ToString();
            lblYazar.Text = row["YazarAdi"]?.ToString();
            lblTur.Text = row["TurAdi"]?.ToString();
            lblISBN.Text = row["ISBN"]?.ToString();
            lblStok.Text = row["Stok"]?.ToString();
            lblDurum.Text = row["Durum"]?.ToString();

            int stok = 0;
            int.TryParse(lblStok.Text, out stok);
            btnOduncAl.Enabled = (stok > 0 && AktifOgrenciID > 0);

            if (picKapak.Image == null)
                picKapak.Image = CreatePlaceholderImage(lblKitapAdi.Text);
        }

        // ==========================
        // FAVORİ TOGGLE
        // ==========================
        private void btnFavori_Click(object sender, EventArgs e)
        {
            try
            {
                if (AktifOgrenciID <= 0 || IDKitap <= 0)
                    return;

                string hata;
                bool yeniDurum = _kitapService.FavoriToggle(AktifOgrenciID, IDKitap, out hata);

                if (!string.IsNullOrWhiteSpace(hata))
                {
                    XtraMessageBox.Show(hata, "Hata");
                    return;
                }

                _isFavori = yeniDurum;
                FavoriButonGorunumUygula();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hata");
            }
        }

        private void FavoriButonGorunumUygula()
        {
            try
            {
                // DevExpress SimpleButton varsayımı
                if (_isFavori)
                {
                    btnFavori.Text = "★ Favorilerde";
                    btnFavori.Appearance.BackColor = Color.FromArgb(255, 245, 230);
                    btnFavori.Appearance.ForeColor = Color.FromArgb(200, 120, 0);
                }
                else
                {
                    btnFavori.Text = "☆ Favoriye Ekle";
                    btnFavori.Appearance.BackColor = Color.FromArgb(240, 245, 255);
                    btnFavori.Appearance.ForeColor = Color.FromArgb(45, 110, 230);
                }

                btnFavori.Appearance.Options.UseBackColor = true;
                btnFavori.Appearance.Options.UseForeColor = true;
                btnFavori.Cursor = Cursors.Hand;
            }
            catch
            {
            }
        }

        // ==========================
        // ÖDÜNÇ AL
        // ==========================
        private void btnOduncAl_Click(object sender, EventArgs e)
        {
            try
            {
                if (AktifOgrenciID <= 0)
                {
                    XtraMessageBox.Show("Öğrenci bilgisi bulunamadı.", "Uyarı");
                    return;
                }

                int stok = 0;
                int.TryParse(lblStok.Text, out stok);
                if (stok <= 0)
                {
                    XtraMessageBox.Show("Bu kitap şu an stokta yok.", "Uyarı");
                    return;
                }

                string hata = _kitapService.OduncVer(IDKitap, AktifOgrenciID, DateTime.Now);
                if (!string.IsNullOrWhiteSpace(hata))
                {
                    XtraMessageBox.Show(hata, "Uyarı");
                    return;
                }

                XtraMessageBox.Show("Kitap ödünç alındı ✅", "Bilgi");

                stok = Math.Max(0, stok - 1);
                lblStok.Text = stok.ToString();
                btnOduncAl.Enabled = stok > 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hata");
            }
        }

        // ==========================
        // KAPAK (Cache + OpenLibrary + Google)
        // ==========================
        private async Task KapakYukleISBN()
        {
            string isbn = (lblISBN.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(isbn))
                return;

            if (_memoryCache.TryGetValue(isbn, out Image memImg) && memImg != null)
            {
                picKapak.Image = (Image)memImg.Clone();
                return;
            }

            string cacheDir = Path.Combine(Application.StartupPath, "Cache", "Kapaklar");
            Directory.CreateDirectory(cacheDir);
            string cachePath = Path.Combine(cacheDir, isbn + ".jpg");

            if (File.Exists(cachePath))
            {
                Image diskImg = TryLoadImageFromDisk(cachePath);
                if (diskImg != null)
                {
                    picKapak.Image = diskImg;
                    _memoryCache[isbn] = (Image)diskImg.Clone();
                    return;
                }

                try { File.Delete(cachePath); } catch { }
            }

            byte[] bytes = await TryDownloadBytes($"https://covers.openlibrary.org/b/isbn/{isbn}-L.jpg");
            if (bytes == null || bytes.Length < 1000)
                bytes = await TryDownloadBytes($"https://covers.openlibrary.org/b/isbn/{isbn}-M.jpg");

            if (bytes == null || bytes.Length < 1000)
            {
                string googleUrl = await GoogleBooksThumbnailUrlByIsbn(isbn);
                if (!string.IsNullOrWhiteSpace(googleUrl))
                    bytes = await TryDownloadBytes(googleUrl);
            }

            if (bytes == null || bytes.Length < 1000)
                return;

            try { File.WriteAllBytes(cachePath, bytes); } catch { }

            try
            {
                using (var ms = new MemoryStream(bytes))
                {
                    Image img = Image.FromStream(ms);
                    picKapak.Image = img;
                    _memoryCache[isbn] = (Image)img.Clone();
                }
            }
            catch
            {
            }
        }

        private async Task<byte[]> TryDownloadBytes(string url)
        {
            try
            {
                using (var resp = await _http.GetAsync(url))
                {
                    if (!resp.IsSuccessStatusCode)
                        return null;

                    return await resp.Content.ReadAsByteArrayAsync();
                }
            }
            catch
            {
                return null;
            }
        }

        private async Task<string> GoogleBooksThumbnailUrlByIsbn(string isbn)
        {
            try
            {
                string api = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}&maxResults=1";
                using (var resp = await _http.GetAsync(api))
                {
                    if (!resp.IsSuccessStatusCode)
                        return null;

                    string json = await resp.Content.ReadAsStringAsync();

                    // JSON lib yoksa regex ile thumbnail yakala
                    Match m = Regex.Match(json, "\"thumbnail\"\\s*:\\s*\"(?<u>[^\"\\\\]+)\"");
                    if (!m.Success)
                        return null;

                    return m.Groups["u"].Value.Replace("\\u0026", "&");
                }
            }
            catch
            {
                return null;
            }
        }

        private Image TryLoadImageFromDisk(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;

                    using (var tmp = Image.FromStream(ms))
                    {
                        return (Image)tmp.Clone();
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private Image CreatePlaceholderImage(string title)
        {
            Bitmap bmp = new Bitmap(320, 420);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(245, 247, 250));

                using (Pen pen = new Pen(Color.FromArgb(210, 218, 230)))
                    g.DrawRectangle(pen, 8, 8, bmp.Width - 16, bmp.Height - 16);

                string text = string.IsNullOrWhiteSpace(title) ? "Kapak Yok" : title;
                using (Font f = new Font("Tahoma", 11f, FontStyle.Bold))
                using (Brush br = new SolidBrush(Color.FromArgb(60, 70, 90)))
                {
                    RectangleF r = new RectangleF(20, 40, bmp.Width - 40, bmp.Height - 80);
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(text, f, br, r, sf);
                }

                using (Font f2 = new Font("Tahoma", 8.5f, FontStyle.Regular))
                using (Brush br2 = new SolidBrush(Color.Gray))
                {
                    g.DrawString("No cover image", f2, br2, new PointF(20, bmp.Height - 35));
                }
            }
            return bmp;
        }

        // Designer event stubları (hata vermesin)
        private void picKapak_EditValueChanged(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
