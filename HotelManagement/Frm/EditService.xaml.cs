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
    /// Interaction logic for EditService.xaml
    /// </summary>
    public partial class EditService : Window
    {

        public EditService(String Name, String Type, double Price)
        {
  
            InitializeComponent();
            tbName.Text = Name;
            tbPrice.Text = Price.ToString();
            boxType.Text = Type;
           
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
            if (tbPrice.Text != "")
            {
                Model.entity.SERVICE r = new Model.entity.SERVICE();
   
                r.NAME = tbName.Text;
                r.PRICE = Double.Parse(tbPrice.Text);
                r.TYPE = boxType.Text;
              
                Model.dao.ServiceDao sd = new Model.dao.ServiceDao();
                sd.Edit(r);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter price!");
            }


        }
    }
}
