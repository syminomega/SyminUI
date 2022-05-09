using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyminViewTest.DataModel
{
    public class TreeItemData
    {
        public string Content { get; set; } = "123";

        public List<TreeItemData> Children { get; set; } = new();
    }
}
