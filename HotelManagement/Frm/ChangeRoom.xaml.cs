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
    /// Interaction logic for ChangeRoom.xaml
    /// </summary>
    public partial class ChangeRoom : Window
    {

        public ChangeRoom(String Name, Double Price, String type, String Category)
        {

            InitializeComponent();
            tbName.Text = Name;
            tbPrice.Text = Price.ToString();
            boxType.Text = type;
            boxCate.Text = Category;
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
                Model.entity.ROOM r = new Model.entity.ROOM();
                r.NAME = tbName.Text;
                r.PRICE = Double.Parse(tbPrice.Text);
                r.TYPE = boxType.Text;
                r.CATEGORY = boxCate.Text;
                Model.dao.RoomDao rd = new Model.dao.RoomDao();
                rd.Edit(r);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter price!");
            }

        
        }
    }
 }

