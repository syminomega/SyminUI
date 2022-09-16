using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SyminUI.Controls.Attach
{
    public class TabElement : DependencyObject
    {

        public static bool GetUseFadeIn(DependencyObject obj)
        {
            return (bool)obj.GetValue(UseFadeInProperty);
        }

        public static void SetUseFadeIn(DependencyObject obj, bool value)
        {
            obj.SetValue(UseFadeInProperty, value);
        }

        // Using a DependencyProperty as the backing store for UseFadeIn.
        public static readonly DependencyProperty UseFadeInProperty =
            DependencyProperty.RegisterAttached("UseFadeIn",
                typeof(bool), typeof(TabElement),
                new PropertyMetadata(false, OnUseFadeInChanged));

        //切换选项卡时使用渐变浮现效果
        private static void OnUseFadeInChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var tabControl = (TabControl)d;
            if ((bool)e.OldValue == false && (bool)e.NewValue == true)
            {
                tabControl.SelectionChanged += TabControl_FadeInEffect;
            }
            if ((bool)e.OldValue == true && (bool)e.NewValue == false)
            {
                tabControl.SelectionChanged -= TabControl_FadeInEffect;
            }
        }

        private static void TabControl_FadeInEffect(object sender, SelectionChangedEventArgs e)
        {
            var tabControl = (TabControl)sender;
            //判断是子控件消息还是Tab消息
            if (e.Source.GetType() != typeof(TabControl))
            {
                e.Handled = true;
                //继续向父级传递
                var tabParent = tabControl.Parent as UIElement;
                if (tabParent != null)
                {
                    var selectionEventArg = 
                        new SelectionChangedEventArgs(e.RoutedEvent, e.RemovedItems, e.AddedItems);
                    selectionEventArg.Source = e.OriginalSource;
                    tabParent.RaiseEvent(selectionEventArg);
                }
                return;
            }

        }
    }
}
