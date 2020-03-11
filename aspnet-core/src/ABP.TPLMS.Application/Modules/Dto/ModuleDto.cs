using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABP.TPLMS.Entities;

namespace ABP.TPLMS.Modules.Dto
{
    [AutoMapFrom(typeof(Module))]
    public class ModuleDto : EntityDto<long>
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }
        public string HotKey { get; set; }
        public int ParentId { get; set; }
        public bool RequiresAuthentication { get; set; }
        public bool IsAutoExpand { get; set; }
        public string IconName { get; set; }
        public int Status { get; set; }
        public string ParentName { get; set; }

        public string RequiredPermissionName { get; set; }
        public int SortNo { get; set; }
    }
}
