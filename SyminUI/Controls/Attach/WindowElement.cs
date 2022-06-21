using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SyminUI.Controls.Attach
{
    public class WindowElement : DependencyObject
    {


        public static UIElement GetTitleBar(DependencyObject obj)
        {
            return (UIElement)obj.GetValue(TitleBarProperty);
        }

        public static void SetTitleBar(DependencyObject obj, UIElement value)
        {
            obj.SetValue(TitleBarProperty, value);
        }

        // Using a DependencyProperty as the backing store for TitleBar.
        public static readonly DependencyProperty TitleBarProperty =
            DependencyProperty.RegisterAttached("TitleBar", 
                typeof(UIElement), typeof(WindowElement));


    }
}
