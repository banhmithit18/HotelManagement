using HotelManagement.Model.entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelManagement.UC
{
    /// <summary>
    /// Interaction logic for BookingManagement.xaml
    /// </summary>
    public partial class BookingManagement : UserControl
    {
        public BookingManagement()
        {
            InitializeComponent();
            GetBookingView();
            this.MouseRightButtonUp += new MouseButtonEventHandler(Window1_MouseRightButtonUp);

        }
        public void GetBookingView()
        {
            Model.dao.BookingDao BD = new Model.dao.BookingDao();
            var q = BD.GetBooking();
            dataBooking.ItemsSource = q;
        }
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            var filter = hm.BOOKINGs.Where(b => b.STATUS == true).Join(hm.ROOMs.Where(r=> r.NAME.Contains(tbSearch.Text)), b => b.ROOMID, r => r.ID, (b, r) => new { Room = r, Booking = b }).Join(hm.CUSTOMERs, b => b.Booking.CUSID, c => c.ID, (b, c) => new { b.Booking, b.Room, Customer = c }).Select(s => new Model.view.BookingView { RoomName = s.Room.NAME, CusName = s.Customer.NAME, CusPhoneNumber = s.Customer.PHONENUMBER, CheckInTime = s.Booking.CHECKINTIME }).ToList();
            dataBooking.ItemsSource = filter;
        }
        private void UnBooking(object sender, RoutedEventArgs e)
        {
            if (dataBooking.SelectedItems.Count > 0)
            {
                Model.dao.BookingDao BD = new Model.dao.BookingDao();
                Model.dao.RoomDao RD = new Model.dao.RoomDao();
                Model.view.BookingView row = (Model.view.BookingView)dataBooking.SelectedItem;
                if (BD.ChangeBookingStatus(row.CusID, row.RoomID))
                {
                    RD.DisableRoom(2, row.RoomName);
                    MessageBox.Show("Unbook Successfully !");
                }
                else
                {
                    MessageBox.Show("Failed to Unbook !");
                } 
                GetBookingView();
            }
        }
        private void ChangeCheckInDate(object sender, RoutedEventArgs e)
        {
            if (dataBooking.SelectedItems.Count > 0)
            {
                Model.view.BookingView row = (Model.view.BookingView)dataBooking.SelectedItem;
                Frm.ChangeCheckInDate c = new Frm.ChangeCheckInDate(row.CheckInTime,row.RoomID,row.CusID);
                c.ShowDialog();
                GetBookingView();
            }
        }
        void Window1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is DataGridCell))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null) return;

            if (dep is DataGridCell)
            {
                DataGridCell cell = dep as DataGridCell;
                cell.Focus();

                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                DataGridRow row = dep as DataGridRow;
                dataBooking.SelectedItem = row.DataContext;
            }

        }

   
    }
}
