using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SyminUI.Utilities
{
    public class ViewHelper
    {
        /// <summary>
        /// 查找父控件
        /// </summary>
        /// <typeparam name="T">父控件的类型</typeparam>
        /// <param name="obj">要找的是obj的父控件</param>
        /// <param name="name">想找的父控件的Name属性</param>
        /// <returns>目标父控件</returns>
        public static T? GetParent<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            var parent = VisualTreeHelper.GetParent(obj);

            while (parent != null)
            {
                if (parent is T parentElement && parentElement.Name == name)
                {
                    return parentElement;
                }

                // 在上一级父控件中没有找到指定名字的控件，就再往上一级找
                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }

        /// <summary>
        /// 查找父控件
        /// </summary>
        /// <typeparam name="T">父控件的类型</typeparam>
        /// <param name="obj">要找的是obj的父控件</param>
        /// <returns>目标父控件</returns>
        public static T? GetParent<T>(DependencyObject obj) where T : FrameworkElement
        {
            var parent = VisualTreeHelper.GetParent(obj);

            while (parent != null)
            {
                if (parent is T parentElement)
                {
                    return parentElement;
                }

                // 在上一级父控件中没有找到指定名字的控件，就再往上一级找
                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }
    }
}
