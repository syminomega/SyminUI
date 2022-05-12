using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SyminUI.Convertor.Slot
{
    [ValueConversion(typeof(double), typeof(Thickness))]
    public class IntensityToMargin : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intensity = (double)value;
            //边距越小，留下的边框越窄
            var uniformValue = 4 * intensity + 4;
            return new Thickness(uniformValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
