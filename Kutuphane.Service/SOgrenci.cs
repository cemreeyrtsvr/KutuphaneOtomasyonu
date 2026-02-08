using KutuphaneOtomasyon.Kutuphane.Common;
using KutuphaneOtomasyonu.Kutuphane.Interface;
using System;
using System.Data;
using System.Data.SqlClient;

namespace KutuphaneOtomasyonu.Kutuphane.Service
{
    /// <summary>
    /// Öğrenci işlemleri servis sınıfı.
    /// </summary>
    public class SOgrenci : IOgrenci
    {
        /// <summary>
        /// Kullanıcı adı ve şifreye göre öğrenci giriş kontrolü yapar.
        /// </summary>
        public DataTable GirisYap(string kadi, string sifre)
        {
            DataTable dt = new DataTable();

            try
            {
                using (sMan session = new sMan())
                {
                    const string query = "SELECT * FROM TblOgrenciBilgisi WHERE KullaniciAdi=@p1 AND Sifre=@p2";
                    using (SqlCommand cmd = new SqlCommand(query, session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", kadi);
                        cmd.Parameters.AddWithValue("@p2", sifre);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch
            {
                return null;
            }

            return dt;
        }

        /// <summary>
        /// Sisteme yeni bir öğrenci kaydı oluşturur.
        /// Hata varsa hata mesajı, başarılıysa null döner.
        /// </summary>
        public string KayitOl(string kadi, string sifre, string mail, string adSoyad)
        {
            string hata = null;

            try
            {
                using (sMan session = new sMan())
                {
                    const string kontrolQuery = "SELECT COUNT(*) FROM TblOgrenciBilgisi WHERE KullaniciAdi=@p1";
                    using (SqlCommand cmdKontrol = new SqlCommand(kontrolQuery, session.Connection))
                    {
                        cmdKontrol.Parameters.AddWithValue("@p1", kadi);
                        int varMi = Convert.ToInt32(cmdKontrol.ExecuteScalar());
                        if (varMi > 0)
                            return "Bu kullanıcı adı zaten kullanımda.";
                    }

                    const string insertQuery = "INSERT INTO TblOgrenciBilgisi (KullaniciAdi, Sifre, Mail, AdSoyad) VALUES (@p1, @p2, @p3, @p4)";
                    using (SqlCommand cmdKayit = new SqlCommand(insertQuery, session.Connection))
                    {
                        cmdKayit.Parameters.AddWithValue("@p1", kadi);
                        cmdKayit.Parameters.AddWithValue("@p2", sifre);
                        cmdKayit.Parameters.AddWithValue("@p3", mail);
                        cmdKayit.Parameters.AddWithValue("@p4", adSoyad);

                        DMLManager dml = new DMLManager();
                        dml.ExecuteDML(cmdKayit, session);
                    }
                }
            }
            catch (Exception ex)
            {
                hata = ex.Message;
            }

            return hata;
        }

        /// <summary>
        /// ID'si verilen öğrencinin Ad Soyad bilgisini getirir.
        /// </summary>
        public string AdSoyadGetir(int id)
        {
            string isim = string.Empty;

            try
            {
                using (sMan session = new sMan())
                {
                    const string sql = "SELECT AdSoyad FROM TblOgrenciBilgisi WHERE IDOgrenci = @p1";
                    using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", id);

                        object sonuc = cmd.ExecuteScalar();
                        if (sonuc != null && sonuc != DBNull.Value)
                            isim = sonuc.ToString();
                    }
                }
            }
            catch
            {
                // boş dönsün
            }

            return isim;
        }

        /// <summary>
        /// Öğrencinin iletişim bilgilerini getirir.
        /// </summary>
        public DataRow OgrenciIletisimBilgisiGetir(int ogrenciID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (sMan session = new sMan())
                {
                    const string sql = "SELECT KullaniciAdi, Mail FROM TblOgrenciBilgisi WHERE IDOgrenci = @p1";
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, session.Connection))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@p1", ogrenciID);
                        da.Fill(dt);
                    }

                    if (dt.Rows.Count > 0)
                        return dt.Rows[0];
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        /// <summary>
        /// Kullanıcı adı ve şifreye göre öğrenci ID döndürür.
        /// </summary>
        public int OgrenciIDGetir(string kadi, string sifre)
        {
            try
            {
                using (sMan db = new sMan())
                {
                    const string sorgu = "SELECT IDOgrenci FROM TblOgrenciBilgisi WHERE KullaniciAdi = @p1 AND Sifre = @p2";
                    using (SqlCommand cmd = new SqlCommand(sorgu, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", kadi);
                        cmd.Parameters.AddWithValue("@p2", sifre);

                        object sonuc = cmd.ExecuteScalar();
                        if (sonuc != null && sonuc != DBNull.Value)
                            return Convert.ToInt32(sonuc);
                    }
                }
            }
            catch
            {
                // 0 dönsün
            }

            return 0;
        }

        /// <summary>
        /// Öğrencinin üzerinde olan (teslim edilmemiş) kitapları getirir.
        /// AlisTarihi + 15 gün hesabıyla TeslimGerekenTarih kolonunu döndürür.
        /// </summary>
        public DataTable UzerimdekileriGetir(int ogrenciID)
        {
            const string sorgu = @"
                SELECT 
                    K.IDKitap,
                    K.KitapAdi,
                    E.AlisTarihi,
                    DATEADD(DAY, 15, E.AlisTarihi) AS TeslimGerekenTarih
                FROM TblEmanet E
                INNER JOIN TblKitaplar K ON E.IDKitap = K.IDKitap
                WHERE E.IDOgrenci = @p1
                  AND E.IslemDurumu = 1
                  AND E.TeslimTarihi IS NULL
                ORDER BY E.AlisTarihi DESC";

            DataTable dt = new DataTable();

            try
            {
                using (sMan db = new sMan())
                using (SqlCommand cmd = new SqlCommand(sorgu, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@p1", ogrenciID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch
            {
                return new DataTable();
            }

            return dt;
        }

        /// <summary>
        /// Öğrencinin üzerinde olan (teslim edilmemiş) kitap sayısını ve en yakın teslim tarihini döndürür.
        /// </summary>
        public DataRow UzerimdekilerOzetGetir(int ogrenciID)
        {
            const string sql = @"
        SELECT 
            COUNT(*) AS KitapSayisi,
            MIN(DATEADD(DAY, 15, E.AlisTarihi)) AS EnYakinTeslim
        FROM TblEmanet E
        WHERE E.IDOgrenci = @p1
          AND E.IslemDurumu = 1
          AND E.TeslimTarihi IS NULL";

            DataTable dt = new DataTable();

            try
            {
                using (sMan session = new sMan())
                using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                {
                    cmd.Parameters.AddWithValue("@p1", ogrenciID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
            }
            catch
            {
                return null;
            }

            return null;
        }
        /// <summary>
        /// Öğrencinin okuma geçmişini (teslim edilmiş kitaplar) getirir.
        /// </summary>
        public DataTable OkumaGecmisiGetir(int ogrenciID)
        {
            DataTable dt = new DataTable();

            string sql = @"
        SELECT
            K.KitapAdi,
            E.AlisTarihi,
            E.TeslimTarihi
        FROM TblEmanet E
        INNER JOIN TblKitaplar K ON K.IDKitap = E.IDKitap
        WHERE E.IDOgrenci = @p1
          AND E.TeslimTarihi IS NOT NULL
        ORDER BY E.TeslimTarihi DESC
    ";

            try
            {
                using (sMan db = new sMan())
                using (SqlCommand cmd = new SqlCommand(sql, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@p1", ogrenciID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch
            {
                return new DataTable();
            }

            return dt;
        }
        public string EnCokOkunanTurGetir(int ogrenciId)
        {
            try
            {
                using (sMan session = new sMan())
                {
                    string sql = @"
            SELECT TOP 1 T.TurAdi, COUNT(*) AS Sayi
            FROM TblEmanet E
            INNER JOIN TblKitaplar K ON K.IDKitap = E.IDKitap
            INNER JOIN TblTur T ON T.IDTur = K.IDTur
            WHERE E.IDOgrenci = @p1
              AND E.TeslimTarihi IS NOT NULL
            GROUP BY T.TurAdi
            ORDER BY COUNT(*) DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", ogrenciId);
                        object sonuc = cmd.ExecuteScalar();
                        return sonuc?.ToString();
                    }
                }
            }
            catch
            {
                return null;
            }
        }


    }
}
