using KutuphaneOtomasyon.Kutuphane.Common;
using System;
using System.Data;
using System.Data.SqlClient;

namespace KutuphaneOtomasyonu.Kutuphane.Service
{
    public class SBagis
    {
        public string BagisEkle(int ogrenciId, string kitapAdi, string yazarAdi, string isbn)
        {
            string hata = null;

            try
            {
                if (ogrenciId <= 0) return "Öğrenci bulunamadı.";
                if (string.IsNullOrWhiteSpace(kitapAdi)) return "Kitap adı boş olamaz.";
                if (string.IsNullOrWhiteSpace(yazarAdi)) return "Yazar adı boş olamaz.";

                using (sMan session = new sMan())
                {
                    // ✅ KayitTarihi garanti (DB default yoksa bile)
                    string sql = @"
                        INSERT INTO TblBagis (IDOgrenci, KitapAdi, YazarAdi, ISBN, Durum, KayitTarihi)
                        VALUES (@pOgrenci, @pKitap, @pYazar, @pISBN, 0, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@pOgrenci", ogrenciId);
                        cmd.Parameters.AddWithValue("@pKitap", kitapAdi.Trim());
                        cmd.Parameters.AddWithValue("@pYazar", yazarAdi.Trim());
                        cmd.Parameters.AddWithValue("@pISBN", string.IsNullOrWhiteSpace(isbn) ? (object)DBNull.Value : isbn.Trim());

                        DMLManager dml = new DMLManager();
                        dml.ExecuteDML(cmd, session);
                    }
                }
            }
            catch (Exception ex)
            {
                hata = ex.Message;
            }

            return hata;
        }

        public DataTable OgrenciBagislariListele(int ogrenciId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (sMan session = new sMan())
                {
                    string sql = @"
                        SELECT 
                            IDBagis,
                            KitapAdi,
                            YazarAdi,
                            ISBN,
                            Durum,
                            KayitTarihi,
                            OnayTarihi,
                            RedNedeni
                        FROM TblBagis
                        WHERE IDOgrenci = @p1
                        ORDER BY KayitTarihi DESC";

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

        public DataTable BekleyenBagislariListele()
        {
            DataTable dt = new DataTable();
            try
            {
                using (sMan session = new sMan())
                {
                    string sql = @"
                        SELECT 
                            B.IDBagis,
                            B.IDOgrenci,
                            O.KullaniciAdi,
                            B.KitapAdi,
                            B.YazarAdi,
                            B.ISBN,
                            B.KayitTarihi
                        FROM TblBagis B
                        INNER JOIN TblOgrenciBilgisi O ON O.IDOgrenci = B.IDOgrenci
                        WHERE B.Durum = 0
                        ORDER BY B.KayitTarihi ASC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, session.Connection);
                    da.Fill(dt);
                }
            }
            catch
            {
                return new DataTable();
            }
            return dt;
        }

        public string BagisOnayla(int idBagis, int? personelId)
        {
            string hata = null;

            try
            {
                using (sMan session = new sMan())
                {
                    // 1) Bağış bilgisi
                    DataTable dt = new DataTable();
                    using (SqlCommand cmdGet = new SqlCommand(
                        "SELECT KitapAdi, YazarAdi, ISBN FROM TblBagis WHERE IDBagis=@p1 AND Durum=0",
                        session.Connection))
                    {
                        cmdGet.Parameters.AddWithValue("@p1", idBagis);
                        SqlDataAdapter da = new SqlDataAdapter(cmdGet);
                        da.Fill(dt);
                    }

                    if (dt.Rows.Count == 0)
                        return "Bağış bulunamadı veya zaten işlem görmüş.";

                    DataRow r = dt.Rows[0];
                    string kitapAdi = r["KitapAdi"].ToString();
                    string yazarAdi = r["YazarAdi"].ToString();
                    string isbn = r["ISBN"] == DBNull.Value ? null : r["ISBN"].ToString();

                    DMLManager dml = new DMLManager();

                    // 2) ISBN ile kitap var mı?
                    int? mevcutKitapId = null;
                    if (!string.IsNullOrWhiteSpace(isbn))
                    {
                        using (SqlCommand cmdVar = new SqlCommand(
                            "SELECT TOP 1 IDKitap FROM TblKitaplar WHERE ISBN=@p1",
                            session.Connection))
                        {
                            cmdVar.Parameters.AddWithValue("@p1", isbn.Trim());
                            object sonuc = cmdVar.ExecuteScalar();
                            if (sonuc != null && sonuc != DBNull.Value)
                                mevcutKitapId = Convert.ToInt32(sonuc);
                        }
                    }

                    if (mevcutKitapId.HasValue)
                    {
                        // 3A) Kitap var → stok +1
                        using (SqlCommand cmdStok = new SqlCommand(
                            "UPDATE TblKitaplar SET Stok = ISNULL(Stok,0) + 1 WHERE IDKitap=@p1",
                            session.Connection))
                        {
                            cmdStok.Parameters.AddWithValue("@p1", mevcutKitapId.Value);
                            dml.ExecuteDML(cmdStok, session);
                        }
                    }
                    else
                    {
                        // 3B) Kitap yok → yazar yoksa ekle
                        int idYazar = EnsureYazar(session, yazarAdi);

                        // 3C) Tür default: Belirsiz
                        int idTur = EnsureTur(session, "Belirsiz");

                        // 3D) yeni kitap ekle
                        using (SqlCommand cmdIns = new SqlCommand(@"
                            INSERT INTO TblKitaplar (KitapAdi, ISBN, SayfaSayisi, Stok, IDYazar, IDTur, Durum)
                            VALUES (@pAdi, @pISBN, 0, 1, @pYazar, @pTur, 'True')", session.Connection))
                        {
                            cmdIns.Parameters.AddWithValue("@pAdi", kitapAdi.Trim());
                            cmdIns.Parameters.AddWithValue("@pISBN", string.IsNullOrWhiteSpace(isbn) ? (object)DBNull.Value : isbn.Trim());
                            cmdIns.Parameters.AddWithValue("@pYazar", idYazar);
                            cmdIns.Parameters.AddWithValue("@pTur", idTur);

                            dml.ExecuteDML(cmdIns, session);
                        }
                    }

                    // 4) Bağışı onaylandı yap
                    using (SqlCommand cmdUp = new SqlCommand(@"
                        UPDATE TblBagis
                        SET Durum=1, OnayTarihi=GETDATE(),
                            OnaylayanPersonelID=@pPersonel,
                            RedNedeni=NULL
                        WHERE IDBagis=@pBagis AND Durum=0", session.Connection))
                    {
                        cmdUp.Parameters.AddWithValue("@pBagis", idBagis);
                        cmdUp.Parameters.AddWithValue("@pPersonel", personelId.HasValue ? (object)personelId.Value : DBNull.Value);

                        dml.ExecuteDML(cmdUp, session);
                    }
                }
            }
            catch (Exception ex)
            {
                hata = ex.Message;
            }

            return hata;
        }

        public string BagisReddet(int idBagis, int? personelId, string redNedeni)
        {
            string hata = null;

            try
            {
                using (sMan session = new sMan())
                {
                    DMLManager dml = new DMLManager();

                    using (SqlCommand cmd = new SqlCommand(@"
                        UPDATE TblBagis
                        SET Durum=2, OnayTarihi=GETDATE(),
                            OnaylayanPersonelID=@pPersonel,
                            RedNedeni=@pNeden
                        WHERE IDBagis=@pBagis AND Durum=0", session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@pBagis", idBagis);
                        cmd.Parameters.AddWithValue("@pPersonel", personelId.HasValue ? (object)personelId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@pNeden", string.IsNullOrWhiteSpace(redNedeni) ? (object)DBNull.Value : redNedeni.Trim());

                        dml.ExecuteDML(cmd, session);
                    }
                }
            }
            catch (Exception ex)
            {
                hata = ex.Message;
            }

            return hata;
        }

        private int EnsureYazar(sMan session, string yazarAdi)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 IDYazar FROM TblYazarlar WHERE YazarAdi=@p1",
                session.Connection))
            {
                cmd.Parameters.AddWithValue("@p1", yazarAdi.Trim());
                object sonuc = cmd.ExecuteScalar();
                if (sonuc != null && sonuc != DBNull.Value)
                    return Convert.ToInt32(sonuc);
            }

            using (SqlCommand cmdIns = new SqlCommand(
                "INSERT INTO TblYazarlar (YazarAdi) VALUES (@p1); SELECT SCOPE_IDENTITY();",
                session.Connection))
            {
                cmdIns.Parameters.AddWithValue("@p1", yazarAdi.Trim());
                object newId = cmdIns.ExecuteScalar();
                return Convert.ToInt32(newId);
            }
        }

        private int EnsureTur(sMan session, string turAdi)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 IDTur FROM TblTur WHERE TurAdi=@p1",
                session.Connection))
            {
                cmd.Parameters.AddWithValue("@p1", turAdi.Trim());
                object sonuc = cmd.ExecuteScalar();
                if (sonuc != null && sonuc != DBNull.Value)
                    return Convert.ToInt32(sonuc);
            }

            using (SqlCommand cmdIns = new SqlCommand(
                "INSERT INTO TblTur (TurAdi) VALUES (@p1); SELECT SCOPE_IDENTITY();",
                session.Connection))
            {
                cmdIns.Parameters.AddWithValue("@p1", turAdi.Trim());
                object newId = cmdIns.ExecuteScalar();
                return Convert.ToInt32(newId);
            }
        }
    }
}
