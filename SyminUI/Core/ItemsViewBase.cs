using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Specialized;
using SyminUI.Views;

namespace SyminUI.Core
{
    public class ItemsViewBase<T> : ControlViewBase<T>
        where T : ItemsControl, new()
    {
        /// <summary>
        /// 控件元素集合
        /// </summary>
        private ObservableCollection<System.Windows.FrameworkElement> ViewCollection { get; } = new();
        /// <summary>
        /// 数据源集合
        /// </summary>
        private IEnumerable? ItemsCollection { get; set; }
        private Func<object, IView> ItemViewConverter;

        protected ItemsViewBase() : base()
        {
            //设置数据源
            Element.ItemsSource = ViewCollection;
            //初始化默认转换器
            ItemViewConverter = item =>
            {
                if (item is IView viewItem)
                {
                    return viewItem;
                }
                var content = item.ToString() ?? string.Empty;
                return new Text(content).FontSize(14);
            };
        }
        /// <summary>
        /// Create view for each item in collection
        /// 为集合中的每个项目指定模板
        /// </summary>
        /// <param name="itemToView">View Generator-模板生成方法</param>
        /// <returns></returns>
        public ItemsViewBase<T> Foreach<TItem>(
            IEnumerable<TItem> collection,
            Func<TItem, IView> itemToView) where TItem : notnull
        {
            //清除之前的UI
            ViewCollection.Clear();
            //清除先前的数据绑定
            if(ItemsCollection != null 
                && ItemsCollection is INotifyCollectionChanged oldNotifyCollection)
            {
                oldNotifyCollection.CollectionChanged -= SourceCollectionChanged;
            }
            //存储数据源
            ItemsCollection = collection;
            //为转换器赋值
            ItemViewConverter = item =>
            {
                return itemToView.Invoke((TItem)item);
            };
            //判断是否是响应式类型
            if(ItemsCollection is INotifyCollectionChanged notifyCollection)
            {
                //添加集合变化事件
                notifyCollection.CollectionChanged += SourceCollectionChanged;
            }
            //TODO:UI对象销毁的时候解除事件
            return this;
        }

        public override T Element
        {
            get
            {
                //Set items before create view
                //创建视图前，设置集合对象
                ItemReset();
                return base.Element;
            }

        }


        #region ItemSource Update
        //数据源发生变化的时候，更新UI
        private void SourceCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: ItemAdd(e); break;
                case NotifyCollectionChangedAction.Remove: ItemRemove(e); break;
                case NotifyCollectionChangedAction.Replace: ItemReplace(e); break;
                case NotifyCollectionChangedAction.Move: ItemMove(e); break;
                case NotifyCollectionChangedAction.Reset: ItemReset(); break;
                default: break;
            }
        }
        private void ItemAdd(NotifyCollectionChangedEventArgs e)
        {
            var newItems = e.NewItems;
            //判断是否为空
            if (newItems == null) return;
            //从标记开始插入每个对象
            var insertIndex = e.NewStartingIndex;
            foreach (var item in newItems)
            {
                //转换为泛型对象
                var itemData = item;
                var newView = ItemViewConverter.Invoke(itemData);
                ViewCollection.Insert(insertIndex, newView.Element);
                insertIndex++;
            }
        }
        private void ItemRemove(NotifyCollectionChangedEventArgs e)
        {
            var itemsToRemove = e.OldItems;
            if (itemsToRemove == null) return;
            //从标记开始删除
            var removeIndex = e.OldStartingIndex;
            for (int i = 0; i < itemsToRemove.Count; i++)
            {
                ViewCollection.RemoveAt(removeIndex);
                //删除后会自动向前，无需改变索引
            }
        }
        private void ItemReplace(NotifyCollectionChangedEventArgs e)
        {
            var newItems = e.NewItems;
            //判断是否为空
            if (newItems == null) return;
            //从标记开始替换每个对象
            var replaceIndex = e.NewStartingIndex;
            foreach (var item in newItems)
            {
                //转换为泛型对象
                var itemData = item;
                var newView = ItemViewConverter.Invoke(itemData);
                ViewCollection[replaceIndex] = newView.Element;
                replaceIndex++;
            }
        }
        private void ItemMove(NotifyCollectionChangedEventArgs e)
        {
            var oldIndex = e.OldStartingIndex;
            var newIndex = e.NewStartingIndex;
            ViewCollection.Move(oldIndex, newIndex);
        }
        private void ItemReset()
        {
            //集合内容为空的时候
            if(ItemsCollection == null) return;

            if (ViewCollection.Count != 0)
            {
                ViewCollection.Clear();
            }
            //重新设置对象
            foreach (var item in ItemsCollection)
            {
                var view = ItemViewConverter.Invoke(item);
                ViewCollection.Add(view.Element);
            }
        }
        #endregion




    }
}
