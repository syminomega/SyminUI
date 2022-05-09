using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SyminUI.Convertor.Emboss
{
    [ValueConversion(typeof(double), typeof(Thickness))]
    public class RatioToMargin : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ratio = (double)value;
            //数值为1的时候边距最小，露出的着色边框越大
            var marginValue = 4 * (1 - ratio);
            return new Thickness(marginValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
