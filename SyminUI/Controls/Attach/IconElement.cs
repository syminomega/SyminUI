using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SyminUI.Controls.Attach
{
    public class IconElement : DependencyObject
    {
        public static Geometry GetGeometry(DependencyObject obj)
        {
            return (Geometry)obj.GetValue(GeometryProperty);
        }

        public static void SetGeometry(DependencyObject obj, Geometry value)
        {
            obj.SetValue(GeometryProperty, value);
        }

        // Using a DependencyProperty as the backing store for Geometry.
        public static readonly DependencyProperty GeometryProperty =
            DependencyProperty.RegisterAttached("Geometry", 
                typeof(Geometry), typeof(IconElement));


    }
}
