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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace HotelManagement.UC
{
    /// <summary>
    /// Interaction logic for ServiceManagement.xaml
    /// </summary>
    public partial class ServiceManagement : UserControl
    {
        public ServiceManagement()
        {
            InitializeComponent();
            GetServiceView();
            this.MouseRightButtonUp += new MouseButtonEventHandler(Window1_MouseRightButtonUp);

        }
        public void GetServiceView()
        {
            Model.dao.ServiceDao SD = new Model.dao.ServiceDao();
            var q = SD.GetService();
            dataService.ItemsSource = q;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frm.AddService add = new Frm.AddService();
            add.ShowDialog();
            GetServiceView();
        }
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            var filter = hm.SERVICEs.Where(r => r.NAME.Contains(tbSearch.Text)).ToList();
            dataService.ItemsSource = filter;
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
                dataService.SelectedItem = row.DataContext;

                Model.view.ServiceView RowData = (Model.view.ServiceView)dataService.SelectedItem;

                Disable_MenuItem.Header = RowData.STATUS == "Disabled" ? "Active" : "Disable Room";

            
            }
        }
        private void DisableService(object sender, RoutedEventArgs e)
        {
            if (dataService.SelectedItems.Count > 0)
            {
                Model.dao.ServiceDao sd = new Model.dao.ServiceDao();
                Model.view.ServiceView RowData = (Model.view.ServiceView)dataService.SelectedItem;
                if (RowData.STATUS == "Active")
                {
                    sd.ChangeStatus(2, RowData.NAME);
                }
                else
                {
                    sd.ChangeStatus(1, RowData.NAME);
                }
                GetServiceView();
            }
        }
        private void EditService(object sender, RoutedEventArgs e)
        {
            if (dataService.SelectedItems.Count > 0)
            {
                Model.view.ServiceView row = (Model.view.ServiceView)dataService.SelectedItem;

                Frm.EditService ES = new Frm.EditService(row.NAME,row.TYPE, row.PRICE);

                ES.ShowDialog();
                GetServiceView();
            }
        }

    }
}
