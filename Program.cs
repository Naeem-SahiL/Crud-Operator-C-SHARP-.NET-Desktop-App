using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_Operator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// Data Source=MUHAMMAD-NAEEM;Initial Catalog=crud;Integrated Security=True
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SqlConnection con = new SqlConnection(@"Data Source=MUHAMMAD-NAEEM;Initial Catalog=crud;Integrated Security=True");
            Application.Run(new Form1(con));
        }
    }
}
