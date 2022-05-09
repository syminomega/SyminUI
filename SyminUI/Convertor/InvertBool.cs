using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SyminUI.Convertor
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InvertBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueIn = (bool)value;
            return !valueIn;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueIn = (bool)value;
            return !valueIn;
        }
    }
}
