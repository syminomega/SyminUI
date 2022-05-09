using SyminUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminUI.Core
{
    public interface IPanelView : IEnumerable<IView>, ICollection<IView>
    {

    }
}
