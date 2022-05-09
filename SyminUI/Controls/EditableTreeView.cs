using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SyminUI.Controls
{
    public class EditableTreeView : ItemsControl
    {
        static EditableTreeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditableTreeView),
                new FrameworkPropertyMetadata(typeof(EditableTreeView)));
        }
        public EditableTreeView() : base()
        {
            //监听对象选中事件
            this.AddHandler(EditableTreeViewItem.ItemSelectedEvent,
                new RoutedEventHandler(SetSelection));
            //不知道这个事件是否会自动触发
            //this.SelectionChanged
        }


        private void SetSelection(object sender, RoutedEventArgs e)
        {
            //重置先前的选项
            if (SelectedItem is EditableTreeViewItem currentSelection)
            {
                currentSelection.IsSelected = false;
            }
            //获取新的对象
            SelectedItem = e.OriginalSource;
            //设置新的选项
            if (SelectedItem is EditableTreeViewItem selectedItem)
            {
                selectedItem.IsSelected = true;
            }

        }


        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem",
                typeof(object), typeof(EditableTreeView),
                new PropertyMetadata(null));

        //设置ItemContainer类型
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is EditableTreeViewItem;
        }
        protected override DependencyObject GetContainerForItemOverride()
        {
            var item = new EditableTreeViewItem();
            return item;
        }
    }
}
