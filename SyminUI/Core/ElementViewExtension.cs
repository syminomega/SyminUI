using SyminUI.Views;
using System.Windows;
using System.Windows.Data;

namespace SyminUI.Core;

/// <summary>
/// ElementView basic properties and events 
/// </summary>
public static class ElementViewExtension
{
    #region FrameworkElement Properties

    /// <summary>
    /// Set ViewElement Height
    /// 设置视图元素高度
    /// </summary>
    /// <param name="element"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static T Height<T>(this T element, double height) where T : IView
    {
        element.ViewElement.Height = height;
        return element;
    }
    /// <summary>
    /// Set ViewElement Height
    /// 设置视图元素高度
    /// </summary>
    /// <param name="element"></param>
    /// <param name="dynamicHeight"></param>
    /// <returns></returns>
    public static T Height<T>(this T element, State<double> dynamicHeight) where T : IView
    {
        element.ViewElement.SetBinding(FrameworkElement.HeightProperty, (Binding)dynamicHeight);
        return element;
    }
    /// <summary>
    /// Set ViewElement Width
    /// 设置视图元素宽度
    /// </summary>
    /// <param name="element"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    public static T Width<T>(this T element, double width) where T : IView
    {
        element.ViewElement.Width = width;
        return element;
    }
    /// <summary>
    /// Set ViewElement Width
    /// 设置视图元素宽度
    /// </summary>
    /// <param name="element"></param>
    /// <param name="dynamicWidth"></param>
    /// <returns></returns>
    public static T Width<T>(this T element, State<double> dynamicWidth) where T : IView
    {
        element.ViewElement.SetBinding(FrameworkElement.WidthProperty, (Binding)dynamicWidth);
        return element;
    }


    /// <summary>
    /// Set ViewElement HorizontalAlignment
    /// 设置水平方向对齐方式
    /// </summary>
    /// <param name="element"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public static T HorizontalAlignment<T>(this T element, HorizontalAlignment alignment) where T : IView
    {
        element.ViewElement.HorizontalAlignment = alignment;
        return element;
    }
    /// <summary>
    /// Set ViewElement HorizontalAlignment
    /// 设置水平方向对齐方式
    /// </summary>
    /// <param name="element"></param>
    /// <param name="dynamicAlignment"></param>
    /// <returns></returns>
    public static T HorizontalAlignment<T>(this T element, State<HorizontalAlignment> dynamicAlignment) where T : IView
    {
        element.ViewElement.SetBinding(FrameworkElement.HorizontalAlignmentProperty, (Binding)dynamicAlignment);
        return element;
    }
    /// <summary>
    /// Set ViewElement VerticalAlignment
    /// 设置垂直方向对齐方式
    /// </summary>
    /// <param name="element"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public static T VerticalAlignment<T>(this T element, VerticalAlignment alignment) where T : IView
    {
        element.ViewElement.VerticalAlignment = alignment;
        return element;
    }
    /// <summary>
    /// Set ViewElement VerticalAlignment
    /// 设置垂直方向对齐方式
    /// </summary>
    /// <param name="element"></param>
    /// <param name="dynamicAlignment"></param>
    /// <returns></returns>
    public static T VerticalAlignment<T>(this T element, State<VerticalAlignment> dynamicAlignment) where T : IView
    {
        element.ViewElement.SetBinding(FrameworkElement.VerticalAlignmentProperty, (Binding)dynamicAlignment);
        return element;
    }

    //TODO:LayoutTransform

    /// <summary>
    /// Set ViewElement Margin
    /// 设置视图元素的Margin
    /// </summary>
    /// <param name="element"></param>
    /// <param name="left">Left-左</param>
    /// <param name="top">Top-上</param>
    /// <param name="right">Right-右</param>
    /// <param name="bottom">Bottom-下</param>
    /// <returns>视图元素</returns>
    public static T Margin<T>(this T element, double left, double top, double right, double bottom) where T : IView
    {
        element.ViewElement.Margin = new Thickness(left, top, right, bottom);
        return element;
    }
    /// <summary>
    /// Set ViewElement Margin
    /// 设置视图元素的Margin
    /// </summary>
    /// <param name="element"></param>
    /// <param name="margin">Margin-边距</param>
    /// <returns></returns>
    public static T Margin<T>(this T element, Thickness margin) where T : IView
    {
        element.ViewElement.Margin = margin;
        return element;
    }
    /// <summary>
    /// Set ViewElement Margin
    /// 设置视图元素的Margin
    /// </summary>
    /// <param name="element"></param>
    /// <param name="dynamicMargin"></param>
    /// <param name="margin">DynamicMargin-动态边距</param>
    /// <returns>视图元素</returns>
    public static T Margin<T>(this T element, State<Thickness> dynamicMargin) where T : IView
    {
        element.ViewElement.SetBinding(FrameworkElement.MarginProperty, (Binding)dynamicMargin);
        return element;
    }

    /// <summary>
    /// Set ViewElement MaxHeight
    /// 设置视图元素最大高度
    /// </summary>
    /// <param name="element"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static T MaxHeight<T>(this T element, double height) where T : IView
    {
        element.ViewElement.MaxHeight = height;
        return element;
    }
    /// <summary>
    /// Set ViewElement MaxWidth
    /// 设置视图元素最大宽度
    /// </summary>
    /// <param name="element"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    public static T MaxWidth<T>(this T element, double width) where T : IView
    {
        element.ViewElement.MaxWidth = width;
        return element;
    }
    /// <summary>
    /// Set ViewElement MinHeight
    /// 设置视图元素最小高度
    /// </summary>
    /// <param name="element"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static T MinHeight<T>(this T element, double height) where T : IView
    {
        element.ViewElement.MinHeight = height;
        return element;
    }
    /// <summary>
    /// Set ViewElement MinWidth
    /// 设置视图元素最小宽度
    /// </summary>
    /// <param name="element"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    public static T MinWidth<T>(this T element, double width) where T : IView
    {
        element.ViewElement.MinWidth = width;
        return element;
    }

    /// <summary>
    /// Set ViewElement Style
    /// 设置视图元素风格
    /// </summary>
    /// <param name="element"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public static T Style<T>(this T element, Style style) where T : IView
    {
        element.ViewElement.Style = style;
        return element;
    }
    //TODO:Tag
    /// <summary>
    /// Set ToolTip View
    /// 设置ToolTip视图
    /// </summary>
    /// <param name="element"></param>
    /// <param name="tipView"></param>
    /// <returns></returns>
    public static T ToolTip<T>(this T element, IView tipView) where T : IView
    {
        element.ViewElement.ToolTip = tipView.ViewElement;
        return element;
    }
    /// <summary>
    /// Set ToolTip Text
    /// 设置ToolTip文本
    /// </summary>
    /// <param name="element"></param>
    /// <param name="tip"></param>
    /// <returns></returns>
    public static T ToolTip<T>(this T element, string tip) where T : IView
    {
        element.ViewElement.ToolTip = tip;
        return element;
    }
    #endregion



    #region UIElement Properties
    /// <summary>
    /// Whether the element is enabled in the user interface
    /// 设置控件元素是否可交互
    /// </summary>
    /// <param name="element"></param>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public static T IsEnabled<T>(this T element, bool enabled) where T : IView
    {
        element.ViewElement.IsEnabled = enabled;
        return element;
    }
    /// <summary>
    /// Whether the element is enabled in the user interface
    /// 设置控件元素是否可交互
    /// </summary>
    /// <param name="element"></param>
    /// <param name="dynamicEnabled"></param>
    /// <returns></returns>
    public static T IsEnabled<T>(this T element, State<bool> dynamicEnabled) where T : IView
    {
        element.ViewElement.SetBinding(UIElement.IsEnabledProperty, (Binding)dynamicEnabled);
        return element;
    }

    #endregion
}