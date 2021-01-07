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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public static int empid;
        public static bool loginstatus = false;
        public static String accounttype;
        public LoginForm()
        {
            InitializeComponent();
        }
  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String username = tbUser.Text;
            String pass = tbPass.Password;
            Model.dao.EmployeeDao ED = new Model.dao.EmployeeDao();
            if (ED.Login(username, pass))
            {

                loginstatus = true;
                String[] info = ED.GetIDEmp(username, pass);
                empid = int.Parse(info[0]);
                accounttype = info[1];
                this.Close();
            }
            else
            {
                loginstatus = false;
                MessageBox.Show("Wrong Username Or Password !");
                
            }
        }
        private void ShowPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e) => ShowPasswordFunction();
        private void ShowPassword_PreviewMouseUp(object sender, MouseButtonEventArgs e) => HidePasswordFunction();
        private void ShowPassword_MouseLeave(object sender, MouseEventArgs e) => HidePasswordFunction();

        private void ShowPasswordFunction()
        {
            ShowPassword.Text = "HIDE";
            tbPassUnmask.Visibility = Visibility.Visible;
            tbPass.Visibility = Visibility.Hidden;
            tbPassUnmask.Text = tbPass.Password;
        }

        private void HidePasswordFunction()
        {
            ShowPassword.Text = "SHOW";
            tbPassUnmask.Visibility = Visibility.Hidden;
            tbPass.Visibility = Visibility.Visible;
        }
    }
}
