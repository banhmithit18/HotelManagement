using HotelManagement.Model.entity;
using System;
using System.Collections;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelManagement.UC
{
    /// <summary>
    /// Interaction logic for RoomManagement.xaml
    /// </summary>
    public partial class RoomManagement : UserControl
    {
        int empid;
        string accounttype;
        public RoomManagement(int id, String type)
        {
            empid = id;
            accounttype = type;
            InitializeComponent();
            if (accounttype == "Employee")
            {
                btnAdd.IsEnabled = false;
            }
            GetRoomView();
            this.MouseRightButtonUp += new MouseButtonEventHandler(Window1_MouseRightButtonUp);
            
        }
        public void GetRoomView() {
            Model.dao.RoomDao r = new Model.dao.RoomDao();
            var q = r.GetRoom();
            dataRoom.ItemsSource = q;
           
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
                dataRoom.SelectedItem = row.DataContext;

                Model.view.RoomView RowData = (Model.view.RoomView)dataRoom.SelectedItem;

                DisRoom.Header = RowData.STATUS == "Disabled" ? "Active" : "Disable Room";

                switch (RowData.STATUS)
                {
                    case "In Use":
                        CusInfo.IsEnabled = true;
                        DisRoom.IsEnabled = false;
                        Booking_MenuItem.IsEnabled = false;
                        Order_MenuItem.IsEnabled = true;
                        Edit_MenuItem.IsEnabled = false;
                        Checkbill_MenuItem.IsEnabled = true;
                        Checkin_MenuItem.IsEnabled = true;
                        break;
                    case "Booked":
                        CusInfo.IsEnabled = true;
                        DisRoom.IsEnabled = false;
                        Booking_MenuItem.IsEnabled = false;
                        Order_MenuItem.IsEnabled = false;
                        Edit_MenuItem.IsEnabled = false;
                        Checkbill_MenuItem.IsEnabled = false;
                        Checkin_MenuItem.IsEnabled = true;
                        break;
                    case "Disabled":
                        CusInfo.IsEnabled = false;
                        DisRoom.IsEnabled = true;
                        Booking_MenuItem.IsEnabled = false;
                        Order_MenuItem.IsEnabled = false;
                        Edit_MenuItem.IsEnabled = false;
                        Checkbill_MenuItem.IsEnabled = false;
                        Checkin_MenuItem.IsEnabled = false;
                        break;
                    case "Empty":
                        CusInfo.IsEnabled = false;
                        DisRoom.IsEnabled = true;
                        Booking_MenuItem.IsEnabled = true;
                        Order_MenuItem.IsEnabled = false;
                        Edit_MenuItem.IsEnabled = true;
                        Checkbill_MenuItem.IsEnabled = false;
                        Checkin_MenuItem.IsEnabled = true;
                        break;
                }
                if (accounttype == "Employee")
                {
                    DisRoom.IsEnabled = false;
                    Edit_MenuItem.IsEnabled = false;
                }
            }
        }
        public class RowToIndexConverter : MarkupExtension, IValueConverter
        {
            static RowToIndexConverter converter;

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                DataGridRow row = value as DataGridRow;
                if (row != null)
                    return row.GetIndex() + 1;
                else
                    return -1;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                if (converter == null) converter = new RowToIndexConverter();
                return converter;
            }

            public RowToIndexConverter()
            {
            }
        }

        private void ChangeRoom(object sender, RoutedEventArgs e)
        {
            if (dataRoom.SelectedItems.Count > 0)
            {
                Model.view.RoomView row = (Model.view.RoomView)dataRoom.SelectedItem;

                Frm.ChangeRoom CR = new Frm.ChangeRoom(row.NAME, row.PRICE, row.TYPE, row.CATEGORY);

                CR.ShowDialog();
                GetRoomView();
            }
        }
        private void CheckIn(object sender, RoutedEventArgs e)
        {
            if (dataRoom.SelectedItems.Count > 0)
            {
                Model.view.RoomView row = (Model.view.RoomView)dataRoom.SelectedItem;
                Frm.CheckIn CI = new Frm.CheckIn(row.NAME, row.STATUS,empid);
                CI.ShowDialog();
                GetRoomView();
            }
        }
        private void EditNote(object sender, RoutedEventArgs e)
        {
            if (dataRoom.SelectedItems.Count > 0)
            {
                Model.view.RoomView row = (Model.view.RoomView)dataRoom.SelectedItem;
                Frm.EditNote CR = new Frm.EditNote(row.NOTE, row.NAME);
                CR.ShowDialog();
                GetRoomView();
            }
        }
        private void Booking(object sender, RoutedEventArgs e)
        {
            if (dataRoom.SelectedItems.Count > 0)
            {
                Model.view.RoomView row = (Model.view.RoomView)dataRoom.SelectedItem;
                Frm.Booking BK = new Frm.Booking(row.NAME, empid);
                BK.ShowDialog();
                GetRoomView();
            }
        }
        private void OrderService(object sender, RoutedEventArgs e)
        {
            if (dataRoom.SelectedItems.Count > 0)
            {
                Model.view.RoomView row = (Model.view.RoomView)dataRoom.SelectedItem;
                Frm.OrderService AR = new Frm.OrderService(row.NAME, empid);
                AR.ShowDialog();
                GetRoomView();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                Frm.AddRoom AR = new Frm.AddRoom();
                AR.ShowDialog();
                GetRoomView();
            
        }
        private void CheckBill(object sender, RoutedEventArgs e)
        {
            if (dataRoom.SelectedItems.Count > 0)
            {
                Model.view.RoomView row = (Model.view.RoomView)dataRoom.SelectedItem;
                Model.dao.RoomDao RD = new Model.dao.RoomDao();

                Frm.CheckBill CB = new Frm.CheckBill(RD.GetID(row.NAME));
                CB.ShowDialog();
                GetRoomView();
            }

        }
        private void DisableRoom(object sender, RoutedEventArgs e)
        {
            if (dataRoom.SelectedItems.Count > 0)
            {
                Model.view.RoomView row = (Model.view.RoomView)dataRoom.SelectedItem;
                Model.dao.RoomDao RD = new Model.dao.RoomDao();
                if (DisRoom.Header.ToString() == "Disable Room")
                {
                    
                    RD.DisableRoom(1,row.NAME);
                }
                else
                {
                    RD.DisableRoom(2, row.NAME);
                }
                GetRoomView();

            }
        }
      
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            var filter = hm.ROOMs.Where(r => r.NAME.Contains(tbSearch.Text)).ToList();
            dataRoom.ItemsSource = filter;
        }
    }
}
