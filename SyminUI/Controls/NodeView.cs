using System;
using System.Collections;
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
using SyminData.NodeModel;
using SyminUI.Data.NodeModel;

namespace SyminUI.Controls
{
    public class NodeView : Control
    {
        static NodeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NodeView),
                new FrameworkPropertyMetadata(typeof(NodeView)));
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            //初始化属性
            InitViewItems(NodeItemSource);
        }


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title",
                typeof(string), typeof(NodeView),
                new PropertyMetadata(""));

        #region InputAndOutputItems

        public IEnumerable? InputNodeItems
        {
            get { return (IEnumerable)GetValue(InputNodeItemsProperty); }
            set { SetValue(InputNodeItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InputNodeItems.
        public static readonly DependencyProperty InputNodeItemsProperty =
            DependencyProperty.Register("InputNodeItems",
                typeof(IEnumerable), typeof(NodeView));



        public IEnumerable? OutputNodeItems
        {
            get { return (IEnumerable)GetValue(OutputNodeItemsProperty); }
            set { SetValue(OutputNodeItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OutputNodeItems.
        public static readonly DependencyProperty OutputNodeItemsProperty =
            DependencyProperty.Register("OutputNodeItems",
                typeof(IEnumerable), typeof(NodeView));


        #endregion

        public INodeItem? NodeItemSource
        {
            get { return (INodeItem?)GetValue(NodeItemSourceProperty); }
            set { SetValue(NodeItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NodeItemSource.
        public static readonly DependencyProperty NodeItemSourceProperty =
            DependencyProperty.Register(
                "NodeItemSource",
                typeof(INodeItem),
                typeof(NodeView),
                new FrameworkPropertyMetadata(null,
                    FrameworkPropertyMetadataOptions.AffectsRender));


        private bool dataLoaded = false;
        //初始化面板各种属性
        private void InitViewItems(INodeItem? nodeItem)
        {
            if (dataLoaded)
            {
                return;
            }

            if (nodeItem != null)
            {
                Title = nodeItem.Title;
                //初始化节点属性
                InputNodeItems = nodeItem.InputProperties;
                OutputNodeItems = nodeItem.OutputProperties;
            }
            else
            {
                Title = "";
                //为空时不加载节点对象
                InputNodeItems = null;
                OutputNodeItems = null;
            }

            dataLoaded = true;
        }

    }
}
