using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SyminUI.Core
{
    public interface IControlView
    {
        public Control Element { get; }
    }
}
