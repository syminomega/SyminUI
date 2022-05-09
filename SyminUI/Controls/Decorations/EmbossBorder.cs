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
    public class EmbossBorder : ContentControl
    {
        static EmbossBorder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EmbossBorder),
                new FrameworkPropertyMetadata(typeof(EmbossBorder)));
        }


        /// <summary>
        /// Weight of emboss effect, Range 0~1
        /// 浮现高度比例，范围0~1
        /// </summary>
        public double EmbossRatio
        {
            get { return (double)GetValue(EmbossRatioProperty); }
            set { SetValue(EmbossRatioProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EmbossRatio.
        public static readonly DependencyProperty EmbossRatioProperty =
            DependencyProperty.Register("EmbossRatio", 
                typeof(double), typeof(EmbossBorder), 
                new PropertyMetadata(1.0));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", 
                typeof(CornerRadius), typeof(EmbossBorder),
                new PropertyMetadata(new CornerRadius(4)));


    }
}
