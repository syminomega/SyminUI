using SyminUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SyminUI.Views
{
    public class StackView : PanelViewBase<StackPanel>
    {
        public StackView(Orientation orientation)
        {
            Element.Orientation = orientation;
        }
    }
}
