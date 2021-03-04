using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KP.FunOA.DailyWorks
{
    [Table("KPDailyWork")]
    public class DailyWork : FullAuditedEntity<Guid>
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }
    
        /// <summary>
        /// 是否发布
        /// </summary>
        public virtual bool IsPublished { get; set; }

        /// <summary>
        /// 用户显示名
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 租户Id
        /// </summary>
        public virtual int TenantId { get; set; }
    }
}