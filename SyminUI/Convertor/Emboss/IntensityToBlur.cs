using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SyminUI.Convertor.Emboss
{
    [ValueConversion(typeof(double), typeof(double))]
    public class IntensityToBlur : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intensity = (double)value;
            //数值最大的时候，模糊达到预设最大值 4~12
            var blur = 4 + intensity * 8;
            return blur;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
