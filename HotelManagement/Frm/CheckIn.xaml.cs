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
    /// Interaction logic for CheckIn.xaml
    /// </summary>
    public partial class CheckIn : Window
    {
        String Status;
        String RoomName;
        int empid;
        public CheckIn(String Name, String status,int id)
        {

            empid = id;
            InitializeComponent();
            RoomName = Name;
            Status = status;
            if (Status == "Booked")
            {
                Model.dao.RoomDao RD = new Model.dao.RoomDao();
                Model.dao.CustomerDao CD = new Model.dao.CustomerDao();
                String [] info = RD.GetIDCardWithCheckOut(RoomName);
                tbIDCard.Text = info[0];
                Model.entity.CUSTOMER c = CD.GetCustomerInfo(tbIDCard.Text);
                tbCusName.Text = c.NAME;
                tbCusAge.Text = c.AGE.ToString();
                tbCusPhone.Text = c.PHONENUMBER;
                tbCusAddress.Text = c.ADDRESS;
                dpCheckOut.Text = info[1];
                tbIDCard.IsReadOnly = true;
                tbIDCard.IsEnabled = false;
                
            }
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
            if (tbIDCard.Text == "" || tbCusName.Text == "" || tbCusAge.Text == "" || tbCusPhone.Text == "" || tbCusAddress.Text == "" || dpCheckOut.Text == "")
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
        
            Model.dao.ServiceDao sd = new Model.dao.ServiceDao();
            Model.dao.RoomDao RD = new Model.dao.RoomDao();
            Model.dao.CustomerDao CD = new Model.dao.CustomerDao();
            Model.dao.OrderDetailDao odd = new Model.dao.OrderDetailDao();
            Model.dao.SrvOrderDao sod = new Model.dao.SrvOrderDao();
            if (CD.CheckCus(tbIDCard.Text))
            {
                if (CheckEmpty())
                {
                    Model.entity.SRVORDER order = new Model.entity.SRVORDER();
                    order.CUSID = CD.GetID(tbIDCard.Text);
                    order.ROOMID = RD.GetID(RoomName);
                    if (sd.CheckServiceName(2, RoomName))
                    {
                        order.SRVID = sd.GetServiceId(RoomName);
                    }
                    else
                    {
                        Model.entity.SERVICE s = new Model.entity.SERVICE();
                        s.NAME = RD.GetSrvName(RoomName);
                        s.TYPE = "Room";
                        s.PRICE = RD.GetPrice(RoomName);
                        s.STATUS = "Active";
                        if (sd.Add(s))
                        {
                            order.SRVID = sd.GetServiceId(RoomName);

                        }

                    }
                    order.QUANTITY = 1;
                    order.PAYMENTSTATUS = false;
                    if (sod.Add(order))
                    {
                        DateTime now = DateTime.Now;
                        Model.entity.ORDERDETAIL orderdetail = new Model.entity.ORDERDETAIL();
                        orderdetail.date = now.ToString("dd/MM/yyyy HH:mm:ss");
                        orderdetail.DISCOUNT = 0;
                        orderdetail.EMPID = empid;
                        orderdetail.PRICE = RD.GetPrice(RoomName);
                        orderdetail.ORDERID = sod.GetInsertedSrvOrderId();
                        if (odd.Add(orderdetail))
                        {
                            if (Status == "Booked")
                            {
                                Model.dao.BookingDao BD = new Model.dao.BookingDao();
                                BD.ChangeBookingStatus(CD.GetID(tbIDCard.Text), RD.GetID(RoomName));
                            }
                            RD.DisableRoom(4, RoomName);
                            MessageBox.Show("Check In Successfully!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed To Check In!");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed To Check In!");
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
                    c.AGE = int.Parse(tbCusAge.Text);
                    c.PHONENUMBER = tbCusPhone.Text;
                    c.ADDRESS = tbCusAddress.Text;
                    if (CD.Add(c))
                    {
                        Model.entity.SRVORDER order = new Model.entity.SRVORDER();
                        order.CUSID = CD.GetID(tbIDCard.Text);
                        order.ROOMID = RD.GetID(RoomName);
                        if (sd.CheckServiceName(2, RoomName))
                        {
                            order.SRVID = sd.GetServiceId(RoomName);
                        }
                        else
                        {
                            Model.entity.SERVICE s = new Model.entity.SERVICE();
                            s.NAME = RD.GetSrvName(RoomName);
                            s.TYPE = "Room";
                            s.PRICE = RD.GetPrice(RoomName);
                            s.STATUS = "Active";
                            if (sd.Add(s))
                            {
                                order.SRVID = sd.GetServiceId(RoomName);

                            }

                        }
                        order.QUANTITY = 1;
                        order.PAYMENTSTATUS = false;
                        if (sod.Add(order))
                        {
                            DateTime now = DateTime.Now;
                            Model.entity.ORDERDETAIL orderdetail = new Model.entity.ORDERDETAIL();
                            orderdetail.date = now.ToString("dd/MM/yyyy HH:mm:ss");
                            orderdetail.DISCOUNT = 0;
                            orderdetail.EMPID = empid; 
                            orderdetail.PRICE = RD.GetPrice(RoomName);
                            orderdetail.ORDERID = sod.GetInsertedSrvOrderId();
                            if (odd.Add(orderdetail))
                            {
                                RD.DisableRoom(4, RoomName);
                                MessageBox.Show("Check In Successfully!");
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Failed To Check In!");

                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed To Check In!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed To Add Customer!");
                    }

                }
            }
        
        }
    }
}
