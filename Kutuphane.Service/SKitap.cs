using KutuphaneOtomasyon.Kutuphane.Common;

using KutuphaneOtomasyonu.Kutuphane.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu.Kutuphane.Service
{
    /// <summary>
    /// Kitap, Emanet ve İstatistik işlemlerini yürüten servis sınıfı.
    /// </summary>
    public class SKitap : IKitap
    {
        // --- KİTAP İŞLEMLERİ ---

        public DataTable KitaplariListele()
        {
            DataTable _dt = new DataTable();
            try
            {
                using (sMan session = new sMan())
                {
                    string _sql = @"SELECT k.IDKitap, k.KitapAdi, k.SayfaSayisi, k.Stok, k.ISBN,
                                           y.YazarAdi, t.TurAdi      
                                    FROM TblKitaplar k
                                    INNER JOIN TblYazarlar y ON k.IDYazar = y.IDYazar    
                                    INNER JOIN TblTur t ON k.IDTur = t.IDTur";
                    SqlDataAdapter da = new SqlDataAdapter(_sql, session.Connection);
                    da.Fill(_dt);
                }
            }
            catch { return null; }
            return _dt;
        }

        public DataTable YazarlariGetir()
        {
            DataTable dt = new DataTable();
            try
            {
                using (sMan session = new sMan())
                {
                    // ✅ IDYazar + YazarAdi
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT IDYazar, YazarAdi FROM TblYazarlar ORDER BY YazarAdi",
                        session.Connection
                    );
                    da.Fill(dt);
                }
            }
            catch { return null; }
            return dt;
        }

        public DataTable TurleriGetir()
        {
            DataTable dt = new DataTable();
            try
            {
                using (sMan session = new sMan())
                {
                    // ✅ IDTur + TurAdi
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT IDTur, TurAdi FROM TblTur ORDER BY TurAdi",
                        session.Connection
                    );
                    da.Fill(dt);
                }
            }
            catch { return null; }
            return dt;
        }
       



        /// <summary>
        /// Toggle: varsa siler, yoksa ekler.
        /// Dönen değer: true => artık favori, false => artık favori değil
        /// Hata olursa exception mesajı döner.
        /// </summary>


        /// <summary>
        /// Favori kitapları listelemek için (Favoriler sayfasında kullanacaksın)
        /// </summary>
        public DataTable FavorileriListele(int ogrenciId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (sMan session = new sMan())
                {
                    string sql = @"
                SELECT 
                    K.IDKitap,
                    K.KitapAdi,
                    Y.YazarAdi,
                    T.TurAdi,
                    K.Stok,
                    K.ISBN,
                    F.KayitTarihi
                FROM TblFavori F
                INNER JOIN TblKitaplar K ON K.IDKitap = F.IDKitap
                INNER JOIN TblYazarlar Y ON Y.IDYazar = K.IDYazar
                INNER JOIN TblTur T ON T.IDTur = K.IDTur
                WHERE F.IDOgrenci = @p1
                ORDER BY F.KayitTarihi DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", ogrenciId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        public string KitapEkle(string ad, string isbn, string sayfa, string stok, string yazar, string tur)
        {
            string _hata = null;
            try
            {
                using (sMan session = new sMan())
                {
                    // Mükerrer Kontrol
                    SqlCommand cmdKontrol = new SqlCommand("SELECT Count(*) FROM TblKitaplar WHERE ISBN = @pISBN", session.Connection);
                    cmdKontrol.Parameters.AddWithValue("@pISBN", isbn);
                    int _varMi = Convert.ToInt32(cmdKontrol.ExecuteScalar());

                    if (_varMi > 0)
                    {
                        // Varsa Stok Artır
                        string _sqlStok = "UPDATE TblKitaplar SET Stok = Stok + @pAdet WHERE ISBN = @pISBN";
                        SqlCommand cmdStok = new SqlCommand(_sqlStok);
                        cmdStok.Parameters.AddWithValue("@pAdet", stok);
                        cmdStok.Parameters.AddWithValue("@pISBN", isbn);
                        DMLManager _dml = new DMLManager();
                        _dml.ExecuteDML(cmdStok, session);
                        return "Kitap zaten vardı, stok adedi artırıldı.";
                    }

                    // Yoksa Ekle
                    string _sqlEkle = @"INSERT INTO TblKitaplar (KitapAdi, ISBN, SayfaSayisi, Stok, IDYazar, IDTur, Durum) 
                                        VALUES (@p1, @p2, @p3, @p4, 
                                        (SELECT IDYazar FROM TblYazarlar WHERE YazarAdi = @p5), 
                                        (SELECT IDTur FROM TblTur WHERE TurAdi = @p6), 'True')";
                    SqlCommand cmdEkle = new SqlCommand(_sqlEkle);
                    cmdEkle.Parameters.AddWithValue("@p1", ad);
                    cmdEkle.Parameters.AddWithValue("@p2", isbn);
                    cmdEkle.Parameters.AddWithValue("@p3", sayfa);
                    cmdEkle.Parameters.AddWithValue("@p4", stok);
                    cmdEkle.Parameters.AddWithValue("@p5", yazar);
                    cmdEkle.Parameters.AddWithValue("@p6", tur);

                    DMLManager _dmlEkle = new DMLManager();
                    _dmlEkle.ExecuteDML(cmdEkle, session);
                }
            }
            catch (Exception ex) { _hata = ex.Message; }
            return _hata;
        }

        public string KitapGuncelle(int id, string ad, string isbn, string sayfa, string stok, string yazar, string tur)
        {
            string _hata = null;
            try
            {
                using (sMan session = new sMan())
                {
                    string _sql = @"UPDATE TblKitaplar SET 
                                    KitapAdi=@p1, ISBN=@p2, SayfaSayisi=@p3, Stok=@p4,
                                    IDYazar=(SELECT IDYazar FROM TblYazarlar WHERE YazarAdi=@p5),
                                    IDTur=(SELECT IDTur FROM TblTur WHERE TurAdi=@p6)
                                    WHERE IDKitap=@pID";
                    SqlCommand cmd = new SqlCommand(_sql);
                    cmd.Parameters.AddWithValue("@p1", ad);
                    cmd.Parameters.AddWithValue("@p2", isbn);
                    cmd.Parameters.AddWithValue("@p3", sayfa);
                    cmd.Parameters.AddWithValue("@p4", stok);
                    cmd.Parameters.AddWithValue("@p5", yazar);
                    cmd.Parameters.AddWithValue("@p6", tur);
                    cmd.Parameters.AddWithValue("@pID", id);

                    DMLManager _dml = new DMLManager();
                    _dml.ExecuteDML(cmd, session);
                }
            }
            catch (Exception ex) { _hata = ex.Message; }
            return _hata;
        }

        public string KitapSil(int id)
        {
            string _hata = null;
            try
            {
                using (sMan session = new sMan())
                {
                    string _sql = "DELETE FROM TblKitaplar WHERE IDKitap = @p1";
                    SqlCommand cmd = new SqlCommand(_sql);
                    cmd.Parameters.AddWithValue("@p1", id);
                    DMLManager _dml = new DMLManager();
                    _dml.ExecuteDML(cmd, session);
                }
            }
            catch (Exception ex) { _hata = ex.Message; }
            return _hata;
        }

        // --- EMANET (ÖDÜNÇ) İŞLEMLERİ ---

        public DataTable MusaitKitaplariGetir()
        {
            DataTable _dt = new DataTable();
            try
            {
                using (sMan session = new sMan())
                {
                    string _sql = "SELECT IDKitap, KitapAdi, ISBN FROM TblKitaplar WHERE Stok > 0";
                    SqlDataAdapter da = new SqlDataAdapter(_sql, session.Connection);
                    da.Fill(_dt);
                }
            }
            catch { return null; }
            return _dt;
        }

        
        public DataRow KitapDetayGetir(int idKitap)
        {
            DataTable dt = new DataTable();
            try
            {
                using (sMan session = new sMan())
                {
                    string sql = @"
                            SELECT 
                                K.IDKitap,
                                K.KitapAdi,
                                Y.YazarAdi,
                                T.TurAdi,
                                K.Stok,
                                K.Durum,
                                K.ISBN
                            FROM TblKitaplar K
                            INNER JOIN TblTur T ON K.IDTur = T.IDTur
                            INNER JOIN TblYazarlar Y ON K.IDYazar = Y.IDYazar
                            WHERE K.IDKitap = @pIDKitap";

                    using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@pIDKitap", idKitap);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch { return null; }

            if (dt.Rows.Count == 0) return null;
            return dt.Rows[0];
        }
        public DataTable OgrencileriGetir()
        {
            DataTable _dt = new DataTable();
            try
            {
                using (sMan session = new sMan())
                {
                    string _sql = "SELECT IDOgrenci, KullaniciAdi FROM TblOgrenciBilgisi";
                    SqlDataAdapter da = new SqlDataAdapter(_sql, session.Connection);
                    da.Fill(_dt);
                }
            }
            catch { return null; }
            return _dt;
        }

        public bool FavoriMi(int ogrenciId, int kitapId)
        {
            try
            {
                using (sMan session = new sMan())
                {
                    string sql = "SELECT COUNT(*) FROM TblFavori WHERE IDOgrenci=@p1 AND IDKitap=@p2";
                    using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", ogrenciId);
                        cmd.Parameters.AddWithValue("@p2", kitapId);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch { return false; }
        }

        public DataTable CezaDetayGetir(int ogrenciId)
        {
            DataTable dt = new DataTable();

            try
            {
                using (sMan session = new sMan())
                {
                    string sql = @"
SELECT
    e.IDKitap,
    k.KitapAdi,
    e.AlisTarihi,
    DATEADD(DAY, 15, e.AlisTarihi) AS TeslimGerekenTarih,
    DATEDIFF(DAY, DATEADD(DAY, 15, e.AlisTarihi), CAST(GETDATE() AS DATE)) AS GecikmeGun
FROM TblEmanet e
INNER JOIN TblKitaplar k ON k.IDKitap = e.IDKitap
WHERE e.IDOgrenci = @p1
  AND e.IslemDurumu = 1
  AND e.TeslimTarihi IS NULL
  AND DATEADD(DAY, 15, e.AlisTarihi) < CAST(GETDATE() AS DATE)
ORDER BY GecikmeGun DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", ogrenciId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }

                if (!dt.Columns.Contains("SatirBorcu"))
                    dt.Columns.Add("SatirBorcu", typeof(decimal));

                foreach (DataRow r in dt.Rows)
                {
                    int gun = Convert.ToInt32(r["GecikmeGun"]);
                    r["SatirBorcu"] = gun * 1.00m; // günlük 1 TL
                }
            }
            catch
            {
                return new DataTable();
            }

            return dt;
        }

        public decimal CezaHesaplananToplamGetir(int ogrenciId)
        {
            decimal toplam = 0m;
            DataTable dt = CezaDetayGetir(ogrenciId);
            foreach (DataRow r in dt.Rows)
            {
                if (r["SatirBorcu"] != DBNull.Value)
                    toplam += Convert.ToDecimal(r["SatirBorcu"]);
            }
            return toplam;
        }


        public bool FavoriToggle(int ogrenciId, int kitapId, out string hata)
        {
            hata = null;

            try
            {
                using (sMan session = new sMan())
                {
                    DMLManager dml = new DMLManager();

                    string sqlVar = "SELECT COUNT(*) FROM TblFavori WHERE IDOgrenci=@p1 AND IDKitap=@p2";
                    using (SqlCommand cmdVar = new SqlCommand(sqlVar, session.Connection))
                    {
                        cmdVar.Parameters.AddWithValue("@p1", ogrenciId);
                        cmdVar.Parameters.AddWithValue("@p2", kitapId);
                        int sayi = Convert.ToInt32(cmdVar.ExecuteScalar());

                        if (sayi > 0)
                        {
                            SqlCommand cmdSil = new SqlCommand("DELETE FROM TblFavori WHERE IDOgrenci=@p1 AND IDKitap=@p2");
                            cmdSil.Parameters.AddWithValue("@p1", ogrenciId);
                            cmdSil.Parameters.AddWithValue("@p2", kitapId);
                            dml.ExecuteDML(cmdSil, session);
                            return false;
                        }
                        else
                        {
                            SqlCommand cmdEkle = new SqlCommand(
                                "INSERT INTO TblFavori (IDOgrenci, IDKitap, KayitTarihi) VALUES (@p1, @p2, GETDATE())"
                            );
                            cmdEkle.Parameters.AddWithValue("@p1", ogrenciId);
                            cmdEkle.Parameters.AddWithValue("@p2", kitapId);
                            dml.ExecuteDML(cmdEkle, session);
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                hata = ex.Message;
                return false;
            }
        }

        public DataTable FavorileriGetir(int ogrenciId)
        {
            DataTable dt = new DataTable();

            try
            {
                using (sMan session = new sMan())
                {
                    string sql = @"
SELECT
    f.IDKitap,
    k.KitapAdi,
    y.YazarAdi,
    t.TurAdi,
    f.KayitTarihi
FROM TblFavori f
INNER JOIN TblKitaplar k ON k.IDKitap = f.IDKitap
INNER JOIN TblYazarlar y ON y.IDYazar = k.IDYazar
INNER JOIN TblTur t ON t.IDTur = k.IDTur
WHERE f.IDOgrenci = @p1
ORDER BY f.KayitTarihi DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", ogrenciId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        public string FavoriSil(int ogrenciId, int kitapId)
        {
            string hata = null;

            try
            {
                using (sMan session = new sMan())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM TblFavori WHERE IDOgrenci=@p1 AND IDKitap=@p2");
                    cmd.Parameters.AddWithValue("@p1", ogrenciId);
                    cmd.Parameters.AddWithValue("@p2", kitapId);

                    DMLManager dml = new DMLManager();
                    dml.ExecuteDML(cmd, session);
                }
            }
            catch (Exception ex)
            {
                hata = ex.Message;
            }

            return hata;
        }
        public DataTable EmanetleriListele()
        {
            DataTable _dt = new DataTable();
            try
            {
                using (sMan session = new sMan())
                {
                    // DÜZELTME:
                    // Senin tablonun sütun adı: IDHareket (Resminde böyle görünüyor)
                    // Bizim kodun kullandığı isim: IDEmanet
                    // ÇÖZÜM: 'e.IDHareket AS IDEmanet' diyerek iki tarafı barıştırıyoruz.

                    string _sql = @"SELECT 
                                e.IDHareket AS IDEmanet, 
                                e.IDOgrenci, 
                                k.IDKitap, 
                                k.KitapAdi, 
                                o.KullaniciAdi as Ogrenci, 
                                e.AlisTarihi 
                            FROM TblEmanet e
                            INNER JOIN TblKitaplar k ON e.IDKitap = k.IDKitap
                            INNER JOIN TblOgrenciBilgisi o ON e.IDOgrenci = o.IDOgrenci
                            WHERE e.TeslimTarihi IS NULL";

                    SqlDataAdapter da = new SqlDataAdapter(_sql, session.Connection);
                    da.Fill(_dt);
                }
            }
            catch { return null; }
            return _dt;
        }

        public string OduncVer(int kitapId, int ogrenciId, DateTime tarih)
        {
            string _hata = null;
            try
            {
                using (sMan session = new sMan())
                {
                    
                    SqlCommand cmdStok = new SqlCommand("SELECT Stok FROM TblKitaplar WHERE IDKitap=@p1", session.Connection);
                    cmdStok.Parameters.AddWithValue("@p1", kitapId);
                    int _stok = Convert.ToInt32(cmdStok.ExecuteScalar());

                    if (_stok <= 0) return "Bu kitabın stoğu tükenmiş!";

                    
                    string _sqlEkle = "INSERT INTO TblEmanet (IDKitap, IDOgrenci, AlisTarihi, IslemDurumu) VALUES (@p1, @p2, @p3, 1)";
                    SqlCommand cmdEkle = new SqlCommand(_sqlEkle);
                    cmdEkle.Parameters.AddWithValue("@p1", kitapId);
                    cmdEkle.Parameters.AddWithValue("@p2", ogrenciId);
                    cmdEkle.Parameters.AddWithValue("@p3", tarih);

                    DMLManager _dml = new DMLManager();
                    _dml.ExecuteDML(cmdEkle, session);

                    
                    string _sqlAzalt = "UPDATE TblKitaplar SET Stok = Stok - 1 WHERE IDKitap=@p1";
                    SqlCommand cmdAzalt = new SqlCommand(_sqlAzalt);
                    cmdAzalt.Parameters.AddWithValue("@p1", kitapId);
                    _dml.ExecuteDML(cmdAzalt, session);
                }
            }
            catch (Exception ex) { _hata = ex.Message; }
            return _hata;
        }

        public string IadeAl(int emanetId, int kitapId, DateTime iadeTarihi, string gecikmeBedeli)
        {
            string _hata = null;
            try
            {
                using (sMan session = new sMan())
                {
                    
                    string _sqlIade = "UPDATE TblEmanet SET IslemDurumu = 0, TeslimTarihi = @p1, GecikmeBedeli = @p3 WHERE IDHareket = @p2";
                    SqlCommand cmdIade = new SqlCommand(_sqlIade);
                    cmdIade.Parameters.AddWithValue("@p1", iadeTarihi);
                    cmdIade.Parameters.AddWithValue("@p2", emanetId);
                    cmdIade.Parameters.AddWithValue("@p3", string.IsNullOrEmpty(gecikmeBedeli) ? "0" : gecikmeBedeli);

                    DMLManager _dml = new DMLManager();
                    _dml.ExecuteDML(cmdIade, session);

                    
                    string _sqlArtir = "UPDATE TblKitaplar SET Stok = Stok + 1 WHERE IDKitap=@p1";
                    SqlCommand cmdArtir = new SqlCommand(_sqlArtir);
                    cmdArtir.Parameters.AddWithValue("@p1", kitapId);
                    _dml.ExecuteDML(cmdArtir, session);
                }
            }
            catch (Exception ex) { _hata = ex.Message; }
            return _hata;
        }

        

        public DataTable GrafikTurGetir()
        {
            DataTable _dt = new DataTable();
            try { using (sMan s = new sMan()) { new SqlDataAdapter("SELECT t.TurAdi, COUNT(k.IDKitap) as Sayi FROM TblKitaplar k INNER JOIN TblTur t ON k.IDTur = t.IDTur GROUP BY t.TurAdi", s.Connection).Fill(_dt); } } catch { return null; }
            return _dt;
        }

        public DataTable GrafikYazarGetir()
        {
            DataTable _dt = new DataTable();
            try { using (sMan s = new sMan()) { new SqlDataAdapter("SELECT TOP 5 y.YazarAdi, COUNT(k.IDKitap) as Sayi FROM TblKitaplar k INNER JOIN TblYazarlar y ON k.IDYazar = y.IDYazar GROUP BY y.YazarAdi ORDER BY COUNT(k.IDKitap) DESC", s.Connection).Fill(_dt); } } catch { return null; }
            return _dt;
        }

        public DataTable GrafikEnCokOkunanGetir()
        {
            DataTable _dt = new DataTable();
            try { using (sMan s = new sMan()) { new SqlDataAdapter("SELECT TOP 5 k.KitapAdi, COUNT(h.IDKitap) as OkunmaSayisi FROM TblEmanet h INNER JOIN TblKitaplar k ON h.IDKitap = k.IDKitap GROUP BY k.KitapAdi ORDER BY OkunmaSayisi DESC", s.Connection).Fill(_dt); } } catch { return null; }
            return _dt;
        }

        public Dictionary<string, string> KartIstatistikleriniGetir()
        {
            Dictionary<string, string> _sonuclar = new Dictionary<string, string>();
            try
            {
                using (sMan s = new sMan())
                {
                    _sonuclar.Add("ToplamKitap", new SqlCommand("SELECT COUNT(*) FROM TblKitaplar", s.Connection).ExecuteScalar().ToString());
                    _sonuclar.Add("ToplamUye", new SqlCommand("SELECT COUNT(*) FROM TblOgrenciBilgisi", s.Connection).ExecuteScalar().ToString());
                    _sonuclar.Add("ToplamPersonel", new SqlCommand("SELECT COUNT(*) FROM TblPersonel", s.Connection).ExecuteScalar().ToString());
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TblEmanet WHERE CAST(AlisTarihi AS DATE) = @p1", s.Connection);
                    cmd.Parameters.AddWithValue("@p1", DateTime.Now.Date);
                    _sonuclar.Add("BugunVerilen", cmd.ExecuteScalar().ToString());
                }
            }
            catch { return null; }
            return _sonuclar;
        }

        public string EmanetVerilebilirMi(int ogrenciId)
        {
            try
            {
                using (sMan session = new sMan())
                {
                    DMLManager _dml = new DMLManager();

                    // DÜZELTME: UyeID yerine IDOgrenci yazdık
                    // 1. Kural: Gecikmiş kitap kontrolü
                    string sqlGecikme = "SELECT COUNT(*) FROM TblEmanet WHERE IDOgrenci = @p1 AND IslemDurumu = 1 AND TeslimTarihi < GETDATE()";
                    SqlCommand cmd = new SqlCommand(sqlGecikme);
                    cmd.Parameters.AddWithValue("@p1", ogrenciId);

                    object sonucGecikme = _dml.ExecuteScalar(cmd, session);
                    int gecikenSayisi = Convert.ToInt32(sonucGecikme);

                    if (gecikenSayisi > 0)
                    {
                        return $"Öğrencinin elinde {gecikenSayisi} adet süresi geçmiş kitap var. Yeni kitap verilemez!";
                    }

                    // 2. Kural: Kitap limiti kontrolü
                    string sqlLimit = "SELECT COUNT(*) FROM TblEmanet WHERE IDOgrenci = @p1 AND IslemDurumu = 1";
                    SqlCommand cmd2 = new SqlCommand(sqlLimit);
                    cmd2.Parameters.AddWithValue("@p1", ogrenciId);

                    object sonucLimit = _dml.ExecuteScalar(cmd2, session);
                    int elindekiSayi = Convert.ToInt32(sonucLimit);

                    if (elindekiSayi >= 3)
                    {
                        return "Öğrenci kitap alma limitini (3 Adet) doldurmuş. Daha fazla kitap alamaz.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Sistem hatası: " + ex.Message;
            }

            return null;
        }

        public DataTable KitapHareketleriniGetir(int kitapID)
        {
            DataTable _dt = new DataTable();
            try
            {
                // Senin projendeki 'sMan' yapısını kullanıyoruz
                using (sMan session = new sMan())
                {
                    // Tablo isimlerini senin veritabanına göre düzelttim:
                    // Tbl_Hareket -> TblEmanet
                    // Tbl_Ogrenci -> TblOgrenciBilgisi
                    string _sql = @"
                        SELECT 
                            e.IDHareket,
                            o.KullaniciAdi AS OgrenciAdSoyad, -- Eğer Ad/Soyad sütunu ayrıysa burayı (o.Ad + ' ' + o.Soyad) yapabilirsin
                            e.AlisTarihi,
                            e.TeslimTarihi,
                            e.IslemDurumu
                        FROM TblEmanet e
                        INNER JOIN TblOgrenciBilgisi o ON e.IDOgrenci = o.IDOgrenci
                        WHERE e.IDKitap = @p1
                        ORDER BY e.AlisTarihi DESC";

                    SqlDataAdapter da = new SqlDataAdapter(_sql, session.Connection);
                    da.SelectCommand.Parameters.AddWithValue("@p1", kitapID);
                    da.Fill(_dt);
                }
            }
            catch { return null; }
            return _dt;
        }

        
        

        public DataTable KitapAra(
            string kitapAdi,
            int? idTur,
            int? idYazar,
            bool sadeceStokta
)
        {
            DataTable dt = new DataTable();

            try
            {
                using (sMan session = new sMan())
                {
                    string sql = @"
                SELECT 
                    K.IDKitap,
                    K.KitapAdi,
                    Y.YazarAdi,
                    T.TurAdi,
                    K.Stok,
                    K.Durum,
                    K.ISBN
                FROM TblKitaplar K
                INNER JOIN TblTur T ON K.IDTur = T.IDTur
                INNER JOIN TblYazarlar Y ON K.IDYazar = Y.IDYazar
                WHERE 1=1
            ";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = session.Connection;

                    if (!string.IsNullOrWhiteSpace(kitapAdi))
                    {
                        sql += " AND K.KitapAdi LIKE @pKitapAdi";
                        cmd.Parameters.AddWithValue("@pKitapAdi", "%" + kitapAdi + "%");
                    }

                    if (idTur.HasValue)
                    {
                        sql += " AND K.IDTur = @pIDTur";
                        cmd.Parameters.AddWithValue("@pIDTur", idTur.Value);
                    }

                    if (idYazar.HasValue)
                    {
                        sql += " AND K.IDYazar = @pIDYazar";
                        cmd.Parameters.AddWithValue("@pIDYazar", idYazar.Value);
                    }

                    if (sadeceStokta)
                    {
                        sql += " AND K.Stok > 0";
                    }

                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch
            {
                return null;
            }

            return dt;
        }
        private static readonly Dictionary<int, Image> _kapakCache = new Dictionary<int, Image>();

        public Image KapakGetir(int idKitap)
        {
            try
            {
                // RAM cache
                if (_kapakCache.TryGetValue(idKitap, out Image cached) && cached != null)
                    return cached;

                string folder = Path.Combine(Application.StartupPath, "Kapaklar");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string jpg = Path.Combine(folder, idKitap + ".jpg");
                string png = Path.Combine(folder, idKitap + ".png");

                string path = File.Exists(jpg) ? jpg : (File.Exists(png) ? png : null);
                if (path == null) return null;

                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    Image img = Image.FromStream(fs);
                    _kapakCache[idKitap] = img;
                    return img;
                }
            }
            catch
            {
                return null;
            }
        }

        private void KapakKolonuEkle(DataTable dt)
        {
            if (dt == null) return;

            if (!dt.Columns.Contains("Kapak"))
                dt.Columns.Add("Kapak", typeof(Image));

            foreach (DataRow r in dt.Rows)
            {
                if (r["IDKitap"] == DBNull.Value) continue;
                int id = Convert.ToInt32(r["IDKitap"]);
                r["Kapak"] = KapakGetir(id);
            }
        }

        // ===============================
        // 📚 ADAY KİTAPLAR (AI)
        // ===============================
        public DataTable AdayKitaplariGetir(int limit = 80)
        {
            DataTable dt = new DataTable();
            using (sMan session = new sMan())
            {
                string sql = @"
                SELECT TOP (@pLimit)
                    K.IDKitap,
                    K.KitapAdi,
                    Y.YazarAdi,
                    T.TurAdi
                FROM TblKitaplar K
                INNER JOIN TblYazarlar Y ON Y.IDYazar = K.IDYazar
                INNER JOIN TblTur T ON T.IDTur = K.IDTur
                WHERE K.Stok > 0
                ORDER BY NEWID()";

                using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                {
                    cmd.Parameters.AddWithValue("@pLimit", limit);
                    new SqlDataAdapter(cmd).Fill(dt);
                }
            }

            KapakKolonuEkle(dt);
            return dt;
        }

    }
}