using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SyminUI.Convertor
{
    [ValueConversion(typeof(double), typeof(CornerRadius))]
    public class ValueToRadius : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var radiusValue = (double)value;

            var paramStr = parameter as string;
            if (!string.IsNullOrEmpty(paramStr))
            {
                var paramArray = paramStr.Split(',');
                var r1 = double.Parse(paramArray[0]) * radiusValue;
                var r2 = double.Parse(paramArray[1]) * radiusValue;
                var r3 = double.Parse(paramArray[2]) * radiusValue;
                var r4 = double.Parse(paramArray[3]) * radiusValue;
                return new CornerRadius(r1, r2, r3, r4);
            }
            else
            {
                return new CornerRadius(radiusValue);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
