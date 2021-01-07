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
    /// Interaction logic for OrderService.xaml
    /// </summary>
    public partial class OrderService : Window
    {
        String RoomName;
        int empid;
        public OrderService(String Name, int id)
        {
            empid = id;
            RoomName = Name;
            InitializeComponent();
            Model.dao.ServiceDao SD = new Model.dao.ServiceDao();
            List<String> SrvName = SD.getServiceName();
            boxService.ItemsSource = SrvName;

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValidInput(e.Text);
        }
        private bool IsValidInput(string p)
        {
            return Regex.Match(p, @"^[0-9]*(?:\.[0-9]*)?$").Success;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbQuantity.Text != "")
            {
                Model.dao.RoomDao RD = new Model.dao.RoomDao();
                Model.dao.CustomerDao CD = new Model.dao.CustomerDao();
                Model.dao.ServiceDao SD = new Model.dao.ServiceDao();
                Model.dao.SrvOrderDao SOD = new Model.dao.SrvOrderDao();
                Model.dao.OrderDetailDao ODD = new Model.dao.OrderDetailDao();


                Model.entity.SRVORDER order = new Model.entity.SRVORDER();
                Model.entity.ORDERDETAIL orderdetail = new Model.entity.ORDERDETAIL();

                order.CUSID = CD.GetID(RD.GetIDCard(RoomName));
                order.SRVID = SD.GetID(boxService.Text);
                order.ROOMID = RD.GetID(RoomName);
                order.QUANTITY = int.Parse(tbQuantity.Text);
                order.NOTE = tbNote.Text;
                order.PAYMENTSTATUS = false;

                if (SOD.Add(order))
                {
                    DateTime now = DateTime.Now;

                    orderdetail.ORDERID = SOD.GetInsertedSrvOrderId();
                    orderdetail.DISCOUNT = 0; //// warning
                    orderdetail.EMPID = empid;
                    orderdetail.date = now.ToString("dd/MM/yyyy HH:mm:ss");
                    orderdetail.PRICE = SD.GetPrice(boxService.Text);

                    if (ODD.Add(orderdetail))
                    {
                        MessageBox.Show("Order Successfully !");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Failed To Order !");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Quantity!");
            }
        }
    }
}
