using System.Data.SqlClient;

namespace KutuphaneOtomasyon.Kutuphane.Common
{
    /// <summary>
    /// Insert, Update, Delete işlemlerini yöneten sınıf.
    /// </summary>
    public class DMLManager
    {
        
        public void ExecuteDML(SqlCommand cmd, sMan session)
        {
            
            cmd.Connection = session.Connection;
            cmd.ExecuteNonQuery();
        }
        public object ExecuteScalar(SqlCommand cmd, sMan session)
        {
            // Komutun bağlantısını session nesnesinden alıyoruz
            // (Senin projende bağlantı nesnesinin adı 'baglanti' veya 'conn' olabilir, onu kontrol et)
            cmd.Connection = session.Connection;

            // Veritabanında sorguyu çalıştırıp tek bir değer (ilk satır, ilk sütun) döndürür
            object sonuc = cmd.ExecuteScalar();

            return sonuc;
        }
    }
}