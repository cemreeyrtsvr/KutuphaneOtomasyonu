using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // SQL kütüphanesini buraya eklemeyi unutma!

namespace KutuphaneOtomasyonu.Kutuphane.Forms // NOT: Burayı kendi namespace'inle aynı yaparsan 'using' eklemene gerek kalmaz.
{
    class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {


            SqlConnection baglan = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DbKutuphane;Integrated Security=True;Encrypt=False");

            baglan.Open(); 
            return baglan;
        }
    }
}