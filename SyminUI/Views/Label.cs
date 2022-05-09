using SyminUI.Controls;
using SyminUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SyminUI.Views
{
    public class Label : ContentViewBase<System.Windows.Controls.Label>
    {
        /// <summary>
        /// Label
        /// </summary>
        /// <param name="text"></param>
        public Label(string text) : base(text)
        {

        }
        /// <summary>
        /// Label
        /// </summary>
        /// <param name="dynamicText"></param>
        public Label(State<string> dynamicText) : base(dynamicText)
        {

        }
        /// <summary>
        /// Label
        /// </summary>
        /// <param name="view"></param>
        public Label(IView view): base(view)
        {

        }



        #region Label Properties
        //TODO:Target
        #endregion

        #region Override
        public override Label Content(string text)
        {
            return (Label)base.Content(text);
        }

        public override Label Content(State<string> dynamicText)
        {
            return (Label)base.Content(dynamicText);
        }

        public override Label Content(IView view)
        {
            return (Label)base.Content(view);
        }

        public override Label Content(State<IView> dynamicView)
        {
            return (Label)base.Content(dynamicView);
        }

        public override ElementViewBase<System.Windows.Controls.Label> Height(double height)
        {
            return (Label)base.Height(height);
        }

        public override ElementViewBase<System.Windows.Controls.Label> Height(State<double> dynamicHeight)
        {
            return (Label)base.Height(dynamicHeight);
        }

        public override ElementViewBase<System.Windows.Controls.Label> HorizontalAlignment(HorizontalAlignment alignment)
        {
            return (Label)base.HorizontalAlignment(alignment);
        }

        public override ElementViewBase<System.Windows.Controls.Label> HorizontalAlignment(State<HorizontalAlignment> dynamicAlignment)
        {
            return (Label)base.HorizontalAlignment(dynamicAlignment);
        }

        public override ElementViewBase<System.Windows.Controls.Label> Margin(double left, double top, double right, double bottom)
        {
            return (Label)base.Margin(left, top, right, bottom);
        }

        public override ElementViewBase<System.Windows.Controls.Label> Margin(Thickness margin)
        {
            return (Label)base.Margin(margin);
        }

        public override ElementViewBase<System.Windows.Controls.Label> Margin(State<Thickness> dynamicMargin)
        {
            return (Label)base.Margin(dynamicMargin);
        }

        public override ElementViewBase<System.Windows.Controls.Label> MaxHeight(double height)
        {
            return (Label)base.MaxHeight(height);
        }

        public override ElementViewBase<System.Windows.Controls.Label> MaxWidth(double width)
        {
            return (Label)base.MaxWidth(width);
        }

        public override ElementViewBase<System.Windows.Controls.Label> MinHeight(double height)
        {
            return (Label)base.MinHeight(height);
        }

        public override ElementViewBase<System.Windows.Controls.Label> MinWidth(double width)
        {
            return (Label)base.MinWidth(width);
        }

        public override ElementViewBase<System.Windows.Controls.Label> OnLoaded(Action action)
        {
            return (Label)base.OnLoaded(action);
        }

        public override ElementViewBase<System.Windows.Controls.Label> OnSizeChanged(Action action)
        {
            return (Label)base.OnSizeChanged(action);
        }

        public override ElementViewBase<System.Windows.Controls.Label> Style(Style style)
        {
            return (Label)base.Style(style);
        }

        public override ElementViewBase<System.Windows.Controls.Label> ToolTip(IView tipView)
        {
            return (Label)base.ToolTip(tipView);
        }

        public override ElementViewBase<System.Windows.Controls.Label> ToolTip(string tip)
        {
            return (Label)base.ToolTip(tip);
        }

        public override ElementViewBase<System.Windows.Controls.Label> Unloaded(Action action)
        {
            return (Label)base.Unloaded(action);
        }

        public override ElementViewBase<System.Windows.Controls.Label> VerticalAlignment(VerticalAlignment alignment)
        {
            return (Label)base.VerticalAlignment(alignment);
        }

        public override ElementViewBase<System.Windows.Controls.Label> VerticalAlignment(State<VerticalAlignment> dynamicAlignment)
        {
            return (Label)base.VerticalAlignment(dynamicAlignment);
        }

        public override ElementViewBase<System.Windows.Controls.Label> Width(double width)
        {
            return (Label)base.Width(width);
        }

        public override ElementViewBase<System.Windows.Controls.Label> Width(State<double> dynamicWidth)
        {
            return (Label)base.Width(dynamicWidth);
        }

        #endregion
    }
}
