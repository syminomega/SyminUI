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
    public class RightBottomRadius : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var radius = (CornerRadius)values[0];
            var isWidthGreaterThanHeight = (bool)values[1];
            if (isWidthGreaterThanHeight)
            {
                return new CornerRadius(0, 0, radius.BottomRight, radius.BottomLeft);
            }
            else
            {
                return new CornerRadius(0, radius.TopRight, radius.BottomRight, 0);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
