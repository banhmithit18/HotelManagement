using HotelManagement.Model.entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Model.dao
{
    class BookingDao
    {
        string connstring = "server=localhost;database=HOTELMANAGEMENT;user=sa;password=123456";
        SqlConnection conn;
        SqlCommand q;
        SqlDataReader r;
        public bool Add(Model.entity.BOOKING c)
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            try
            {
                hm.BOOKINGs.Add(c);
                hm.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return false;

            }
        }
        public bool ChangeBookingStatus(int cusid , int roomid)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("update booking set status = 0 where cusid ="+cusid+"and roomid ="+roomid, conn);
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
        public bool ChangeBookingTime(String date,int cusid, int roomid)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            q = new SqlCommand("update booking set checkintime ='"+date+"' where status = 1 and cusid ="  + cusid + " and roomid = " + roomid, conn);
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
        public List<Model.view.BookingView> GetBooking() {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            var q = hm.BOOKINGs.Where(b=> b.STATUS == true).Join(hm.ROOMs, b => b.ROOMID, r => r.ID, (b, r) => new { Room = r, Booking = b }).Join(hm.CUSTOMERs, b => b.Booking.CUSID, c => c.ID, (b, c) => new {b.Booking,b.Room, Customer = c }).Select(s => new Model.view.BookingView {RoomName = s.Room.NAME ,CusName = s.Customer.NAME, CusPhoneNumber = s.Customer.PHONENUMBER, CheckInTime = s.Booking.CHECKINTIME,CusID=s.Customer.ID,RoomID=s.Room.ID}).ToList();
            return q;
        }
    }
}
