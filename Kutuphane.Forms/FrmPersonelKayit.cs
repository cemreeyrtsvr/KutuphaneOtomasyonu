using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;
using KutuphaneOtomasyonu.Kutuphane.Service; 

namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    /// <summary>
    /// Personel kayıt işlemlerini yöneten form sınıfı.
    /// </summary>
    public partial class FrmPersonelKayit : XtraForm
    {
       
        private SPersonel _personelService = new SPersonel();

        public FrmPersonelKayit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form yüklendiğinde çalışacak başlangıç ayarları.
        /// </summary>
        private void FrmPersonelKayit_Load(object sender, EventArgs e)
        {
            ButonuPictureEditParentYap(btnGeriDon, pctEdit);
            if (btnGeriDon.Parent != null)
            {
                btnGeriDon.BackColor = Color.Transparent;
                btnGeriDon.Location = new Point(10, 10);
            }

            // Şifre kutularını gizle
            txtSifre.Properties.UseSystemPasswordChar = true;
            txtSifreTekrar.Properties.UseSystemPasswordChar = true;
        }
        private void ButonuPictureEditParentYap(SimpleButton btn, PictureEdit pic)
        {
            // 1️⃣ Mevcut konumu ekran koordinatı olarak al
            Point eskiKonum = btn.PointToScreen(Point.Empty);

            // 2️⃣ Parent'ı PictureEdit yap
            btn.Parent = pic;

            // 3️⃣ Yeni parent'a göre konumu geri hesapla
            btn.Location = pic.PointToClient(eskiKonum);

            // 4️⃣ Arka planı TAM ŞEFFAF yap
            btn.Appearance.BackColor = Color.Transparent;
            btn.Appearance.Options.UseBackColor = true;

            // 5️⃣ Border kapat (beyaz çerçeve kalmasın)
            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }

        /// <summary>
        /// Kayıt ol butonuna tıklandığında çalışır.
        /// </summary>
        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            
            lblBilgi.Text = "";
            lblBilgi.Visible = false;

            
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text) ||
                string.IsNullOrWhiteSpace(txtSifreTekrar.Text) ||
                string.IsNullOrWhiteSpace(txtOzelKod.Text))
            {
                ShowError("Lütfen tüm alanları eksiksiz doldurunuz!");
                return;
            }

            
            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                ShowError("Şifreler uyuşmuyor! Lütfen tekrar giriniz.");
                txtSifre.Text = "";
                txtSifreTekrar.Text = "";
                txtSifre.Focus();
                return;
            }

           
            if (txtOzelKod.Text != "Yonetici2025")
            {
                ShowError("Hatalı Özel Kod! Kayıt yetkiniz yok.");
                txtOzelKod.Text = "";
                txtOzelKod.Focus();
                return;
            }

            
            try
            {
                
                string _sonuc = _personelService.KayitOl(txtKullaniciAdi.Text.Trim(), txtSifre.Text.Trim());

                
                if (_sonuc == null)
                {
                    // --- BAŞARILI ---
                    XtraMessageBox.Show("Aramıza hoş geldiniz! Kayıt başarıyla tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    
                    ShowError(_sonuc); 

                   
                    if (_sonuc.ToLower().Contains("kullanıcı adı"))
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

        /// <summary>
        /// Hata mesajlarını ekranda göstermek için yardımcı metod.
        /// </summary>
        private void ShowError(string message)
        {
            lblBilgi.Visible = true;
            lblBilgi.Text = message;
        }

        /// <summary>
        /// Formu kapatır.
        /// </summary>
        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}