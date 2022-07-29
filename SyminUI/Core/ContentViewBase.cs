using SyminUI.Core;
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
    public abstract class ContentViewBase<T> : ControlViewBase<T> 
        where T : ContentControl, new()
    {
        protected ContentViewBase() : base()
        {

        }
        protected ContentViewBase(string text) : base()
        {
            ViewElement.Content = text;
        }
        protected ContentViewBase(State<string> dynamicText) : base()
        {
            ViewElement.SetBinding(ContentControl.ContentProperty, (Binding)dynamicText);
        }
        protected ContentViewBase(IView view) : base()
        {
            ViewElement.Content = view.ViewElement;
        }
        protected ContentViewBase(State<IView> dynamicView) : base()
        {
            Binding binding = new("Value")
            {
                Source = dynamicView,
                Converter = new ViewDefinitionToElement()
            };
            //Warning!!!!
            //TODO:不知道绑定的视图切换后，对于state里面的PropertyChanged事件是否会解除占用
            ViewElement.SetBinding(ContentControl.ContentProperty, binding);
        }


        #region ContentControl Properties
        public virtual ContentViewBase<T> Content(string text)
        {
            ViewElement.Content = text;
            return  this;
        }
        public virtual ContentViewBase<T> Content(State<string> dynamicText)
        {
            ViewElement.SetBinding(ContentControl.ContentProperty, (Binding)dynamicText);
            return  this;
        }
        public virtual ContentViewBase<T> Content(IView view)
        {
            ViewElement.Content = view.ViewElement;
            return  this;
        }
        public virtual ContentViewBase<T> Content(State<IView> dynamicView)
        {
            Binding binding = new("Value")
            {
                Source = dynamicView,
                Converter = new ViewDefinitionToElement()
            };
            //TODO:不知道绑定的视图切换后，对于state里面的PropertyChanged事件是否会解除占用
            ViewElement.SetBinding(ContentControl.ContentProperty, binding);
            return  this;
        }
        //TODO:ContentStringFormat
        //TODO:ContentTemplate
        //TODO:ContentTemplateSelector

        #endregion
    }
}
