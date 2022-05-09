using SyminUI.Utilities;
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
    public class DraggableCanvasItem : ContentControl
    {
        static DraggableCanvasItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DraggableCanvasItem),
                new FrameworkPropertyMetadata(typeof(DraggableCanvasItem)));
        }


        private bool _isMoving;
        //鼠标按下的位置
        Point _mouseDownPosition;
        //鼠标按下时控件的位置
        Point _controlPosition;
        //父对象
        UIElement? _parentElement;

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            //按下时候获取父对象
            _parentElement = ViewHelper.GetParent<DraggableCanvas>(this);
            //如果父对象不是可推拽容器，结束操作
            if (_parentElement is null) return;

            _isMoving = true;
            _mouseDownPosition = e.GetPosition(_parentElement);
            var x = double.IsNaN(DraggableCanvas.GetLeftAnchor(this)) ? 0 : DraggableCanvas.GetLeftAnchor(this);
            var y = double.IsNaN(DraggableCanvas.GetTopAnchor(this)) ? 0 : DraggableCanvas.GetTopAnchor(this);
            _controlPosition = new Point(x, y);
            //防止鼠标移动过快跑出控件，持续监听鼠标事件
            this.CaptureMouse();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //判断是否可移动
            if (!_isMoving) return;
            //获取鼠标位置
            var pos = e.GetPosition(_parentElement);
            var dp = pos - _mouseDownPosition;
            DraggableCanvas.SetLeftAnchor(this, _controlPosition.X + dp.X);
            DraggableCanvas.SetTopAnchor(this, _controlPosition.Y + dp.Y);
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            _isMoving = false;
            this.ReleaseMouseCapture();
        }
    }
}
