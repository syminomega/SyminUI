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
    public class IntensityToMarginRightBottom : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intensity = (double)value;
            //数值为1的时候边距最小，露出的着色边框越大
            var marginValue = 4 * intensity;
            return new Thickness(marginValue, marginValue, -marginValue, -marginValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
