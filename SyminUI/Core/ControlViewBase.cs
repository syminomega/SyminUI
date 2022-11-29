using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SyminUI.Core
{
    public abstract class ControlViewBase<T> : ElementViewBase<T>, IControlView
        where T : Control, new()
    {
        Control IControlView.Element => this.Element;
    }
}
