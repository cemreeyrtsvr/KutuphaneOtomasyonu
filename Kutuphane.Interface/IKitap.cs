using System;
using System.Collections.Generic;
using System.Data;

namespace KutuphaneOtomasyonu.Kutuphane.Interface
{
    /// <summary>
    /// Kitap modülü, İstatistikler ve Emanet işlemleri için sözleşme.
    /// </summary>
    public interface IKitap
    {
        // --- 1. KİTAP YÖNETİMİ (CRUD) ---

        /// <summary>
        /// Kitapları, yazar ve tür adlarıyla birleştirerek listeler.
        /// </summary>
        DataTable KitaplariListele();

        /// <summary>
        /// Yazarları getirir.
        /// </summary>
        DataTable YazarlariGetir();

        /// <summary>
        /// Türleri getirir.
        /// </summary>
        DataTable TurleriGetir();

        /// <summary>
        /// Yeni kitap ekler.
        /// </summary>
        string KitapEkle(string ad, string isbn, string sayfa, string stok, string yazar, string tur);

        /// <summary>
        /// Mevcut kitabı günceller.
        /// </summary>
        string KitapGuncelle(int id, string ad, string isbn, string sayfa, string stok, string yazar, string tur);

        /// <summary>
        /// Kitabı siler.
        /// </summary>
        string KitapSil(int id);

        // --- 2. EMANET (ÖDÜNÇ) YÖNETİMİ ---

        /// <summary>
        /// Ödünç verilebilir (Stoğu > 0) kitapları listeler.
        /// </summary>
        DataTable MusaitKitaplariGetir();

        /// <summary>
        /// Öğrenci listesini getirir.
        /// </summary>
        DataTable OgrencileriGetir();

        /// <summary>
        /// Henüz iade edilmemiş (Dışarıdaki) kitapları listeler.
        /// </summary>
        DataTable EmanetleriListele();

        /// <summary>
        /// Kitabı öğrenciye ödünç verir (Stok düşer).
        /// </summary>
        string OduncVer(int kitapId, int ogrenciId, DateTime tarih);

        /// <summary>
        /// Kitabı iade alır (Stok artar).
        /// </summary>
        string IadeAl(int emanetId, int kitapId, DateTime iadeTarihi, string gecikmeBedeli);

        DataTable KitapAra(string kitapAdi,int? idTur,int? idYazar,bool sadeceStokta);

        // --- 3. İSTATİSTİK ve GRAFİKLER ---

        DataTable GrafikTurGetir();
        DataTable GrafikYazarGetir();
        DataTable GrafikEnCokOkunanGetir();
        Dictionary<string, string> KartIstatistikleriniGetir();
    }
}