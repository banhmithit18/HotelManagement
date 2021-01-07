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
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        public EditEmployee(Model.entity.EMPLOYEE emp)
        {
            InitializeComponent();
            tbIDCard.Text = emp.IDCARD;
            tbIDCard.IsReadOnly = true;
            tbIDCard.IsEnabled = false;

            tbName.Text = emp.NAME;
            tbName.IsReadOnly = true;
            tbName.IsEnabled = false;

            tbAge.Text = emp.AGE.ToString();
            tbEmail.Text = emp.EMAIL;
            tbPhone.Text = emp.PHONENUMBER;
            tbAddress.Text = emp.ADDRESS;
            boxType.Text = emp.ACCOUNTTYPE;

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
        private bool CheckEmpty()
        {
            if (tbIDCard.Text == "" || tbName.Text == "" || tbAge.Text == "" || tbPhone.Text == "" || tbEmail.Text == "" || tbAddress.Text == "")
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
                Model.entity.EMPLOYEE emp = new Model.entity.EMPLOYEE();
                emp.IDCARD = tbIDCard.Text;
                emp.AGE = int.Parse(tbAge.Text);
                emp.EMAIL = tbEmail.Text;
                emp.ADDRESS = tbAddress.Text;
                emp.PHONENUMBER = tbPhone.Text;
                emp.ACCOUNTTYPE = boxType.Text;
                Model.dao.EmployeeDao ED = new Model.dao.EmployeeDao();
                if (ED.EditEmp(emp))
                {
                    MessageBox.Show("Employee Edited !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed To Edited !");

                }
            }
        }
    }
}
