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
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        int cusid;
        public EditCustomer(Model.entity.CUSTOMER c)
        {
            InitializeComponent();
            cusid = c.ID;
            tbIDCard.Text = c.IDCARD;        
            tbIDCard.IsReadOnly = true;
            tbIDCard.IsEnabled = false;
            
            tbCusName.Text = c.NAME;
            tbCusName.IsReadOnly = true;
            tbCusName.IsEnabled = false;

            tbCusAge.Text = c.AGE.ToString();
            tbCusPhone.Text = c.PHONENUMBER;
            tbCusAddress.Text = c.ADDRESS;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(CheckEmpty())
            {
                Model.entity.CUSTOMER c = new Model.entity.CUSTOMER();
                c.ID = cusid;
                c.AGE = int.Parse(tbCusAge.Text);
                c.PHONENUMBER = tbCusPhone.Text;
                c.ADDRESS = tbCusAddress.Text;

                Model.dao.CustomerDao CD = new Model.dao.CustomerDao();
                CD.Edit(c);
                this.Close();

            }
        }
    }
}
