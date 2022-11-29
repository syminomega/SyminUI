using SyminUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SyminUI.Views
{
    //TODO: Control 属性
    /// <summary>
    /// ControlView basic properties and events
    /// </summary>
    public static class ControlViewExtension
    {

        #region Control Properties
        /// <summary>
        /// Whether the view is enabled in the user interface
        /// 设置控件元素是否可交互
        /// </summary>
        /// <param name="view"></param>
        /// <param name="background"></param>
        /// <returns></returns>
        public static T Background<T>(this T view, Brush background) where T : IControlView
        {
            view.Element.Background = background;
            return view;
        }
        #endregion
    }
}
