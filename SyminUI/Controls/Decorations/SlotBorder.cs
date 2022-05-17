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

namespace SyminUI.Controls.Decorations
{
    public class SlotBorder : DecorationBase
    {
        static SlotBorder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SlotBorder),
                new FrameworkPropertyMetadata(typeof(SlotBorder)));
           
        }

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }


        #region Dependency Properties

        // Using a DependencyProperty as the backing store for Radius.
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius",
                typeof(double), typeof(SlotBorder),
                new PropertyMetadata(4.0));

        #endregion

    }

}
