using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SyminUI.Effects
{
    public class LightedSurfaceEffect : ShaderEffect
    {
        public Brush Input
        {
            get => (Brush)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }

        public static readonly DependencyProperty InputProperty
            = RegisterPixelShaderSamplerProperty("Input",
                typeof(LightedSurfaceEffect), 0);


        /// <summary>
        /// 鼠标相对控件位置
        /// </summary>
        public Point MousePosition
        {
            get => (Point)GetValue(MousePositionProperty);
            set => SetValue(MousePositionProperty, value);
        }

        // Using a DependencyProperty as the backing store for MousePosition.
        public static readonly DependencyProperty MousePositionProperty =
            DependencyProperty.Register("MousePosition",
                typeof(Point), typeof(LightedSurfaceEffect),
                new PropertyMetadata(new Point(100,20),
                    PixelShaderConstantCallback(0)));



        public Point UISize
        {
            get => (Point)GetValue(UISizeProperty);
            set => SetValue(UISizeProperty, value);
        }

        // Using a DependencyProperty as the backing store for UISize.
        public static readonly DependencyProperty UISizeProperty =
            DependencyProperty.Register("UISize",
                typeof(Point), typeof(LightedSurfaceEffect),
                new PropertyMetadata(new Point(200,40),
                PixelShaderConstantCallback(1)));



        public double LightSize
        {
            get => (double)GetValue(LightSizeProperty);
            set => SetValue(LightSizeProperty, value);
        }

        // Using a DependencyProperty as the backing store for LightSize.
        public static readonly DependencyProperty LightSizeProperty =
            DependencyProperty.Register("LightSize",
                typeof(double), typeof(LightedSurfaceEffect),
                new PropertyMetadata(40.0,
                    PixelShaderConstantCallback(2)));



        public double Intensity
        {
            get => (double)GetValue(IntensityProperty);
            set => SetValue(IntensityProperty, value);
        }

        // Using a DependencyProperty as the backing store for Intensity.
        public static readonly DependencyProperty IntensityProperty =
            DependencyProperty.Register("Intensity", 
                typeof(double), typeof(LightedSurfaceEffect),
                new PropertyMetadata(1.0,
                PixelShaderConstantCallback(3)));



        public Color LightColor
        {
            get => (Color)GetValue(LightColorProperty);
            set => SetValue(LightColorProperty, value);
        }

        // Using a DependencyProperty as the backing store for LightColor.
        public static readonly DependencyProperty LightColorProperty =
            DependencyProperty.Register("LightColor",
                typeof(Color), typeof(LightedSurfaceEffect),
                new PropertyMetadata(Color.FromArgb(255,255,255,255),
                PixelShaderConstantCallback(4)));



        public LightedSurfaceEffect()
        {
            var shaderUri
                = "pack://application:,,,/SyminUI;component/Shaders/LightedSurfacePS.ps";
            PixelShader = new PixelShader()
            {
                UriSource = new Uri(shaderUri)
            };

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(MousePositionProperty);
            UpdateShaderValue(UISizeProperty);
            UpdateShaderValue(LightSizeProperty);
            UpdateShaderValue(LightColorProperty);
            UpdateShaderValue(IntensityProperty);
        }
    }
}
