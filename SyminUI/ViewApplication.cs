using Microsoft.Extensions.DependencyInjection;
using SyminUI.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SyminUI
{
    /// <summary>
    /// 程序构建工具
    /// </summary>
    public static class ViewApplication
    {
        internal static IServiceProvider ServiceProvider { get; set; } = null!;

        public static ViewApplicationBuilder CreateBuilder()
        {
            var builder = new ViewApplicationBuilder();

            return builder;
        }

        /// <summary>
        /// 打开指定类型窗口
        /// </summary>
        /// <typeparam name="T">窗口类型</typeparam>
        /// <param name="app"></param>
        /// <returns></returns>
        public static T OpenWindow<T>(this Application app) where T : Window
        {
            var window = ServiceProvider.GetRequiredService<T>();
            window.Show();
            return window;
        }

        //public static Window OpenWindowWithView<T>() where T : Window
    }
}
