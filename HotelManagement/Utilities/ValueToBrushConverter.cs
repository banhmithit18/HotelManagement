using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace HotelManagement.Utilities
{
    public class ValueToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int input = 0;
            try
            {
                DataGridCell dgc = (DataGridCell)value;
                Model.view.BookingView rowView = (Model.view.BookingView)dgc.DataContext;
                DateTime now = DateTime.Now;
                DateTime CheckIn = DateTime.Parse(rowView.CheckInTime);
                TimeSpan ts = CheckIn - now;
                if (ts.TotalDays <= 0)
                {
                    input = 1;
                }
              
            }
            catch (InvalidCastException e)
            {
                return DependencyProperty.UnsetValue;
            }
            switch (input)
            {
                
                case 1: return Brushes.Red;
                
                default: return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
