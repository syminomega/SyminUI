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
    public class AngleGradientEffect : ShaderEffect
    {
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public static readonly DependencyProperty InputProperty
            = RegisterPixelShaderSamplerProperty("Input",
                typeof(AngleGradientEffect), 0);


        public Point Center
        {
            get { return (Point)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }
        public static readonly DependencyProperty CenterProperty
            = DependencyProperty.Register("Center",
                typeof(Point), typeof(AngleGradientEffect),
            new PropertyMetadata(new Point(0.5, 0.5),
                PixelShaderConstantCallback(0)));



        public Color Color1
        {
            get { return (Color)GetValue(Color1Property); }
            set { SetValue(Color1Property, value); }
        }

        // Using a DependencyProperty as the backing store for Color1.
        public static readonly DependencyProperty Color1Property =
            DependencyProperty.Register("Color1",
                typeof(Color), typeof(AngleGradientEffect),
                new PropertyMetadata(Color.FromRgb(249, 250, 254),
                    PixelShaderConstantCallback(1)));



        public Color Color2
        {
            get { return (Color)GetValue(Color2Property); }
            set { SetValue(Color2Property, value); }
        }

        // Using a DependencyProperty as the backing store for Color2.
        public static readonly DependencyProperty Color2Property =
            DependencyProperty.Register("Color2",
                typeof(Color), typeof(AngleGradientEffect),
                new PropertyMetadata(Color.FromRgb(179, 181, 193),
                    PixelShaderConstantCallback(2)));



        public Point AngleRange
        {
            get { return (Point)GetValue(AngleRangeProperty); }
            set { SetValue(AngleRangeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AngleRange.
        public static readonly DependencyProperty AngleRangeProperty =
            DependencyProperty.Register("AngleRange", 
                typeof(Point), typeof(AngleGradientEffect), 
                new PropertyMetadata(new Point(0,0.25),
                    PixelShaderConstantCallback(3)));




        public AngleGradientEffect()
        {
            var shaderUri
                = "pack://application:,,,/SyminUI;component/Shaders/AngleGradientPS.ps";
            PixelShader = new PixelShader()
            {
                UriSource = new Uri(shaderUri)
            };

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(CenterProperty);
            UpdateShaderValue(Color1Property);
            UpdateShaderValue(Color2Property);
            UpdateShaderValue(AngleRangeProperty);

        }
    }
}
