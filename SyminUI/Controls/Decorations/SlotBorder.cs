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
using SyminUI.Effects;

namespace SyminUI.Controls.Decorations
{
    public class SlotBorder : DecorationBase
    {
        static SlotBorder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SlotBorder),
                new FrameworkPropertyMetadata(typeof(SlotBorder)));
        }

        public double Radius
        {
            get => (double)GetValue(RadiusProperty);
            set => SetValue(RadiusProperty, value);
        }

        public SolidColorBrush LightBrush
        {
            get => (SolidColorBrush)GetValue(LightBrushProperty);
            set => SetValue(LightBrushProperty, value);
        }

        public SolidColorBrush ShadowBrush
        {
            get => (SolidColorBrush)GetValue(ShadowBrushProperty);
            set => SetValue(ShadowBrushProperty, value);
        }

        #region Dependency Properties

        // Using a DependencyProperty as the backing store for Radius.
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius",
                typeof(double), typeof(SlotBorder),
                new PropertyMetadata(4.0));


        // Using a DependencyProperty as the backing store for LightBrush.
        public static readonly DependencyProperty LightBrushProperty =
            DependencyProperty.Register("LightBrush",
                typeof(SolidColorBrush), typeof(SlotBorder),
                new PropertyMetadata(Brushes.WhiteSmoke));


        // Using a DependencyProperty as the backing store for ShadowBrush.
        public static readonly DependencyProperty ShadowBrushProperty =
            DependencyProperty.Register("ShadowBrush",
                typeof(SolidColorBrush), typeof(SlotBorder),
                new PropertyMetadata(Brushes.DarkGray));

        #endregion

    }
}