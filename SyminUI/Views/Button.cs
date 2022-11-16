using SyminUI.Controls;
using SyminUI.Core;
using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace SyminUI.Views
{
    public class Button : ContentViewBase<System.Windows.Controls.Button>,
        IButtonBase<System.Windows.Controls.Button, Button>
    {
        public Button(string text) : base(text)
        {
        }
        public Button(State<string> dynamicText) : base(dynamicText)
        {
        }
        public Button() : base()
        {
        }


        #region Button Properties

        public Button ClickMode(ClickMode clickMode)
        {
            Element.ClickMode = clickMode;
            return this;
        }

        public Button ClickMode(State<ClickMode> clickMode)
        {
            Element.SetBinding(ButtonBase.ClickModeProperty, (Binding)clickMode);
            return this;
        }

        #endregion

        #region Button Events

        public Button OnClick(Action action)
        {
            if (!_onClickListened)
            {
                Element.Click += ViewElement_Click;
                _onClickListened = true;
            }
            OnClickAction += action;
            return this;
        }

        #endregion

        #region EventHandle

        private bool _onClickListened = false;
        private event Action? OnClickAction;
        private void ViewElement_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnClickAction?.Invoke();
        }


        #endregion

    }
}
