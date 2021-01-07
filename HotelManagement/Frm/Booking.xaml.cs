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
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        int empid;
        String RoomName;
        public Booking(String Name, int id)
        {
            empid = id;
            InitializeComponent();
            RoomName = Name;
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
        private bool CheckEmpty()
        {
            if (tbIDCard.Text == "" || tbCusName.Text == "" || tbCusAge.Text == "" || tbCusPhone.Text == "" || tbCusAddress.Text == "" || dpCheckIn.Text == "" || dpCheckOut.Text == "")
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
            Model.dao.RoomDao RD = new Model.dao.RoomDao();
            Model.dao.CustomerDao CD = new Model.dao.CustomerDao();
            Model.dao.BookingDao BD = new Model.dao.BookingDao();
            if (CD.CheckCus(tbIDCard.Text))
            {
                if (CheckEmpty())
                {
                    Model.entity.BOOKING b = new Model.entity.BOOKING();
                    b.CUSID = CD.GetID(tbIDCard.Text);
                    b.EMPID = empid; 
                    b.ROOMID = RD.GetID(RoomName);
                    b.CHECKINTIME = dpCheckIn.Text;
                    b.CHECKOUTTIME = dpCheckOut.Text;
                    DateTime now = DateTime.Now;
                    b.BOOKINGDATE = now.ToString("dd/MM/yyyy HH:mm:ss");
                    b.STATUS = true;
                    if (BD.Add(b))
                    {
                        MessageBox.Show("Booking Succesfully !");
                        RD.DisableRoom(3, RoomName);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed To Book");
                    }
                }
            }
            else
            {
                if (CheckEmpty())
                {
                    Model.entity.CUSTOMER c = new Model.entity.CUSTOMER();
                    c.IDCARD = tbIDCard.Text;
                    c.NAME = tbCusName.Text;
                    c.AGE = int.Parse( tbCusAge.Text);
                    c.PHONENUMBER = tbCusPhone.Text;
                    c.ADDRESS = tbCusAddress.Text;
                    if (CD.Add(c))
                    {
                        Model.entity.BOOKING b = new Model.entity.BOOKING();
                        b.CUSID = CD.GetID(tbIDCard.Text);
                        b.EMPID = empid;
                        b.ROOMID = RD.GetID(RoomName);
                        b.CHECKINTIME = dpCheckIn.Text;
                        b.CHECKOUTTIME = dpCheckOut.Text;
                        DateTime now = DateTime.Now;
                        b.BOOKINGDATE = now.ToString("dd/MM/yyyy HH:mm:ss");
                        b.STATUS = false;
                        if (BD.Add(b))
                        {
                            MessageBox.Show("Booking Succesfully !");
                            RD.DisableRoom(3, RoomName);
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Failed To Book");
                        }    
                    }
                    else
                    {
                        MessageBox.Show("Not Saved!");
                    }

                }
            }
        }
    }
}
