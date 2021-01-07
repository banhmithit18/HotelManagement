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
    /// Interaction logic for EmployeeManagement.xaml
    /// </summary>
    public partial class EmployeeManagement : UserControl
    {
        public EmployeeManagement()
        {
            InitializeComponent();
            this.MouseRightButtonUp += new MouseButtonEventHandler(Window1_MouseRightButtonUp);
            GetEmployeeView();
        }
        public void GetEmployeeView()
        {
            Model.dao.EmployeeDao SD = new Model.dao.EmployeeDao();
            var q = SD.GetEmployee();
            dataEmployee.ItemsSource = q;
        }
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            HOTELMANAGEMENTEntities hm = new HOTELMANAGEMENTEntities();
            var filter = hm.CUSTOMERs.Where(r => r.NAME.Contains(tbSearch.Text)).ToList();
            dataEmployee.ItemsSource = filter;
        }
        private void EditEmployee(object sender, RoutedEventArgs e)
        {
            if (dataEmployee.SelectedItems.Count > 0)
            {
                Model.view.EmployeeView row = (Model.view.EmployeeView)dataEmployee.SelectedItem;

                Model.entity.EMPLOYEE emp = new EMPLOYEE();
                emp.IDCARD = row.IDCARD;
                emp.NAME = row.NAME;
                emp.AGE = row.AGE;
                emp.ADDRESS = row.ADDRESS;
                emp.EMAIL = row.EMAIL;
                emp.PHONENUMBER = row.PHONENUMBER;
                emp.ACCOUNTTYPE = row.ACCOUNTTYPE;

                Frm.EditEmployee EE = new Frm.EditEmployee(emp);
                EE.ShowDialog();
                GetEmployeeView();
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
                dataEmployee.SelectedItem = row.DataContext;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frm.AddEmployee add = new Frm.AddEmployee();
            add.ShowDialog();
            GetEmployeeView();
        }
        private void DeleteEmp(object sender, RoutedEventArgs e)
        {
            if (dataEmployee.SelectedItems.Count > 0)
            {
                Model.view.EmployeeView RowData = (Model.view.EmployeeView)dataEmployee.SelectedItem;
                Model.dao.EmployeeDao ED = new Model.dao.EmployeeDao();
                if (ED.DeleteEmp(RowData.IDCARD))
                {
                    MessageBox.Show("Employee Deleted !");
                    GetEmployeeView();
                }
                else
                {
                    MessageBox.Show("Failed To Delete !");
                }
            }
    
        }
    }
}
