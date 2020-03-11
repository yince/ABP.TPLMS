using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABP.TPLMS.Entities;
using ABP.TPLMS.Modules.Dto;

namespace ABP.TPLMS.Modules
{
    public interface IModuleAppService: IApplicationService
    {
        Task CreateAsync(CreateUpdateModuleDto input);
        Task UpdateAsync(CreateUpdateModuleDto input);
        Task<ListResultDto<ModuleDto>> GetAllItemAsync();
        List<Module> GetAll();
        Task DeleteAsync(int id);
        void DeleteById(int id);
    }
}
