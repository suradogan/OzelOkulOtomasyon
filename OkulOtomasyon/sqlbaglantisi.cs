using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OkulOtomasyon
{
    public class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
        SqlConnection baglan = new SqlConnection("Data Source=şura;Initial Catalog=dbo.OkulOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;

        }
    }
}
