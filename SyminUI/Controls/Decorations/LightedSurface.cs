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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SyminUI.Effects;

namespace SyminUI.Controls.Decorations
{
    public class LightedSurface : ContentControl
    {
        static LightedSurface()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LightedSurface),
                new FrameworkPropertyMetadata(typeof(LightedSurface)));
        }

        private readonly LightedSurfaceEffect _effect = new();

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            InitEffect();
        }

        private void InitEffect()
        {
            var contentBorder = GetTemplateChild("PART_lightBorder") as Border;
            _effect.UISize = new Point(ActualWidth, ActualHeight);
            _effect.LightSize = LightSize;
            _effect.LightColor = LightColorBrush.Color;
            _effect.Intensity = LightIntensity;
            contentBorder!.Effect = _effect;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _effect.MousePosition = e.GetPosition(this);
        }

        // 更新Effect中的UI尺寸
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            _effect.UISize = new Point(sizeInfo.NewSize.Width, sizeInfo.NewSize.Height);
        }

        public SolidColorBrush LightColorBrush
        {
            get => (SolidColorBrush)GetValue(LightColorBrushProperty);
            set => SetValue(LightColorBrushProperty, value);
        }

        // Using a DependencyProperty as the backing store for LightBrush.
        public static readonly DependencyProperty LightColorBrushProperty =
            DependencyProperty.Register("LightColorBrush",
                typeof(SolidColorBrush), typeof(LightedSurface),
                new PropertyMetadata(Brushes.White, LightColorChangedCallback));

        private static void LightColorChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not LightedSurface lightedSurface)
            {
                return;
            }

            lightedSurface._effect.LightColor = ((SolidColorBrush)e.NewValue).Color;
        }

        public double LightIntensity
        {
            get => (double)GetValue(LightIntensityProperty);
            set => SetValue(LightIntensityProperty, value);
        }

        // Using a DependencyProperty as the backing store for LightIntensity.
        public static readonly DependencyProperty LightIntensityProperty =
            DependencyProperty.Register("LightIntensity",
                typeof(double), typeof(LightedSurface),
                new PropertyMetadata(0.0, LightIntensityChangedCallback));

        private static void LightIntensityChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not LightedSurface lightedSurface)
            {
                return;
            }
            
            lightedSurface._effect.Intensity = (double)e.NewValue;
        }

        public double LightSize
        {
            get => (double)GetValue(LightSizeProperty);
            set => SetValue(LightSizeProperty, value);
        }

        // Using a DependencyProperty as the backing store for LightSize.
        public static readonly DependencyProperty LightSizeProperty =
            DependencyProperty.Register("LightSize",
                typeof(double), typeof(LightedSurface),
                new PropertyMetadata(40.0, LightSizeChangedCallback));

        private static void LightSizeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not LightedSurface lightedSurface)
            {
                return;
            }

            lightedSurface._effect.LightSize = (double)e.NewValue;
        }


        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        // Using a DependencyProperty as the backing store for CornerRadius.
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius",
                typeof(CornerRadius), typeof(LightedSurface),
                new PropertyMetadata(new CornerRadius(4)));
    }
}