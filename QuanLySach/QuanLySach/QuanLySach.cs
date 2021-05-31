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
    public partial class QuanLySach : Form
    {
        public QuanLySach()
        {
            InitializeComponent();
        }
        private void XuatGiaoDien1()
        {
            txtLoaiSach.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNXB.Text = "";
            txtSoLuong.Text = "";
            txtGiaTien.Text = "";
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (txtLoaiSach.Text != "" && txtTenSach.Text != "" && txtTacGia.Text != "" && txtNXB.Text != "" && txtSoLuong.Text != "" && txtGiaTien.Text != "")
            {
                try
                {
                    int soluong = Convert.ToInt32(txtSoLuong.Text);

                    try
                    {
                        int giatien = Convert.ToInt32(txtGiaTien.Text);
                        dataGridViewKho.Rows.Add(txtLoaiSach.Text, txtTenSach.Text, txtTacGia.Text, txtNXB.Text, txtSoLuong.Text, txtGiaTien.Text);
                        XuatGiaoDien1();
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
                MessageBox.Show(" Vui Lòng Nhập Đủ Thông Tin");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int vitri = dataGridViewKho.CurrentCell.RowIndex;
            dataGridViewKho[0, vitri].Value = txtLoaiSach.Text;
            dataGridViewKho[1, vitri].Value = txtTenSach.Text;
            dataGridViewKho[2, vitri].Value = txtTacGia.Text;
            dataGridViewKho[3, vitri].Value = txtSoLuong.Text;
            dataGridViewKho[4, vitri].Value = txtGiaTien.Text;
            XuatGiaoDien1();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int vitri = dataGridViewKho.CurrentCell.RowIndex;
            if (MessageBox.Show("Bạn có muốn xoá dòng Này ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridViewKho.Rows.RemoveAt(vitri);
            }
        }

        private void dataGridViewKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
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
                        dataGridViewTimKiem.Rows.Add(dataGridViewKho[0, i].Value, dataGridViewKho[1, i].Value, dataGridViewKho[2, i].Value);
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
            if (dataGridViewKho.SelectedCells.Count != 0)
            {
                DataGridViewRow row = dataGridViewKho.Rows[dataGridViewKho.CurrentCell.RowIndex];
                txtLoaiSach.Text = row.Cells[0].Value.ToString();
                txtTenSach.Text = row.Cells[1].Value.ToString();
                txtTacGia.Text = row.Cells[2].Value.ToString();
                txtNXB.Text = row.Cells[3].Value.ToString();
                txtSoLuong.Text = row.Cells[4].Value.ToString();
                txtGiaTien.Text = row.Cells[5].Value.ToString();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtGiaTien1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
