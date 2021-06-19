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
    public partial class MuaSach : Form
    {
        public MuaSach()
        {
            InitializeComponent();
        }

        private void btnMUA_Click(object sender, EventArgs e)

        {
            if (comboBox1.Text != "" && txtTen.Text != "" && txtSL.Text != "" && txtGIA.Text != "")
            {

                dataGridViewSACHMUA.Rows.Add( comboBox1.Text, txtTen.Text
                , txtSL.Text, txtGIA.Text, dateTimePicker3.Text);


                int len = dataGridViewSACHMUA.Rows.Count;
                int price = 0;
                for (int i = 0; i < len-1; i++)
                {
                    price += int.Parse(dataGridViewSACHMUA.Rows[i].Cells[3].Value.ToString());
                    Console.WriteLine(price);
                }
                txtPrice.Text = price.ToString();

            }
            else
            {
                MessageBox.Show("kiểm tra lai thông tin");
            }

           

        }
    }
}