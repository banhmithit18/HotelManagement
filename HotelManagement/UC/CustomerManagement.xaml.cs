using HotelManagement.Model.entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelManagement.UC
{
    /// <summary>
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class CustomerManagement : UserControl
    {
        public CustomerManagement()
        {
            InitializeComponent();
            GetCustomerView();
            this.MouseRightButtonUp += new MouseButtonEventHandler(Window1_MouseRightButtonUp);
        }
        public void GetCustomerView()
        {
            Model.dao.CustomerDao CD = new Model.dao.CustomerDao();
            var q = CD.GetCustomer();
            dataCustomer.ItemsSource = q;
        }
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            var filter = hm.CUSTOMERs.Where(r => r.NAME.Contains(tbSearch.Text)|| r.IDCARD.Contains(tbSearch.Text)|| r.ADDRESS.Contains(tbSearch.Text)).ToList();
            dataCustomer.ItemsSource = filter;
        }
        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            
          
                Frm.AddCustomer ES = new Frm.AddCustomer();

                ES.ShowDialog();
                GetCustomerView();
            
        }
        private void EditCustomer(object sender, RoutedEventArgs e)
        {
            if (dataCustomer.SelectedItems.Count > 0)
            {
                Model.view.CustomerView row = (Model.view.CustomerView)dataCustomer.SelectedItem;
                Model.entity.CUSTOMER c = new Model.entity.CUSTOMER();
                c.ID = row.ID;
                c.IDCARD = row.IDCARD;
                c.NAME = row.NAME;
                c.AGE = row.AGE;
                c.PHONENUMBER = row.PHONENUMBER;
                c.ADDRESS = row.ADDRESS;

                Frm.EditCustomer ES = new Frm.EditCustomer(c);

                ES.ShowDialog();
                GetCustomerView();
            }
        }
        void Window1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is DataGridCell))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null) return;

            if (dep is DataGridCell)
            {
                DataGridCell cell = dep as DataGridCell;
                cell.Focus();

                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                DataGridRow row = dep as DataGridRow;
                dataCustomer.SelectedItem = row.DataContext;

            }
        }
    }
}
