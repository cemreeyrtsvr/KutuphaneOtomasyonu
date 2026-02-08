using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;
using KutuphaneOtomasyonu.Kutuphane.Service;

namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    /// <summary>
    /// Öğrenci kayıt işlemlerini yöneten form sınıfı.
    /// </summary>
    public partial class FrmOgrenciKayit : XtraForm
    {
        private readonly SOgrenci _ogrenciService = new SOgrenci();

        public FrmOgrenciKayit()
        {
            InitializeComponent();

            // ✅ Geri dön click garanti (Designer'da bağlı değilse bile çalışsın)
            btnGeriDon.Click -= btnGeriDon_Click;
            btnGeriDon.Click += btnGeriDon_Click;
        }

        private void FrmOgrenciKayit_Load(object sender, EventArgs e)
        {
            // ✅ Şifre ayarları
            txtSifre.Properties.UseSystemPasswordChar = true;
            txtSifreTekrar.Properties.UseSystemPasswordChar = true;

            // ✅ Geri dön butonu: PictureEdit üstünde saydam
            MakeButtonTransparentOnPictureEdit(btnGeriDon, pictureEdit1);

            // İstersen konum sabitle
            btnGeriDon.Location = new Point(10, 10);
            btnGeriDon.BringToFront();
        }

        // =====================================================
        // ✅ PictureEdit üstünde "GERÇEK" saydam buton (DevExpress)
        // =====================================================
        private void MakeButtonTransparentOnPictureEdit(SimpleButton btn, PictureEdit pic)
        {
            if (btn == null || pic == null) return;

            // 1) Eski konumu ekran koordinatıyla al (parent değişince kaymasın)
            Point screenPos = btn.PointToScreen(Point.Empty);

            // 2) Parent değiştir
            btn.Parent = pic;

            // 3) Yeni parent'a göre konumu geri hesapla
            btn.Location = pic.PointToClient(screenPos);

            // 4) Saydam arka plan + border kapat
            btn.Appearance.BackColor = Color.Transparent;
            btn.Appearance.Options.UseBackColor = true;

            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btn.LookAndFeel.UseDefaultLookAndFeel = false;

            // 5) Hover/Press anında da beyaz basmasın
            btn.AppearanceHovered.BackColor = Color.Transparent;
            btn.AppearanceHovered.Options.UseBackColor = true;

            btn.AppearancePressed.BackColor = Color.Transparent;
            btn.AppearancePressed.Options.UseBackColor = true;

            // 6) PictureEdit arka planı ile uyum (bazı temalarda fark eder)
            pic.Properties.Appearance.BackColor = Color.Transparent;
            pic.Properties.Appearance.Options.UseBackColor = true;

            btn.BringToFront();
        }

        // =====================================================
        // ✅ Kayıt Ol
        // =====================================================
        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            lblHata.Text = "";
            lblHata.Visible = false;

            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text) ||
                string.IsNullOrWhiteSpace(txtSifreTekrar.Text) ||
                string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                ShowError("Lütfen Ad Soyad, Kullanıcı Adı ve Şifre alanlarını doldurunuz!");
                return;
            }

            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                ShowError("Şifreler uyuşmuyor!");
                txtSifre.Text = "";
                txtSifreTekrar.Text = "";
                txtSifre.Focus();
                return;
            }

            try
            {
                string sonuc = _ogrenciService.KayitOl(
                    txtKullaniciAdi.Text.Trim(),
                    txtSifre.Text.Trim(),
                    txtMail.Text.Trim(),
                    txtAdSoyad.Text.Trim()
                );

                // Senin serviste: null => başarılı
                if (sonuc == null)
                {
                    XtraMessageBox.Show(
                        "Kaydınız başarıyla oluşturuldu! Giriş yapabilirsiniz.",
                        "Tebrikler",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // ✅ Kayıt ekranını kapatınca arka form (Öğrenci Giriş) zaten görünür kalır
                    this.Close();
                }
                else
                {
                    ShowError(sonuc);

                    if (sonuc.ToLower().Contains("kullanıcı adı"))
                    {
                        txtKullaniciAdi.Text = "";
                        txtKullaniciAdi.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Beklenmedik bir hata: " + ex.Message);
            }
        }

        private void ShowError(string message)
        {
            lblHata.Visible = true;
            lblHata.Text = message;
        }

        // =====================================================
        // ✅ GERİ DÖN (Çalışmama sorununu kesin çözer)
        // =====================================================
        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            // Bu form genelde "FrmOgrenciGiris" üstünden açılıyor.
            // O form kapatılmadıysa zaten arkada duruyor -> sadece kapatmak yeter.
            this.Close();
        }

        // Eğer şifre textboxında göz ikonu varsa:
        private void txtSifre_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSifre.Properties.UseSystemPasswordChar = !txtSifre.Properties.UseSystemPasswordChar;
        }

        private void txtSifreTekrar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSifreTekrar.Properties.UseSystemPasswordChar = !txtSifreTekrar.Properties.UseSystemPasswordChar;
        }
    }
}
