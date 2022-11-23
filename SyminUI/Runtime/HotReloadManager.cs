using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Loader;
using System.Windows;

namespace SyminUI.Runtime
{
    /// <summary>
    /// View热重载管理
    /// </summary>
    internal static class HotReloadManager
    {
        /// <summary>
        /// 清理热重载缓存
        /// </summary>
        /// <param name="updatedTypes"></param>
        public static void ClearCache(Type[]? updatedTypes)
        {
            //未更新
            if (updatedTypes == null)
            {
                return;
            }

        }

        /// <summary>
        /// 更新应用
        /// </summary>
        /// <param name="updatedTypes"></param>
        public static void UpdateApplication(Type[]? updatedTypes)
        {
            //未更新
            if (updatedTypes == null)
            {
                return;
            }


        }

    }
}