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
        /// 视图元素控件实例
        /// </summary>
        public FrameworkElement ViewElement { get; }
        
    }
    public interface IView<T> : IView where T : FrameworkElement
    {
        /// <summary>
        /// 视图元素控件实例
        /// </summary>
        public new T ViewElement { get; }
    }
}
