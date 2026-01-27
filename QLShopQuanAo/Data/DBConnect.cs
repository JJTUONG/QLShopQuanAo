using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.Data
{
    internal class DBConnect
    {
        public static SqlConnection GetConnection()
        {
            string connStr =
                @"Data Source=LAPTOPVIPRONUMB\SQLEXPRESS;
                  Initial Catalog=dbQLShopQuanAo;
                  Integrated Security=True";

            return new SqlConnection(connStr);
        }
    }
}
