﻿using System.Collections.Generic;
using System.Linq;
using Abp.Application.Navigation;
using Abp.Localization;
using ABP.TPLMS.Entities;

namespace ABP.TPLMS.Web.Startup
{
    public class DynamicAddMenu
    {
        readonly Modules.IModuleAppService _moduleAppService;

        public DynamicAddMenu(Modules.IModuleAppService moduleApp)
        {
            _moduleAppService = moduleApp;

        }
        public MenuItemDefinition AddMenus()
        {
            #region 动态菜单
            var modules = _moduleAppService.GetAll();
            var project = new MenuItemDefinition(
                "Business",
                L("Business"),

                icon: "menu",
                order: 5
            );

            var list = modules.ToList();
            FillMenu(project, 0, list);
            return project;
            #endregion
        }

        // 递归算法
        private void FillMenu(MenuItemDefinition menu, int parentId, List<Module> modules)
        {
            List<Module> drs = modules.Where(x => x.ParentId == parentId).ToList();
            if (drs.Count <= 0)
            {
            }
            else
            {
                for (int i = 0; i < drs.Count; i++)
                {
                    Module dr = drs[i];
                    MenuItemDefinition nodeName = new MenuItemDefinition(
                        dr.Name,
                        L(dr.DisplayName),
                        url: dr.Url,
                        icon: "business",
                        requiredPermissionName: dr.RequiredPermissionName,
                        customData: i
                    );
                    menu.AddItem(nodeName);
                    FillMenu(nodeName, dr.Id, modules);
                }
            }
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TPLMSConsts.LocalizationSourceName);
        }
    }
}
