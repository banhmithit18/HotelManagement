using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelManagement.Frm
{
    /// <summary>
    /// Interaction logic for ChangeCheckInDate.xaml
    /// </summary>
    public partial class ChangeCheckInDate : Window
    {
        String Time;
        int RoomID, CusID;
        public ChangeCheckInDate(String time,int roomid, int cusid)
        {
            InitializeComponent();
            Time = time;
            RoomID = roomid;
            CusID = cusid;
            dpTime.Text = time;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.dao.BookingDao BD = new Model.dao.BookingDao();
            Time = dpTime.Text;
            if (BD.ChangeBookingTime(Time, CusID, RoomID))
            {
                MessageBox.Show("Change Date Successfully !");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to Save");
            }
        }
    }
}
