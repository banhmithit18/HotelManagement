using HotelManagement.Model.entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Model.dao
{
    class SrvOrderDao
    {
        string connstring = "server=localhost;database=HOTELMANAGEMENT;user=sa;password=123456";
        SqlConnection conn;
        SqlCommand q;
        SqlDataReader r;
        public bool Add(Model.entity.SRVORDER so)
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            try
            {
                hm.SRVORDERs.Add(so);
                hm.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return false;

            }
        }
        public int GetInsertedSrvOrderId()
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select IDENT_CURRENT('SRVORDER') as InsertedID", conn);
            int id = 0;
            r = q.ExecuteReader();
            while (r.Read())
            {
                id = Convert.ToInt32(r["InsertedID"]);
            }
            return id;

        }
        public void UpdateRentDay(int RoomID)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("UpdateRentDay",conn);
            q.CommandType = System.Data.CommandType.StoredProcedure;
            q.Parameters.Add(new SqlParameter("@RoomID", RoomID));
            int rowAffected = q.ExecuteNonQuery();
            conn.Close();
        }
        public bool ChangePaymentStatus(int roomid)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("update srvorder set paymentstatus = 1 where paymentstatus = 0 and roomid =" + roomid, conn);
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

    }
}
