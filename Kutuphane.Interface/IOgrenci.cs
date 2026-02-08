using System.Data;

namespace KutuphaneOtomasyonu.Kutuphane.Interface
{
    /// <summary>
    /// Öğrenci modülü işlemleri için arayüz (Sözleşme).
    /// </summary>
    public interface IOgrenci
    {
        /// <summary>
        /// Kullanıcı adı ve şifreye göre öğrenci giriş kontrolü yapar.
        /// </summary>
        /// <param name="kadi">Kullanıcı Adı</param>
        /// <param name="sifre">Şifre</param>
        /// <returns>Eşleşen öğrenci kaydını içeren tablo döner.</returns>
        DataTable GirisYap(string kadi, string sifre);

        /// <summary>
        /// Sisteme yeni bir öğrenci kaydı oluşturur.
        /// </summary>
        /// <param name="kadi">Kullanıcı Adı</param>
        /// <param name="sifre">Şifre</param>
        /// <param name="mail">Öğrenci Mail Adresi</param>
        /// <param name="adSoyad">Öğrenci Adı ve Soyadı</param>
        /// <returns>Hata varsa hata mesajı, işlem başarılıysa NULL döner.</returns>
        string KayitOl(string kadi, string sifre, string mail, string adSoyad);

        /// <summary>
        /// ID'si verilen öğrencinin Ad Soyad bilgisini getirir.
        /// (Ana ekranda "Hoşgeldin Ahmet" yazmak için kullanılır).
        /// </summary>
        /// <param name="id">Öğrenci ID</param>
        /// <returns>Ad Soyad metni döner.</returns>
        string AdSoyadGetir(int id);

        /// <summary>
        /// Öğrencinin iletişim bilgilerini (Mail) getirir.
        /// </summary>
        /// <param name="ogrenciID">Öğrenci ID</param>
        /// <returns>KullanıcıAdi ve Mail içeren DataRow döner.</returns>
        DataRow OgrenciIletisimBilgisiGetir(int ogrenciID);
    }
}