using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    public partial class FrmOdemeDemo1 : XtraForm
    {
        public int OgrenciId { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }

        // ödeme sonucu
        public bool OdemeBasarili { get; private set; }

        public FrmOdemeDemo1()
        {
            InitializeComponent();
            Load += FrmOdemeDemo1_Load;
        }

        private void FrmOdemeDemo1_Load(object sender, EventArgs e)
        {
            // Basit modern görünüm
            Font = new Font("Tahoma", 9F);
            BackColor = Color.White;

            // Label'lar
            if (lblBaslik != null)
            {
                lblBaslik.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
                lblBaslik.Appearance.ForeColor = Color.FromArgb(30, 90, 200);
            }

            if (lblTutar != null)
            {
                lblTutar.Appearance.Font = new Font("Tahoma", 11F, FontStyle.Bold);
                lblTutar.Appearance.ForeColor = Color.FromArgb(0, 120, 0);
                lblTutar.Text = $"Ödenecek Tutar: {Tutar:n2} TL";
            }

            if (lblAciklama != null)
            {
                lblAciklama.Appearance.ForeColor = Color.DimGray;
            }

            // TextEdit hint
            if (txtKartNo != null) txtKartNo.Properties.NullValuePrompt = "Kart No (16 hane)";
            if (txtKartAdSoyad != null) txtKartAdSoyad.Properties.NullValuePrompt = "Kart Üzerindeki Ad Soyad";
            if (txtSKT != null) txtSKT.Properties.NullValuePrompt = "SKT (AA/YY)";
            if (txtCVV != null) txtCVV.Properties.NullValuePrompt = "CVV (3 hane)";

            // Maskeler (DEMO)
            if (txtKartNo != null)
            {
                txtKartNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                txtKartNo.Properties.Mask.EditMask = "0000 0000 0000 0000";
                txtKartNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            }

            if (txtSKT != null)
            {
                txtSKT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                txtSKT.Properties.Mask.EditMask = "00/00";
                txtSKT.Properties.Mask.UseMaskAsDisplayFormat = true;
            }

            if (txtCVV != null)
            {
                txtCVV.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                txtCVV.Properties.Mask.EditMask = "000";
                txtCVV.Properties.PasswordChar = '●';
            }

            // Buton renkleri
            if (btnOde != null)
            {
                btnOde.Appearance.BackColor = Color.FromArgb(40, 110, 230);
                btnOde.Appearance.ForeColor = Color.White;
                btnOde.Appearance.Options.UseBackColor = true;
                btnOde.Appearance.Options.UseForeColor = true;
                btnOde.Height = 40;
                btnOde.Click -= btnOde_Click;
                btnOde.Click += btnOde_Click;
            }

            if (btnIptal != null)
            {
                btnIptal.Appearance.BackColor = Color.FromArgb(240, 240, 240);
                btnIptal.Appearance.ForeColor = Color.Black;
                btnIptal.Appearance.Options.UseBackColor = true;
                btnIptal.Appearance.Options.UseForeColor = true;
                btnIptal.Height = 40;
                btnIptal.Click -= btnIptal_Click;
                btnIptal.Click += btnIptal_Click;
            }

            // Checkbox zorunlu (opsiyonel)
            if (chkSozlesme != null)
                chkSozlesme.Checked = true; // istersen false yap
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            OdemeBasarili = false;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOde_Click(object sender, EventArgs e)
        {
            // basit doğrulama (DEMO)
            string kartNo = (txtKartNo?.Text ?? "").Replace(" ", "").Trim();
            string adSoyad = (txtKartAdSoyad?.Text ?? "").Trim();
            string skt = (txtSKT?.Text ?? "").Trim();
            string cvv = (txtCVV?.Text ?? "").Trim();

            if (chkSozlesme != null && chkSozlesme.Checked == false)
            {
                XtraMessageBox.Show("Devam etmek için onay kutusunu işaretleyin.", "Uyarı");
                return;
            }

            if (kartNo.Length != 16)
            {
                XtraMessageBox.Show("Kart numarası 16 hane olmalı.", "Uyarı");
                return;
            }

            if (string.IsNullOrWhiteSpace(adSoyad) || adSoyad.Length < 3)
            {
                XtraMessageBox.Show("Kart üzerindeki ad soyadı girin.", "Uyarı");
                return;
            }

            if (!Regex.IsMatch(skt, @"^\d{2}/\d{2}$"))
            {
                XtraMessageBox.Show("SKT formatı AA/YY olmalı.", "Uyarı");
                return;
            }

            if (cvv.Length != 3)
            {
                XtraMessageBox.Show("CVV 3 hane olmalı.", "Uyarı");
                return;
            }

            // DEMO başarılı
            OdemeBasarili = true;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
