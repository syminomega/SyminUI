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
    [ValueConversion(typeof(CornerRadius), typeof(CornerRadius))]
    public class CornerRadiusMultiply : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var originRadius = (CornerRadius)value;
            var paramStr = parameter as string;
            if (string.IsNullOrEmpty(paramStr))
            {
                return originRadius;
            }
            var paramArray = paramStr.Split(',');
            var r0 = originRadius.TopLeft * double.Parse(paramArray[0]);
            var r1 = originRadius.TopRight * double.Parse(paramArray[1]);
            var r2 = originRadius.BottomRight * double.Parse(paramArray[2]);
            var r3 = originRadius.BottomLeft * double.Parse(paramArray[3]);

            return new CornerRadius(r0, r1, r2, r3);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
