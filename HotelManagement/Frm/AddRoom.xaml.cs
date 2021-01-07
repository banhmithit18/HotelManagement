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
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        public AddRoom()
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
            Model.dao.RoomDao rd = new Model.dao.RoomDao();

            Model.entity.ROOM r = new Model.entity.ROOM();
            r.NAME = tbName.Text;
            if (tbName.Text != "")
            {
                if (!rd.CheckRoomName(r.NAME))
                {
                    if (tbPrice.Text != "")
                    {
                        r.PRICE = Double.Parse(tbPrice.Text);
                        r.TYPE = boxType.Text;
                        r.NOTE = "";
                        r.CATEGORY = boxCate.Text;
                        r.STATUS = "Empty";
                        if (rd.Add(r))
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
                    MessageBox.Show("Room's Name Is Already Exists");

                }
            }
            else
            {
                MessageBox.Show("Please Enter Room Name!");
            }
          
        }
    }
}
