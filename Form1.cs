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
    public partial class Form1 : Form
    {
        public SqlConnection con;
        public Form1(SqlConnection obj)
        {
            con = SQL_Connection.Connect();
            InitializeComponent();
            display();
            grid.ClearSelection();
        }
        private void search()
        {
            con.Open();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from employees where name like '" + searchbox.Text + "%'", con);
            adapter.Fill(table);
            grid.DataSource = table;
            con.Close();
            grid.ClearSelection();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            search();
        }
        private void display()
        {
            con.Open();
            DataTable table = new DataTable();
            string id = "ID";
            SqlDataAdapter adapter = new SqlDataAdapter("select id as '"+id+"',name as 'Name',contact as 'Contact' from employees", con);
            adapter.Fill(table);
            grid.DataSource = table;

            grid.Columns[1].MinimumWidth = 100;
            grid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column_property.Text = grid.Columns[0].DataPropertyName;
            //grid.Columns[0].Name = "iddd";
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                //grid.Columns[i].FillWeight = DataGridViewTextBoxColumn;
            }
            con.Close();
            grid.ClearSelection();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void createobj(Control obj)
        {
            controlholder.Show();
            controlholder.Controls.Add(obj);
            obj.Dock = DockStyle.Fill;
        }
        private void insertbtn_Click(object sender, EventArgs e)
        {
            insert obj = new insert(controlholder, con, grid);
            controlholder.Show();
            createobj(obj);
            
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            update obj = new update(controlholder, con, grid);
            createobj(obj);
        }
        private void delete()
        {
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
                    MessageBox.Show("Select a non null row to delete!");
                    return;
                }
                else
                {
                    con.Open();
                    string rw = grid.SelectedRows[0].Cells[0].Value.ToString();
                    SqlCommand cmd = new SqlCommand("delete from employees where id=@id", con);
                    cmd.Parameters.AddWithValue("@id", rw);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been deleted successfuly");
                    con.Close();
                    display();
                }
            }
        }
        private void deletebtn_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'crudDataSet.employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.crudDataSet.employees);

        }

        private void searchbox_KeyUp(object sender, KeyEventArgs e)
        {
            search();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
       
        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
