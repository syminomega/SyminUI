using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SyminUI.Convertor.List;

//隔行交错背景颜色
[ValueConversion(typeof(int), typeof(Visibility))]
public class InterlacedBackgroundVisibility : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var line = (int)value;
        return line % 2 == 0 ? Visibility.Collapsed : Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}