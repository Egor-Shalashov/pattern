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
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            bool flag_login = false;
            bool flag_id = false;
            using (SqlConnection conn = new SqlConnection(classes.conn.str_conn))
            {
                string sql = @"Select id, login from Users";
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["id"].ToString() == tb_id.Text)
                    {
                        flag_id = true;
                    }
                    if (reader["login"].ToString() == tb_login.Text)
                    {
                        flag_login = true;
                    }
                }

            }
            if (flag_login == false && flag_id == false)
            {
                using (SqlConnection conn = new SqlConnection(classes.conn.str_conn))
                {
                    string sql = @"INSERT INTO Users (id, login, passwd) VALUES (@id, @login, @passwd)";
                    conn.Open();
                    SqlCommand comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("id", tb_id.Text);
                    comm.Parameters.AddWithValue("login", tb_login.Text);
                    comm.Parameters.AddWithValue("passwd", tb_passwd.Text);
                    try
                    {
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                        throw;
                    }

                }
            }
            else if (flag_id)
            {
                MessageBox.Show("id");
            }
            else if (flag_login)
            {
                MessageBox.Show("login");
            }
        }
    }
}
