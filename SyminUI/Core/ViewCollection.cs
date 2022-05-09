using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminUI.Core
{
    public class ViewCollection : IEnumerable<IView>, ICollection<IView>
    {
        protected readonly List<IView> _children;
        /// <summary>
        /// 子控件数量
        /// </summary>
        public int Count => _children.Count;
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly => false;


        /// <summary>
        /// 垂直堆叠元素
        /// </summary>
        protected ViewCollection()
        {
            _children = new List<IView>();
        }


        public IEnumerator<IView> GetEnumerator()
        {
            return _children.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// 添加视图元素
        /// </summary>
        /// <param name="item">视图元素</param>
        public virtual void Add(IView item)
        {
            _children.Add(item);
        }
        /// <summary>
        /// 实现ViewCollection嵌套
        /// </summary>
        /// <param name="viewCollection"></param>
        public virtual void Add(ViewCollection viewCollection)
        {
            foreach (var item in viewCollection)
            {
                _children.Add(item);
            }
        }
        /// <summary>
        /// 清空视图元素
        /// </summary>
        public virtual void Clear()
        {
            _children.Clear();
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
        /// 拷贝视图元素
        /// </summary>
        /// <param name="array">目标数组</param>
        /// <param name="arrayIndex">目标索引</param>
        public void CopyTo(IView[] array, int arrayIndex)
        {
            _children.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// 移除视图元素
        /// </summary>
        /// <param name="item">待移除元素</param>
        /// <returns>操作结果</returns>
        public virtual bool Remove(IView item)
        {
            return (_children.Remove(item));
        }
        /// <summary>
        /// 移除视图元素集合
        /// </summary>
        /// <param name="viewCollection">待移除集合</param>
        /// <returns>成功移除的数量</returns>
        public virtual int Remove(ViewCollection viewCollection)
        {
            int count = 0;
            foreach (var item in viewCollection)
            {
                if (_children.Remove(item))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
