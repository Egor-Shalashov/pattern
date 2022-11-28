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

namespace DEMO
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string sql = @"Select id, login, passwd from Users";
            bool flag = false;
            string passwd = "";
            int id = 0;
            using (SqlConnection conn = new SqlConnection(classes.conn.str_conn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"].ToString());
                    if (reader["login"].ToString() == tb_login.Text)
                    {
                        flag = true;
                        passwd = reader["passwd"].ToString();
                    }
                    //passwd = reader["passwd"].ToString();
                }
            }
            if (flag && passwd == tb_paswd.Text)
            {
                Forms.table table = new Forms.table(id);
                table.ShowDialog();
            }
            else if (flag)
            {
                MessageBox.Show("пароль");
            }
            else if (flag == false)
            {
                MessageBox.Show("не существует пользователя");
            }
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            Forms.reg reg = new Forms.reg();
            reg.ShowDialog();
        }
    }
}
