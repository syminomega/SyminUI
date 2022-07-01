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
                new PropertyMetadata(4.0, RadiusChangedCallback));

        private static void RadiusChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not SlotBorder slotBorder)
            {
                return;
            }

            UpdateEffectAngle(slotBorder._topRightEffect,
                slotBorder._topRightBorder,
                0.25, (double)e.NewValue);
            UpdateEffectAngle(slotBorder._bottomLeftEffect,
                slotBorder._bottomLeftBorder,
                0.75, (double)e.NewValue);
        }

        // Using a DependencyProperty as the backing store for LightBrush.
        public static readonly DependencyProperty LightBrushProperty =
            DependencyProperty.Register("LightBrush",
                typeof(SolidColorBrush), typeof(SlotBorder),
                new PropertyMetadata(Brushes.WhiteSmoke, LightBrushChangedCallback));


        // Using a DependencyProperty as the backing store for ShadowBrush.
        public static readonly DependencyProperty ShadowBrushProperty =
            DependencyProperty.Register("ShadowBrush",
                typeof(SolidColorBrush), typeof(SlotBorder),
                new PropertyMetadata(Brushes.DarkGray, ShadowBrushChangedCallback));

        #endregion

        private static void LightBrushChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not SlotBorder slotBorder)
            {
                return;
            }

            slotBorder._topRightEffect.Color2 = ((SolidColorBrush)e.NewValue).Color;
            slotBorder._bottomLeftEffect.Color1 = ((SolidColorBrush)e.NewValue).Color;
        }

        private static void ShadowBrushChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not SlotBorder slotBorder)
            {
                return;
            }

            slotBorder._topRightEffect.Color1 = ((SolidColorBrush)e.NewValue).Color;
            slotBorder._bottomLeftEffect.Color2 = ((SolidColorBrush)e.NewValue).Color;
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            UpdateEffectAngle(_topRightEffect, _topRightBorder, 0.25, Radius);
            UpdateEffectAngle(_bottomLeftEffect, _bottomLeftBorder, 0.75, Radius);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            InitEffect();
        }

        private readonly AngleGradientEffect _topRightEffect = new();
        private readonly AngleGradientEffect _bottomLeftEffect = new();
        private Border? _topRightBorder;
        private Border? _bottomLeftBorder;

        private void InitEffect()
        {
            _topRightBorder = GetTemplateChild("PART_TopRightCorner") as Border;
            _bottomLeftBorder = GetTemplateChild("PART_BottomLeftCorner") as Border;
            //右上角
            _topRightEffect.Color1 = ShadowBrush.Color;
            _topRightEffect.Color2 = LightBrush.Color;
            _topRightEffect.Center = new Point(0, 1);
            UpdateEffectAngle(_topRightEffect, _topRightBorder, 0.25, Radius);
            //左下角
            _bottomLeftEffect.Color1 = LightBrush.Color;
            _bottomLeftEffect.Color2 = ShadowBrush.Color;
            _bottomLeftEffect.Center = new Point(1, 0);
            UpdateEffectAngle(_bottomLeftEffect, _bottomLeftBorder, 0.75, Radius);

            _topRightBorder!.Effect = _topRightEffect;
            _bottomLeftBorder!.Effect = _bottomLeftEffect;
        }

        private static void UpdateEffectAngle(AngleGradientEffect effect,
            Border? border, double initRange, double radiusValue)
        {
            double size = 0;
            if (border != null)
            {
                size = border.ActualWidth;
            }

            //计算转过角度
            var angleClip = Math.Atan((size - radiusValue) / size) / (2 * Math.PI);
            var angleStart = initRange + angleClip;
            var angleEnd = initRange + 0.25 - angleClip;

            effect.AngleRange = new Point(angleStart, angleEnd);
        }
    }
}