using HotelManagement.Model.entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagement.Model.dao
{
    class CustomerDao
    {
        string connstring = "server=localhost;database=HOTELMANAGEMENT;user=sa;password=123456";
        SqlConnection conn;
        SqlCommand q;
        SqlDataReader r;
        public bool Add(Model.entity.CUSTOMER c) {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            try
            {
                hm.CUSTOMERs.Add(c);
                hm.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                
            }
        }
        public bool CheckCus(String IDCard)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select * from customer  where idcard='" + IDCard + "'", conn);
               
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
        public CUSTOMER GetCustomerInfo(String IDCard)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select * from customer  where idcard='" + IDCard + "'", conn);
            CUSTOMER c = new CUSTOMER();
            r = q.ExecuteReader();
            while (r.Read())
            {
                c.NAME = (String)r["NAME"];
                c.AGE = (int)r["AGE"];
                c.PHONENUMBER = (String)r["PHONENUMBER"];
                c.ADDRESS = (String)r["ADDRESS"];
            }
            return c;
        }
        public int GetID(String IDCard)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select id from customer  where idcard='" + IDCard + "'", conn);
            int id = 0;
            r = q.ExecuteReader();
            while (r.Read())
            {
                id = (int)r["ID"];
           
            }
            return id;

        }
        public void Edit(entity.CUSTOMER c)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("update customer set age= " +c.AGE + " , phonenumber='" + c.PHONENUMBER + "', address='" + c.ADDRESS + "' where id= " +c.ID , conn);
            try
            {
                q.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("Not Saved");
            }
        }
        public List<Model.view.CustomerView> GetCustomer() {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            var q = hm.CUSTOMERs.Select(s => new Model.view.CustomerView { ID = s.ID, IDCARD = s.IDCARD, NAME = s.NAME, ADDRESS = s.ADDRESS, AGE = (s.AGE??0), PHONENUMBER= s.PHONENUMBER }).ToList();
           

            return q;
        }
      
    }
}
