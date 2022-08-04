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
    public class CardBorder : ContentControl
    {
        static CardBorder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CardBorder),
                new FrameworkPropertyMetadata(typeof(CardBorder)));
        }


        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius",
                typeof(CornerRadius), typeof(CardBorder),
                new PropertyMetadata(new CornerRadius(4)));



        public double LightSize
        {
            get { return (double)GetValue(LightSizeProperty); }
            set { SetValue(LightSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LightSize.
        public static readonly DependencyProperty LightSizeProperty =
            DependencyProperty.Register("LightSize",
                typeof(double), typeof(CardBorder),
                new PropertyMetadata(200.0));


        /// <summary>
        /// Enable or disable the border effect
        /// </summary>
        public bool ShaderEnabled
        {
            get => (bool)GetValue(ShaderEnabledProperty);
            set => SetValue(ShaderEnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for ShaderEnabled.
        public static readonly DependencyProperty ShaderEnabledProperty =
            DependencyProperty.Register("ShaderEnabled",
                typeof(bool), typeof(CardBorder),
                new PropertyMetadata(true));

    }
}
