using System.Windows;
using System.Windows.Data;

namespace SyminUI.Views;

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
    /// <param name="view"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static T Height<T>(this T view, double height) where T : IView
    {
        view.Element.Height = height;
        return view;
    }

    /// <summary>
    /// Set ViewElement Height
    /// 设置视图元素高度
    /// </summary>
    /// <param name="view"></param>
    /// <param name="dynamicHeight"></param>
    /// <returns></returns>
    public static T Height<T>(this T view, State<double> dynamicHeight) where T : IView
    {
        view.Element.SetBinding(FrameworkElement.HeightProperty, (Binding)dynamicHeight);
        return view;
    }

    /// <summary>
    /// Set ViewElement Width
    /// 设置视图元素宽度
    /// </summary>
    /// <param name="view"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    public static T Width<T>(this T view, double width) where T : IView
    {
        view.Element.Width = width;
        return view;
    }

    /// <summary>
    /// Set ViewElement Width
    /// 设置视图元素宽度
    /// </summary>
    /// <param name="view"></param>
    /// <param name="dynamicWidth"></param>
    /// <returns></returns>
    public static T Width<T>(this T view, State<double> dynamicWidth) where T : IView
    {
        view.Element.SetBinding(FrameworkElement.WidthProperty, (Binding)dynamicWidth);
        return view;
    }


    /// <summary>
    /// Set ViewElement HorizontalAlignment
    /// 设置水平方向对齐方式
    /// </summary>
    /// <param name="view"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public static T HorizontalAlignment<T>(this T view, HorizontalAlignment alignment) where T : IView
    {
        view.Element.HorizontalAlignment = alignment;
        return view;
    }

    /// <summary>
    /// Set ViewElement HorizontalAlignment
    /// 设置水平方向对齐方式
    /// </summary>
    /// <param name="view"></param>
    /// <param name="dynamicAlignment"></param>
    /// <returns></returns>
    public static T HorizontalAlignment<T>(this T view, State<HorizontalAlignment> dynamicAlignment) where T : IView
    {
        view.Element.SetBinding(FrameworkElement.HorizontalAlignmentProperty, (Binding)dynamicAlignment);
        return view;
    }

    /// <summary>
    /// Set ViewElement VerticalAlignment
    /// 设置垂直方向对齐方式
    /// </summary>
    /// <param name="view"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public static T VerticalAlignment<T>(this T view, VerticalAlignment alignment) where T : IView
    {
        view.Element.VerticalAlignment = alignment;
        return view;
    }

    /// <summary>
    /// Set ViewElement VerticalAlignment
    /// 设置垂直方向对齐方式
    /// </summary>
    /// <param name="view"></param>
    /// <param name="dynamicAlignment"></param>
    /// <returns></returns>
    public static T VerticalAlignment<T>(this T view, State<VerticalAlignment> dynamicAlignment) where T : IView
    {
        view.Element.SetBinding(FrameworkElement.VerticalAlignmentProperty, (Binding)dynamicAlignment);
        return view;
    }

    //TODO:LayoutTransform

    /// <summary>
    /// Set ViewElement Margin
    /// 设置视图元素的Margin
    /// </summary>
    /// <param name="view"></param>
    /// <param name="left">Left-左</param>
    /// <param name="top">Top-上</param>
    /// <param name="right">Right-右</param>
    /// <param name="bottom">Bottom-下</param>
    /// <returns>视图元素</returns>
    public static T Margin<T>(this T view, double left, double top, double right, double bottom) where T : IView
    {
        view.Element.Margin = new Thickness(left, top, right, bottom);
        return view;
    }

    /// <summary>
    /// Set ViewElement Margin
    /// 设置视图元素的Margin
    /// </summary>
    /// <param name="view"></param>
    /// <param name="margin">Margin-边距</param>
    /// <returns></returns>
    public static T Margin<T>(this T view, Thickness margin) where T : IView
    {
        view.Element.Margin = margin;
        return view;
    }

    /// <summary>
    /// Set ViewElement Margin
    /// 设置视图元素的Margin
    /// </summary>
    /// <param name="view"></param>
    /// <param name="dynamicMargin"></param>
    /// <returns>视图元素</returns>
    public static T Margin<T>(this T view, State<Thickness> dynamicMargin) where T : IView
    {
        view.Element.SetBinding(FrameworkElement.MarginProperty, (Binding)dynamicMargin);
        return view;
    }

    /// <summary>
    /// Set ViewElement MaxHeight
    /// 设置视图元素最大高度
    /// </summary>
    /// <param name="view"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static T MaxHeight<T>(this T view, double height) where T : IView
    {
        view.Element.MaxHeight = height;
        return view;
    }

    /// <summary>
    /// Set ViewElement MaxWidth
    /// 设置视图元素最大宽度
    /// </summary>
    /// <param name="view"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    public static T MaxWidth<T>(this T view, double width) where T : IView
    {
        view.Element.MaxWidth = width;
        return view;
    }

    /// <summary>
    /// Set ViewElement MinHeight
    /// 设置视图元素最小高度
    /// </summary>
    /// <param name="view"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static T MinHeight<T>(this T view, double height) where T : IView
    {
        view.Element.MinHeight = height;
        return view;
    }

    /// <summary>
    /// Set ViewElement MinWidth
    /// 设置视图元素最小宽度
    /// </summary>
    /// <param name="view"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    public static T MinWidth<T>(this T view, double width) where T : IView
    {
        view.Element.MinWidth = width;
        return view;
    }

    /// <summary>
    /// Set ViewElement Style
    /// 设置视图元素风格
    /// </summary>
    /// <param name="view"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public static T Style<T>(this T view, Style style) where T : IView
    {
        view.Element.Style = style;
        return view;
    }

    //TODO:Tag
    /// <summary>
    /// Set ToolTip View
    /// 设置ToolTip视图
    /// </summary>
    /// <param name="view"></param>
    /// <param name="tipView"></param>
    /// <returns></returns>
    public static T ToolTip<T>(this T view, IView tipView) where T : IView
    {
        view.Element.ToolTip = tipView.Element;
        return view;
    }

    /// <summary>
    /// Set ToolTip Text
    /// 设置ToolTip文本
    /// </summary>
    /// <param name="view"></param>
    /// <param name="tip"></param>
    /// <returns></returns>
    public static T ToolTip<T>(this T view, string tip) where T : IView
    {
        view.Element.ToolTip = tip;
        return view;
    }

    #endregion

    #region UIElement Properties

    /// <summary>
    /// Whether the view is enabled in the user interface
    /// 设置控件元素是否可交互
    /// </summary>
    /// <param name="view"></param>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public static T IsEnabled<T>(this T view, bool enabled) where T : IView
    {
        view.Element.IsEnabled = enabled;
        return view;
    }

    /// <summary>
    /// Whether the view is enabled in the user interface
    /// 设置控件元素是否可交互
    /// </summary>
    /// <param name="view"></param>
    /// <param name="dynamicEnabled"></param>
    /// <returns></returns>
    public static T IsEnabled<T>(this T view, State<bool> dynamicEnabled) where T : IView
    {
        view.Element.SetBinding(UIElement.IsEnabledProperty, (Binding)dynamicEnabled);
        return view;
    }

    //TODO:完善剩余
    #endregion
}