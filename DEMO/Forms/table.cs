using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEMO.Forms
{
    public partial class table : Form
    {
        public table(int ID)
        {
            InitializeComponent();
        }

        private void populate(string sql)
        {
            using (SqlConnection conn = new SqlConnection(classes.conn.str_conn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void table_Load(object sender, EventArgs e)
        {

        }

        private void cb_f_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
