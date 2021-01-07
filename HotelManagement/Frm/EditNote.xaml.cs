using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for EditNote.xaml
    /// </summary>
    public partial class EditNote : Window
    {
        String RoomName;
        public EditNote(String Note,String Name)
        {
            InitializeComponent();
            tbNote.Text = Note;
            RoomName = Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbNote.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String note = tbNote.Text;
            Model.dao.RoomDao rd = new Model.dao.RoomDao();
            if (rd.EditNote(note, RoomName))
            {
                MessageBox.Show("Successfully Saved");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
        }
    }
}
