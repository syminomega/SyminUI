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

namespace SyminUI.Controls
{
    public class EditableTreeViewItem : HeaderedItemsControl
    {
        static EditableTreeViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditableTreeViewItem),
                new FrameworkPropertyMetadata(typeof(EditableTreeViewItem)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            // 每次应用新样式都会重新注册事件，先反注册事件
            RemoveEvents();
            GetElements();
            AddEvents();
        }
        private Button? _foldButton;
        private Border? _headerArea;
        private void RemoveEvents()
        {
            //折叠操作
            if (_foldButton != null)
            {
                _foldButton.Click -= FoldButton_Click;
            }
            //点选对象操作
            if (_headerArea != null)
            {
                _headerArea.PreviewMouseLeftButtonDown -= SendItemSelectMessage;
            }
        }
        private void GetElements()
        {
            _foldButton = GetTemplateChild("PART_FoldButton") as Button;
            _headerArea = GetTemplateChild("PART_Header") as Border;
        }
        private void AddEvents()
        {
            if (_foldButton != null)
            {
                _foldButton.Click += FoldButton_Click;
            }
            if (_headerArea != null)
            {
                _headerArea.PreviewMouseLeftButtonDown += SendItemSelectMessage;
            }
        }

        private void SendItemSelectMessage(object sender, MouseButtonEventArgs e)
        {
            //IsSelected = !IsSelected;
            var args = new RoutedEventArgs(ItemSelectedEvent, this);
            this.RaiseEvent(args);
        }

        private void FoldButton_Click(object sender, RoutedEventArgs e)
        {
            IsExpanded = !IsExpanded;
            //激发路由事件,借用Click事件的激发方法
            RoutedEventArgs args = new(ChangeExpandStateEvent, this);
            this.RaiseEvent(args);
        }

        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsFolded.
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register("IsExpanded", typeof(bool),
                typeof(EditableTreeViewItem),
                new PropertyMetadata(false));




        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelected.
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool),
                typeof(EditableTreeViewItem),
                new PropertyMetadata(false));




        /// <summary>
        /// 展开子对象事件
        /// </summary>
        public static readonly RoutedEvent ChangeExpandStateEvent =
            EventManager.RegisterRoutedEvent("ChangeExpandState",
                RoutingStrategy.Bubble,
                typeof(EventHandler<RoutedEventArgs>),
                typeof(EditableTreeViewItem));
        /// <summary>
        /// 展开子对象
        /// </summary>
        public event RoutedEventHandler ExpandStateChanged
        {
            add { this.AddHandler(ChangeExpandStateEvent, value); }
            remove { this.RemoveHandler(ChangeExpandStateEvent, value); }
        }

        /// <summary>
        /// 对象被选中事件
        /// </summary>
        public static readonly RoutedEvent ItemSelectedEvent =
            EventManager.RegisterRoutedEvent("ItemSelected",
                RoutingStrategy.Bubble,
                typeof(EventHandler<RoutedEventArgs>),
                typeof(EditableTreeViewItem));

        /// <summary>
        /// 对象被选中
        /// </summary>
        public event RoutedEventHandler ItemSelected
        {
            add { this.AddHandler(ItemSelectedEvent, value); }
            remove { this.RemoveHandler(ItemSelectedEvent, value); }
        }

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
