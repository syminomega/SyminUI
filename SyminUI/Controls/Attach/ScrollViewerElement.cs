using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SyminUI.Controls.Attach
{
    public class ScrollViewerElement : DependencyObject
    {
        public static ScrollViewer GetSynchronizedScroll(DependencyObject obj)
        {
            return (ScrollViewer)obj.GetValue(SynchronizedScrollProperty);
        }

        public static void SetSynchronizedScroll(DependencyObject obj, ScrollViewer value)
        {
            obj.SetValue(SynchronizedScrollProperty, value);
        }

        // Using a DependencyProperty as the backing store for SynchronizedScroll.
        public static readonly DependencyProperty SynchronizedScrollProperty =
            DependencyProperty.RegisterAttached("SynchronizedScroll",
                typeof(ScrollViewer), typeof(ScrollViewerElement),
                new PropertyMetadata(null, OnSynchronizedScrollChanged));

        private static void OnSynchronizedScrollChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var scroll = d as ScrollViewer;
            if (scroll == null)
            {
                return;
            }

            //从无到有
            if (e.OldValue == null && e.NewValue != null)
            {
                scroll.ScrollChanged += SynchronizeScrollViewer;
            }
        }

        private static void SynchronizeScrollViewer(object sender, ScrollChangedEventArgs e)
        {
            var senderScroll = sender as ScrollViewer;
            if (senderScroll == null)
            {
                return;
            }

            //获取要被驱动的ScrollViewer
            var targetScroll = GetSynchronizedScroll(senderScroll);
            targetScroll.ScrollToHorizontalOffset(senderScroll.HorizontalOffset);
        }
    }
}