using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SyminUI.Controls.Decorations
{
    public class LightedSurface : Control
    {
        static LightedSurface()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LightedSurface),
                new FrameworkPropertyMetadata(typeof(LightedSurface)));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MousePosition = e.GetPosition(this);
            DisplayText = $"x:{MousePosition.X} y:{MousePosition.Y}";
        }



        public Point MousePosition
        {
            get { return (Point)GetValue(MousePositionProperty); }
            set { SetValue(MousePositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MousePosition.
        public static readonly DependencyProperty MousePositionProperty =
            DependencyProperty.Register("MousePosition",
                typeof(Point), typeof(LightedSurface),
                new PropertyMetadata(new Point(0, 0)));



        public string DisplayText
        {
            get { return (string)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayText.
        public static readonly DependencyProperty DisplayTextProperty =
            DependencyProperty.Register("DisplayText",
                typeof(string), typeof(LightedSurface),
                new PropertyMetadata(""));


    }
}
