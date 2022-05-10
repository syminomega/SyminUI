using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace SyminUI.Convertor.Emboss
{
    public class LightAndShadow : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var lightBrush = (SolidColorBrush)values[0];
            var shadowBrush = (SolidColorBrush)values[1];

            var lightStop = new GradientStop(lightBrush.Color, 0.5);
            var shadowStop = new GradientStop(shadowBrush.Color, 0.5);

            var grandient = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 0)
            };
            grandient.GradientStops.Add(lightStop);
            grandient.GradientStops.Add(shadowStop);
            grandient.RelativeTransform = new RotateTransform(52, 0.5, 0.5);

            return grandient;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
