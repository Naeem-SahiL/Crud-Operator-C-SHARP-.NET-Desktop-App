using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_Operator
{
    public partial class insert : UserControl
    {
        public Panel obj;
        public SqlConnection con;
        DataGridView grid;
        public insert(Panel obj, SqlConnection con, DataGridView grid)
        {
            this.obj = obj;
            this.con = con;
            this.grid = grid;
            InitializeComponent();
        }
        private int insert_fnc()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into employees(id, name, contact) values(@id, @name, @contact)", con);
            cmd.Parameters.AddWithValue("@id", idbox.Text);
            cmd.Parameters.AddWithValue("@name", namebox.Text);
            cmd.Parameters.AddWithValue("@contact", phonebox.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has been inserted successfuly");
            }
            catch (Exception e)
            {
                MessageBox.Show("The id should be unique!");
                con.Close();
                return -1;
            }
            con.Close();
            return 0;
        }
        private void display()
        {
            con.Open();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select id as 'Id', name as 'Name', contact as 'Contact' from employees ", con);
            adapter.Fill(table);
            grid.DataSource = table;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            insert_fnc();
            this.obj.Controls.Clear();
            this.obj.Hide();
            display();
        }
       
    }
}
