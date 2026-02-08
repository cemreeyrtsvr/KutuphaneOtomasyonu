using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KutuphaneOtomasyonu.Kutuphane.Service;

namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    /// <summary>
    /// Öğrenci giriş işlemlerinin yapıldığı form sınıfı.
    /// </summary>
    public partial class FrmOgrenciGiris : XtraForm
    {
        private readonly SOgrenci _ogrenciService = new SOgrenci();

        public FrmOgrenciGiris()
        {
            InitializeComponent();

           
            this.DoubleBuffered = true;

            this.FormClosed += FrmOgrenciGiris_FormClosed;
        }

        private void FrmOgrenciGiris_Load(object sender, EventArgs e)
        {
            
            ButonuPictureEditParentYap(btnGeriDon, pictureEdit1);

            
            HazirlaKart();

            
            this.AcceptButton = btnGiris;
        }

        
        private void HazirlaKart()
        {
            
            Control kart = grpGiris; 
            if (kart == null) return;

            

            kart.BackColor = Color.FromArgb(245, 245, 245);

            // Ortala
            kart.Left = (ClientSize.Width - kart.Width) / 2;
            kart.Top = (ClientSize.Height - kart.Height) / 2;

            kart.Anchor = AnchorStyles.None;

            
        }

        
        private void ButonuPictureEditParentYap(SimpleButton btn, PictureEdit pic)
        {
            if (btn == null || pic == null) return;

           
            btn.Parent = pic;
           
            btn.Appearance.BackColor = Color.Transparent;
            btn.Appearance.Options.UseBackColor = true;
            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }

        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                XtraMessageBox.Show(
                    "Lütfen kullanıcı adı ve şifreyi giriniz.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = _ogrenciService.GirisYap(
                    txtKullaniciAdi.Text.Trim(),
                    txtSifre.Text.Trim());

                if (dt != null && dt.Rows.Count > 0)
                {
                    int ogrenciId = Convert.ToInt32(dt.Rows[0]["IDOgrenci"]);
                    string ogrenciAdi = Convert.ToString(dt.Rows[0]["KullaniciAdi"]);

                    XtraMessageBox.Show(
                        $"Hoş geldin {ogrenciAdi}",
                        "Giriş Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    FrmAnaSayfaOgrenci frm = new FrmAnaSayfaOgrenci();
                    frm.AktifOgrenciID = ogrenciId;
                    frm.Show();

                    this.Hide();
                }
                else
                {
                    XtraMessageBox.Show(
                        "Hatalı kullanıcı adı veya şifre!",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    txtSifre.Text = "";
                    txtSifre.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.ToString(),
                    "Sistem Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
        private void txtSifre_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSifre.Properties.UseSystemPasswordChar =
                !txtSifre.Properties.UseSystemPasswordChar;
        }

        
        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        
        private void FrmOgrenciGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is FrmGiris)
                {
                    frm.Show();
                    return;
                }
            }

            
            new FrmGiris().Show();
        }

        private void lnkKayitOl_Click(object sender, EventArgs e)
        {
            FrmOgrenciKayit fr = new FrmOgrenciKayit();
            fr.Show();
        }
    }
}
