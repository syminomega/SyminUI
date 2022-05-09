using SyminViewTest.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// ControlTestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ControlTestWindow : Window
    {
        public ControlTestWindow()
        {
            InitializeComponent();
            SetViewData();
            SetItemsData();
        }
        private void SetViewData()
        {
            var i1 = new TreeData("1111");
            i1.Children = new List<TreeData>
            {
                new TreeData("AAA"),
                new TreeData("BBB")
            };
            List<TreeData> datalist = new()
            {
                i1,
                new TreeData("2222"),
                new TreeData("3333")
            };

            myTreeView.ItemsSource = datalist;
            OldTreeView.ItemsSource = datalist;
        }

        private void SetItemsData()
        {

        }
    }
    public class TreeData
    {
        public TreeData(string name)
        {
            ItemName = name;
        }
        public string ItemName { get; set; }
        public List<TreeData> Children { get; set; } = new List<TreeData>();
    }
}
