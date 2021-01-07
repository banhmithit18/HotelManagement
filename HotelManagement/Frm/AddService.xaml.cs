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
    /// Interaction logic for AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        public AddService()
        {
            InitializeComponent();
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
  
            Model.dao.ServiceDao sd = new Model.dao.ServiceDao();
            Model.entity.SERVICE s = new Model.entity.SERVICE();
            s.NAME = tbName.Text;
            if (tbName.Text != "")
            {
                if (!sd.CheckServiceName(1,s.NAME))
                {
                    if (tbPrice.Text != "")
                    {
                        s.PRICE = Double.Parse(tbPrice.Text);
                        s.TYPE = boxType.Text;
                        s.STATUS = "Active";
                        if (sd.Add(s))
                        {
                            MessageBox.Show("Successfully Saved");
                        }
                        else
                        {
                            MessageBox.Show("Not Saved");
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Price!");
                    }

                }
                else
                {
                    MessageBox.Show("Service's Name Is Already Exists");

                }
            }
            else
            {
                MessageBox.Show("Please Enter Service Name!");
            }
        }
    }
}
