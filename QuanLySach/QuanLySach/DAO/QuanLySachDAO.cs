using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySach.DAO
{
    public class QuanLySachDAO
    {
        private static QuanLySachDAO instance;

        public static QuanLySachDAO Instance
        {
            get { if (instance == null) instance = new QuanLySachDAO(); return QuanLySachDAO.instance; }
            private set { QuanLySachDAO.instance = value; }
        }


        private QuanLySachDAO() { }

        public object User()
        {
            string query = "select * from Client";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public void add(string name, string email, string pass, string birthday, string phone)
        {
            string query = "insert into Client values (N'" + name + "','" + email + "','" + pass + "','" + birthday + "'," + phone + ")";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void datele(string email)
        {
            string query = "delete from Client where Email='" + email + "'";
            DataProvider.Instance.ExecuteNonQuery(query);

        }

        public void update(int id, string name, string email, string pass, string birthday, string phone)
        {
            string query = "update Client set Name=N'" + name + "', Email='" + email + "', Pass='" + pass + "',DateOfBirth='" + birthday + "', PhoneNumber=" + phone + "";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
