using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using SyminUI.Convertor;

namespace SyminUI.Controls.Decorations
{
    public class DecorationBase : ContentControl
    {
        static DecorationBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DecorationBase),
                new FrameworkPropertyMetadata(typeof(DecorationBase)));
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            IsWidthGreaterThanHeight = ActualWidth > ActualHeight;

            base.OnRenderSizeChanged(sizeInfo);
        }

        /// <summary>
        /// Weight of shader effect, Range 0~1
        /// 浮现比例，范围0~1
        /// </summary>
        public double Intensity
        {
            get => (double)GetValue(IntensityProperty);
            set => SetValue(IntensityProperty, value);
        }

        /// <summary>
        /// Enable or disable the border effect
        /// </summary>
        public bool ShaderEnabled
        {
            get => (bool)GetValue(ShaderEnabledProperty);
            set => SetValue(ShaderEnabledProperty, value);
        }

        [ReadOnly(true)]
        public bool IsWidthGreaterThanHeight
        {
            get => (bool)GetValue(IsWidthGreaterThanHeightProperty);
            set => SetValue(IsWidthGreaterThanHeightProperty, value);
        }


        #region Dependency Properties

        // Using a DependencyProperty as the backing store for Intensity.
        public static readonly DependencyProperty IntensityProperty =
            DependencyProperty.Register("Intensity",
                typeof(double), typeof(DecorationBase),
                new PropertyMetadata(1.0));

        // Using a DependencyProperty as the backing store for ShaderEnabled.
        public static readonly DependencyProperty ShaderEnabledProperty =
            DependencyProperty.Register("ShaderEnabled",
                typeof(bool), typeof(DecorationBase),
                new PropertyMetadata(true));
        

        // Using a DependencyProperty as the backing store for IsWidthGreaterThanHeight.
        public static readonly DependencyProperty IsWidthGreaterThanHeightProperty =
            DependencyProperty.Register("IsWidthGreaterThanHeight",
                typeof(bool), typeof(DecorationBase),
                new PropertyMetadata(true));

        #endregion

    }
}
