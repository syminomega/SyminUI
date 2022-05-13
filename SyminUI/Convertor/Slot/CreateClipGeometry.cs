using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Globalization;
using System.Windows.Media;

namespace SyminUI.Convertor.Slot
{
    public class CreateClipGeometry : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var radius = (double)values[0];
            var width = (double)values[1];
            var height = (double)values[2];

            var paramStr = parameter as string;
            _ = double.TryParse(paramStr, out double margin);

            var rectW = width - (2 * margin);
            var rectH = height - (2 * margin);

            //防止初始化时候小于0
            if (rectW < 0)
            {
                rectW = 0;
            }
            if (rectH < 0)
            {
                rectH = 0;
            }

            RectangleGeometry rectangleGeometry = new()
            {
                RadiusX = radius,
                RadiusY = radius,
                Rect = new Rect(margin, margin, rectW, rectH),
            };

            return rectangleGeometry;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
