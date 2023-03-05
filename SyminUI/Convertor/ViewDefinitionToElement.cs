using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SyminUI.Convertor
{
    [ValueConversion(typeof(IView), typeof(FrameworkElement))]
    public class ViewDefinitionToElement : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            var viewDefinition = (IView)value;
            var content = viewDefinition.Element;
            return content;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
