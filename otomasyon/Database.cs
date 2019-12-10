using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace otomasyon
{
    class Database
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source =.; Initial Catalog = hapis; Integrated Security = True";
            return new SqlConnection(connectionString);
        }
    }
}
