
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Loader;
using System.Windows;

namespace SyminUI
{
    

    public static class HotReloadManager
    {
        public static void ClearCache(Type[]? updatedTypes)
        {
            Console.WriteLine("HotReloadManager.ClearCache");
        }

        public static void UpdateApplication(Type[]? updatedTypes)
        {
            Console.WriteLine("HotReloadManager.UpdateApplication");
            MessageBox.Show("程序已更新");
        }
    }
}
