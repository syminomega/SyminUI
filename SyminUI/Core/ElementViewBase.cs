using SyminUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SyminUI.Core
{
    public abstract class ElementViewBase<T> : IView<T>
        where T : FrameworkElement, new()
    {
        /// <summary>
        /// Initialize controls
        /// 初始化控件对象
        /// </summary>
        protected ElementViewBase()
        {
            T viewControl = new();
            _viewElement = viewControl;
        }

        private readonly T _viewElement;
        /// <summary>
        /// Control element
        /// 控件对象
        /// </summary>
        public virtual T ViewElement => _viewElement;

        FrameworkElement IView.ViewElement => ViewElement;


        //实现View嵌套的隐式转换
        public static implicit operator FrameworkElement(ElementViewBase<T> elementViewBase)
        {
            return elementViewBase.ViewElement;
        }

        #region FrameworkElement Properties

        /// <summary>
        /// Set ViewElement Height
        /// 设置视图元素高度
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> Height(double height)
        {
            ViewElement.Height = height;
            return this;
        }
        /// <summary>
        /// Set ViewElement Height
        /// 设置视图元素高度
        /// </summary>
        /// <param name="dynamicHeight"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> Height(State<double> dynamicHeight)
        {
            ViewElement.SetBinding(FrameworkElement.HeightProperty, (Binding)dynamicHeight);
            return this;
        }
        /// <summary>
        /// Set ViewElement Width
        /// 设置视图元素宽度
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> Width(double width)
        {
            ViewElement.Width = width;
            return this;
        }
        /// <summary>
        /// Set ViewElement Width
        /// 设置视图元素宽度
        /// </summary>
        /// <param name="dynamicWidth"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> Width(State<double> dynamicWidth)
        {
            ViewElement.SetBinding(FrameworkElement.WidthProperty, (Binding)dynamicWidth);
            return this;
        }
        /// <summary>
        /// Set ViewElement HorizontalAlignment
        /// 设置水平方向对齐方式
        /// </summary>
        /// <param name="alignment"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> HorizontalAlignment(HorizontalAlignment alignment)
        {
            ViewElement.HorizontalAlignment = alignment;
            return this;
        }
        /// <summary>
        /// Set ViewElement HorizontalAlignment
        /// 设置水平方向对齐方式
        /// </summary>
        /// <param name="dynamicAlignment"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> HorizontalAlignment(State<HorizontalAlignment> dynamicAlignment)
        {
            ViewElement.SetBinding(FrameworkElement.HorizontalAlignmentProperty, (Binding)dynamicAlignment);
            return this;
        }
        /// <summary>
        /// Set ViewElement VerticalAlignment
        /// 设置垂直方向对齐方式
        /// </summary>
        /// <param name="alignment"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> VerticalAlignment(VerticalAlignment alignment)
        {
            ViewElement.VerticalAlignment = alignment;
            return this;
        }
        /// <summary>
        /// Set ViewElement VerticalAlignment
        /// 设置垂直方向对齐方式
        /// </summary>
        /// <param name="dynamicAlignment"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> VerticalAlignment(State<VerticalAlignment> dynamicAlignment)
        {
            ViewElement.SetBinding(FrameworkElement.VerticalAlignmentProperty, (Binding)dynamicAlignment);
            return this;
        }
        //TODO:LayoutTransform

        /// <summary>
        /// Set ViewElement Margin
        /// 设置视图元素的Margin
        /// </summary>
        /// <param name="left">Left-左</param>
        /// <param name="top">Top-上</param>
        /// <param name="right">Right-右</param>
        /// <param name="bottom">Bottom-下</param>
        /// <returns>视图元素</returns>
        public virtual ElementViewBase<T> Margin(double left, double top, double right, double bottom)
        {
            ViewElement.Margin = new Thickness(left, top, right, bottom);
            return this;
        }
        /// <summary>
        /// Set ViewElement Margin
        /// 设置视图元素的Margin
        /// </summary>
        /// <param name="margin">Margin-边距</param>
        /// <returns></returns>
        public virtual ElementViewBase<T> Margin(Thickness margin)
        {
            ViewElement.Margin = margin;
            return this;
        }
        /// <summary>
        /// Set ViewElement Margin
        /// 设置视图元素的Margin
        /// </summary>
        /// <param name="margin">DynamicMargin-动态边距</param>
        /// <returns>视图元素</returns>
        public virtual ElementViewBase<T> Margin(State<Thickness> dynamicMargin)
        {
            ViewElement.SetBinding(FrameworkElement.MarginProperty, (Binding)dynamicMargin);
            return this;
        }
        /// <summary>
        /// Set ViewElement MaxHeight
        /// 设置视图元素最大高度
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> MaxHeight(double height)
        {
            ViewElement.MaxHeight = height;
            return this;
        }
        /// <summary>
        /// Set ViewElement MaxWidth
        /// 设置视图元素最大宽度
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> MaxWidth(double width)
        {
            ViewElement.MaxWidth = width;
            return this;
        }
        /// <summary>
        /// Set ViewElement MinHeight
        /// 设置视图元素最小高度
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> MinHeight(double height)
        {
            ViewElement.MinHeight = height;
            return this;
        }
        /// <summary>
        /// Set ViewElement MinWidth
        /// 设置视图元素最小宽度
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> MinWidth(double width)
        {
            ViewElement.MinWidth = width;
            return this;
        }
        /// <summary>
        /// Set ViewElement Style
        /// 设置视图元素风格
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> Style(Style style)
        {
            ViewElement.Style = style;
            return this;
        }
        //TODO:Tag
        /// <summary>
        /// Set ToolTip View
        /// 设置ToolTip视图
        /// </summary>
        /// <param name="tipView"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> ToolTip(IView tipView)
        {
            ViewElement.ToolTip = tipView.ViewElement;
            return this;
        }
        /// <summary>
        /// Set ToolTip Text
        /// 设置ToolTip文本
        /// </summary>
        /// <param name="tip"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> ToolTip(string tip)
        {
            ViewElement.ToolTip = tip;
            return this;
        }
        #endregion

        #region FrameworkElement Events

        /// <summary>
        /// Invoke when element size changed
        /// 视图元素大小变化事件
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> OnSizeChanged(Action action)
        {
            if (!_sizeChangedListened)
            {
                ViewElement.SizeChanged += ViewElement_SizeChanged;
                _sizeChangedListened = true;
            }
            SizeChanged += action;
            return this;
        }
        /// <summary>
        /// Invoke when element loaded
        /// 视图加载完成事件
        /// Be careful that this event will be also triggered while Window state changed 
        /// or TabItem changed
        /// 小心此事件！在系统主题变化（包括显示缩放）或TabItem切换时，同样会触发此事件
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> OnLoaded(Action action)
        {
            if (!_loadedListened)
            {
                ViewElement.Loaded += ViewElement_Loaded;
                _loadedListened = true;
            }

            Loaded += action;
            return this;
        }
        /// <summary>
        /// Invoke when element unloaded
        /// 视图卸载完成事件
        /// Be careful that this event will be also triggered while Window state changed 
        /// or TabItem changed
        /// 小心此事件！在系统主题变化（包括显示缩放）或TabItem切换时，同样会触发此事件
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual ElementViewBase<T> Unloaded(Action action)
        {
            if (!_unloadedListened)
            {
                ViewElement.Unloaded += ViewElement_Unloaded;
                _unloadedListened = true;
            }
            Unload += action;
            return this;
        }

        #endregion

        #region FrameworkElement EventHandle
        //尺寸变化
        private bool _sizeChangedListened = false;
        private event Action? SizeChanged;
        private void ViewElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SizeChanged?.Invoke();
        }
        //加载完成
        private bool _loadedListened = false;
        private event Action? Loaded;
        private void ViewElement_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded?.Invoke();
        }
        //卸载完成
        private bool _unloadedListened = false;
        private event Action? Unload;
        private void ViewElement_Unloaded(object sender, RoutedEventArgs e)
        {
            Unload?.Invoke();
        }
        #endregion

        //TODO:如何获取属性值？
        //备选方案：增加out方法
        //TODO:传递对象被移除或销毁事件 


        #region UIElement Properties

        #endregion
    }
}
