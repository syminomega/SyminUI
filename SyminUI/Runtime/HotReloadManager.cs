using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Loader;
using System.Windows;
using System.Diagnostics;
using SyminUI.Views;

namespace SyminUI.Runtime
{
    /// <summary>
    /// View热重载管理
    /// </summary>
    internal static class HotReloadManager
    {
        public static List<RuntimeViewInfo> ViewInfos { get; } = new();
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
            //找到需要更新的类型
            foreach (var updatedType in updatedTypes)
            {
                //找到所有 ViewProvider
                if (updatedType.IsAssignableTo(typeof(IViewProvider)))
                {
                    var views = ViewInfos
                        .Where(x => x.ViewType == updatedType)
                        .ToList();
                    //更新该类型的所有视图
                    foreach (var viewInfo in views)
                    {
                        viewInfo.ViewRenderer.UpdateView();
                    }
                }

            }

        }

    }
}