using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySach.DAO
{
     public class LoginDAO
    {
        private static LoginDAO instance;

        public static LoginDAO Instance
        {
            get { if (instance == null) instance = new LoginDAO(); return LoginDAO.instance; }
            private set { LoginDAO.instance = value; }
        }


        private LoginDAO() { }

        public bool loginAdmin(string user, string pass)
        {
            string query = "select * from Staff where UserName = '" + user + "' AND Pass = '" + pass + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public bool loginUser(string user, string pass)
        {
            string query = "select * from Client where Email='" + user + "' and Pass='" + pass + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public object getName(string email)
        {
            string query = "select NameClient from Client where Email='" + email + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows[0].ItemArray[0];
        }
    }
}
