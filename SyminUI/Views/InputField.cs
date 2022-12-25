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
    public class InputField : ControlViewBase<TextBox>
    {

        public InputField(IState dynamicText)
        {
            Element.SetBinding(TextBox.TextProperty, dynamicText.GetBinding());
        }
        //TODO:完成InputField
    }
}
