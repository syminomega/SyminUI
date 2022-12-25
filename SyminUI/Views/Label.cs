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
        /// <param name="dynamicContent"></param>
        public Label(IState dynamicContent) : base(dynamicContent)
        {

        }
        /// <summary>
        /// Label
        /// </summary>
        /// <param name="view"></param>
        public Label(IView view) : base(view)
        {

        }
        
        #region Label Properties
        //TODO:Target
        #endregion

        #region Override
   
        public override ElementViewBase<System.Windows.Controls.Label> OnLoaded(Action action)
        {
            return (Label)base.OnLoaded(action);
        }

        public override ElementViewBase<System.Windows.Controls.Label> OnSizeChanged(Action action)
        {
            return (Label)base.OnSizeChanged(action);
        }


        public override ElementViewBase<System.Windows.Controls.Label> Unloaded(Action action)
        {
            return (Label)base.Unloaded(action);
        }


        #endregion
    }
}
