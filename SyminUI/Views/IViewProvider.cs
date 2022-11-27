using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SyminUI.Views;

namespace SyminUI.Views
{
    /// <summary>
    /// View provider interface
    /// </summary>
    public interface IViewProvider
    {
        /// <summary>
        /// View Content
        /// 视图主体内容
        /// </summary>
        public IView Body { get; }

        /// <summary>
        /// Parent window of this view.
        /// </summary>
        public Window? HostWindow { get; set; }


        //TODO:嵌套时候的热更新和类型转换
    }

    /// <summary>
    /// View provider. Customize your view here.
    /// 视图提供者，在此处自定义View
    /// </summary>
    public abstract class ViewProvider : IViewProvider
    {
        /// <inheritdoc/>
        public abstract IView Body { get; }
        /// <inheritdoc/>
        public Window? HostWindow { get; set; }

    }

}
