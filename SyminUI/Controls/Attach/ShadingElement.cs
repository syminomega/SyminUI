using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SyminUI.Controls.Attach
{
    public class ShadingElement : DependencyObject
    {
        #region LightBrush
        public static SolidColorBrush GetLightBrush(DependencyObject obj)
        {
            return (SolidColorBrush)obj.GetValue(LightBrushProperty);
        }
        public static void SetLightBrush(DependencyObject obj, SolidColorBrush value)
        {
            obj.SetValue(LightBrushProperty, value);
        }

        // Using a DependencyProperty as the backing store for LightBrush.
        public static readonly DependencyProperty LightBrushProperty =
            DependencyProperty.RegisterAttached("LightBrush",
                typeof(SolidColorBrush), typeof(ShadingElement),
                new PropertyMetadata(Brushes.White));

        #endregion

        #region ShadowBrush
        public static SolidColorBrush GetShadowBrush(DependencyObject obj)
        {
            return (SolidColorBrush)obj.GetValue(ShadowBrushProperty);
        }

        public static void SetShadowBrush(DependencyObject obj, SolidColorBrush value)
        {
            obj.SetValue(ShadowBrushProperty, value);
        }

        // Using a DependencyProperty as the backing store for ShadowBrush. 
        public static readonly DependencyProperty ShadowBrushProperty =
            DependencyProperty.RegisterAttached("ShadowBrush",
                typeof(SolidColorBrush), typeof(ShadingElement),
                new PropertyMetadata(Brushes.Black));

        #endregion

        #region DisabledBackground
        public static Brush GetDisabledBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(DisabledBackgroundProperty);
        }

        public static void SetDisabledBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(DisabledBackgroundProperty, value);
        }

        // Using a DependencyProperty as the backing store for DisabledBackground.
        public static readonly DependencyProperty DisabledBackgroundProperty =
            DependencyProperty.RegisterAttached("DisabledBackground",
                typeof(Brush), typeof(ShadingElement),
                new PropertyMetadata(Brushes.Gray));

        #endregion

        #region DisabledForeground
        public static Brush GetDisabledForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(DisabledForegroundProperty);
        }

        public static void SetDisabledForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(DisabledForegroundProperty, value);
        }

        // Using a DependencyProperty as the backing store for DisabledForeground.
        public static readonly DependencyProperty DisabledForegroundProperty =
            DependencyProperty.RegisterAttached("DisabledForeground",
                typeof(Brush), typeof(ShadingElement),
                new PropertyMetadata(Brushes.DarkGray));

        #endregion

        #region LightedBorder
        public static Brush GetLightedBorder(DependencyObject obj)
        {
            return (Brush)obj.GetValue(LightedBorderProperty);
        }

        public static void SetLightedBorder(DependencyObject obj, Brush value)
        {
            obj.SetValue(LightedBorderProperty, value);
        }

        // Using a DependencyProperty as the backing store for LightedBorder.
        public static readonly DependencyProperty LightedBorderProperty =
            DependencyProperty.RegisterAttached("LightedBorder",
                typeof(Brush), typeof(ShadingElement),
                new PropertyMetadata(Brushes.White));

        #endregion


    }
}
