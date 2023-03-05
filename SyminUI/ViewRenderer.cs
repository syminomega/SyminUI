using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using SyminUI.Core;
using SyminUI.Runtime;
using SyminUI.Views;

namespace SyminUI
{
    /// <summary>
    /// MVU容器
    /// </summary>
    public class ViewRenderer<T> : ContentControl, IViewRenderer where T : IViewProvider, new()
    {
        private IViewProvider _viewProvider;
        private Window? _hostWindow;
        private readonly RuntimeViewInfo _runtimeViewInfo;

        /// <summary>
        /// 初始化视图容器
        /// </summary>
        public ViewRenderer()
        {
            T viewProvider = new();
            _viewProvider = viewProvider;
            Content = viewProvider.Body.Element;
            //设置运行属性
            _runtimeViewInfo = new RuntimeViewInfo
            {
                ViewType = typeof(T),
                ViewRenderer = this,
            };
            //初次初始化完成后设置父窗口
            Loaded += ViewRenderer_Loaded;
            
        }

        //初次加载的时候注册一些方法
        private void ViewRenderer_Loaded(object sender, RoutedEventArgs e)
        {
            _hostWindow = Window.GetWindow(this);
            _viewProvider.HostWindow = _hostWindow;

            AddToHotReloadManager();
            //初次加载完成后取消订阅
            Loaded -= ViewRenderer_Loaded;
        }
        
        [Conditional("DEBUG")]
        private void AddToHotReloadManager()
        {

            HotReloadManager.ViewInfos.Add(_runtimeViewInfo);
            //this.Dispatcher.
            if (_hostWindow != null)
            {
                _hostWindow.Closed += HostWindowClosed;
            }
        }

        //宿主窗口关闭时取消热重载
        private void HostWindowClosed(object? sender, EventArgs e)
        {
            HotReloadManager.ViewInfos.Remove(_runtimeViewInfo);
        }

        /// <summary>
        /// Hot reload support.
        /// </summary>
        public void UpdateView()
        {
            Dispatcher.Invoke(() =>
            {
                T viewProvider = new();
                _viewProvider = viewProvider;
                _viewProvider.HostWindow = _hostWindow;
                Content = viewProvider.Body.Element;
            });
        }
    }
}