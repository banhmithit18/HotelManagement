using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for CheckBill.xaml
    /// </summary>
    public partial class CheckBill : Window
    {
        int RoomID;
        public CheckBill(int roomid)
        {
            InitializeComponent();
            RoomID = roomid;
            GetBillView(roomid);
        }
        public void GetBillView(int RoomID)
        {
            Model.dao.SrvOrderDao SOD = new Model.dao.SrvOrderDao();
            SOD.UpdateRentDay(RoomID);
            Model.dao.BillDao r = new Model.dao.BillDao();
            var q = r.GetBill(RoomID);
            dataBill.ItemsSource = q;
            double subtotal = 0;
            double total = 0; ;
            foreach (Model.view.BillView row in dataBill.Items)
            {
                subtotal += row.TOTAL;
            }
            total = subtotal + (subtotal * 10) / 100;
            lbSubTotal.Content = subtotal.ToString()+"$";
            lbTotal.Content = total.ToString()+"$";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.dao.RoomDao RD = new Model.dao.RoomDao();
            String RoomName = RD.GetRoomName(RoomID);
            RD.DisableRoom(2,RoomName );
            RD.EditNote("", RoomName);
            Model.dao.SrvOrderDao SOD = new Model.dao.SrvOrderDao();
            if (SOD.ChangePaymentStatus(RoomID))
            {
                MessageBox.Show("Check Out Sucessfully !");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed To Check Out !");
             }    

        }
    }
}
