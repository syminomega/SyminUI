using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminUI.Views
{
    /// <summary>
    /// View provider. Customize your view here.
    /// 视图提供者，在此处自定义View
    /// </summary>
    public interface IViewProvider
    {
        /// <summary>
        /// View Content
        /// 视图主体内容
        /// </summary>
        public IView Body { get; set; }
    }
}
