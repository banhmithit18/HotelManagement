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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int empid;
        String accounttype;
        public MainWindow()
        {
            Frm.LoginForm LG = new Frm.LoginForm();
            LG.ShowDialog();
            if (Frm.LoginForm.loginstatus == true)
            {
                empid = Frm.LoginForm.empid;
                accounttype = Frm.LoginForm.accounttype;
                InitializeComponent();
                if (accounttype == "Employee")
                {
                    menuMngCus.IsEnabled = false;
                    menuMngSrv.IsEnabled = false;
                    menuMngEmp.IsEnabled = false;
                    
                }
                grMain.Children.Clear();
                UC.RoomManagement rm = new UC.RoomManagement(empid,accounttype);
                grMain.Children.Add(rm);

            }
            else {

                this.Close();
            }

        }

       

        private void ManagementRoom_Click(object sender, RoutedEventArgs e)
        {
            grMain.Children.Clear();
            UC.RoomManagement rm = new UC.RoomManagement(empid,accounttype);
            grMain.Children.Add(rm);
        }
        private void ManagementService_Click(object sender, RoutedEventArgs e)
        {
            grMain.Children.Clear();
            UC.ServiceManagement sm = new UC.ServiceManagement();
            grMain.Children.Add(sm);
        }
        private void ManagementBooking_Click(object sender, RoutedEventArgs e)
        {
            grMain.Children.Clear();
            UC.BookingManagement bm = new UC.BookingManagement();
            grMain.Children.Add(bm);
        }
        private void ManagementCustomer_Click(object sender, RoutedEventArgs e)
        {
            grMain.Children.Clear();
            UC.CustomerManagement cm = new UC.CustomerManagement();
            grMain.Children.Add(cm);
        }
        private void ManagementEmployee_Click(object sender, RoutedEventArgs e)
        {
            grMain.Children.Clear();
            UC.EmployeeManagement cm = new UC.EmployeeManagement();
            grMain.Children.Add(cm);
        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var mv = new MainWindow();
            mv.Show();
            this.Close();

        }
        private void ChangePass(object sender, RoutedEventArgs e)
        {
            Frm.ChangePass cp = new Frm.ChangePass(empid);
            cp.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
           
          
        }
      
    }
}
