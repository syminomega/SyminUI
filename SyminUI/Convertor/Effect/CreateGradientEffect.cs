using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using SyminUI.Effects;

namespace SyminUI.Convertor.Effect
{
    public class CreateGradientEffect : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            
            var brushA = (SolidColorBrush)values[0];
            var brushB = (SolidColorBrush)values[1];
            var radiusValue = (double)values[2];
            var size = (double)values[3];

            var center = new Point(0, 0);
            var initRange = 0d;

            var paramStr = parameter as string;
            if (!string.IsNullOrEmpty(paramStr))
            {
                var paramArray = paramStr.Split(',');
                var p1 = double.Parse(paramArray[0]);
                var p2 = double.Parse(paramArray[1]);
                center = new Point(p1, p2);
                initRange = double.Parse(paramArray[2]);
            }
            var angleGradientEffect = new AngleGradientEffect
            {
                Center = center,
                Color1 = brushA.Color,
                Color2 = brushB.Color
            };

            //计算转过角度
            var angleClip = Math.Atan((size - radiusValue) / size) / (2 * Math.PI);
            var angleStart = initRange + angleClip;
            var angleEnd = initRange + 0.25 - angleClip;

            angleGradientEffect.AngleRange = new Point(angleStart, angleEnd);

            return angleGradientEffect;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
