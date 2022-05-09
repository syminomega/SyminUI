using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SyminUI.Controls.Elements
{
    public class OutputNodeListItem : ContentControl
    {
        static OutputNodeListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OutputNodeListItem),
                new FrameworkPropertyMetadata(typeof(OutputNodeListItem)));
        }
    }
}
