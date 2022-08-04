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
using System.Windows.Shapes;

namespace SyminViewTest
{
    /// <summary>
    /// StyleTestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StyleTestWindow : Window
    {
        public StyleTestWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(!_loaded ) return;
            textMessage.Text = "选项变化" + e.OriginalSource;
        }
        private bool _loaded = false;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _loaded = true;
        }
    }
}
