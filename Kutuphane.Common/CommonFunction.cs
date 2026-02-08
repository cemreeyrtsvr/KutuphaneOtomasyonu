using System.Windows.Forms;
using System.IO;

namespace KutuphaneOtomasyon.Kutuphane.Common
{
    /// <summary>
    /// Proje genelindeki ortak fonksiyonlar (Dosya yolları vb.)
    /// </summary>
    public static class CommonFunction
    {
        /// <summary>
        /// Rapor dosyalarının bulunduğu klasör yolunu döndürür.
        /// </summary>
        public static string GetReportDirectoryPath()
        {
            // Debug/bin klasörü içindeki 'Reports' klasörünü hedefler
            string path = Path.Combine(Application.StartupPath, "Reports");

            // Klasör yoksa oluştursun (Garanti olsun)
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        /// <summary>
        /// Şablon dosyalarının bulunduğu klasör yolunu döndürür.
        /// </summary>
        public static string GetTemplateDirectoryPath()
        {
            string path = Path.Combine(Application.StartupPath, "Templates");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}