using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
        }
        private void AgeNumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void PhoneNumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
        private bool CheckEmpty()
        {
            if (tbIDCard.Text == "" || tbName.Text == "" || tbAge.Text == "" || tbPhone.Text == "" || tbEmail.Text == "" || tbAddress.Text == ""|| tbUser.Text == "" ||tbPass.Password == "")
            {
                MessageBox.Show("Please Enter All Information !");
                return false;
            }
            else
            {
                return true;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmpty())
            {
                Model.dao.EmployeeDao ED = new Model.dao.EmployeeDao();
                if (!ED.CheckEmp(tbIDCard.Text))
                {
                    Model.entity.EMPLOYEE emp = new Model.entity.EMPLOYEE();
                    emp.IDCARD = tbIDCard.Text;
                    emp.NAME = tbName.Text;
                    emp.AGE = int.Parse(tbAge.Text);
                    emp.PHONENUMBER = tbPhone.Text;
                    emp.EMAIL = tbEmail.Text;
                    emp.ADDRESS = tbAddress.Text;
                    emp.USERNAME = tbUser.Text;
                    emp.PASSWORD = tbPass.Password;
                    emp.ACCOUNTTYPE = boxType.Text;

                    if (ED.Add(emp))
                    {
                        MessageBox.Show("Employee Added !");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed To Add !");
                    }
                }
                else
                {
                    MessageBox.Show("Employee Is Already Exists!");
                }

            }
        }
    }
}
