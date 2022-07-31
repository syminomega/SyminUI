using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;

namespace SyminUI.Convertor.Range
{
    public class ValueToRangeWidth : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var paramStr = parameter as string;
            _ = double.TryParse(paramStr, out var margin);

            var minimum = (double)values[0];
            var maximum = (double)values[1];
            var currentValue = (double)values[2];
            var width = (double)values[3];
            var actualWidth = width - 2 * margin;

            if (actualWidth < 0)
            {
                actualWidth = 0;
            }
            if (currentValue < minimum)
            {
                return 0;
            }
            if (currentValue > maximum)
            {
                return actualWidth;
            }

            return ((currentValue - minimum) / (maximum - minimum)) * actualWidth;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
