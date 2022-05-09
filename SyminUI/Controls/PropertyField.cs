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
    /// <summary>
    /// 带有名称的属性输入
    /// </summary>
    public class PropertyField : Control
    {
        static PropertyField()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyField),
                new FrameworkPropertyMetadata(typeof(PropertyField)));
        }

        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PropertyName.
        public static readonly DependencyProperty PropertyNameProperty =
            DependencyProperty.Register("PropertyName", typeof(string), typeof(PropertyField));


        /// <summary>
        /// 属性值
        /// </summary>
        public string PropertyValue
        {
            get { return (string)GetValue(PropertyValueProperty); }
            set { SetValue(PropertyValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PropertyValue.
        public static readonly DependencyProperty PropertyValueProperty =
            DependencyProperty.Register("PropertyValue", typeof(string), typeof(PropertyField));


        /// <summary>
        /// 是否只读
        /// </summary>
        public bool ReadOnly
        {
            get { return (bool)GetValue(ReadOnlyProperty); }
            set { SetValue(ReadOnlyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReadOnly.
        public static readonly DependencyProperty ReadOnlyProperty =
            DependencyProperty.Register("ReadOnly", typeof(bool), typeof(PropertyField),
                new PropertyMetadata(false));



        /// <summary>
        /// 名称区域宽度
        /// </summary>
        public GridLength NameAreaWidth
        {
            get { return (GridLength)GetValue(NameAreaWidthProperty); }
            set { SetValue(NameAreaWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameAreaWidth.
        public static readonly DependencyProperty NameAreaWidthProperty =
            DependencyProperty.Register("NameAreaWidth", typeof(GridLength), typeof(PropertyField),
                new PropertyMetadata(new GridLength(2, GridUnitType.Star)));



        public GridLength ValueAreaWidth
        {
            get { return (GridLength)GetValue(ValueAreaWidthProperty); }
            set { SetValue(ValueAreaWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValueAreaWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueAreaWidthProperty =
            DependencyProperty.Register("ValueAreaWidth", typeof(GridLength), typeof(PropertyField),
                new PropertyMetadata(new GridLength(3, GridUnitType.Star)));


    }
}
