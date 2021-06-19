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
using QuanLySach.DAO;

namespace QuanLySach
{
    public partial class DangNhap : Form
    {
        
       
        public DangNhap()
        {
            InitializeComponent();
        }

        
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string tk = txtName.Text;
            string Mk = txtPassword.Text;
            if (LoginDAO.Instance.loginAdmin(tk, Mk))
            {
                QuanLySach qls = new QuanLySach();
                this.Hide();
                qls.ShowDialog();
            }
            else if (LoginDAO.Instance.loginUser(tk, Mk))
            {
                User user = new User();
                user.NameClient = LoginDAO.Instance.getName(tk).ToString();
                this.Hide();
                user.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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

       

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
    }
}
