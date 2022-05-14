using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SyminUI.Convertor.Effect
{
    //专门用于自定义的角度渐变
    public class RadiusToGradientAngle : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var radius = (double)values[0];
            var width = (double)values[1];

            var paramStr = parameter as string;
            //起始位置
            _ = double.TryParse(paramStr, out double initRange);
            //计算转过角度
            var angleClip = Math.Atan((width - radius) / width) / (2 * Math.PI);
            var angleStart = initRange + angleClip;
            var angleEnd = initRange + 0.25 - angleClip;
            return new Point(angleStart, angleEnd);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
