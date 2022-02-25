using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Operator
{
    class SQL_Connection
    {
        private static SqlConnection con = null;
        private SQL_Connection()
        {

        }
        public static SqlConnection Connect()
        {
            if(con == null)
            {
                con = new SqlConnection(@"Data Source=MUHAMMAD-NAEEM;Initial Catalog=crud;Integrated Security=True");
            }
            return con;
        }
    }
}
