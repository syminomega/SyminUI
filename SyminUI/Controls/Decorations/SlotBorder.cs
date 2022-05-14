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
    public class SlotBorder : ContentControl
    {
        static SlotBorder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SlotBorder),
                new FrameworkPropertyMetadata(typeof(SlotBorder)));
           
        }

        public double Intensity
        {
            get { return (double)GetValue(IntensityProperty); }
            set { SetValue(IntensityProperty, value); }
        }

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public bool ShaderEnabled
        {
            get { return (bool)GetValue(ShaderEnabledProperty); }
            set { SetValue(ShaderEnabledProperty, value); }
        }

        public SolidColorBrush LightBrush
        {
            get { return (SolidColorBrush)GetValue(LightBrushProperty); }
            set { SetValue(LightBrushProperty, value); }
        }

        public SolidColorBrush ShadowBrush
        {
            get { return (SolidColorBrush)GetValue(ShadowBrushProperty); }
            set { SetValue(ShadowBrushProperty, value); }
        }


        #region Dependency Properties

        // Using a DependencyProperty as the backing store for Intensity.
        public static readonly DependencyProperty IntensityProperty =
            DependencyProperty.Register("Intensity",
                typeof(double), typeof(SlotBorder),
                new PropertyMetadata(1.0));

        // Using a DependencyProperty as the backing store for Radius.
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius",
                typeof(double), typeof(SlotBorder),
                new PropertyMetadata(4.0));

        // Using a DependencyProperty as the backing store for ShaderEnabled.
        public static readonly DependencyProperty ShaderEnabledProperty =
            DependencyProperty.Register("ShaderEnabled",
                typeof(bool), typeof(SlotBorder),
                new PropertyMetadata(true));

        // Using a DependencyProperty as the backing store for LightBrush.
        public static readonly DependencyProperty LightBrushProperty =
            DependencyProperty.Register("LightBrush",
                typeof(SolidColorBrush), typeof(SlotBorder));

        // Using a DependencyProperty as the backing store for ShadowBrush.
        public static readonly DependencyProperty ShadowBrushProperty =
            DependencyProperty.Register("ShadowBrush",
                typeof(SolidColorBrush), typeof(SlotBorder));

        #endregion




    }


}
