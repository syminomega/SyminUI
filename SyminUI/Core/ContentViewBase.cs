using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SyminUI.Convertor;

namespace SyminUI.Core
{
    public abstract class ContentViewBase<T> : ControlViewBase<T>, IContentView
        where T : ContentControl, new()
    {
        protected ContentViewBase()
        {
        }

        protected ContentViewBase(string text)
        {
            Element.Content = text;
        }

        protected ContentViewBase(IState dynamicContent)
        {
            Element.SetBinding(ContentControl.ContentProperty, dynamicContent.GetBinding());
        }

        protected ContentViewBase(IView view)
        {
            Element.Content = view.Element;
        }

        protected ContentViewBase(State<IView> dynamicView)
        {
            Binding binding = new("Value")
            {
                Source = dynamicView,
                Converter = new ViewDefinitionToElement()
            };
            //Warning!!!!
            //TODO:不知道绑定的视图切换后，对于state里面的PropertyChanged事件是否会解除占用
            Element.SetBinding(ContentControl.ContentProperty, binding);
        }

        ContentControl IContentView.Element => this.Element;
    }
}