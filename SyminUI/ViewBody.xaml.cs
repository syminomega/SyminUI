using SyminUI.Core;
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

namespace SyminUI
{
    /// <summary>
    /// ViewBody.xaml 的交互逻辑
    /// </summary>
    [Obsolete("Please use inheritance of ViewContainer")]
    public partial class ViewBody : UserControl
    {
        public ViewBody()
        {
            InitializeComponent();
        }


        public IView ViewDefinition
        {
            get { return (IView)GetValue(ViewDefinitionProperty); }
            set { SetValue(ViewDefinitionProperty, value); }
        }

        public static readonly DependencyProperty ViewDefinitionProperty =
            DependencyProperty.Register("ViewDefinition", typeof(IView), typeof(ViewBody));


    }
}
