using KutuphaneOtomasyon.Kutuphane.Common;

using KutuphaneOtomasyonu.Kutuphane.Interface;
using System;
using System.Data;
using System.Data.SqlClient;

namespace KutuphaneOtomasyonu.Kutuphane.Service
{
    /// <summary>
    /// Personel işlemlerini yöneten servis sınıfı.
    /// </summary>
    public class SPersonel : IPersonel
    {
        /// <summary>
        /// Kullanıcı adı ve şifreye göre giriş yapar.
        /// </summary>
        public DataTable GirisYap(string kadi, string sifre)
        {
            DataTable _dt = new DataTable();

            try
            {
                using (sMan session = new sMan())
                {
                    string _query = "SELECT * FROM TblPersonel WHERE KullaniciAdi=@p1 AND Sifre=@p2";
                    SqlCommand cmd = new SqlCommand(_query, session.Connection);

                    cmd.Parameters.AddWithValue("@p1", kadi);
                    cmd.Parameters.AddWithValue("@p2", sifre);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dt);
                }
            }
            catch (Exception)
            {
                // Select işleminde hata olursa null dönebiliriz.
                return null;
            }

            return _dt;
        }

        /// <summary>
        /// Yeni personel kaydı yapar.
        /// </summary>
        public string KayitOl(string kadi, string sifre)
        {
            string _hata = null; // Standart: Hata değişkeni başta null tanımlanmalı.

            try
            {
                using (sMan session = new sMan())
                {
                    // 1. KONTROL: Kullanıcı adı daha önce alınmış mı?
                    string _kontrolQuery = "SELECT Count(*) FROM TblPersonel WHERE KullaniciAdi=@p1";
                    SqlCommand cmdKontrol = new SqlCommand(_kontrolQuery, session.Connection);
                    cmdKontrol.Parameters.AddWithValue("@p1", kadi);

                    // ExecuteScalar tek bir değer (sayı) döndürür
                    int _varMi = Convert.ToInt32(cmdKontrol.ExecuteScalar());

                    if (_varMi > 0)
                    {
                        return "Bu kullanıcı adı zaten kullanımda.";
                    }

                    // 2. İŞLEM: Kayıt Ekleme (DMLManager ile)
                    string _insertQuery = "INSERT INTO TblPersonel (KullaniciAdi, Sifre) VALUES (@p1, @p2)";

                    // Not: Connection'ı burada vermiyoruz, DMLManager session üzerinden alacak.
                    SqlCommand cmdKayit = new SqlCommand(_insertQuery);
                    cmdKayit.Parameters.AddWithValue("@p1", kadi);
                    cmdKayit.Parameters.AddWithValue("@p2", sifre);

                    // Standart: DML işlemleri DMLManager ile yapılmalı
                    DMLManager _dml = new DMLManager();
                    _dml.ExecuteDML(cmdKayit, session);
                }
            }
            catch (Exception ex)
            {
                // Hata oluşursa mesajı yakalayıp döndürüyoruz
                _hata = ex.Message;
            }

            return _hata; // Başarılıysa null, hatalıysa mesaj döner.
        }
    }
}