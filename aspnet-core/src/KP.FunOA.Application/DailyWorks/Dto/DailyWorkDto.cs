using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace KP.FunOA.DailyWorks.Dto
{
    [AutoMap(typeof(DailyWork))]
    public class DailyWorkDto : EntityDto<Guid>
    {
        [Required]
        [StringLength(DailyWork.MaxTitleLength)]
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual string UserName { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual long CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
    }
}