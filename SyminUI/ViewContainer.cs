﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using SyminUI.Runtime;
using SyminUI.Views;

namespace SyminUI
{
    /// <summary>
    /// MVU容器
    /// </summary>
    public class ViewContainer : ContentPresenter
    {
        /// <summary>
        /// 视图View提供方法，重载此属性以自定义View对象
        /// </summary>
        public virtual IView ViewProvider =>
            new Text("Empty view. Try to override ViewProvider.")
                .HorizontalAlignment(HorizontalAlignment.Center)
                .VerticalAlignment(VerticalAlignment.Center);

        public void GetViewFromProvider<T>() where T : IViewProvider
        {
            //TODO:
            //app.services.get<T>
        }

        /// <summary>
        /// 获取View所在窗口
        /// </summary>
        /// <typeparam name="T">窗口类型</typeparam>
        /// <returns></returns>
        [Obsolete("Use HostWindow() or HostWindow<T>() instead")]
        public T GetHostWindow<T>() where T : Window
        {
            return (T)Window.GetWindow(this);
        }

        /// <summary>
        /// 获取View所在窗口
        /// </summary>
        /// <typeparam name="T">窗口类型</typeparam>
        /// <returns></returns>
        public T HostWindow<T>() where T : Window
        {
            return (T)Window.GetWindow(this);
        }

        /// <summary>
        /// 获取View所在窗口
        /// </summary>
        /// <returns></returns>
        public Window HostWindow()
        {
            return Window.GetWindow(this);
        }

        /// <summary>
        /// 初始化视图容器
        /// </summary>
        public ViewContainer()
        {
            Content = ViewProvider.Element;
        }

    }


}