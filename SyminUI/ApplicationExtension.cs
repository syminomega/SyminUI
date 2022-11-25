using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace SyminUI
{
    /// <summary>
    /// 原生Application扩展
    /// </summary>
    public static class ApplicationExtension
    {
        /// <summary>
        /// 打开指定类型窗口
        /// </summary>
        /// <typeparam name="T">窗口类型</typeparam>
        /// <param name="app"></param>
        /// <returns></returns>
        public static T OpenWindow<T>(this Application app) where T : Window
        {
            var window = ViewApplication.Current.ServiceProvider.GetService<T>();
            if (window == null)
            {
                throw new NullReferenceException($"{typeof(T).Name} was not registered to the services.");
            }
            window.Show();
            return window;
        }
    }
}