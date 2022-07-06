using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SyminUI.Effects;

public class BrightnessContrastEffect : ShaderEffect
{
    public Brush Input
    {
        get => (Brush)GetValue(InputProperty);
        set => SetValue(InputProperty, value);
    }

    public static readonly DependencyProperty InputProperty
        = RegisterPixelShaderSamplerProperty("Input",
            typeof(BrightnessContrastEffect), 0);



    public double Brightness
    {
        get => (double)GetValue(BrightnessProperty);
        set => SetValue(BrightnessProperty, value);
    }

    // Using a DependencyProperty as the backing store for Brightness.
    public static readonly DependencyProperty BrightnessProperty =
        DependencyProperty.Register(nameof(Brightness), typeof(double),
            typeof(BrightnessContrastEffect), 
            new PropertyMetadata(0.0, PixelShaderConstantCallback(0)));



    public double Contrast
    {
        get => (double)GetValue(ContrastProperty);
        set => SetValue(ContrastProperty, value);
    }

    // Using a DependencyProperty as the backing store for Contrast.
    public static readonly DependencyProperty ContrastProperty =
        DependencyProperty.Register(nameof(Contrast), typeof(double),
            typeof(BrightnessContrastEffect),
            new PropertyMetadata(0.0, PixelShaderConstantCallback(1)));


    public BrightnessContrastEffect()
    {
        var shaderUri
            = "pack://application:,,,/SyminUI;component/Shaders/BrightnessContrastPS.ps";
        PixelShader = new PixelShader()
        {
            UriSource = new Uri(shaderUri)
        };

        UpdateShaderValue(InputProperty);
        UpdateShaderValue(BrightnessProperty);
        UpdateShaderValue(ContrastProperty);
    }

}