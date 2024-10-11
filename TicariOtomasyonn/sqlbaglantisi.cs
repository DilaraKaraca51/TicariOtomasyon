using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicariOtomasyonn
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-82HPLIB\\SQLEXPRESS;Initial Catalog=TicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
