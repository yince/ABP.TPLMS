using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace ABP.TPLMS.Entities
{
    public class Module : Entity, IHasCreationTime
    {
        public const int MaxLength = 255;

        public Module()
        {
            DisplayName = string.Empty;
            Name = string.Empty;
            Url = string.Empty;
            HotKey = string.Empty;
            ParentId = 0;
            IconName = string.Empty;
            Status = 0;
            ParentName = string.Empty;
            RequiredPermissionName = string.Empty;
            RequiresAuthentication = false;
            IsAutoExpand = false;
            SortNo = 0;

            CreationTime = Clock.Now;
        }

        [Required]
        [StringLength(MaxLength)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(MaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MaxLength)]
        public string Url { get; set; }


        [StringLength(MaxLength)]
        public string HotKey { get; set; }
        public int ParentId { get; set; }
        public bool RequiresAuthentication { get; set; }
        public bool IsAutoExpand { get; set; }

        [StringLength(MaxLength)]
        public string IconName { get; set; }
        public int Status { get; set; }

        [Required]
        [StringLength(MaxLength)]
        public string ParentName { get; set; }


        [StringLength(MaxLength)]
        public string RequiredPermissionName { get; set; }
        public int SortNo { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
