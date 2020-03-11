using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using ABP.TPLMS.Entities;

namespace ABP.TPLMS.IRepositories
{
    public interface IModuleRepository:IRepository<Module>
    {
        /// <summary>
        /// 分页查询功能模块
        /// </summary>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">每页多少条</param>
        /// <returns>模块列表</returns>
        IEnumerable<Module> LoadModules(int pageindex, int pagesize);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Delete(string ids);
    }
}
