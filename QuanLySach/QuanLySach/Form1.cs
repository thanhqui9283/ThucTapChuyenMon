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
    public partial class Form1 : Form
    {
        
       
        public Form1()
        {
            InitializeComponent();
        }

        DataTable load(string query)
        {
            string connStr = "Data Source=localhost,1999;Initial Catalog=QuanLydangnhap;Integrated Security=True";
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
            string query = "select * from Dangnhap where Taikhoan = '" + tk + "' AND Matkhau = '" + Mk + "'";
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
    }
}
