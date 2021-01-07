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
    class RoomDao
    {
        string connstring = "server=localhost;database=HOTELMANAGEMENT;user=sa;password=123456";
        SqlConnection conn;
        SqlCommand q;
        SqlDataReader r;
        public bool Add(entity.ROOM r)
        {
            try
            {
                HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
                hm.ROOMs.Add(r);
                hm.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        public void Edit(entity.ROOM r) {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("update room set type='" + r.TYPE + "', price=" + r.PRICE + ", category='" + r.CATEGORY + "' where name='" + r.NAME + "'",conn); 
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
        public bool CheckRoomName(String Name)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select * from room  where name='" + Name + "'", conn);
            int RoomExist = q.ExecuteScalar()==null?0:1;

            if (RoomExist > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EditNote(String Note, String Name)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("update room set note='" + Note + "' where name='" + Name + "'", conn);
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
      
        public string[] GetIDCardWithCheckOut(String Name)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("select idcard,checkouttime from customer join booking on customer.id = booking.cusid join room on booking.roomid = room.id where room.name='"+ Name +"'", conn);
            string[] info = new string[2];
           
            r = q.ExecuteReader();
            while (r.Read())
            {
                info[0] = (String)r["IDCARD"];
                info[1] = (String)r["CHECKOUTTIME"];

            }
            return info;
        }
        public int GetID(String Name)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select id from room  where name='" + Name + "'", conn);
            int id = 0;
            r = q.ExecuteReader();
            while (r.Read())
            {
                id = (int)r["ID"];

            }
            return id;
        }
        public String GetIDCard(String Name)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("select distinct idcard from customer join srvorder on customer.id = srvorder.cusid join room on srvorder.roomid = room.id where room.name='" + Name + "'", conn);
            String id = "";
            r = q.ExecuteReader();
            while (r.Read())
            {
                id = (String)r["IDCARD"];

            }
            return id;
        }
        public String GetRoomName(int id)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("select name from room where id="+id , conn);
            String RoomName = "";
            r = q.ExecuteReader();
            while (r.Read())
            {
                RoomName = (String)r["NAME"];

            }
            return RoomName;
        }
        public double GetPrice(String Name)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("Select price from room  where name='" + Name + "'", conn);
            double price = 0;
            r = q.ExecuteReader();
            while (r.Read())
            {
                price = (double)r["PRICE"];

            }
            return price;
        }
        public String GetSrvName(String Name)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("select CONCAT(room.type,room.category) as SrvName from room where room.name ='" + Name+"'", conn);
            String ReturnName = "";
            r = q.ExecuteReader();
            while (r.Read())
            {
                ReturnName = (String)r["SrvName"];
            }
            return ReturnName;
        }
        public bool DisableRoom(int Case,String Name)   
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            switch (Case)
            {
                // sorry for being f**king lazy
                case 1:
                    q = new SqlCommand("update room set status='" + "Disabled" + "' where name='" + Name + "'", conn); //Disable
                    break;
                case 2:
                    q = new SqlCommand("update room set status='" + "Empty" + "' where name='" + Name + "'", conn); //Empty
                    break;
                case 3:
                    q = new SqlCommand("update room set status='" + "Booked" + "' where name='" + Name + "'", conn); //Booked
                    break;
                case 4:
                    q = new SqlCommand("update room set status='In Use' where name='"+Name+"'",conn); //In Use
                    break;
                default:
                    break;
            }
            
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
        public List<view.RoomView> GetRoom() {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            var q = hm.ROOMs.Select(d => new view.RoomView { NAME = d.NAME, TYPE = d.TYPE, CATEGORY =d.CATEGORY , PRICE = (d.PRICE ?? 0), NOTE = d.NOTE, STATUS = d.STATUS }).ToList();
            return q;
        }
    }
}
