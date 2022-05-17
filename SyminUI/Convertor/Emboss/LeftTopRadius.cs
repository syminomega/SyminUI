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
    public class LeftTopRadius : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var radius = (CornerRadius)values[0];
            var isWidthGreaterThanHeight = (bool)values[1];
            if (isWidthGreaterThanHeight)
            {
                return new CornerRadius(radius.TopLeft, radius.TopRight, 0, 0);
            }
            else
            {
                return new CornerRadius(radius.TopLeft, 0, 0, radius.BottomLeft);
            }
            
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
