using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KutuphaneOtomasyonu.Kutuphane.Service;

namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    public partial class FrmPersonelGiris : XtraForm
    {
        private readonly SPersonel _personelService = new SPersonel();

        public FrmPersonelGiris()
        {
            InitializeComponent();

            // ENTER ile login
            this.AcceptButton = btnGiris;

            // ESC ile geri dön
            this.CancelButton = btnGeriDon;

            this.FormClosed += FrmPersonelGiris_FormClosed;
        }

        private void FrmPersonelGiris_Load(object sender, EventArgs e)
        {
            // Geri butonu arka plana bağla
            ButonuPictureEditParentYap(btnGeriDon, pictureEdit1);

            btnGeriDon.Location = new Point(12, 12);
            btnGeriDon.Cursor = Cursors.Hand;

            lblHata.Visible = false;
        }

        // 🔁 FORM KAPANINCA ANA GİRİŞE DÖN
        private void FrmPersonelGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is FrmGiris)
                {
                    frm.Show();
                    return;
                }
            }
        }

        // 🔐 GİRİŞ
        private void btnGiris_Click(object sender, EventArgs e)
        {
            lblHata.Visible = false;

            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                HataGoster("Kullanıcı adı veya şifre boş bırakılamaz.");
                return;
            }

            try
            {
                DataTable sonuc = _personelService.GirisYap(
                    txtKullaniciAdi.Text.Trim(),
                    txtSifre.Text.Trim()
                );

                if (sonuc != null && sonuc.Rows.Count > 0)
                {
                    FrmAnaSayfaPersonel ana = new FrmAnaSayfaPersonel();
                    ana.Show();

                    this.FormClosed -= FrmPersonelGiris_FormClosed;
                    this.Close();
                }
                else
                {
                    HataGoster("Hatalı kullanıcı adı veya şifre!");
                    txtSifre.Clear();
                    txtSifre.Focus();
                }
            }
            catch (Exception ex)
            {
                HataGoster("Sistem hatası: " + ex.Message);
            }
        }

        // 🔙 GERİ DÖN
        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 👁 ŞİFRE GÖSTER / GİZLE
        private void txtSifre_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSifre.Properties.UseSystemPasswordChar =
                !txtSifre.Properties.UseSystemPasswordChar;
        }

        // 📝 KAYIT OL
        private void lnkKayitOl_Click(object sender, EventArgs e)
        {
            FrmPersonelKayit fr = new FrmPersonelKayit();
            fr.Show();
        }

        // 🎨 HATA GÖSTER
        private void HataGoster(string mesaj)
        {
            lblHata.Text = mesaj;
            lblHata.Visible = true;
        }

        // 🖼 GERİ BUTONU ŞEFFAFLIK
        private void ButonuPictureEditParentYap(SimpleButton btn, PictureEdit pic)
        {
            Point ekranKonum = btn.PointToScreen(Point.Empty);
            btn.Parent = pic;
            btn.Location = pic.PointToClient(ekranKonum);

            btn.Appearance.BackColor = Color.Transparent;
            btn.Appearance.Options.UseBackColor = true;
            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }
    }
}
