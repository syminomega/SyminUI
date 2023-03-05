using SyminUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SyminUI
{
    /// <summary>
    /// 视图
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// 视图元素控件实例
        /// </summary>
        public FrameworkElement Element { get; }

    }
    /// <summary>
    /// 视图
    /// </summary>
    /// <typeparam name="T">WPF Control Type</typeparam>
    public interface IView<T> : IView where T : FrameworkElement
    {
        /// <summary>
        /// 视图元素控件实例
        /// </summary>
        public new T Element { get; }
    }
}
