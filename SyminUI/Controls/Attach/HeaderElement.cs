using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SyminUI.Controls.Attach
{
    /// <summary>
    /// Header元素附加属性
    /// </summary>
    public class HeaderElement : DependencyObject
    {
        #region 水平对齐方式
        public static HorizontalAlignment GetHorizontalContentAlignment(DependencyObject obj)
        {
            return (HorizontalAlignment)obj.GetValue(HorizontalContentAlignmentProperty);
        }

        public static void SetHorizontalContentAlignment(DependencyObject obj, HorizontalAlignment value)
        {
            obj.SetValue(HorizontalContentAlignmentProperty, value);
        }

        // Using a DependencyProperty as the backing store for HorizontalContentAlignment.
        public static readonly DependencyProperty HorizontalContentAlignmentProperty =
            DependencyProperty.RegisterAttached("HorizontalContentAlignment",
                typeof(HorizontalAlignment), typeof(HeaderElement),
                new PropertyMetadata(HorizontalAlignment.Center));
        #endregion

        #region 垂直对齐方式


        public static VerticalAlignment GetVerticalContentAlignment(DependencyObject obj)
        {
            return (VerticalAlignment)obj.GetValue(VerticalContentAlignmentProperty);
        }

        public static void SetVerticalContentAlignment(DependencyObject obj, VerticalAlignment value)
        {
            obj.SetValue(VerticalContentAlignmentProperty, value);
        }

        // Using a DependencyProperty as the backing store for VerticalContentAlignment.
        public static readonly DependencyProperty VerticalContentAlignmentProperty =
            DependencyProperty.RegisterAttached("VerticalContentAlignment", 
                typeof(VerticalAlignment), typeof(HeaderElement),
                new PropertyMetadata(VerticalAlignment.Center));


        #endregion

    }
}
