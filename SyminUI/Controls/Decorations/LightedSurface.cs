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

        private LightedSurfaceEffect? _effect;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            InitEffect();
        }
        private void InitEffect()
        {
            var contentBorder = GetTemplateChild("PART_lightBorder") as Border;
            _effect = new LightedSurfaceEffect
            {
                UISize = new Point(ActualWidth, ActualHeight),
                LightSize = LightSize,
                LightColor = LightColorBrush.Color,
                Intensity = LightIntensity,
            };
            contentBorder!.Effect = _effect;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_effect != null)
            {
                _effect.MousePosition = e.GetPosition(this);
            }
        }

        // 更新Effect中的UI尺寸
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            if (_effect != null)
            {
                _effect.UISize = new Point(sizeInfo.NewSize.Width, sizeInfo.NewSize.Height);
            }
        }

        public SolidColorBrush LightColorBrush
        {
            get { return (SolidColorBrush)GetValue(LightColorBrushProperty); }
            set { SetValue(LightColorBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LightBrush.
        public static readonly DependencyProperty LightColorBrushProperty =
            DependencyProperty.Register("LightColorBrush",
                typeof(SolidColorBrush), typeof(LightedSurface),
                new PropertyMetadata(Brushes.White, LightColorChangedCallback));

        private static void LightColorChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var lightedSurface = d as LightedSurface;
            if (lightedSurface == null)
            {
                return;
            }
            if (lightedSurface._effect != null)
            {
                lightedSurface._effect.LightColor = ((SolidColorBrush)e.NewValue).Color;
            }
        }

        public double LightIntensity
        {
            get { return (double)GetValue(LightIntensityProperty); }
            set { SetValue(LightIntensityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LightIntensity.
        public static readonly DependencyProperty LightIntensityProperty =
            DependencyProperty.Register("LightIntensity",
                typeof(double), typeof(LightedSurface),
                new PropertyMetadata(0.0, LightIntensityChangedCallback));

        private static void LightIntensityChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var lightedSurface = d as LightedSurface;
            if (lightedSurface == null)
            {
                return;
            }
            if (lightedSurface._effect != null)
            {
                lightedSurface._effect.Intensity = (double)e.NewValue;
            }
        }

        public double LightSize
        {
            get { return (double)GetValue(LightSizeProperty); }
            set { SetValue(LightSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LightSize.
        public static readonly DependencyProperty LightSizeProperty =
            DependencyProperty.Register("LightSize",
                typeof(double), typeof(LightedSurface),
                new PropertyMetadata(40.0, LightSizeChangedCallback));

        private static void LightSizeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var lightedSurface = d as LightedSurface;
            if (lightedSurface == null)
            {
                return;
            }
            if (lightedSurface._effect != null)
            {
                lightedSurface._effect.LightSize = (double)e.NewValue;
            }
        }



        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius",
                typeof(CornerRadius), typeof(LightedSurface),
                new PropertyMetadata(new CornerRadius(4)));


    }
}
