using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SyminUI.Utilities
{
    public class ViewInfo
    {
        public static bool IsInDesignMode
            => (bool)DesignerProperties.IsInDesignModeProperty
            .GetMetadata(typeof(DependencyObject)).DefaultValue;
    }
}
