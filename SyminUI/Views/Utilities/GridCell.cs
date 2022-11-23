using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminUI.Views.Utilities
{
    /// <summary>
    /// 用于布置网格元素
    /// </summary>
    public class GridCell
    {
        public GridCell(IView view)
        {
            View = view;
        }
        public int Row { get; set; }
        public int Col { get; set; }
        public int RowSpan { get; set; }
        public int ColSpan { get; set; }
        public IView View { get; set; }
    }
}
