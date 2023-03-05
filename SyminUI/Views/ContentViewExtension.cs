using SyminUI.Convertor;
using SyminUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace SyminUI.Views
{
    /// <summary>
    /// ContentView properties and events
    /// </summary>
    public static class ContentViewExtension
    {
        #region ContentControl Properties
        /// <summary>
        /// Set Text Content
        /// 设置文本内容
        /// </summary>
        /// <param name="view"></param>
        /// <param name="text"></param>
        /// <returns></returns>

        public static T Content<T>(this T view, string text) where T : IContentView
        {
            view.Element.Content = text;
            return view;
        }
        /// <summary>
        /// Set dynamic Text Content
        /// 设置动态文本内容
        /// </summary>
        /// <param name="view"></param>
        /// <param name="dynamicText"></param>
        /// <returns></returns>
        public static T Content<T>(this T view, State<string> dynamicText) where T : IContentView
        {
            view.Element.SetBinding(ContentControl.ContentProperty, (Binding)dynamicText);
            return view;
        }
        public static T Content<T>(this T view, IView childView) where T : IContentView
        {
            view.Element.Content = childView.Element;
            return view;
        }
        public static T Content<T>(this T view, State<IView> dynamicView) where T : IContentView
        {
            Binding binding = new("Value")
            {
                Source = dynamicView,
                Converter = new ViewDefinitionToElement()
            };
            //TODO:不知道绑定的视图切换后，对于state里面的PropertyChanged事件是否会解除占用
            view.Element.SetBinding(ContentControl.ContentProperty, binding);
            return view;
        }

        //TODO:ContentStringFormat
        //TODO:ContentTemplate
        //TODO:ContentTemplateSelector

        #endregion
    }
}
