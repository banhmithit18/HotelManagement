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
    /// Interaction logic for ChangePass.xaml
    /// </summary>
    public partial class ChangePass : Window
    {
        int empid;
        public ChangePass(int id)
        {
            empid = id;
            InitializeComponent();
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
        private void ShowOldPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e) => ShowOldPasswordFunction();
        private void ShowOldPassword_PreviewMouseUp(object sender, MouseButtonEventArgs e) => HideOldPasswordFunction();
        private void ShowOldPassword_MouseLeave(object sender, MouseEventArgs e) => HideOldPasswordFunction();

        private void ShowOldPasswordFunction()
        {
            ShowOldPassword.Text = "HIDE";
            tbOldPassUnmask.Visibility = Visibility.Visible;
            tbOldPass.Visibility = Visibility.Hidden;
            tbOldPassUnmask.Text = tbOldPass.Password;
        }

        private void HideOldPasswordFunction()
        {
            ShowOldPassword.Text = "SHOW";
            tbOldPassUnmask.Visibility = Visibility.Hidden;
            tbOldPass.Visibility = Visibility.Visible;
        }
        private bool CheckEmpty() {
            if (tbPass.Password == "" || tbOldPass.Password == "")
            {
                MessageBox.Show("Please enter all required information !");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.dao.EmployeeDao ED = new Model.dao.EmployeeDao();
            if (CheckEmpty())
            {
                if (ED.CheckPass(empid, tbOldPass.Password))
                {
                    if (ED.ChangePass(empid, tbPass.Password))
                    {
                        MessageBox.Show("Change Password Successfully!");
                        this.Close();
                       
                    }
                    else
                    {
                        MessageBox.Show("Failed To Change Password !");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Wrong Old Password !");
                }
            }
        }
    }
}
