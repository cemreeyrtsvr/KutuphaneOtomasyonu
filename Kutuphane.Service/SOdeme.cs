using KutuphaneOtomasyon.Kutuphane.Common;
using System;
using System.Data;
using System.Data.SqlClient;

namespace KutuphaneOtomasyonu.Kutuphane.Service
{
    public class SOdeme
    {
        public DataTable OdemeleriListele(int ogrenciId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (sMan session = new sMan())
                {
                    string sql = @"
SELECT IDOdeme, Tutar, OdemeTarihi, Aciklama, Durum
FROM TblOdeme
WHERE IDOgrenci=@p1
ORDER BY OdemeTarihi DESC";

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

        public decimal OdenenToplamGetir(int ogrenciId)
        {
            try
            {
                using (sMan session = new sMan())
                {
                    string sql = @"
SELECT ISNULL(SUM(Tutar),0)
FROM TblOdeme
WHERE IDOgrenci=@p1 AND Durum=1";

                    using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", ogrenciId);
                        object val = cmd.ExecuteScalar();
                        return Convert.ToDecimal(val);
                    }
                }
            }
            catch
            {
                return 0m;
            }
        }

        /// <summary>
        /// DEMO ödeme kaydı atar. (Gerçek banka ödeme değil)
        /// </summary>
        public string OdemeEkle(int ogrenciId, decimal tutar, string aciklama)
        {
            if (ogrenciId <= 0) return "Öğrenci bulunamadı.";
            if (tutar <= 0) return "Tutar 0'dan büyük olmalı.";

            try
            {
                using (sMan session = new sMan())
                {
                    string sql = @"
INSERT INTO TblOdeme (IDOgrenci, Tutar, Aciklama, Durum)
VALUES (@p1, @p2, @p3, 1)";

                    using (SqlCommand cmd = new SqlCommand(sql, session.Connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", ogrenciId);
                        cmd.Parameters.AddWithValue("@p2", tutar);
                        cmd.Parameters.AddWithValue("@p3", string.IsNullOrWhiteSpace(aciklama) ? (object)DBNull.Value : aciklama.Trim());

                        DMLManager dml = new DMLManager();
                        dml.ExecuteDML(cmd, session);
                    }
                }

                return null; // hata yok
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
