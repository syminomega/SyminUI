using SyminUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SyminUI.Core
{
    public interface IView
    {
        /// <summary>
        /// 获取视图元素
        /// </summary>
        /// <returns>视图元素实例</returns>
        public FrameworkElement GetViewElement();
    }
    public interface IView<T> : IView where T : FrameworkElement
    {
        /// <summary>
        /// 视图元素控件实例
        /// </summary>
        public T ViewElement { get; }
    }
}
