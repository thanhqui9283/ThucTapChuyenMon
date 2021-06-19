using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySach.DAO
{
    public class UserDAO
    {
        private static UserDAO instance;

        public static UserDAO Instance
        {
            get { if (instance == null) instance = new UserDAO(); return UserDAO.instance; }
            private set { UserDAO.instance = value; }
        }


        private UserDAO() { }

        public object WareHouse()
        {
            string query = "select * from KhoSach";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}
