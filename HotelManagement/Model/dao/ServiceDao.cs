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
    class ServiceDao
    {
        string connstring = "server=localhost;database=HOTELMANAGEMENT;user=sa;password=123456";
        SqlConnection conn;
        SqlCommand q;
        SqlDataReader r;
        public bool Add(Model.entity.SERVICE s)
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            try
            {
                hm.SERVICEs.Add(s);
                hm.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return false;

            }
        }
        public bool CheckServiceName(int Case,String Name)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            switch (Case)
           
            {
                case 1:
                    q = new SqlCommand("Select * from service  where name='" + Name + "'", conn);
                    break;
                case 2:
                    q = new SqlCommand("select service.name from room full join srvorder on room.id = srvorder.roomid full join service on service.id = srvorder.srvid where service.name = (Select CONCAT(room.type, room.category)from room where room.name ='"+Name+"')", conn);
                    break;
                default:
                    break;
            }
            int SrvExist = q.ExecuteScalar() == null ? 0 : 1;

            if (SrvExist > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetServiceId(String RoomName)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("select service.id from room full join srvorder on room.id = srvorder.roomid full join service on service.id = srvorder.srvid where service.name = ( Select CONCAT(room.type,room.category)from room where room.name ='"+RoomName+"' and service.status = 'Active')", conn);
            int id = 0;
            r = q.ExecuteReader();
            while (r.Read())
            {
                id = (int)r["ID"];

            }
            return id;

        }
        public List<String> getServiceName() {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("select Name from service where type != 'Room' and status= 'Active'", conn);
            List<String> SrvName = new List<string>();
            r = q.ExecuteReader();
            while (r.Read())
            {
                SrvName.Add((String)r["Name"]);

            }
            return SrvName;
        }
        public int GetID(String Name)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select id from service  where name='" + Name + "'and status= 'Active'", conn);
            int id = 0;
            r = q.ExecuteReader();
            while (r.Read())
            {
                id = (int)r["ID"];

            }
            return id;

        }
        public double GetPrice(String Name)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select price from service  where name='" + Name + "'and status= 'Active'", conn);
            double price = 0;
            r = q.ExecuteReader();
            while (r.Read())
            {
                price = (double)r["PRICE"];

            }
            return price;
        }
        public List<view.ServiceView> GetService()
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            var q = hm.SERVICEs.Select(d => new view.ServiceView { NAME = d.NAME, TYPE = d.TYPE, PRICE = (d.PRICE ?? 0), STATUS = d.STATUS }).ToList();
            return q;
        }
        public void ChangeStatus(int Case, String Name)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            switch (Case)
            {
                case 1:
                    q = new SqlCommand("Update service set status = 'Active' where Name='" + Name +"'", conn);
                    break;
                case 2:
                    q = new SqlCommand("Update service set status = 'Disabled' where Name='" + Name + "'", conn);
                    break;
                default:
                    break;
            }
            q.ExecuteNonQuery();

        }
        public void Edit(entity.SERVICE r)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("update service set type='" + r.TYPE + "', price="+ r.PRICE +"  where name='" + r.NAME + "'", conn);
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
    }
}
