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
using ClosedXML.Excel;
using QuanLySach.DAO;

namespace QuanLySach
{
    public partial class QuanLySach : Form
    {
        public QuanLySach()
        {
            InitializeComponent();
        }

        public object ketnoicsdl()
        {
            string connStr = "Data Source=localhost,1999;Initial Catalog=QuanLySach;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string query = "select * from KhoSach";
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data);
            conn.Close();
            return data;
        }
        private void XuatGiaoDien1()
        {
            txtLoaiSach.Text = string.Empty;
            txtTenSach.Text = string.Empty;
            txtTacGia.Text = string.Empty;
            txtNXB.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtGiaTien.Text = string.Empty;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {

            string connStr = "Data Source=localhost,1999;Initial Catalog=QuanLySach;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd;
            string a = "INSERT INTO KhoSach VALUES (N'" + txtLoaiSach.Text + "',N'" + txtTenSach.Text + "',N'" + txtTacGia.Text + "',N'" + txtNXB.Text + "'," + int.Parse(txtSoLuong.Text) + "," + int.Parse(txtGiaTien.Text) + ")";
            cmd = new SqlCommand(a, conn);
            cmd.ExecuteNonQuery();
            XuatGiaoDien1();
            dataGridViewKho.DataSource = ketnoicsdl();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int vitri = dataGridViewKho.CurrentCell.RowIndex;
            dataGridViewKho[0, vitri].Value = txtLoaiSach.Text;
            dataGridViewKho[1, vitri].Value = txtTenSach.Text;
            dataGridViewKho[2, vitri].Value = txtTacGia.Text;
            dataGridViewKho[3, vitri].Value = txtNXB.Text;
            dataGridViewKho[4, vitri].Value = txtSoLuong.Text;
            dataGridViewKho[5, vitri].Value = txtGiaTien.Text;


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int vitri = dataGridViewKho.CurrentCell.RowIndex;
            if (MessageBox.Show("Bạn có muốn xoá dòng Này ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridViewKho.Rows.RemoveAt(vitri);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dataGridViewTimKiem.Rows.Clear();
                for (int i = 0; i < dataGridViewKho.Rows.Count - 1; i++)
                {
                    if (dataGridViewKho[0, i].Value.ToString() == txtLoaiSach1.Text)
                    {
                        dataGridViewTimKiem.Rows.Add(dataGridViewKho[0, i].Value, dataGridViewKho[1, i].Value, dataGridViewKho[2, i].Value
                            , dataGridViewKho[3, i].Value, dataGridViewKho[4, i].Value, dataGridViewKho[5, i].Value);
                    }

                }
            }
            else if (checkBox2.Checked)
            {
                dataGridViewTimKiem.Rows.Clear();
                for (int i = 0; i < dataGridViewKho.Rows.Count - 1; i++)
                {
                    if (dataGridViewKho[2, i].Value.ToString() == txtTacGia1.Text)
                    {
                        dataGridViewTimKiem.Rows.Add(dataGridViewKho[0, i].Value, dataGridViewKho[1, i].Value, dataGridViewKho[2, i].Value);
                    }

                }
            }
            else if (checkBox1.Checked && checkBox2.Checked)
            {
                dataGridViewTimKiem.Rows.Clear();
                for (int i = 0; i < dataGridViewKho.Rows.Count - 1; i++)
                {
                    if (dataGridViewKho[0, 1].Value.ToString() == txtLoaiSach1.Text && dataGridViewKho[2, 1].Value.ToString() == txtTacGia1.Text)
                    {
                        dataGridViewTimKiem.Rows.Add(dataGridViewKho[0, i].Value, dataGridViewKho[1, i].Value, dataGridViewKho[2, i].Value);
                    }

                }
            }
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            if (txtTenSach1.Text != "" && txtSoLuong1.Text != "" && txtGiaTien1.Text != "")
            {
                try
                {
                    int soluong = Convert.ToInt32(txtSoLuong1.Text);

                    try
                    {
                        int giatien = Convert.ToInt32(txtGiaTien1.Text);
                        for (int i = 0; i < dataGridViewKho.Rows.Count - 1; i++)
                        {
                            //nếu sách có trong kho
                            if (dataGridViewKho[1, i].Value.ToString() == txtTenSach1.Text)
                            {
                                // đk số sách trong kho còn
                                if (Convert.ToInt32(dataGridViewKho[4, i].Value) - Convert.ToInt32(txtSoLuong1.Text) >= 0)
                                {
                                    int gia1 = Convert.ToInt32(dataGridViewKho[5, i].Value) / Convert.ToInt32(dataGridViewKho[4, i].Value);
                                    int gia2 = Convert.ToInt32(txtGiaTien1.Text) / Convert.ToInt32(txtSoLuong1.Text);
                                    int tienlai = (gia2 - gia1) * Convert.ToInt32(txtSoLuong1.Text);


                                    dataGridViewMua.Rows.Add(dataGridViewKho[0, i].Value, txtTenSach1.Text, txtSoLuong1.Text
                                        , tienlai.ToString(), dateTimePicker1.Text);

                                    dataGridViewKho[4, i].Value = Convert.ToInt32(dataGridViewKho[4, i].Value) - Convert.ToInt32(txtSoLuong1.Text);
                                    dataGridViewKho[5, i].Value = Convert.ToInt32(dataGridViewKho[4, i].Value) * gia1;
                                }
                                else
                                {
                                    MessageBox.Show("Sách Không Đủ  , chỉ còn " + dataGridViewKho[4, i].Value);
                                }

                            }
                        }


                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Bạn Cần Nhập Đúng Giá Tiền");

                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Bạn Cần Nhập Đúng Số Lượng");
                }

            }
            else
            {
                MessageBox.Show("Vui lòng Nhập đầy đủ thông tin");
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                dataGridViewThongKe.Rows.Clear();
                for (int i = 0; i < dataGridViewMua.Rows.Count - 1; i++)
                {
                    if (dataGridViewMua[0, i].Value.ToString() == txtLoaiSach2.Text)
                    {
                        dataGridViewThongKe.Rows.Add(dataGridViewMua[0, i].Value, dataGridViewMua[1, i].Value,
                            dataGridViewMua[2, i].Value, dataGridViewMua[3, i].Value, dataGridViewMua[4, i].Value);
                    }

                }
            }
            else if (checkBox4.Checked)
            {
                dataGridViewThongKe.Rows.Clear();
                for (int i = 0; i < dataGridViewMua.Rows.Count - 1; i++)
                {
                    if (dataGridViewMua[4, i].Value.ToString() == dateTimePicker2.Text)
                    {
                        dataGridViewThongKe.Rows.Add(dataGridViewMua[0, i].Value, dataGridViewMua[1, i].Value,
                            dataGridViewMua[2, i].Value, dataGridViewMua[3, i].Value, dataGridViewMua[4, i].Value);
                    }

                }
            }
            else if (checkBox3.Checked && checkBox4.Checked)
            {
                dataGridViewThongKe.Rows.Clear();
                for (int i = 0; i < dataGridViewMua.Rows.Count - 1; i++)
                {
                    if (dataGridViewKho[0, i].Value.ToString() == txtLoaiSach2.Text && dataGridViewMua[5, i].Value.ToString() == dateTimePicker2.Text)
                    {
                        dataGridViewThongKe.Rows.Add(dataGridViewMua[0, i].Value, dataGridViewMua[1, i].Value,
                            dataGridViewMua[2, i].Value, dataGridViewMua[3, i].Value, dataGridViewMua[4, i].Value);

                    }

                }
            }
        }

        private void dataGridViewKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridViewKho.Rows[e.RowIndex];
                    txtLoaiSach.Text = row.Cells[0].Value.ToString();
                    txtTenSach.Text = row.Cells[1].Value.ToString();
                    txtTacGia.Text = row.Cells[2].Value.ToString();
                    txtNXB.Text = row.Cells[3].Value.ToString();
                    txtSoLuong.Text = row.Cells[4].Value.ToString();
                    txtGiaTien.Text = row.Cells[5].Value.ToString();

                }

            }
            catch (Exception) { }

        }


        private void QuanLySach_Load(object sender, EventArgs e)
        {
            dataGridViewKho.DataSource = ketnoicsdl();


            dataGridView1.DataSource = QuanLySachDAO.Instance.User();
            //btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.Handled)
                MessageBox.Show("Vui lòng nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.Handled)
                MessageBox.Show("Vui lòng nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void QuanLySach_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dataGridViewThongKe, saveFileDialog1.FileName);
            }
        }

        private void ToExcel(DataGridView dataGridViewThongKe, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbook = excel.Workbooks.Add(Type.Missing);

                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet.Name = "Quan Ly Ban Sach ";

                // export header
                for (int i = 0; i < dataGridViewThongKe.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridViewThongKe.Columns[i].HeaderText;
                }

                // export content
                for (int i = 0; i < dataGridViewThongKe.RowCount; i++)
                {
                    for (int j = 0; j < dataGridViewThongKe.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridViewThongKe.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save workbook
                workbook.SaveAs(fileName);
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Lưu Thành Công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

      

        private void txtSoLuong1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.Handled)
                MessageBox.Show("Vui lòng nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtGiaTien1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.Handled)
                MessageBox.Show("Vui lòng nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


      
        private void btnDangxuat_Click(object sender, EventArgs e)
        {

            var Mess = MessageBox.Show("Bạn có muốn đăng xuất", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(Mess == DialogResult.Yes)
            {
                DangNhap f = new DangNhap();
                this.Hide();
                f.ShowDialog();
            }
        }
       
        
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" || txtEmail.Text != "" || txtPass.Text != "" || txtName.Text != "" || txtDay.Text != "" || txtPhoneNumber.Text != "")
            {
                QuanLySachDAO.Instance.add(txtName.Text, txtEmail.Text, txtPass.Text, txtDay.Text, txtPhoneNumber.Text);
                MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = QuanLySachDAO.Instance.User();
            }
            else
            {
                MessageBox.Show("Vui lòng không để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int vitri = dataGridView1.CurrentCell.RowIndex;
            if (MessageBox.Show("Bạn có muốn xoá dòng Này ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(vitri);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int vitri1 = dataGridView1.CurrentCell.RowIndex;
            dataGridView1[0, vitri1].Value = txtID.Text;
            dataGridView1[1, vitri1].Value = txtName.Text;
            dataGridView1[2, vitri1].Value = txtEmail.Text;
            dataGridView1[3, vitri1].Value = txtPass.Text;
            dataGridView1[4, vitri1].Value = txtDay.Text;
            dataGridView1[5, vitri1].Value = txtPhoneNumber.Text;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    txtID.Text = row.Cells[0].Value.ToString();
                    txtName.Text = row.Cells[1].Value.ToString();
                    txtEmail.Text = row.Cells[2].Value.ToString();
                    txtPass.Text = row.Cells[3].Value.ToString();
                    txtDay.Text = row.Cells[4].Value.ToString();
                    txtPhoneNumber.Text = row.Cells[5].Value.ToString();

                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }
            catch (Exception) { }
        }

      
    }
}
