using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_Operator
{
    public partial class delete : UserControl
    {
        public Panel obj;
        public delete(Panel obj)
        {
            this.obj = obj;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj.Controls.Clear();
            obj.Hide();
        }
    }
}
