using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SyminUI.Core
{
    public abstract class PanelViewBase<T> : ElementViewBase<T>,
        IPanelView where T : Panel, new()
    {
        private readonly List<IView> _children;
        protected PanelViewBase() : base()
        {
            _children = new List<IView>();
        }

        #region 实现集合和迭代器
        /// <summary>
        /// 添加视图元素
        /// </summary>
        /// <param name="item">视图元素</param>
        public void Add(IView item)
        {
            _children.Add(item);
            ViewElement.Children.Add(item.ViewElement);
        }
        /// <summary>
        /// 添加视图元素集合
        /// </summary>
        /// <param name="viewCollection">待添加集合</param>
        public void Add(ViewCollection viewCollection)
        {
            foreach (var item in viewCollection)
            {
                _children.Add(item);
                ViewElement.Children.Add(item.ViewElement);
            }
        }
        /// <summary>
        /// 移除视图元素
        /// </summary>
        /// <param name="item">待移除元素</param>
        /// <returns>操作结果</returns>
        public bool Remove(IView item)
        {
            if (_children.Remove(item))
            {
                ViewElement.Children.Remove(item.ViewElement);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 移除视图集合元素
        /// </summary>
        /// <param name="viewCollection">待移除集合</param>
        /// <returns>成功移除的数量</returns>
        public int Remove(ViewCollection viewCollection)
        {
            int count = 0;
            foreach (var item in viewCollection)
            {
                //判断释放有对象移除
                if (_children.Remove(item))
                {
                    ViewElement.Children.Remove(item.ViewElement);
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// 清空视图元素
        /// </summary>
        public void Clear()
        {
            _children.Clear();
            ViewElement.Children.Clear();
        }
        /// <summary>
        /// 是否包含视图元素
        /// </summary>
        /// <param name="item">包含的元素</param>
        /// <returns>判断结果</returns>
        public bool Contains(IView item)
        {
            return _children.Contains(item);
        }
        /// <summary>
        /// 子控件数量
        /// </summary>
        public int Count => _children.Count;
        public bool IsReadOnly => false;
        public IEnumerator<IView> GetEnumerator()
        {
            return _children.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// 拷贝视图元素
        /// </summary>
        /// <param name="array">目标数组</param>
        /// <param name="arrayIndex">目标索引</param>
        public void CopyTo(IView[] array, int arrayIndex)
        {
            _children.CopyTo(array, arrayIndex);
            //TODO:转移视图控件
        }
        #endregion

        #region Panel Properites
        public PanelViewBase<T> Background(Brush background)
        {
            ViewElement.Background = background;
            return this;
        }
        public PanelViewBase<T> Background(State<Brush> dynamicBackground)
        {
            ViewElement.SetBinding(Panel.BackgroundProperty, (Binding)dynamicBackground);
            return this;
        }
        //TODO:IsItemsHost
        //TODO:ZIndex of element
        #endregion
    }
}
