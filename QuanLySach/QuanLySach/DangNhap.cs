using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace QuanLySach
{
    public partial class DangNhap : Form
    {
        
       
        public DangNhap()
        {
            InitializeComponent();
        }

        DataTable load(string query)
        {
            string connStr = "Data Source=localhost,1999;Initial Catalog=QuanLySach;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            DataTable data = new DataTable();           
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data);
            conn.Close();
            return data;

        }
  

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string tk = txtName.Text;
            string Mk = txtPassword.Text;
            string query = "select * from DangNhap where TaiKhoan = '" + tk + "' AND MatKhau = '" + Mk + "'";
            if (check(query))
            {
                QuanLySach f = new QuanLySach();
                this.Hide();
             
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập sai, vui lòng nhập lại","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        bool check(string query)
        {           
            return (load(query).Rows.Count > 0);
        }

        private void ckbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false ;
            }
            else 
                    {
                txtPassword.UseSystemPasswordChar = true;
                    }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
    }
}
