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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        public AddCustomer()
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
        private bool CheckEmpty()
        {
            if (tbIDCard.Text == "" || tbCusName.Text == "" || tbCusAge.Text == "" || tbCusPhone.Text == "" || tbCusAddress.Text == "")
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
            Model.dao.CustomerDao CD = new Model.dao.CustomerDao();
            if (CD.CheckCus(tbIDCard.Text))
            {
                Model.entity.CUSTOMER c = CD.GetCustomerInfo(tbIDCard.Text);
                tbCusName.Text = c.NAME;
                tbCusAge.Text = c.AGE.ToString();
                tbCusPhone.Text = c.PHONENUMBER;
                tbCusAddress.Text = c.ADDRESS;
                MessageBox.Show("Customer Found!");
            }
            else
            {
                MessageBox.Show("No Customer Found!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Model.dao.CustomerDao CD = new Model.dao.CustomerDao();
            if (CD.CheckCus(tbIDCard.Text))
            {
                MessageBox.Show("Customer is already exists!");
            }
            else
            {
                if (CheckEmpty())
                {
                    Model.entity.CUSTOMER c = new Model.entity.CUSTOMER();
                    c.IDCARD = tbIDCard.Text;
                    c.NAME = tbCusName.Text;
                    c.AGE = int.Parse(tbCusAge.Text);
                    c.PHONENUMBER = tbCusPhone.Text;
                    c.ADDRESS = tbCusAddress.Text;
                    if (CD.Add(c))
                    {
                        MessageBox.Show("Customer Added !");
                        this.Close();
                    }
                }
                }
            }
        }
    }

