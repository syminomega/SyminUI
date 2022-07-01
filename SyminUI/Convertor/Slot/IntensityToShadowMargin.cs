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
    public class IntensityToShadowMargin : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intensity = (double)value;
            //此处与中央Margin匹配
            var offset = 4 + intensity * 4;
            return new Thickness(0,0,offset,offset);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
