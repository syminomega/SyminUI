using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Data;

namespace SyminUI.Core
{
    //按钮基类
    //原本的按钮基类是抽象类，暂时做成接口约束
    public interface IButtonBase<TControl, TView> : IView<TControl> 
        where TControl : ButtonBase, new() 
        where TView : IButtonBase<TControl, TView>
    {

        #region ButtonBase Properties

        public TView ClickMode(ClickMode clickMode);
        public TView ClickMode(State<ClickMode> clickMode);

        //TODO:Command

        #endregion

        #region ButtonBase Events
        public TView OnClick(Action action);
        #endregion
    }
}
