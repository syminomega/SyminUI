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
using SyminUI.Views;


namespace SyminViewTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenStyleDemo_Click(object sender, RoutedEventArgs e)
        {
            new StyleTestWindow().Show();
        }

        private void OpenCSharpUI_Click(object sender, RoutedEventArgs e)
        {
            new ViewTestWindow().Show();
        }

        private void OpenCustomControlDemo_Click(object sender, RoutedEventArgs e)
        {
            new ControlTestWindow().Show();
        }

        private void Developing_Click(object sender, RoutedEventArgs e)
        {
            new DevelopingWindow().Show();
        }
    }
}
