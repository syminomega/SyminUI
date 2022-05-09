using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SyminUI.Controls
{
    public class DraggableCanvas : Canvas
    {
        static DraggableCanvas()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DraggableCanvas),
                new FrameworkPropertyMetadata(typeof(DraggableCanvas)));
        }

        public DraggableCanvas() : base()
        {
            this.PreviewMouseRightButtonDown += StartDrag;
            this.PreviewMouseRightButtonUp += FinishDrag;
            this.PreviewMouseMove += MouseMoving;
        }

        // 当类型为 AffectsRender 的依赖属性被修改时触发
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            UpdateAllChildrenPosition();
            UpdateBackground();
        }
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            //在设计视图下更新UI
            if (Utilities.ViewInfo.IsInDesignMode)
            {
                UpdateAllChildrenPosition();
            }
            return base.ArrangeOverride(arrangeSize);
        }
        #region DragEvents

        private bool _dragging = false;
        private Point _mouseStartPoint;
        private Point _canvasStartOffset;
        private void StartDrag(object sender, MouseButtonEventArgs e)
        {
            _mouseStartPoint = e.GetPosition(this);
            _canvasStartOffset = Offset;
            _dragging = true;
            this.CaptureMouse();
        }
        private void FinishDrag(object sender, MouseButtonEventArgs e)
        {
            _dragging = false;
            this.ReleaseMouseCapture();
        }
        private void MouseMoving(object sender, MouseEventArgs e)
        {
            if (!_dragging) { return; }
            var mouseCurrentPosition = e.GetPosition(this);
            //设置子对象Offset
            var mouseOffset = mouseCurrentPosition - _mouseStartPoint;
            var newOffset = _canvasStartOffset + mouseOffset;
            Offset = newOffset;
        }

        #endregion

        #region Offset Properties

        /// <summary>
        /// Canvas offset
        /// 画布偏移
        /// </summary>
        public Point Offset
        {
            get { return (Point)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Point
        public static readonly DependencyProperty OffsetProperty =
            DependencyProperty.Register("Offset", typeof(Point),
                typeof(DraggableCanvas),
                new FrameworkPropertyMetadata(
                    new Point(0, 0),
                    //修改时触发OnRender
                    FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region Child Offset Settins

        // Offset变化时，更新所有子元素位置
        private void UpdateAllChildrenPosition()
        {
            foreach (var item in this.Children)
            {
                SetChildOffsetInfo((UIElement)item, Offset);
                UpdateChildPosition((UIElement)item);
            }
        }

        private static void UpdateChildPosition(UIElement child)
        {
            var offset = GetChildOffsetInfo(child);
            //获取锚点
            var leftAnchor = GetLeftAnchor(child);
            var topAnchor = GetTopAnchor(child);
            //计算Canvas位置
            var canvasLeft = leftAnchor + offset.X;
            var canvasTop = topAnchor + offset.Y;
            //设置对象位置
            SetLeft(child, canvasLeft);
            SetTop(child, canvasTop);
        }
        private static Point GetChildOffsetInfo(UIElement target)
        {
            return (Point)target.GetValue(ChildOffsetProperty);
        }

        private static void SetChildOffsetInfo(UIElement target, Point value)
        {
            target.SetValue(ChildOffsetProperty, value);
        }

        // Using a DependencyProperty as the backing store for ChildOffsetInfo.
        public static readonly DependencyProperty ChildOffsetProperty =
            DependencyProperty.RegisterAttached("ChildOffsetInfo",
                typeof(Point), typeof(DraggableCanvas),
                new FrameworkPropertyMetadata(
                    new Point(0, 0)));
        #endregion

        #region Child Anchor Settings
        public static double GetLeftAnchor(UIElement target)
        {
            return (double)target.GetValue(LeftAnchorProperty);
        }

        public static void SetLeftAnchor(UIElement target, double value)
        {
            target.SetValue(LeftAnchorProperty, value);
            UpdateChildPosition(target);
            //target.InvalidateVisual();
        }

        // Using a DependencyProperty as the backing store for LeftAnchor.
        public static readonly DependencyProperty LeftAnchorProperty =
            DependencyProperty.RegisterAttached("LeftAnchor", typeof(double),
                typeof(DraggableCanvas),
                new FrameworkPropertyMetadata(0.0,
                    //触发父对象重新排列
                    FrameworkPropertyMetadataOptions.AffectsParentArrange));



        public static double GetTopAnchor(UIElement target)
        {
            return (double)target.GetValue(TopAnchorProperty);
        }

        public static void SetTopAnchor(UIElement target, double value)
        {
            target.SetValue(TopAnchorProperty, value);
            UpdateChildPosition(target);
            //target.InvalidateVisual();
        }

        // Using a DependencyProperty as the backing store for TopAnchor.
        public static readonly DependencyProperty TopAnchorProperty =
            DependencyProperty.RegisterAttached("TopAnchor", typeof(double),
                typeof(DraggableCanvas),
                new FrameworkPropertyMetadata(0.0,
                    //触发父对象重新排列
                    FrameworkPropertyMetadataOptions.AffectsParentArrange));

        #endregion

        #region Background Properties


        public double GridVisualSize
        {
            get { return (double)GetValue(GridVisualSizeProperty); }
            set { SetValue(GridVisualSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GridVisualSize.
        public static readonly DependencyProperty GridVisualSizeProperty =
            DependencyProperty.Register("GridVisualSize",
                typeof(double), typeof(DraggableCanvas),
                new FrameworkPropertyMetadata(25.0,
                    FrameworkPropertyMetadataOptions.AffectsRender));

        //更新网格大小
        private void UpdateBackground()
        {
            var backgroundBrush = Background as VisualBrush;
            if (backgroundBrush == null) return;
            backgroundBrush.Viewport = new Rect(0, 0, GridVisualSize, GridVisualSize);

            Background.Transform = new TranslateTransform(Offset.X, Offset.Y);
        }

        #endregion






    }
}
