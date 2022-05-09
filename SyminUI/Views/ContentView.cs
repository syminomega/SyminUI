using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SyminUI.Core;

namespace SyminUI.Views
{
    public class ContentView : ContentViewBase<ContentControl>
    {
        public ContentView() : base()
        {

        }
        public ContentView(string text) : base(text)
        {

        }
        public ContentView(State<string> dynamicText) : base(dynamicText)
        {

        }
        public ContentView(IView view) : base(view)
        {

        }
        public ContentView(State<IView> dynamicView) : base(dynamicView)
        {

        }
    }
}
