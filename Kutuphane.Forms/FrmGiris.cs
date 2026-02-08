using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu.Kutuphane.Forms
{
    public partial class FrmGiris : XtraForm
    {
        private Panel panelCard;

        // ✅ Arka plan cache (ilk decode 1 kez)
        private static Image _bgCached;
        private static readonly object _bgLock = new object();

        public FrmGiris()
        {
            InitializeComponent();

            // ✅ Flicker azaltma
            this.DoubleBuffered = true;

            // Mevcut davranışın kalsın
            this.FormClosed += FrmGiris_FormClosed;

            // Resize event’in designer’dan bağlı değilse burası garanti eder
            this.Resize -= FrmGiris_Resize;
            this.Resize += FrmGiris_Resize;
        }

        // ✅ İlk gösterimde ortala (UI hazırken)
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            CenterCard();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            
            EnsureBackgroundCached();

            // Arka plan ayarı
            peArkaPlan.Dock = DockStyle.Fill;
            peArkaPlan.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;

            // Cache'ten ver (yeniden decode olmasın)
            if (_bgCached != null)
                peArkaPlan.Image = _bgCached;

            
            this.SuspendLayout();
            peArkaPlan.SuspendLayout();

            BuildCard();

            peArkaPlan.ResumeLayout(true);
            this.ResumeLayout(true);

            
            BeginInvoke(new Action(CenterCard));
        }

       
        private void EnsureBackgroundCached()
        {
            if (_bgCached != null) return;

            lock (_bgLock)
            {
                if (_bgCached != null) return;

                
                if (peArkaPlan.Image != null)
                {
                    _bgCached = new Bitmap(peArkaPlan.Image);
                }
            }
        }

        
        private void BuildCard()
        {
            // Eğer Load tekrar çağrılırsa iki kere eklemesin
            if (panelCard != null && !panelCard.IsDisposed)
            {
                panelCard.Dispose();
                panelCard = null;
            }

            panelCard = new Panel();
            panelCard.Size = new Size(700, 420);
            panelCard.BackColor = Color.White;
            panelCard.Parent = peArkaPlan;
            panelCard.Anchor = AnchorStyles.None;

            

            panelCard.BringToFront();

           
            Panel panelHeader = new Panel();
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 110;
            panelHeader.BackColor = Color.Transparent;

            LabelControl lblBaslik = new LabelControl();
            lblBaslik.Text = "KÜTÜPHANE OTOMASYON SİSTEMİ";
            lblBaslik.Appearance.Font = new Font("Tahoma", 18F, FontStyle.Bold);
            lblBaslik.Appearance.ForeColor = Color.Teal;
            lblBaslik.AutoSizeMode = LabelAutoSizeMode.None;
            lblBaslik.Dock = DockStyle.Top;
            lblBaslik.Height = 60;
            lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblBaslik.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            LabelControl lblAlt = new LabelControl();
            lblAlt.Text = "Öğrenci ve personel işlemlerini hızlıca yönetin.";
            lblAlt.Appearance.Font = new Font("Tahoma", 10F);
            lblAlt.Appearance.ForeColor = Color.Gray;
            lblAlt.AutoSizeMode = LabelAutoSizeMode.None;
            lblAlt.Dock = DockStyle.Top;
            lblAlt.Height = 30;
            lblAlt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblAlt.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            panelHeader.Controls.Add(lblAlt);
            panelHeader.Controls.Add(lblBaslik);
            panelCard.Controls.Add(panelHeader);

            // ===== BUTONLAR =====
            int btnW = 250;
            int btnH = 65;

            PrepareButton(btnPersonelGirisi);
            btnPersonelGirisi.Parent = panelCard;
            btnPersonelGirisi.Size = new Size(btnW, btnH);
            btnPersonelGirisi.Text = "PERSONEL GİRİŞİ";

            PrepareButton(btnOgrenciGirisi);
            btnOgrenciGirisi.Parent = panelCard;
            btnOgrenciGirisi.Size = new Size(btnW, btnH);
            btnOgrenciGirisi.Text = "ÖĞRENCİ GİRİŞİ";

            // Konumlar
            btnPersonelGirisi.Location = new Point((panelCard.Width - btnW) / 2, 160);
            btnOgrenciGirisi.Location = new Point((panelCard.Width - btnW) / 2, 280);

            // ✅ 3) Yuvarlak köşe region’u sadece gerektiğinde uygula
            ApplyRoundedRegion();
            panelCard.SizeChanged += (s, e) => ApplyRoundedRegion();
        }

        private void ApplyRoundedRegion()
        {
            if (panelCard == null || panelCard.IsDisposed) return;
            if (panelCard.Width <= 0 || panelCard.Height <= 0) return;

            int radius = 20;

            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle r = panelCard.ClientRectangle;
                r.Width--; r.Height--;

                path.AddArc(r.X, r.Y, radius, radius, 180, 90);
                path.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90);
                path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                panelCard.Region?.Dispose();
                panelCard.Region = new Region(path);
            }
        }

        
        private void CenterCard()
        {
            if (panelCard == null || panelCard.IsDisposed) return;

            panelCard.Left = (peArkaPlan.Width - panelCard.Width) / 2;
            panelCard.Top = (peArkaPlan.Height - panelCard.Height) / 2;
        }

        private void FrmGiris_Resize(object sender, EventArgs e)
        {
            CenterCard();
        }

        
        private void PrepareButton(SimpleButton btn)
        {
            btn.Appearance.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            btn.Appearance.BackColor = Color.White;
            btn.Appearance.ForeColor = Color.Black;
            btn.Appearance.Options.UseBackColor = true;
            btn.Appearance.Options.UseForeColor = true;
            btn.Appearance.Options.UseFont = true;

            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.LookAndFeel.UseDefaultLookAndFeel = false;

            btn.MouseEnter += (s, e) =>
            {
                btn.Appearance.BackColor = Color.Teal;
                btn.Appearance.ForeColor = Color.White;
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.Appearance.BackColor = Color.White;
                btn.Appearance.ForeColor = Color.Black;
            };
        }

        
        private void FrmGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

     
        private void btnPersonelGirisi_Click(object sender, EventArgs e)
        {
            new FrmPersonelGiris().Show();
            this.Hide();
        }

        private void btnOgrenciGirisi_Click(object sender, EventArgs e)
        {
            new FrmOgrenciGiris().Show();
            this.Hide();
        }
    }
}
