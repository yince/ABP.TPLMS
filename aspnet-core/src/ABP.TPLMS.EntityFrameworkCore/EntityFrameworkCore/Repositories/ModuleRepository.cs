using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Abp.EntityFrameworkCore;
using ABP.TPLMS.Entities;
using ABP.TPLMS.IRepositories;

namespace ABP.TPLMS.EntityFrameworkCore.Repositories
{
    public class ModuleRepository : TPLMSRepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(IDbContextProvider<TPLMSDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IEnumerable<Module> LoadModules(int pageindex, int pagesize)
        {
            return Context.Modules.OrderBy(u => u.Id).Skip((pageindex - 1) * pagesize).Take(pagesize);
        }

        public bool Delete(string ids)
        {
            var idList = ids.Split(',');
            Expression<Func<Module, bool>> exp = m => idList.Contains(m.Id.ToString());

            Delete(exp);
            return true;
        }
    }
}
