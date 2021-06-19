using QuanLySach.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySach
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        public string NameClient;
      
        private void User_Load(object sender, EventArgs e)            
        {
            dataGridView1.DataSource = UserDAO.Instance.WareHouse();
            lbName.Text = "Xin Chào " + NameClient;
            dataGridView1.ClearSelection();
           
        }

        DataTable dtBook;
        DataView dwBook;
        private void btnTimkiem1_Click(object sender, EventArgs e)
        {
            DangNhap login = new DangNhap();
            this.Hide();
            login.ShowDialog();

        }

        private void btnMuaSach_Click(object sender, EventArgs e)
        {
            MuaSach frmMUA = new MuaSach();
            frmMUA.Show();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                dataGridView1.ClearSelection();
            }
            else
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Tác Giả] LIKE '{0}%'", txtName.Text);
                dataGridView1.ClearSelection();
            }
        }
    }
}
