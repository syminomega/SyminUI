using SyminUI.Controls;
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
using SyminData.NodeModel.Presets;
using SyminViewTest.Views;

namespace SyminViewTest
{
    /// <summary>
    /// CanvasTestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CanvasTestWindow : Window
    {
        NumberAddNode AddNode { get; set; }
        public CanvasTestWindow()
        {
            InitializeComponent();
            AddNode = new NumberAddNode();
            NodeTest.NodeItemSource = AddNode;
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            AddNode.InputNumberA.Value = 1;
            AddNode.InputNumberB.Value = 2;
        }
    }
}
