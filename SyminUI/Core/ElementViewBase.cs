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
            Element = viewControl;
        }

        /// <summary>
        /// Control element
        /// 控件对象
        /// </summary>
        public virtual T Element { get; }

        FrameworkElement IView.Element => Element;
        

        //TODO:迁移到扩展方法
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
                Element.SizeChanged += ViewElement_SizeChanged;
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
                Element.Loaded += ViewElement_Loaded;
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
                Element.Unloaded += ViewElement_Unloaded;
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

    }
}
