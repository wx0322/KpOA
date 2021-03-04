using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace KP.FunOA.DailyWorks.Dto
{
    [AutoMapTo(typeof(DailyWork))]
    public class CreateDailyWorkDto
    {
        [Required]
        [StringLength(DailyWork.MaxTitleLength)]
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual bool IsPublished { get; set; }
    }
}