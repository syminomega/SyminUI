using System;
using System.Collections;
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
    public class EmbossBorder : DecorationBase
    {
        static EmbossBorder()
        {

            DefaultStyleKeyProperty.OverrideMetadata(typeof(EmbossBorder),
                new FrameworkPropertyMetadata(typeof(EmbossBorder)));
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
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

        // Using a DependencyProperty as the backing store for CornerRadius.
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius",
                typeof(CornerRadius), typeof(EmbossBorder),
                new PropertyMetadata(new CornerRadius(4)));
        
        // Using a DependencyProperty as the backing store for LightBrush.
        public static readonly DependencyProperty LightBrushProperty =
            DependencyProperty.Register("LightBrush",
                typeof(SolidColorBrush), typeof(EmbossBorder), 
                new PropertyMetadata(Brushes.WhiteSmoke));
        
        // Using a DependencyProperty as the backing store for ShadowBrush.
        public static readonly DependencyProperty ShadowBrushProperty =
            DependencyProperty.Register("ShadowBrush",
                typeof(SolidColorBrush), typeof(EmbossBorder),
                new PropertyMetadata(Brushes.DarkGray));
        
        #endregion

    }
}

