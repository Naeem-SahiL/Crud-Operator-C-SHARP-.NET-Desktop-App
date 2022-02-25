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
    public partial class update : UserControl
    {
        public Panel obj;
        public SqlConnection con;
        DataGridView grid;
        public update(Panel obj, SqlConnection con, DataGridView grid)
        {
            this.obj = obj;
            this.con = con;
            this.grid = grid;
            InitializeComponent();
            if (grid.SelectedRows.Count > 0)
            {
                bool rowIsEmpty = true;

                foreach (DataGridViewCell cell in grid.SelectedRows[0].Cells)
                {
                    if (cell.Value != null)
                    {
                        rowIsEmpty = false;
                        break;
                    }
                }

                if (rowIsEmpty)
                {
                    MessageBox.Show("Select a non null row!");
                    return;
                }
                else
                {
                    idbox.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
                    namebox.Text = grid.SelectedRows[0].Cells[1].Value.ToString();
                    phonebox.Text = grid.SelectedRows[0].Cells[2].Value.ToString();
                }
            }
            
        }
        private void update_fnc()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update employees set id=@id, name=@name, contact=@contact where id=@id", con);
            cmd.Parameters.AddWithValue("@id", idbox.Text);
            cmd.Parameters.AddWithValue("@name", namebox.Text);
            cmd.Parameters.AddWithValue("@contact", phonebox.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data has been updated successfuly");
            con.Close();

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
            update_fnc();
            obj.Controls.Clear();
            obj.Hide();
            display();
        }
       
    }
}
