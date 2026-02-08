using System.Data;

namespace KutuphaneOtomasyonu.Kutuphane.Interface
{
    /// <summary>
    /// Personel modülü işlemleri için arayüz (Sözleşme).
    /// </summary>
    public interface IPersonel
    {
        /// <summary>
        /// Kullanıcı adı ve şifre kontrolü yapar.
        /// </summary>
        /// <param name="kadi">Kullanıcı Adı</param>
        /// <param name="sifre">Şifre</param>
        /// <returns>Bulunan personelin bilgilerini tablo olarak döner.</returns>
        DataTable GirisYap(string kadi, string sifre);

        /// <summary>
        /// Yeni personel kaydı oluşturur.
        /// </summary>
        /// <param name="kadi">Kullanıcı Adı</param>
        /// <param name="sifre">Şifre</param>
        /// <returns>Hata varsa hata mesajı döner, işlem başarılıysa NULL döner.</returns>
        string KayitOl(string kadi, string sifre);
    }
}