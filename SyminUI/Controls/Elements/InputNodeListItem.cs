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

    public class InputNodeListItem : ContentControl
    {
        static InputNodeListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InputNodeListItem),
                new FrameworkPropertyMetadata(typeof(InputNodeListItem)));
        }
        public InputNodeListItem()
        {
            Loaded += InputNodeListItem_Loaded;
        }

        private void InputNodeListItem_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO:属性对象相对于节点视图的坐标
        }


        /// <summary>
        /// 相对Canvas容器的坐标
        /// </summary>
        public Point PositionOnCanvas
        {
            get { return (Point)GetValue(PositionOnCanvasProperty); }
            set { SetValue(PositionOnCanvasProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PositionOnCanvas.
        public static readonly DependencyProperty PositionOnCanvasProperty =
            DependencyProperty.Register("PositionOnCanvas",
                typeof(Point), typeof(InputNodeListItem),
                new PropertyMetadata(new Point(0, 0)));


    }
}
