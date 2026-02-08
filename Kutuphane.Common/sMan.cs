using System;
using System.Data;
using System.Data.SqlClient;

namespace KutuphaneOtomasyon.Kutuphane.Common
{
    /// <summary>
    /// Veritabanı bağlantılarını yöneten sınıf (Session Manager)
    /// </summary>
    public class sMan : IDisposable
    {
        
        private SqlConnection _connection;
 
        
        private string _connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=DbKutuphane;Integrated Security=True;Encrypt=False";

        public SqlConnection Connection
        {
            get { return _connection; }
        }

        public sMan()
        {
            _connection = new SqlConnection(_connString);
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                _connection.Dispose();
            }
        }
    }
}