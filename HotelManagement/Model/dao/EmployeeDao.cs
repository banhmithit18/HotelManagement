using HotelManagement.Model.entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Model.dao
{
    class EmployeeDao
    {
        string connstring = "server=localhost;database=HOTELMANAGEMENT;user=sa;password=123456";
        SqlConnection conn;
        SqlCommand q;
        SqlDataReader r;
        public bool Add(Model.entity.EMPLOYEE e)
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            try
            {
                hm.EMPLOYEEs.Add(e);
                hm.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }
        public List<Model.view.EmployeeView> GetEmployee() {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            var q = hm.EMPLOYEEs.Select(s => new Model.view.EmployeeView { ID = s.ID, IDCARD = s.IDCARD, NAME = s.NAME, AGE = s.AGE ?? 0, EMAIL = s.EMAIL, PHONENUMBER = s.PHONENUMBER, ADDRESS = s.ADDRESS, ACCOUNTTYPE = s.ACCOUNTTYPE }).ToList();
            return q;
        }
        public bool CheckEmp(String IDCard)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select * from employee  where idcard='" + IDCard + "'", conn);

            int CusExist = q.ExecuteScalar() == null ? 0 : 1;

            if (CusExist > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckPass(int empid, String pass)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select * from employee  where password='" + pass + "' and id="+empid, conn);

            int CusExist = q.ExecuteScalar() == null ? 0 : 1;

            if (CusExist > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ChangePass(int empid, String pass)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("update employee set password='"+pass+"'  where id="+empid, conn);

            try
            {
                q.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteEmp(String IDCard)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("delete  from employee  where idcard='" + IDCard + "'", conn);

            try
            {
                q.ExecuteNonQuery();
                return true;
               
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditEmp(Model.entity.EMPLOYEE e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("update employee set age= "+e.AGE+" ,email='"+e.EMAIL+"' ,phonenumber='"+e.PHONENUMBER+"' ,address='"+e.ADDRESS+ "' ,accounttype='" + e.ACCOUNTTYPE + "' where idcard='" + e.IDCARD + "'", conn);

            try
            {
                q.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Login(String username, String password)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select * from  employee where username= '"+username+"' and password= '"+password+"'", conn);
            r = q.ExecuteReader();
            int id = 0;
            while (r.Read())
            {
                id = (int)r["ID"];

            }
            return id != 0 ? true : false;
        }
        public String[] GetIDEmp(String username, String password)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select id,accounttype from  employee where username= '" + username + "' and password= '" + password + "'", conn);
            r = q.ExecuteReader();
            String[] info = new String[2];
            while (r.Read())
            {
                info[0] = ((int)r["ID"]).ToString();
                info[1] = (String)r["ACCOUNTTYPE"];


            }
            return info;
        }
    }
}
